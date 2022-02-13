using GeniePlugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;

namespace Character_Inventory
{
    // To work with Genie, the class must extend IPlugin, using GeniePlugin.Interfaces
    public class Plugin_Code : IPlugin
    {
        //Constant variable for the Properties of the plugin
        //At the top for easy changes.
        readonly string _NAME = "Character_Inventory";
        readonly string _VERSION = "1.0";
        readonly string _AUTHOR = "Guadrul";
        readonly string _DESCRIPTION = "Plug-in for Genie to help visualize character inventory";

        public System.Windows.Forms.Form _parent;       //Required for plugin
        public static IHost _host;                             //Required for plugin
        public MainForm _form;                          //Required for plugin and for using a pop-up Window in Genie

        private bool _enabled = true;                   //Required for plugin, for method Enabled

        #region Custom Properties for your Plugin

        //Required for ParseText and ParseInput methods
        public string ScanMode = null;
        public string locationForItem = null;

        // Items to look for and assign locations
        public LocationsOnForm helpMeFindIt = new LocationsOnForm();

        // List of Characters loaded into Memory from XML
        public static Character_List _character_list_XML = new Character_List();

        //Used for Stand-alone Plug-in use (not for use in Genie Client)
        private static string _pluginPath;
        private static string _filePath;

        private static string basePath = Application.StartupPath;

        //Temp variables for filepath save
        private static string _filePath_save;

        private int level;
        private int indexOfRootItem = 0;
        private int indexOfFirstlevel = 0;
        private int indexOfSecondlevel = 0;

        #endregion

        #region iPlugin Required Properties

        //Required for Plugin - Name Called when Genie needs the name of the plugin (On menu)
        //Return Value:
        //              string: Text that is the name of the Plugin
        public string Name
        {
            get { return _NAME; }
        }

        //Required for Plugin - Called when Genie needs the plugin Author (plugins window)
        //Return Value:
        //              string: Text that is the Author of the plugin
        public string Author
        {
            get { return _AUTHOR; }
        }

        //Required for Plugin - Called when Genie needs the plugin version (error text
        //                      or the plugins window)
        //Return Value:
        //              string: Text that is the version of the plugin
        public string Version
        {
            get { return _VERSION; }
        }

        //Required for Plugin - Called when Genie needs the plugin Description (plugins window)
        //Return Value:
        //              string: Text that is the description of the plugin
        //                      This can only be up to 200 Characters long, else it will appear
        //                      "truncated"
        public string Description
        {
            get { return _DESCRIPTION; }
        }

        //Required for Plugin - Called when Genie needs disable/enable the plugin (Plugins window,
        //                      and from the CLI), or when Genie needs to know the status of the 
        //                      plugin (???)
        //Get:
        //      Not Known what it is used for
        //Set:
        //      Used by Plugins Window + CLI
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }
        #endregion

        #region iPlugin Required Methods

        //Required for Plugin - Initialize() is called on first load
        //Parameters:
        //              IHost Host:  The host (instance of Genie) making the call
        public void Initialize(IHost Host)
        {
            _host = Host;

            //LoadXMLFile();
            basePath = _host.get_Variable("PluginPath");

        }

        //Required for Plugin - ParseText()
        //Parameters:
        //              string Text:    The DIRECT text comes from the game (non-"xml")
        //              string Window:  The Window the Text was received from
        //Return Value:
        //              string: Text that will be sent to the main window
        public string ParseText(string Text, string Window)
        {
            if (ScanMode != null) // If a scan isn't in progress, do nothing here.
            {
                string trimtext = Text.Trim(new char[] { '\n', '\r', ' ' }); // Trims spaces and newlines
                
                //Remove Everything after ":" in Items worn....
                Match _itemsWorn = Regex.Match(trimtext, @"^[^:]+:");
                string item_Location = _itemsWorn.ToString();
                //_host.EchoText("Regex return value:" + item_Location);
                

                if (trimtext.StartsWith("XML") && trimtext.EndsWith("XML")) { } // Skip XML parser lines

                else if (string.IsNullOrEmpty(trimtext)) { } // Skip blank lines

                //Starting the scan from ParseInput, and see which slot trimtext is referring to in "Items worn..."
                else if (helpMeFindIt.IfContains(item_Location) && ScanMode == "Start")
                {
                    //Return a location for the type of item: Arms, Back, Legs, Ground, Back, Head, etc
                    locationForItem = helpMeFindIt.Category(item_Location);

                    //Test Message - confirm item found a category
                    //_host.SendText("#echo Current Location: " + locationForItem + " / trimtext: " + trimtext);

                    if (locationForItem == "NotFound")
                    {
                        //"Items Worn" Not Found
                        ScanMode = "DoneScan";
                    }

                    ScanMode = "Start_Inventory";

                } // end ScanMode = "Start"

                else if (ScanMode == "Start_Inventory")
                {

                    if (helpMeFindIt.IfContains(item_Location))
                    {
                        //Return a location (1 of 6) for the type of item: Arms, Back, Legs, Ground, Back, Head
                        locationForItem = helpMeFindIt.Category(item_Location);

                        //Test Message - confirm item found a category
                        //_host.SendText("#echo Start Location - Current Location: " + locationForItem + " / trimtext: " + item_Location);

                        if (locationForItem == "NotFound")
                        {
                            //"Items Worn" Not Found
                            ScanMode = "DoneScan";
                        }
                    }

                    else if (trimtext.StartsWith("[Use INVENTORY HELP"))
                    {
                        // Skip
                    }

                    //Update total items you are wearing
                    else if (Text.StartsWith("You are currently wearing"))
                    {
                        Match match = Regex.Match(trimtext, @"^You are currently wearing\s{1,3}(\d{1,3})\s{1,3}items?\.$");

                        foreach (My_Character character in _character_list_XML.My_Character)
                        {
                            if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                            {
                                character.Total_Items = match.Groups[1].Value.ToString();
                            }
                        }
                    }

                    else if (Text.StartsWith("Roundtime:"))
                    {

                        // Reached End of Inventory Scan
                        ScanMode = "Scan_ItemsAtFeet";

                        // Inventory List has a RT based on the number of items, so grab the number and pause the thread for that length.
                        Match match = Regex.Match(trimtext, @"^Roundtime:\s{1,3}(\d{1,3})\s{1,3}secs?\.$");

                        _host.EchoText(string.Format("echo >Log Pausing {0} seconds for RT.", int.Parse(match.Groups[1].Value)));
                        System.Threading.Thread.Sleep(int.Parse(match.Groups[1].Value) * 1000);
                        _host.SendText("#echo >Log #fd00f1 CharacterInventory: Updated Worn Items");

                        _host.SendText("inventory atfeet");
                    }
                    else
                    {
                        //Debug Text output to log 
                         //_host.SendText("#echo >Log locationforItem: " + locationForItem + " / trimtext: " + trimtext);

                        //Add Item to WornItem Location
                        Add_Item_To_Location(locationForItem, trimtext);
                    }

                } // end ScanMode == "Start_Inventory"

                else if (ScanMode == "Scan_ItemsAtFeet")
                {
                    //Startswith: All of your items lying
                    if (trimtext.StartsWith("XML") && trimtext.EndsWith("XML")) { } // Skip XML parser lines

                    else if (string.IsNullOrEmpty(trimtext)) { } // Skip blank lines

                    else if (trimtext.StartsWith("All of your items lying at your feet"))
                    {
                        // _host.SendText("#echo >Log Beginning Container Scan");

                        //Skip
                    }

                    else if (trimtext.StartsWith("Roundtime") || trimtext.StartsWith("R>") || trimtext.StartsWith(">"))
                    {
                        //Skip

                    }

                    else if (trimtext.StartsWith("You aren't wearing anything like that."))
                    {

                        //Nothing at your feet, scan done
                        ScanMode = "ScanSlots";

                        _host.SendText("#echo >Log #fd00f1 CharacterInventory: Updated Items at your feet");

                        _host.SendText("inventory slot lists");

                    }

                    else if (trimtext.StartsWith("[Use INVENTORY HELP"))
                    {
                        // Done
                        ScanMode = "ScanSlots";

                        _host.SendText("#echo >Log #fd00f1 CharacterInventory: Updated Items at your feet");

                        _host.SendText("inventory slot lists");
                    }
                    else if (trimtext.StartsWith("a") || trimtext.StartsWith("some"))
                    {
                        //Add Items lying at feet
                        //Add Item to WornItem Location
                        Add_Item_To_Location("ground", trimtext);
                    }

                } //End ScanMode == Scan_ItemsAtFeet

                else if (ScanMode == "ScanSlots")
                {

                    //Debug Message 
                    //_host.SendText("#echo >Log CharacterInventory: Scanning Worn Slots");

                    if (Text.StartsWith("Items worn"))
                    {

                        string locationOfSlot = "Not Found";

                        string tempString = trimtext;
                        string updatedstring;
                        string checkstring;

                        //Special Case: check if String contains (+) and remove it (for Hallows Eve Item expander)
                        tempString = trimtext.Replace("(+)", "");
                        updatedstring = tempString.Trim(new char[] { '\n', '\r', ' ' });

                        //Debug Text
                        //_host.SendText("#echo >Log tempstring checking for (+): " + updatedstring);

                        //Remove end of trimtext since it contains numbers ex: 4/30
                        if (updatedstring.Contains(" "))
                        {
                            checkstring = updatedstring.Substring(0, updatedstring.LastIndexOf(' ')).TrimEnd();

                            //Debug Text
                            //_host.SendText("#echo >Log tempstring checking for removal of numbers: " + checkstring);

                            //Using tempstring, Return a location (1 of 6) for the type of item: Arms, Back, Legs, Ground, Back, Head
                            locationOfSlot = helpMeFindIt.Category(checkstring);
                        }

                        //Get slots for occupied Groups(1) and total Groups(2)
                        Match match_occupied = Regex.Match(trimtext, @"([0-9]+)/([0-9]+)");

                        //Add matched number to character's WornItems slot based on locationOfSlot
                        Add_Slot_To_Location(locationOfSlot, match_occupied.Groups[1].Value, match_occupied.Groups[2].Value);

                    }

                    
                    else if (Text.StartsWith("Items lying"))
                    {

                        //Special Case, Items lying at feet
                        Match match_feet = Regex.Match(trimtext, @"([0-9]+)");

                        //Add matched number to character's WornItems slot based on locationOfSlot
                        Add_Slot_To_Location("ground", match_feet.Groups[1].Value, "0");

                    }

                    else if (trimtext.StartsWith("[Use INVENTORY HELP"))
                    {
                        // Skip
                    }

                    else if (Text.StartsWith("Roundtime:"))
                    {

                        // Reached End of Inventory Scan
                        ScanMode = "DoneScan";

                        // Inventory List has a RT based on the number of items, so grab the number and pause the thread for that length.
                        Match match = Regex.Match(trimtext, @"^Roundtime:\s{1,3}(\d{1,3})\s{1,3}secs?\.$");

                        System.Threading.Thread.Sleep(int.Parse(match.Groups[1].Value) * 1000);
                        _host.EchoText(string.Format("echo >Log Pausing {0} seconds for RT.", int.Parse(match.Groups[1].Value)));
                        _host.SendText("#echo >Log #fd00f1 CharacterInventory: Updated Item Slots");

                        //Issue Next Step
                        //_host.SendText("inventory slot lists");
                    }

                }  // end ScanMode == ScanSlots

                else if (ScanMode == "ScanWornContainerList")
                {
                    //Startswith: All of your containers:
                    if (trimtext.StartsWith("XML") && trimtext.EndsWith("XML")) { } // Skip XML parser lines

                    else if (string.IsNullOrEmpty(trimtext)) { } // Skip blank lines

                    else if (trimtext.StartsWith("All of your containers:"))
                    {
                       // _host.SendText("#echo >Log Beginning Container Scan");

                       //Skip
                    }

                    else if (trimtext.StartsWith("a") || trimtext.StartsWith("some"))
                    {
                        //The text starts with "a" or "some" indicating that it's an item - case sensitive

                        //Remove "closed" from inv container list
                        string tempString = trimtext.Replace("(closed)", "");
                        string newString = tempString.Trim();

                        //_host.SendText("#echo >Log Found container: " + tempString);

                        //If tempstring equals a WornItem.Item.Text, then set that item's IsContainer variable to True
                        Change_IsContainer(newString, "True");
                    }
                    else
                    {
                        //Did not find a string that starts with a or some, so end of list
                        ScanMode = "Start_ScanInventory";
                        _host.SendText("#echo >Log #fd00f1 CharacterInventory: Updated Worn Items that are containers");

                    }

                } //End ScanMode = "ScanWornContainerList"

                else if (ScanMode == "Start_ScanInventory")
                {
                    //When done, scan inventory (inv list)
                    //Build Container.container_items List

                    _host.SendText("inventory list");

                    
                        ScanMode = "Input_ScanInventory";
                        level = 1;

                } //End ScanMode = "Start_ScanInventory

                else if (ScanMode == "Input_ScanInventory")
                {

                    //_host.SendText("#echo >Log Starting Inputting of ScanInventory");

                    if (trimtext.StartsWith("You have:") || trimtext.StartsWith("You take a moment"))
                    {
                        //Skip
                    }
                    else if (trimtext.StartsWith("[Use INVENTORY HELP"))
                    {
                        // Skip
                    }
                    else if (trimtext.StartsWith("Roundtime:")) // text that appears at the end of "inventory list"
                    {
                        // Inventory List has a RT based on the number of items, so grab the number and pause the thread for that length.
                        //_host.EchoText(string.Format("Pausing {0} seconds for RT.", int.Parse(match.Groups[1].Value)));
                        Match match = Regex.Match(trimtext, @"^Roundtime:\s{1,3}(\d{1,3})\s{1,3}secs?\.$");
                        ScanMode = "DoneScan";

                        System.Threading.Thread.Sleep(int.Parse(match.Groups[1].Value) * 1000);
                        _host.SendText("#echo >Log #fd00f1 CharacterInventory: Updated Container List");

                    }
                    else
                    {
                        // The first level of inventory has a padding of 2 spaces to the left, and each level adds an additional 3 spaces.
                        // 2, 5, 8, 11, 14, etc..
                        int spaces = Text.Length - Text.TrimStart().Length;
                        int newlevel = (spaces + 1) / 3;

                        // remove the - from the beginning if it exists.
                        if (trimtext.StartsWith("-")) trimtext = trimtext.Remove(0, 1);

                        //_host.EchoText("New Level: " + newlevel + " / " + "Level:" + level);

                        //Listen, I get it, this is a recursive problem, but I suck at recursion. If someone knows how to implement this recursively without breaking
                        //I'm all ears. Right now, this only scans containers up to four levels deep. 

                        // The logic below builds a tree of inventory items.
                        if (newlevel == 1) // If the item is in the first level, add to the root item list
                        {
                            foreach (My_Character character in _character_list_XML.My_Character)
                            {
                                if (character.Character_Name == _host.get_Variable("charactername"))
                                {
                                    //Add Item to Containter class
                                    ItemData tempItemContainer = new ItemData();
                                    tempItemContainer.Container_name = trimtext;

                                    character.Containers.Container_items.ItemData.Add(tempItemContainer);
                                   //_host.EchoText("Added-- " + trimtext + " --to root of Container");

                                    indexOfRootItem = character.Containers.Container_items.ItemData.IndexOf(tempItemContainer);
                                }

                            }
                        }

                        else if (newlevel == level + 1) // Items at Level 2
                        {
                            //Do something
                            //_host.EchoText("Adding* " + trimtext + " ** add to previous item");

                            foreach (My_Character character in _character_list_XML.My_Character)
                            {
                                if (character.Character_Name == _host.get_Variable("charactername"))
                                {
                                    //Add Item to Containter class
                                    ItemData tempItemContainer = new ItemData();
                                    tempItemContainer.Container_name = trimtext;

                                    character.Containers.Container_items.ItemData[indexOfRootItem].Container_items.ItemData.Add(tempItemContainer);

                                    indexOfFirstlevel = character.Containers.Container_items.ItemData[indexOfRootItem].Container_items.ItemData.IndexOf(tempItemContainer);

                                }
                            }

                        }

                        else if (newlevel == level + 2) // Else, level 3
                        {
                            //_host.EchoText("Adding* " + trimtext + " **to third level");

                            foreach (My_Character character in _character_list_XML.My_Character)
                            {
                                if (character.Character_Name == _host.get_Variable("charactername"))
                                {
                                    //Add Item to Containter class
                                    ItemData tempItemContainer = new ItemData();
                                    tempItemContainer.Container_name = trimtext;

                                    character.Containers.Container_items.ItemData[indexOfRootItem].Container_items.ItemData[indexOfFirstlevel].Container_items.ItemData.Add(tempItemContainer);

                                    indexOfSecondlevel = character.Containers.Container_items.ItemData[indexOfRootItem].Container_items.ItemData[indexOfFirstlevel].Container_items.ItemData.IndexOf(tempItemContainer);
                                }
                            }

                        }

                        else if (newlevel == level + 3) // Else, level 4
                        {
                            //_host.EchoText("Adding* " + trimtext + " **to fourth level");

                            foreach (My_Character character in _character_list_XML.My_Character)
                            {
                                if (character.Character_Name == _host.get_Variable("charactername"))
                                {
                                    //Add Item to Containter class
                                    ItemData tempItemContainer = new ItemData();
                                    tempItemContainer.Container_name = trimtext;

                                    character.Containers.Container_items.ItemData[indexOfRootItem].Container_items.ItemData[indexOfFirstlevel].Container_items.ItemData[indexOfSecondlevel].Container_items.ItemData.Add(tempItemContainer);

                                }
                            }

                        }


                    }

                } //End ScanMode = "Input_ScanInventory"

                else if (ScanMode == "DoneScan")
                {
                    _host.SendText("#echo >Log #ffff66 === Inventory Scanning Done. ===");
                    ScanMode = null;
                    SaveXMLFile();
                }

            } //end ScanMode != null

            return Text;
        }

        //Required for Plugin - ParseInput() is called when user enters text in the command box
        //Parameters:
        //              string Text:  The text the user entered in the command box
        //Return Value:
        //              string: Text that will be sent to the game
        public string ParseInput(string Text)
        {
            //Example Text to input into Genie and example response


            //Conduct an "Inventory Slot Full" in Genie
            if (Text.ToLower().StartsWith("/inventory_scan"))
            {

                if (_host.get_Variable("connected") == "0")
                {
                    _host.EchoText("You must be connected to the server to do a scan.");
                }

                else
                {
                    //Remove Current Logged-in character from Character List since we are scanning from scratch
                    while (_character_list_XML.My_Character.Where(tbl => tbl.Character_Name == _host.get_Variable("charactername")).Count() > 0)
                    {
                        _character_list_XML.My_Character.Remove(_character_list_XML.My_Character.Where(tbl => tbl.Character_Name == _host.get_Variable("charactername")).First());
                    }

                    //_host.SendText("Initilaizing new character");

                    //Now that the character is gone, add a new copy of the character to the Character List
                    Initialize_NewCharacter();

                    _host.SendText("#echo >Log #ffff66 === Starting Character Worn Item Scan ===");
                    _host.SendText("inventory slot full");
                    ScanMode = "Start";
                }

                return string.Empty;

            }

            if (Text.ToLower().StartsWith("/inventory_container"))
            {
                //Remove Current Logged-in character Container.container_items list from XML List since we are scanning containers

                if (_character_list_XML.My_Character.Count() > 0)
                 {
                    foreach (My_Character character in _character_list_XML.My_Character)
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            //_host.SendText("Adding New Container XML to " + _host.get_Variable("charactername"));
                            character.Containers = new Containers();
                        }

                        _host.SendText("#echo >Log #ffff66 === Starting Character Container Scan ===");
                        _host.SendText("inventory containers");
                        ScanMode = "ScanWornContainerList";
                 }

                else
                {
                        _host.SendText("#echo >Log Crimson *** No Character Data found, you must Scan Worn Items first ***");
                }

                return string.Empty;
            }

            return Text;
        }
        
           

        //Required for Plugin - Show() is called when clicking on the plugin 
        //name from the Menu item Plugins
        public void Show()
        {
            OpenWindow(_host.ParentForm);
        }

        //Required for Plugin - VariableChanged() is called when a global variable in genie
        //                      is changed
        //Parameters:
        //              string Text:  The variable name in Genie that changed
        public void VariableChanged(string Variable)
        {

        }

        //Required for Plugin - ParseXML()
        //Parameters:
        //              string Text:  That "xml" text comes from the game
        public void ParseXML(string xml)
        {

        }

        //Required for Plugin - ParentClosing()
        public void ParentClosing()
        {

        }

        #endregion

        #region Custom Methods for your plugin

        //Opens the settings window.  Called when a user clicks on the menu item for 
        //this plugin (via above call)
        //
        //Parameters:
        //              Form Parent:  The parent form of the plugin.  Genie in this case
        public void OpenWindow(Form parent)
        {
            if (_form == null || _form.IsDisposed)
            {
                _form = new MainForm();
                _form.MdiParent = _parent;
            }
            _form.Show();
            _form.BringToFront();
        }

        //Load XML from File on Loading of Plug-In
        //Also called from MainForm when compiler is set to build .DLL (Release/Class Library)
        public static void LoadXMLFile()
        {
            //Compiler Setting: Load for local debugging outside of Genie (DEBUG)
            //                  or for use in Genie (RELEASE)
            string _configFile = Path.Combine(basePath, "Character_Inventory.xml");
            //_host.EchoText(_configFile);

            //Load data from XML file containing character inventory data into Dataset
            XmlSerializer _serializer = new XmlSerializer(typeof(Character_List));

            //Create Empty XML Config File if it doesn't exist
            if (!File.Exists(_configFile))
            {
                using (TextWriter _filepath_toSave = new StreamWriter(_configFile))
                {
                //Write the file to the filepath
                    _serializer.Serialize(_filepath_toSave, _character_list_XML);
                }


            }

            using (FileStream stream = File.OpenRead(_configFile))
            {

                // Load XML file into Serializer
                _character_list_XML = (Character_List)_serializer.Deserialize(stream);
            }// Put a break-point here, then mouse-over dezerialized XML _character_list_XML

        }

        //Save Character List Settings to an XML File
        public static void SaveXMLFile()
        {

            string _configFile = Path.Combine(basePath, "Character_Inventory.xml");

#if DEBUG
            //Compile as Stand-Alone Executable
            _pluginPath = Directory.GetCurrentDirectory();
#else 
            //Compile as DLL for Genie Plug-in
            _pluginPath = Plugin_Code._host.get_Variable("PluginPath");
#endif
            //Temp FileSave path to ensure input file isn't overwritten
            _filePath_save = _pluginPath + "\\Character_Inventory.xml";

            //Location to write the new file too
            using (TextWriter _filepath_toSave = new StreamWriter(_configFile))
            {
                //Serializer to handle conversion of Character_List class to XML
                XmlSerializer _serializer = new XmlSerializer(typeof(Character_List));
                //Write the file to the filepath
                _serializer.Serialize(_filepath_toSave, _character_list_XML);
            }

        }

        //Create a new "MyCharacter" to add to Character List
        public void Initialize_NewCharacter()
        {
            My_Character new_character = new My_Character();
            
            new_character.Character_Name = _host.get_Variable("charactername");
            new_character.Character_Gender = _host.get_Variable("sex");
            new_character.Character_Race = _host.get_Variable("race");

            _character_list_XML.My_Character.Add(new_character);
        }

        //Add the new "Item" to the right body location on "WornItem"
        public void Add_Item_To_Location(string Location, string ItemDescription)
        {
            switch (Location)
            {
                case "head":

                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Head.Item.Add(temp);
                        }
                    };
                    break;

                case "headArmor":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Headarmor.Item.Add(temp);
                        }
                    };
                    break;

                case "hairTied":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.HairTied.Item.Add(temp);
                        }
                    };
                    break;

                case "hairPlaced":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.HairPlaced.Item.Add(temp);
                        }
                    };
                    break;

                case "rightEye":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.RightEye.Item.Add(temp);
                        }
                    };
                    break;

                case "leftEye":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.LeftEye.Item.Add(temp);
                        }
                    };
                    break;

                case "ears":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Ear.Item.Add(temp);
                        }
                    };
                    break;

                case "earBoth":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.EarBoth.Item.Add(temp);
                        }
                    };
                    break;

                case "nose":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Nose.Item.Add(temp);
                        }
                    };
                    break;

                case "neck":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Neck.Item.Add(temp);
                        }
                    };
                    break;

                case "shouldersOn":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.ShouldersOn.Item.Add(temp);
                        }
                    };
                    break;

                case "body":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Body.Item.Add(temp);
                        }
                    };
                    break;

                case "shouldersOver":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.ShouldersOver.Item.Add(temp);
                        }
                    };
                    break;

                case "back":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Back.Item.Add(temp);
                        }
                    };
                    break;

                case "shirtArmor":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.ShirtArmor.Item.Add(temp);
                        }
                    };
                    break;

                case "shirt":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Shirt.Item.Add(temp);
                        }
                    };
                    break;

                case "armUpper":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.ArmUpper.Item.Add(temp);
                        }
                    };
                    break;

                case "armArmor":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.ArmArmor.Item.Add(temp);
                        }
                    };
                    break;

                case "elbowWeapon":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.ElbowWeapon.Item.Add(temp);
                        }
                    };
                    break;

                case "shieldWorn":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.ShieldWorn.Item.Add(temp);
                        }
                    };
                    break;

                case "wrist":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Wrist.Item.Add(temp);
                        }
                    };
                    break;

                case "parryStick":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.ParryStick.Item.Add(temp);
                        }
                    };
                    break;

                case "handWeapon":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.HandWeapon.Item.Add(temp);
                        }
                    };
                    break;

                case "hands":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Hands.Item.Add(temp);
                        }
                    };
                    break;

                case "finger":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Finger.Item.Add(temp);
                        }
                    };
                    break;

                case "waist":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Waist.Item.Add(temp);
                        }
                    };
                    break;

                case "belt":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Belt.Item.Add(temp);
                        }
                    };
                    break;

                case "tail":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Tail.Item.Add(temp);
                        }
                    };
                    break;

                case "pants":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Pants.Item.Add(temp);
                        }
                    };
                    break;

                case "legArmor":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.LegArmor.Item.Add(temp);
                        }
                    };
                    break;

                case "thigh":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Thigh.Item.Add(temp);
                        }
                    };
                    break;

                case "kneeWeapon":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.KneeWeapon.Item.Add(temp);
                        }
                    };
                    break;

                case "ankle":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Ankle.Item.Add(temp);
                        }
                    };
                    break;

                case "footWeapon":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.FootWeapon.Item.Add(temp);
                        }
                    };
                    break;

                case "foot":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Foot.Item.Add(temp);
                        }
                    };
                    break;

                case "ground":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            Character_Inventory.Item temp = new Character_Inventory.Item();
                            temp.Text = ItemDescription;
                            temp.Short_desc = "";

                            character.Worn_Items.Ground.Item.Add(temp);
                        }
                    };
                    break;

                default:
                    
                    break;
            } // end switch / case
        }

        //Add the slot number to the right body location on "WornItem"
        public void Add_Slot_To_Location(string Location, string Occupied_Slot, string Total_Slot)
        {
            switch (Location)
            {
                case "head":

                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Head.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Head.Total_slots = Total_Slot;
                        }
                    };
                    break;

                case "headArmor":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Headarmor.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Headarmor.Total_slots = Total_Slot;
                        }
                    };
                    break;

                case "hairTied":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.HairTied.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.HairTied.Total_slots = Total_Slot;
                        }
                    };
                    break;

                case "hairPlaced":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.HairPlaced.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.HairPlaced.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "rightEye":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.RightEye.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.RightEye.Total_slots = Total_Slot;
                        }
                    };
                    break;

                case "leftEye":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.LeftEye.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.LeftEye.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "ears":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Ear.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Ear.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "earBoth":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.EarBoth.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.EarBoth.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "nose":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Nose.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Nose.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "neck":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Neck.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Neck.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "shouldersOn":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.ShouldersOn.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.ShouldersOn.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "body":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Body.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Body.Total_slots = Total_Slot;
                        }
                    };
                    break;

                case "shouldersOver":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.ShouldersOver.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.ShouldersOver.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "back":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Back.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Back.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "shirtArmor":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.ShirtArmor.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.ShirtArmor.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "shirt":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Shirt.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Shirt.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "armUpper":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.ArmUpper.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.ArmUpper.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "armArmor":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.ArmArmor.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.ArmArmor.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "elbowWeapon":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.ElbowWeapon.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.ElbowWeapon.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "shieldWorn":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.ShieldWorn.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.ShieldWorn.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "wrist":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Wrist.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Wrist.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "parryStick":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.ParryStick.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.ParryStick.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "handWeapon":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.HandWeapon.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.HandWeapon.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "hands":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Hands.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Hands.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "finger":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Finger.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Finger.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "waist":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Waist.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Waist.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "belt":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Belt.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Belt.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "tail":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Tail.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Tail.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "pants":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Pants.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Pants.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "legArmor":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.LegArmor.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.LegArmor.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "thigh":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Thigh.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Thigh.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "kneeWeapon":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.KneeWeapon.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.KneeWeapon.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "ankle":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Ankle.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Ankle.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "footWeapon":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.FootWeapon.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.FootWeapon.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "foot":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Foot.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Foot.Total_slots = Total_Slot;

                        }
                    };
                    break;

                case "ground":
                    foreach (My_Character character in _character_list_XML.My_Character)
                    {
                        if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                        {
                            character.Worn_Items.Ground.Occupied_slots = Occupied_Slot;
                            character.Worn_Items.Ground.Total_slots = "0";

                        }
                    };
                    break;

                default:

                    break;
            } // end switch / case
        }

        //Check for whether an item is a container, then set item property isContainer to True
        public void Change_IsContainer(string TempString, string TrueOrFalse)
        {

            foreach (My_Character character in _character_list_XML.My_Character)
            {
                if (character.Character_Name.ToString() == _host.get_Variable("charactername"))
                {
                    //Head
                    ////////////////

                    for (int i = 0; i < character.Worn_Items.Head.Item.Count; i++)
                    {
                        if (character.Worn_Items.Head.Item[i].Text == TempString)
                            character.Worn_Items.Head.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.Headarmor.Item.Count; i++)
                    {
                        if (character.Worn_Items.Headarmor.Item[i].Text == TempString)
                            character.Worn_Items.Headarmor.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.HairTied.Item.Count; i++)
                    {
                        if (character.Worn_Items.HairTied.Item[i].Text == TempString)
                            character.Worn_Items.HairTied.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.HairPlaced.Item.Count; i++)
                    {
                        if (character.Worn_Items.HairPlaced.Item[i].Text == TempString)
                            character.Worn_Items.HairPlaced.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.Ear.Item.Count; i++)
                    {
                        if (character.Worn_Items.Ear.Item[i].Text == TempString)
                            character.Worn_Items.Ear.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.EarBoth.Item.Count; i++)
                    {
                        if (character.Worn_Items.EarBoth.Item[i].Text == TempString)
                            character.Worn_Items.EarBoth.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.Nose.Item.Count; i++)
                    {
                        if (character.Worn_Items.Nose.Item[i].Text == TempString)
                            character.Worn_Items.Nose.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.Neck.Item.Count; i++)
                    {
                        if (character.Worn_Items.Neck.Item[i].Text == TempString)
                            character.Worn_Items.Neck.Item[i].IsContainer = TrueOrFalse;
                    }

                    // Back
                    ///////////////

                    for (int i = 0; i < character.Worn_Items.ShouldersOn.Item.Count; i++)
                    {
                        if (character.Worn_Items.ShouldersOn.Item[i].Text == TempString)
                            character.Worn_Items.ShouldersOn.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.ShouldersOver.Item.Count; i++)
                    {
                        if (character.Worn_Items.ShouldersOver.Item[i].Text == TempString)
                            character.Worn_Items.ShouldersOver.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.Back.Item.Count; i++)
                    {
                        if (character.Worn_Items.Back.Item[i].Text == TempString)
                            character.Worn_Items.Back.Item[i].IsContainer = TrueOrFalse;
                    }

                    //Hands
                    //////////////////
                    for (int i = 0; i < character.Worn_Items.Hands.Item.Count; i++)
                    {
                        if (character.Worn_Items.Hands.Item[i].Text == TempString)
                            character.Worn_Items.Hands.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.HandWeapon.Item.Count; i++)
                    {
                        if (character.Worn_Items.HandWeapon.Item[i].Text == TempString)
                            character.Worn_Items.HandWeapon.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.Wrist.Item.Count; i++)
                    {
                        if (character.Worn_Items.Wrist.Item[i].Text == TempString)
                            character.Worn_Items.Wrist.Item[i].IsContainer = TrueOrFalse;
                    }

                    //Arms
                    /////////////////////
                    for (int i = 0; i < character.Worn_Items.ArmUpper.Item.Count; i++)
                    {
                        if (character.Worn_Items.ArmUpper.Item[i].Text == TempString)
                            character.Worn_Items.ArmUpper.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.ArmArmor.Item.Count; i++)
                    {
                        if (character.Worn_Items.ArmArmor.Item[i].Text == TempString)
                            character.Worn_Items.ArmArmor.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.ElbowWeapon.Item.Count; i++)
                    {
                        if (character.Worn_Items.ElbowWeapon.Item[i].Text == TempString)
                            character.Worn_Items.ElbowWeapon.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.ShieldWorn.Item.Count; i++)
                    {
                        if (character.Worn_Items.ShieldWorn.Item[i].Text == TempString)
                            character.Worn_Items.ShieldWorn.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.ParryStick.Item.Count; i++)
                    {
                        if (character.Worn_Items.ParryStick.Item[i].Text == TempString)
                            character.Worn_Items.ParryStick.Item[i].IsContainer = TrueOrFalse;
                    }

                    //Body
                    ///////////////

                    for (int i = 0; i < character.Worn_Items.Body.Item.Count; i++)
                    {
                        if (character.Worn_Items.Body.Item[i].Text == TempString)
                            character.Worn_Items.Body.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.ShirtArmor.Item.Count; i++)
                    {
                        if (character.Worn_Items.ShirtArmor.Item[i].Text == TempString)
                            character.Worn_Items.ShirtArmor.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.Shirt.Item.Count; i++)
                    {
                        if (character.Worn_Items.Shirt.Item[i].Text == TempString)
                            character.Worn_Items.Shirt.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.Tail.Item.Count; i++)
                    {
                        if (character.Worn_Items.Tail.Item[i].Text == TempString)
                            character.Worn_Items.Tail.Item[i].IsContainer = TrueOrFalse;
                    }

                    //Waist
                    ///////////////////
                    for (int i = 0; i < character.Worn_Items.Waist.Item.Count; i++)
                    {
                        if (character.Worn_Items.Waist.Item[i].Text == TempString)
                            character.Worn_Items.Waist.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.Belt.Item.Count; i++)
                    {
                        if (character.Worn_Items.Belt.Item[i].Text == TempString)
                            character.Worn_Items.Belt.Item[i].IsContainer = TrueOrFalse;
                    }

                    //Leg
                    ///////////////////
                    for (int i = 0; i < character.Worn_Items.Pants.Item.Count; i++)
                    {
                        if (character.Worn_Items.Pants.Item[i].Text == TempString)
                            character.Worn_Items.Pants.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.LegArmor.Item.Count; i++)
                    {
                        if (character.Worn_Items.LegArmor.Item[i].Text == TempString)
                            character.Worn_Items.LegArmor.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.Thigh.Item.Count; i++)
                    {
                        if (character.Worn_Items.Thigh.Item[i].Text == TempString)
                            character.Worn_Items.Thigh.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.KneeWeapon.Item.Count; i++)
                    {
                        if (character.Worn_Items.KneeWeapon.Item[i].Text == TempString)
                            character.Worn_Items.KneeWeapon.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.Ankle.Item.Count; i++)
                    {
                        if (character.Worn_Items.Ankle.Item[i].Text == TempString)
                            character.Worn_Items.Ankle.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.FootWeapon.Item.Count; i++)
                    {
                        if (character.Worn_Items.FootWeapon.Item[i].Text == TempString)
                            character.Worn_Items.FootWeapon.Item[i].IsContainer = TrueOrFalse;
                    }

                    for (int i = 0; i < character.Worn_Items.Foot.Item.Count; i++)
                    {
                        if (character.Worn_Items.Foot.Item[i].Text == TempString)
                            character.Worn_Items.Foot.Item[i].IsContainer = TrueOrFalse;
                    }

                    //Ground
                    ///////////////////
                    for (int i = 0; i < character.Worn_Items.Ground.Item.Count; i++)
                    {
                        if (character.Worn_Items.Ground.Item[i].Text == TempString)
                            character.Worn_Items.Ground.Item[i].IsContainer = TrueOrFalse;
                    }

                }
            }

        }

        //This can be removed if needed, used to compile a stand-alone plugin independent of launching Genie (for testing)
        //To compile as a stand-alone plug-in in Visual Basic (tested with VS 2019):
        //                   Under Properties, then Applications in Project, change compile from "Class Library" to "Windows Application"
        //                   "Class Library" compiles plug-in as DLL for Genie
        //                   "Windows Application" compiles plug-in as .EXE file (for testing outside of Genie)

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        #endregion
    }

    // Class Used to Find Things and Categorize
    public class LocationsOnForm
    {
        public List<string> EverythingWorn = new List<string> { ItemsWorn._BODY, ItemsWorn._BACK, ItemsWorn._WAIST, ItemsWorn._HEADARMOR, ItemsWorn._SHOULDER,
            ItemsWorn._SHOULDERSWORN, ItemsWorn._PANTS, ItemsWorn._SHIRT, ItemsWorn._WRIST, ItemsWorn._FINGER, ItemsWorn._WORNFEET, ItemsWorn._NECK,
            ItemsWorn._BELT, ItemsWorn._ARMARMOR, ItemsWorn._LEGARMOR, ItemsWorn._EARS, ItemsWorn._BOTHEARS, ItemsWorn._ANKLE, ItemsWorn._HANDS,
            ItemsWorn._THIGH, ItemsWorn._UPPERARM, ItemsWorn._NOSE, ItemsWorn._LEFTEYE, ItemsWorn._RIGHTEYE, ItemsWorn._TIEDHAIR, ItemsWorn._PLACEDHAIR,
            ItemsWorn._SHIRTARMOR, ItemsWorn._HANDWEAPON, ItemsWorn._ELBOWWEAPON, ItemsWorn._KNEEWEAPON, ItemsWorn._FOOTWEAPON,
            ItemsWorn._ARMSHIELD, ItemsWorn._PARRYSTICK, ItemsWorn._HEAD, ItemsWorn._ATFEET, ItemsWorn._TAIL};

        public bool IfContains(string TextToLookFor)
        {
            bool foundIt = false;

            if (TextToLookFor == null || TextToLookFor == "")
            {
                return false;
            }

            foreach (string item in EverythingWorn)
            {
                if (item.Contains(TextToLookFor))
                    foundIt = true;
            }

            return foundIt;

        }

        public string Category(string TexttoLookFor)
        {
            string itemCategory = "NotFound";

            switch (TexttoLookFor)
            {
                case ItemsWorn._HEAD:
                    itemCategory = "Head";
                    break;

                case ItemsWorn._HEADARMOR:
                    itemCategory = "headArmor";
                    break;

                case ItemsWorn._TIEDHAIR:
                    itemCategory = "hairTied";
                    break;

                case ItemsWorn._PLACEDHAIR:
                    itemCategory = "hairPlaced";
                    break;

                case ItemsWorn._RIGHTEYE:
                    itemCategory = "rightEye";
                    break;

                case ItemsWorn._LEFTEYE:
                    itemCategory = "leftEye";
                    break;

                case ItemsWorn._EARS:
                    itemCategory = "ears";
                    break;

                case ItemsWorn._BOTHEARS:
                    itemCategory = "earBoth";
                    break;

                case ItemsWorn._NOSE:
                    itemCategory = "nose";
                    break;

                case ItemsWorn._NECK:
                    itemCategory = "neck";
                    break;

                case ItemsWorn._SHOULDERSWORN:
                    itemCategory = "shouldersOn";
                    break;

                case ItemsWorn._BODY:
                    itemCategory = "body";
                    break;

                case ItemsWorn._SHOULDER:
                    itemCategory = "shouldersOver";
                    break;

                case ItemsWorn._BACK:
                    itemCategory = "back";
                    break;

                case ItemsWorn._SHIRTARMOR:
                    itemCategory = "shirtArmor";
                    break;

                case ItemsWorn._SHIRT:
                    itemCategory = "shirt";
                    break;

                case ItemsWorn._UPPERARM:
                    itemCategory = "armUpper";
                    break;

                case ItemsWorn._ARMARMOR:
                    itemCategory = "armArmor";
                    break;

                case ItemsWorn._ELBOWWEAPON:
                    itemCategory = "elbowWeapon";
                    break;

                case ItemsWorn._ARMSHIELD:
                    itemCategory = "shieldWorn";
                    break;

                case ItemsWorn._WRIST:
                    itemCategory = "wrist";
                    break;

                case ItemsWorn._PARRYSTICK:
                    itemCategory = "parryStick";
                    break;

                case ItemsWorn._HANDWEAPON:
                    itemCategory = "handWeapon";
                    break;

                case ItemsWorn._HANDS:
                    itemCategory = "hands";
                    break;

                case ItemsWorn._FINGER:
                    itemCategory = "finger";
                    break;

                case ItemsWorn._WAIST:
                    itemCategory = "waist";
                    break;

                case ItemsWorn._BELT:
                    itemCategory = "belt";
                    break;

                case ItemsWorn._TAIL:
                    itemCategory = "tail";
                    break;

                case ItemsWorn._PANTS:
                    itemCategory = "pants";
                    break;

                case ItemsWorn._LEGARMOR:
                    itemCategory = "legArmor";
                    break;

                case ItemsWorn._THIGH:
                    itemCategory = "thigh";
                    break;

                case ItemsWorn._KNEEWEAPON:
                    itemCategory = "kneeWeapon";
                    break;

                case ItemsWorn._ANKLE:
                    itemCategory = "ankle";
                    break;

                case ItemsWorn._FOOTWEAPON:
                    itemCategory = "footWeapon";
                    break;

                case ItemsWorn._WORNFEET:
                    itemCategory = "foot";
                    break;

                case ItemsWorn._ATFEET:
                    itemCategory = "ground";
                    break;

                default:
                    itemCategory = "NotFound";
                    break;
            } // end switch / case

            return itemCategory;
        }
    }

    //Class to hold constants of Items Worn for string comparison
    public static class ItemsWorn
    {
        //Items worn on the body:
        public const string _BODY = "Items worn on the body:";

        //Items worn on the back:
        public const string _BACK = "Items worn on the back:";

        //Items worn around the waist:      
        public const string _WAIST = "Items worn around the waist:";

        //Items worn like head armor:
        public const string _HEADARMOR = "Items worn like head armor:";

        //Items worn over the shoulder:
        public const string _SHOULDER = "Items worn over the shoulder:";

        //Items worn on shoulders:          
        public const string _SHOULDERSWORN = "Items worn on shoulders:";

        //Items worn like pants:            
        public const string _PANTS = "Items worn like pants:";

        //Items worn like a shirt:
        public const string _SHIRT = "Items worn like a shirt:";

        //Items worn on the wrist:
        public const string _WRIST = "Items worn on the wrist:";

        //Items worn on a finger:
        public const string _FINGER = "Items worn on a finger:";

        //Items worn on the feet:
        public const string _WORNFEET = "Items worn on the feet:";

        //Items worn around the neck:
        public const string _NECK = "Items worn around the neck:";

        //Items worn attached to the belt:
        public const string _BELT = "Items worn attached to the belt:";

        //Items worn like arm armor:
        public const string _ARMARMOR = "Items worn like arm armor:";

        //Items worn like leg armor:
        public const string _LEGARMOR = "Items worn like leg armor:";

        //Items worn on an ear:
        public const string _EARS = "Items worn on an ear:";

        //Items worn on both ears:
        public const string _BOTHEARS = "Items worn on both ears:";

        //Items worn on an ankle:
        public const string _ANKLE = "Items worn on an ankle:";

        //Items worn on the hands:
        public const string _HANDS = "Items worn on the hands:";

        //Items worn on the thigh:
        public const string _THIGH = "Items worn on the thigh:";

        //Items worn on the upper arm:
        public const string _UPPERARM = "Items worn on the upper arm:";

        //Items worn in/on the nose:
        public const string _NOSE = "Items worn in/on the nose:";

        //Items worn over the left eye:
        public const string _LEFTEYE = "Items worn over the left eye:";

        //Items worn over the right eye:
        public const string _RIGHTEYE = "Items worn over the right eye:";

        //Items worn tied to the hair:
        public const string _TIEDHAIR = "Items worn tied to the hair:";

        //Items worn placed in the hair:
        public const string _PLACEDHAIR = "Items worn placed in the hair:";

        //Items worn as a shirt with armor:
        public const string _SHIRTARMOR = "Items worn as a shirt with armor:";

        //Items worn as a hand weapon:
        public const string _HANDWEAPON = "Items worn as a hand weapon:";

        //Items worn as an elbow weapon:
        public const string _ELBOWWEAPON = "Items worn as an elbow weapon:";

        //Items worn as a knee weapon:
        public const string _KNEEWEAPON = "Items worn as a knee weapon:";

        //Items worn as a foot weapon:
        public const string _FOOTWEAPON = "Items worn as a foot weapon:";

        //Items worn as a left arm shield:
        public const string _ARMSHIELD = "Items worn as a left arm shield:";

        //Items worn as a parry stick:
        public const string _PARRYSTICK = "Items worn as a parry stick:";

        //Items worn on the head:
        public const string _HEAD = "Items worn on the head:";

        //Items lying at your feet:
        public const string _ATFEET = "Items lying at your feet:";

        //Items worn on the tail:
        public const string _TAIL = "Items worn on the tail:";

    }
}
