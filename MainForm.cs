using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using GeniePlugin.Interfaces;

namespace Character_Inventory
{
    //The below class is used to create functionality for any pop-up windows you want to use with
    //Genie. 

    public partial class MainForm : Form
    {
        //Used for Stand-alone Plug-in use (not for use in Genie Client)
        private string _pluginPath;
        private string _filePath;

        //Temp variables for filepath save
        private string _filePath_save;

        //Temp variable for testing
        private string loggedIn_character = null;

        //Event Handler for Double-clicking Items in ListBoxes
        public delegate void DoubleClick_EventHander(object sender, MouseEventArgs mouseclick);

        //Drop-Down Box Selected Character text
        public string selected_Character = "";

        public List<TreeNode> container_treeNode = new List<TreeNode>();

#if DEBUG
        public Character_List _character_list_XML = new Character_List();
#endif
        //Required Method for Form
        public MainForm()
        {
            InitializeComponent();
        }

        //Required Method for Form
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Compiler Setting: Load for local debugging outside of Genie (DEBUG)
            //                  or for use in Genie (RELEASE)

#if DEBUG
            //Compile as Stand-Alone Executable
            _pluginPath = Directory.GetCurrentDirectory();
            _filePath = _pluginPath + "\\Character_Inventory.xml";

            //Load data from XML file containing character inventory data into Dataset
            XmlSerializer _serializer = new XmlSerializer(typeof(Character_List));

            //Create Empty XML Config File if it doesn't exist
            if (!File.Exists(_filePath))
            {

                _pluginPath = Directory.GetCurrentDirectory();

                //Default File Name
                _filePath_save = _pluginPath + "\\Character_Inventory.xml";

                //Location to write the new file too
                using (TextWriter _filepath_toSave = new StreamWriter(_filePath_save))
                {
                    //Write the file to the filepath
                    _serializer.Serialize(_filepath_toSave, _character_list_XML);
                }
            }

            using (FileStream stream = File.OpenRead(_filePath))
            {

                // Load XML file into Serializer
                _character_list_XML = (Character_List)_serializer.Deserialize(stream);
            }// Put a break-point here, then mouse-over dezerialized XML _character_list_XML

            //Add Container Items to TreeNode
            //Load_Tree_Container();

#else
            //Compile as DLL, and call Plugin_Code LoadXMLFile Method
            Plugin_Code.LoadXMLFile();
#endif

            Load_Form_ComboBox();
        }


        //Kick-off Scanning with Button "Scan", using IPlugin class Plugin_Code
        private void button_scanInventory_Click(object sender, EventArgs e)
        {
#if DEBUG
            MessageBox.Show("Can't Scan - you must be logged into your character using Genie!");
#else
            Plugin_Code._host.SendText("/inventory_scan");
            this.Close();
#endif
        }

        private void button_scanContainer_Click(object sender, EventArgs e)
        {
#if DEBUG
            MessageBox.Show("Can't Scan - you must be logged into your character using Genie!");
#else
            Plugin_Code._host.SendText("/inventory_container");
            this.Close();
#endif
        }


        //Optional Method, this controls what happens to the "Close Window" button for the Example Plug-in Window.
        // this.Close() will close the pop-up window when the user clicks the "Close Window" button
        private void button_CloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Show Container when clickbox is checked
        private void checkBox_showContainers_CheckedChanged(object sender, EventArgs e)
        {
#if DEBUG
            My_Character tempChar = _character_list_XML.My_Character.Single(s => s.Character_Name == selected_Character);
#else
            My_Character tempChar = Plugin_Code._character_list_XML.My_Character.Single(s => s.Character_Name == selected_Character);
#endif 
            //Reset to default view of Listboxes Worn_items
            if (checkBox_showContainers.Checked)
            {
                Clear_ListBoxes();
                Updates_Containers_ListBoxes(tempChar);
            }

            //Load Containers into ListBoxes Worn_Items
            else
            {
                Clear_ListBoxes();
                Updates_WormItems_ListBoxes(tempChar);

            }

        }

        //Load Character Selection into Combobox drop-down from available characters in Character List
        public void Load_Form_ComboBox()
        {
#if DEBUG

            //Add Character Name to Top of Form under Combo Box
            foreach (My_Character character in _character_list_XML.My_Character)
            {
                comboBox_CharacterSelect.Items.Add(character.Character_Name);

                //Update Image based on Gender and Race
                Update_Photo(character.Character_Gender, character.Character_Race);

            }

            //Set the logged in character by default to 0
            if (loggedIn_character != null)
                comboBox_CharacterSelect.SelectedItem = loggedIn_character;
            else
                if (loggedIn_character != null)
                        comboBox_CharacterSelect.SelectedIndex = 0;

#else
            foreach (My_Character character in Plugin_Code._character_list_XML.My_Character)
            {
                comboBox_CharacterSelect.Items.Add(character.Character_Name);
                if (character.Character_Name == Plugin_Code._host.get_Variable("charactername"))
                    {
                        loggedIn_character = character.Character_Name;
                    }
            }
            

            if (loggedIn_character != null)
                comboBox_CharacterSelect.SelectedItem = loggedIn_character;
#endif
        }

        //Change which items are loaded based on which character is selected from combobox
        //Clear ListBoxes then reload listboxes based on which WornItems from My_Character (loaded from XML)
        private void comboBox_CharacterSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox selectedBox = (ComboBox)sender;

            checkBox_showContainers.Checked = false;

            selected_Character = (string)selectedBox.SelectedItem;
#if DEBUG
            foreach (My_Character character in _character_list_XML.My_Character)
#else
            foreach (My_Character character in Plugin_Code._character_list_XML.My_Character)
#endif
                if (character.Character_Name.ToString() == selected_Character)
                {
                    //Update Image based on Gender and Race
                    Update_Photo(character.Character_Gender, character.Character_Race);

                    //Update Labels: Set Slots
                    ///////////////////////
                    Update_Slots_ListBoxes(character);

                    //Update List Boxes: Clear List Boxes
                    ///////////////////////
                    Clear_ListBoxes();

                    //Insert Items into List Boxes: Head
                    //////////////////////////
                    Updates_WormItems_ListBoxes(character);

                }

        }

        //Clears all listboxes on main form
        private void Clear_ListBoxes()
        {

            //Head
            listBox_head.Items.Clear();
            listBox_headArmor.Items.Clear();
            listBox_hairTied.Items.Clear();
            listBox_hairPlaced.Items.Clear();
            listBox_leftEye.Items.Clear();
            listBox_righteye.Items.Clear();
            listBox_ear.Items.Clear();
            listBox_bothEars.Items.Clear();
            listBox_nose.Items.Clear();
            listBox_neck.Items.Clear();

            //Back
            listBox_shouldersOn.Items.Clear();
            listBox_shouldersOver.Items.Clear();
            listBox_back.Items.Clear();

            //Hands
            listBox_hands.Items.Clear();
            listBox_handWeapon.Items.Clear();
            listBox_wrist.Items.Clear();
            listBox_fingers.Items.Clear();

            //Arms
            listBox_armUpper.Items.Clear();
            listBox_armArmor.Items.Clear();
            listBox_elbowWeapon.Items.Clear();
            listBox_shieldWorn.Items.Clear();
            listBox_parryStick.Items.Clear();

            //Body
            listBox_body.Items.Clear();
            listBox_shirtArmor.Items.Clear();
            listBox_shirt.Items.Clear();
            listBox_tail.Items.Clear();

            //Waist
            listBox_waist.Items.Clear();
            listBox_belt.Items.Clear();

            //Legs
            listBox_pants.Items.Clear();
            listBox_legArmor.Items.Clear();
            listBox_thigh.Items.Clear();
            listBox_kneeWeapon.Items.Clear();
            listBox_ankle.Items.Clear();
            listBox_footWeapon.Items.Clear();
            listBox_feet.Items.Clear();

            //Ground
            listBox_atFeet.Items.Clear();


        }
        
        //Update labels (not listboxes) with occupied/total slot numbers
        private void Update_Slots_ListBoxes(My_Character character)
        {
            label_totalWorn.Text = character.Total_Items;

            label_Slots_Head.Text = character.Worn_Items.Head.Occupied_slots + " / " + character.Worn_Items.Head.Total_slots;
            label_Slots_headArmor.Text = character.Worn_Items.Headarmor.Occupied_slots + " / " + character.Worn_Items.Headarmor.Total_slots;
            label_Slots_hairTied.Text = character.Worn_Items.HairTied.Occupied_slots + " / " + character.Worn_Items.HairTied.Total_slots;
            label_Slots_hairPlaced.Text = character.Worn_Items.HairPlaced.Occupied_slots + " / " + character.Worn_Items.HairPlaced.Total_slots;
            label_Slots_leftEye.Text = character.Worn_Items.LeftEye.Occupied_slots + " / " + character.Worn_Items.LeftEye.Total_slots;
            label_Slots_rightEye.Text = character.Worn_Items.RightEye.Occupied_slots + " / " + character.Worn_Items.RightEye.Total_slots;
            label_Slots_ear.Text = character.Worn_Items.Ear.Occupied_slots + " / " + character.Worn_Items.Ear.Total_slots;
            label_Slots_bothEars.Text = character.Worn_Items.EarBoth.Occupied_slots + " / " + character.Worn_Items.EarBoth.Total_slots;
            label_Slots_nose.Text = character.Worn_Items.Nose.Occupied_slots + " / " + character.Worn_Items.Nose.Total_slots;
            label_Slots_neck.Text = character.Worn_Items.Neck.Occupied_slots + " / " + character.Worn_Items.Neck.Total_slots;

            label_Slots_shouldersOn.Text = character.Worn_Items.ShouldersOn.Occupied_slots + " / " + character.Worn_Items.ShouldersOn.Total_slots;
            label_Slots_shouldersOver.Text = character.Worn_Items.ShouldersOver.Occupied_slots + " / " + character.Worn_Items.ShouldersOver.Total_slots;
            label_Slots_back.Text = character.Worn_Items.Back.Occupied_slots + " / " + character.Worn_Items.Back.Total_slots;

            label_Slots_hands.Text = character.Worn_Items.Hands.Occupied_slots + " / " + character.Worn_Items.Hands.Total_slots;
            label_Slots_handWeapon.Text = character.Worn_Items.HandWeapon.Occupied_slots + " / " + character.Worn_Items.HandWeapon.Total_slots;
            label_Slots_wrist.Text = character.Worn_Items.Wrist.Occupied_slots + " / " + character.Worn_Items.Wrist.Total_slots;
            label_Slots_fingers.Text = character.Worn_Items.Finger.Occupied_slots + " / " + character.Worn_Items.Finger.Total_slots;

            label_Slots_pants.Text = character.Worn_Items.Pants.Occupied_slots + " / " + character.Worn_Items.Pants.Total_slots;
            label_Slots_legArmor.Text = character.Worn_Items.LegArmor.Occupied_slots + " / " + character.Worn_Items.LegArmor.Total_slots;
            label_Slots_thigh.Text = character.Worn_Items.Thigh.Occupied_slots + " / " + character.Worn_Items.Thigh.Total_slots;
            label_Slots_kneeWeapon.Text = character.Worn_Items.KneeWeapon.Occupied_slots + " / " + character.Worn_Items.KneeWeapon.Total_slots;
            label_Slots_ankle.Text = character.Worn_Items.Ankle.Occupied_slots + " / " + character.Worn_Items.Ankle.Total_slots;
            label_Slots_footWeapon.Text = character.Worn_Items.FootWeapon.Occupied_slots + " / " + character.Worn_Items.FootWeapon.Total_slots;
            label_Slots_feet.Text = character.Worn_Items.Foot.Occupied_slots + " / " + character.Worn_Items.Foot.Total_slots;

            label_Slots_armUpper.Text = character.Worn_Items.ArmUpper.Occupied_slots + " / " + character.Worn_Items.ArmUpper.Total_slots;
            label_Slots_armArmor.Text = character.Worn_Items.ArmArmor.Occupied_slots + " / " + character.Worn_Items.ArmArmor.Total_slots;
            label_Slots_elbowWeapon.Text = character.Worn_Items.ElbowWeapon.Occupied_slots + " / " + character.Worn_Items.ElbowWeapon.Total_slots;
            label_Slots_shieldWorn.Text = character.Worn_Items.ShieldWorn.Occupied_slots + " / " + character.Worn_Items.ShieldWorn.Total_slots;
            label_Slots_parryStick.Text = character.Worn_Items.ParryStick.Occupied_slots + " / " + character.Worn_Items.ParryStick.Total_slots;

            label_Slots_body.Text = character.Worn_Items.Body.Occupied_slots + " / " + character.Worn_Items.Body.Total_slots;
            label_Slots_shirtArmor.Text = character.Worn_Items.ShirtArmor.Occupied_slots + " / " + character.Worn_Items.ShirtArmor.Total_slots;
            label_Slots_shirt.Text = character.Worn_Items.Shirt.Occupied_slots + " / " + character.Worn_Items.Shirt.Total_slots;
            label_Slots_tail.Text = character.Worn_Items.Tail.Occupied_slots + " / " + character.Worn_Items.Tail.Total_slots;

            label_Slots_waist.Text = character.Worn_Items.Waist.Occupied_slots + " / " + character.Worn_Items.Waist.Total_slots;
            label_Slots_belt.Text = character.Worn_Items.Belt.Occupied_slots + " / " + character.Worn_Items.Belt.Total_slots;

            label_Slots_ground.Text = character.Worn_Items.Ground.Occupied_slots;

        }

        //Update listboxes with worn items only (not containers) / Ignores IsContainer == True
        private void Updates_WormItems_ListBoxes(My_Character character)
        {
            for (int i = 0; i < character.Worn_Items.Head.Item.Count; i++)
                listBox_head.Items.Add(character.Worn_Items.Head.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Headarmor.Item.Count; i++)
                listBox_headArmor.Items.Add(character.Worn_Items.Headarmor.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.HairTied.Item.Count; i++)
                listBox_hairTied.Items.Add(character.Worn_Items.HairTied.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.HairPlaced.Item.Count; i++)
                listBox_hairPlaced.Items.Add(character.Worn_Items.HairPlaced.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.LeftEye.Item.Count; i++)
                listBox_leftEye.Items.Add(character.Worn_Items.LeftEye.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.LeftEye.Item.Count; i++)
                listBox_righteye.Items.Add(character.Worn_Items.RightEye.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Ear.Item.Count; i++)
                listBox_ear.Items.Add(character.Worn_Items.Ear.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.EarBoth.Item.Count; i++)
                listBox_bothEars.Items.Add(character.Worn_Items.EarBoth.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Nose.Item.Count; i++)
                listBox_nose.Items.Add(character.Worn_Items.Nose.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Neck.Item.Count; i++)
                listBox_neck.Items.Add(character.Worn_Items.Neck.Item[i].Text);

            //Back
            /////////////////////////
            for (int i = 0; i < character.Worn_Items.ShouldersOn.Item.Count; i++)
                listBox_shouldersOn.Items.Add(character.Worn_Items.ShouldersOn.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.ShouldersOver.Item.Count; i++)
                listBox_shouldersOver.Items.Add(character.Worn_Items.ShouldersOver.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Back.Item.Count; i++)
                listBox_back.Items.Add(character.Worn_Items.Back.Item[i].Text);

            //Hands
            //////////////////////////
            for (int i = 0; i < character.Worn_Items.Hands.Item.Count; i++)
                listBox_hands.Items.Add(character.Worn_Items.Hands.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.HandWeapon.Item.Count; i++)
                listBox_handWeapon.Items.Add(character.Worn_Items.HandWeapon.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Wrist.Item.Count; i++)
                listBox_wrist.Items.Add(character.Worn_Items.Wrist.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Finger.Item.Count; i++)
                listBox_fingers.Items.Add(character.Worn_Items.Finger.Item[i].Text);

            //Arms
            ///////////////////////////
            for (int i = 0; i < character.Worn_Items.ArmUpper.Item.Count; i++)
                listBox_armUpper.Items.Add(character.Worn_Items.ArmUpper.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.ArmArmor.Item.Count; i++)
                listBox_armArmor.Items.Add(character.Worn_Items.ArmArmor.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.ElbowWeapon.Item.Count; i++)
                listBox_elbowWeapon.Items.Add(character.Worn_Items.ElbowWeapon.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.ShieldWorn.Item.Count; i++)
                listBox_shieldWorn.Items.Add(character.Worn_Items.ShieldWorn.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.ParryStick.Item.Count; i++)
                listBox_parryStick.Items.Add(character.Worn_Items.ParryStick.Item[i].Text);

            //Body
            ///////////////////////////
            for (int i = 0; i < character.Worn_Items.Body.Item.Count; i++)
                listBox_body.Items.Add(character.Worn_Items.Body.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.ShirtArmor.Item.Count; i++)
                listBox_shirtArmor.Items.Add(character.Worn_Items.ShirtArmor.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Shirt.Item.Count; i++)
                listBox_shirt.Items.Add(character.Worn_Items.Shirt.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Tail.Item.Count; i++)
                listBox_tail.Items.Add(character.Worn_Items.Tail.Item[i].Text);

            //Waist
            ////////////////////////////
            for (int i = 0; i < character.Worn_Items.Waist.Item.Count; i++)
                listBox_waist.Items.Add(character.Worn_Items.Waist.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Belt.Item.Count; i++)
                listBox_belt.Items.Add(character.Worn_Items.Belt.Item[i].Text);

            //Legs
            ///////////////////////////
            for (int i = 0; i < character.Worn_Items.Pants.Item.Count; i++)
                listBox_pants.Items.Add(character.Worn_Items.Pants.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.LegArmor.Item.Count; i++)
                listBox_legArmor.Items.Add(character.Worn_Items.LegArmor.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Thigh.Item.Count; i++)
                listBox_thigh.Items.Add(character.Worn_Items.Thigh.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.KneeWeapon.Item.Count; i++)
                listBox_kneeWeapon.Items.Add(character.Worn_Items.KneeWeapon.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Ankle.Item.Count; i++)
                listBox_ankle.Items.Add(character.Worn_Items.Ankle.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.FootWeapon.Item.Count; i++)
                listBox_footWeapon.Items.Add(character.Worn_Items.FootWeapon.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Foot.Item.Count; i++)
                listBox_feet.Items.Add(character.Worn_Items.Foot.Item[i].Text);

            //Ground
            ////////////////////////////
            for (int i = 0; i < character.Worn_Items.Ground.Item.Count; i++)
                listBox_atFeet.Items.Add(character.Worn_Items.Ground.Item[i].Text);



        }

        //Update list boxes with just containers (where IsContainer == true)
        private void Updates_Containers_ListBoxes(My_Character character)
        {
            //Head
            //////////////////
            for (int i = 0; i < character.Worn_Items.Head.Item.Count; i++)
                if (character.Worn_Items.Head.Item[i].IsContainer == "True")
                    listBox_head.Items.Add(character.Worn_Items.Head.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Headarmor.Item.Count; i++)
                if (character.Worn_Items.Headarmor.Item[i].IsContainer == "True")
                    listBox_headArmor.Items.Add(character.Worn_Items.Headarmor.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.HairTied.Item.Count; i++)
                if (character.Worn_Items.HairTied.Item[i].IsContainer == "True")
                    listBox_hairTied.Items.Add(character.Worn_Items.HairTied.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.HairPlaced.Item.Count; i++)
                if (character.Worn_Items.HairPlaced.Item[i].IsContainer == "True")
                    listBox_hairPlaced.Items.Add(character.Worn_Items.HairPlaced.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.LeftEye.Item.Count; i++)
                if (character.Worn_Items.LeftEye.Item[i].IsContainer == "True")
                    listBox_leftEye.Items.Add(character.Worn_Items.LeftEye.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.LeftEye.Item.Count; i++)
                if (character.Worn_Items.RightEye.Item[i].IsContainer == "True")
                    listBox_righteye.Items.Add(character.Worn_Items.RightEye.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Ear.Item.Count; i++)
                if (character.Worn_Items.Ear.Item[i].IsContainer == "True")
                    listBox_ear.Items.Add(character.Worn_Items.Ear.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.EarBoth.Item.Count; i++)
                if (character.Worn_Items.EarBoth.Item[i].IsContainer == "True")
                    listBox_bothEars.Items.Add(character.Worn_Items.EarBoth.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Nose.Item.Count; i++)
                if (character.Worn_Items.Nose.Item[i].IsContainer == "True")
                    listBox_nose.Items.Add(character.Worn_Items.Nose.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Neck.Item.Count; i++)
                if (character.Worn_Items.Neck.Item[i].IsContainer == "True")
                    listBox_neck.Items.Add(character.Worn_Items.Neck.Item[i].Text);

            //Back
            /////////////////////////
            for (int i = 0; i < character.Worn_Items.ShouldersOn.Item.Count; i++)
                if (character.Worn_Items.ShouldersOn.Item[i].IsContainer == "True")
                    listBox_shouldersOn.Items.Add(character.Worn_Items.ShouldersOn.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.ShouldersOver.Item.Count; i++)
                if (character.Worn_Items.ShouldersOver.Item[i].IsContainer == "True")
                    listBox_shouldersOver.Items.Add(character.Worn_Items.ShouldersOver.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Back.Item.Count; i++)
                if (character.Worn_Items.Back.Item[i].IsContainer == "True")
                    listBox_back.Items.Add(character.Worn_Items.Back.Item[i].Text);

            //Hands
            //////////////////////////
            for (int i = 0; i < character.Worn_Items.Hands.Item.Count; i++)
                if (character.Worn_Items.Hands.Item[i].IsContainer == "True")
                    listBox_hands.Items.Add(character.Worn_Items.Hands.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.HandWeapon.Item.Count; i++)
                if (character.Worn_Items.HandWeapon.Item[i].IsContainer == "True")
                    listBox_handWeapon.Items.Add(character.Worn_Items.HandWeapon.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Wrist.Item.Count; i++)
                if (character.Worn_Items.Wrist.Item[i].IsContainer == "True")
                    listBox_wrist.Items.Add(character.Worn_Items.Wrist.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Finger.Item.Count; i++)
                if (character.Worn_Items.Finger.Item[i].IsContainer == "True")
                    listBox_fingers.Items.Add(character.Worn_Items.Finger.Item[i].Text);

            //Arms
            ///////////////////////////
            for (int i = 0; i < character.Worn_Items.ArmUpper.Item.Count; i++)
                if (character.Worn_Items.ArmUpper.Item[i].IsContainer == "True")
                    listBox_armUpper.Items.Add(character.Worn_Items.ArmUpper.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.ArmArmor.Item.Count; i++)
                if (character.Worn_Items.ArmArmor.Item[i].IsContainer == "True")
                    listBox_armArmor.Items.Add(character.Worn_Items.ArmArmor.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.ElbowWeapon.Item.Count; i++)
                if (character.Worn_Items.ElbowWeapon.Item[i].IsContainer == "True")
                    listBox_elbowWeapon.Items.Add(character.Worn_Items.ElbowWeapon.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.ShieldWorn.Item.Count; i++)
                if (character.Worn_Items.ShieldWorn.Item[i].IsContainer == "True")
                    listBox_shieldWorn.Items.Add(character.Worn_Items.ShieldWorn.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.ParryStick.Item.Count; i++)
                if (character.Worn_Items.ParryStick.Item[i].IsContainer == "True")
                    listBox_parryStick.Items.Add(character.Worn_Items.ParryStick.Item[i].Text);

            //Body
            ///////////////////////////
            for (int i = 0; i < character.Worn_Items.Body.Item.Count; i++)
                if (character.Worn_Items.Body.Item[i].IsContainer == "True")
                    listBox_body.Items.Add(character.Worn_Items.Body.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.ShirtArmor.Item.Count; i++)
                if (character.Worn_Items.ShirtArmor.Item[i].IsContainer == "True")
                    listBox_shirtArmor.Items.Add(character.Worn_Items.ShirtArmor.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Shirt.Item.Count; i++)
                if (character.Worn_Items.Shirt.Item[i].IsContainer == "True")
                    listBox_shirt.Items.Add(character.Worn_Items.Shirt.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Tail.Item.Count; i++)
                if (character.Worn_Items.Tail.Item[i].IsContainer == "True")
                    listBox_tail.Items.Add(character.Worn_Items.Tail.Item[i].Text);

            //Waist
            ////////////////////////////
            for (int i = 0; i < character.Worn_Items.Waist.Item.Count; i++)
                if (character.Worn_Items.Waist.Item[i].IsContainer == "True")
                    listBox_waist.Items.Add(character.Worn_Items.Waist.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Belt.Item.Count; i++)
                if (character.Worn_Items.Belt.Item[i].IsContainer == "True")
                    listBox_belt.Items.Add(character.Worn_Items.Belt.Item[i].Text);

            //Legs
            ///////////////////////////
            for (int i = 0; i < character.Worn_Items.Pants.Item.Count; i++)
                if (character.Worn_Items.Pants.Item[i].IsContainer == "True")
                    listBox_pants.Items.Add(character.Worn_Items.Pants.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.LegArmor.Item.Count; i++)
                if (character.Worn_Items.LegArmor.Item[i].IsContainer == "True")
                    listBox_legArmor.Items.Add(character.Worn_Items.LegArmor.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Thigh.Item.Count; i++)
                if (character.Worn_Items.Thigh.Item[i].IsContainer == "True")
                    listBox_thigh.Items.Add(character.Worn_Items.Thigh.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.KneeWeapon.Item.Count; i++)
                if (character.Worn_Items.KneeWeapon.Item[i].IsContainer == "True")
                    listBox_kneeWeapon.Items.Add(character.Worn_Items.KneeWeapon.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Ankle.Item.Count; i++)
                if (character.Worn_Items.Ankle.Item[i].IsContainer == "True")
                    listBox_ankle.Items.Add(character.Worn_Items.Ankle.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.FootWeapon.Item.Count; i++)
                if (character.Worn_Items.FootWeapon.Item[i].IsContainer == "True")
                    listBox_footWeapon.Items.Add(character.Worn_Items.FootWeapon.Item[i].Text);

            for (int i = 0; i < character.Worn_Items.Foot.Item.Count; i++)
                if (character.Worn_Items.Foot.Item[i].IsContainer == "True")
                    listBox_feet.Items.Add(character.Worn_Items.Foot.Item[i].Text);

            //Ground
            ////////////////////////////
            for (int i = 0; i < character.Worn_Items.Ground.Item.Count; i++)
                if (character.Worn_Items.Ground.Item[i].IsContainer == "True")
                    listBox_atFeet.Items.Add(character.Worn_Items.Ground.Item[i].Text);



        }

        /// <summary>
        /// Contains all Listbox processes to update tooltip and item location on main form
        /// Listbox OnMouseOver and OnMouseLeave and OnMouseDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
#region Listbox OnMouseOver and OnMouseLeave
        private void listBox_OnMouseLeave(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                label_locationText.ResetText();

            }
        }

        //Head
        //////////////////////////////////
        private void listBox_head_OnMouseOver(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
               toolTip1.SetToolTip(listBox_head, ItemsWorn._HEAD.Replace(":", ""));
               label_locationText.Text = ItemsWorn._HEAD.Replace(":", "");
            }
        }

        private void listBox_head_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_head.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_head.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }

                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }

            }
        }

        private void listBox_headArmor_OnMouseOver(object sender, EventArgs e)
        {
  
            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_headArmor, ItemsWorn._HEADARMOR.Replace(":", ""));
                label_locationText.Text = ItemsWorn._HEADARMOR.Replace(":", "");
            }
        }

        private void listBox_headArmor_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_headArmor.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_headArmor.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }

                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_hairTied_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_hairTied, ItemsWorn._TIEDHAIR.Replace(":", ""));
                label_locationText.Text = ItemsWorn._TIEDHAIR.Replace(":", "");
            }
        }

        private void listBox_hairTied_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_hairTied.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_hairTied.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_hairPlaced_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_hairPlaced, ItemsWorn._PLACEDHAIR.Replace(":", ""));
                label_locationText.Text = ItemsWorn._PLACEDHAIR.Replace(":", "");
            }
        }

        private void listBox_hairPlaced_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_hairPlaced.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_hairPlaced.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_leftEye_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_leftEye, ItemsWorn._LEFTEYE.Replace(":", ""));
                label_locationText.Text = ItemsWorn._LEFTEYE.Replace(":", "");
            }
        }

        private void listBox_leftEye_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_leftEye.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_leftEye.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_righteye_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_righteye, ItemsWorn._RIGHTEYE.Replace(":", ""));
                label_locationText.Text = ItemsWorn._RIGHTEYE.Replace(":", "");
            }
        }

        private void listBox_rightEye_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_righteye.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_righteye.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_ear_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_ear, ItemsWorn._EARS.Replace(":", ""));
                label_locationText.Text = ItemsWorn._EARS.Replace(":", "");
            }
        }

        private void listBox_ear_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_ear.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_ear.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_bothEars_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_bothEars, ItemsWorn._BOTHEARS.Replace(":", ""));
                label_locationText.Text = ItemsWorn._BOTHEARS.Replace(":", "");
            }
        }
        private void listBox_bothEars_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_bothEars.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_bothEars.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_nose_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_nose, ItemsWorn._NOSE.Replace(":", ""));
                label_locationText.Text = ItemsWorn._NOSE.Replace(":", "");
            }
        }

        private void listBox_nose_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_nose.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_nose.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                }
                //Toggle Container View based on checkbox status
                else if (checkBox_showContainers.Checked)
                {
                    //Open Container Form with TreeView
                    Open_Container_Window(temp_string);
                }
            }

        }

        private void listBox_neck_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_neck, ItemsWorn._NECK.Replace(":", ""));
                label_locationText.Text = ItemsWorn._NECK.Replace(":", "");
            }
        }

        private void listBox_neck_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_neck.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_neck.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        //Back
        /////////////////////////////////
        private void listBox_shouldersOn_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_shouldersOn, ItemsWorn._SHOULDER.Replace(":", ""));
                label_locationText.Text = ItemsWorn._SHOULDER.Replace(":", "");
            }
        }

        private void listBox_shouldersOn_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_shouldersOn.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_shouldersOn.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }


                }
            }

        }

        private void listBox_shouldersOver_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_shouldersOver, ItemsWorn._SHOULDERSWORN.Replace(":", ""));
                label_locationText.Text = ItemsWorn._SHOULDER.Replace(":", "");
            }
        }

        private void listBox_shouldersOver_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_shouldersOver.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_shouldersOver.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_back_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_back, ItemsWorn._BACK.Replace(":", ""));
                label_locationText.Text = ItemsWorn._BACK.Replace(":", "");
            }
        }

        private void listBox_back_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                //Get index of item clicked in List Box and then trim it
                int index = this.listBox_back.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_back.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        //Open URL
                        Open_URL_Link(temp_string, index);
                    }

                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }

            }


        }

        //Hands
        ////////////////////////////////
        private void listBox_hands_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_hands, ItemsWorn._HANDS.Replace(":", ""));
                label_locationText.Text = ItemsWorn._HANDS.Replace(":", "");
            }
        }

        private void listBox_hands_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_hands.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_hands.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_handWeapon_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_handWeapon, ItemsWorn._HANDWEAPON.Replace(":", ""));
                label_locationText.Text = ItemsWorn._HANDWEAPON.Replace(":", "");
            }
        }

        private void listBox_handWeapon_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_handWeapon.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_handWeapon.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_wrist_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_wrist, ItemsWorn._WRIST.Replace(":", ""));
                label_locationText.Text = ItemsWorn._WRIST.Replace(":", "");
            }
        }

        private void listBox_wrist_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_wrist.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_wrist.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_fingers_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_fingers, ItemsWorn._FINGER.Replace(":", ""));
                label_locationText.Text = ItemsWorn._FINGER.Replace(":", "");
            }
        }

        private void listBox_fingers_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_fingers.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_fingers.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        //Arms
        ///////////////////////////////
        private void listBox_armUpper_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_armUpper, ItemsWorn._UPPERARM.Replace(":", ""));
                label_locationText.Text = ItemsWorn._UPPERARM.Replace(":", "");
            }
        }

        private void listBox_armUpper_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_armUpper.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_armUpper.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_armArmor_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_armArmor, ItemsWorn._ARMARMOR.Replace(":", ""));
                label_locationText.Text = ItemsWorn._ARMARMOR.Replace(":", "");
            }
        }

        private void listBox_armArmor_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_armArmor.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_armArmor.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_elbowWeapon_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_elbowWeapon, ItemsWorn._ELBOWWEAPON.Replace(":", ""));
                label_locationText.Text = ItemsWorn._ELBOWWEAPON.Replace(":", "");
            }
        }

        private void listBox_elbowWeapon_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_elbowWeapon.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_elbowWeapon.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_shieldWorn_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_shieldWorn, ItemsWorn._ARMSHIELD.Replace(":", ""));
                label_locationText.Text = ItemsWorn._ARMSHIELD.Replace(":", "");
            }
        }

        private void listBox_shieldWorn_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_shieldWorn.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_shieldWorn.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }
        private void listBox_parryStick_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_parryStick, ItemsWorn._PARRYSTICK.Replace(":", ""));
                label_locationText.Text = ItemsWorn._PARRYSTICK.Replace(":", "");
            }
        }

        private void listBox_parryStick_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_parryStick.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_parryStick.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        //Body
        //////////////////////////////
        private void listBox_body_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_body, ItemsWorn._BODY.Replace(":", ""));
                label_locationText.Text = ItemsWorn._BODY.Replace(":", "");
            }
        }

        private void listBox_body_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_body.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_body.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_shirtArmor_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_shirtArmor, ItemsWorn._SHIRTARMOR.Replace(":", ""));
                label_locationText.Text = ItemsWorn._SHIRTARMOR.Replace(":", "");
            }
        }

        private void listBox_shirtArmor_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_shirtArmor.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_shirtArmor.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_shirt_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_shirt, ItemsWorn._SHIRT.Replace(":", ""));
                label_locationText.Text = ItemsWorn._SHIRT.Replace(":", "");
            }
        }

        private void listBox_shirt_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_shirt.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_shirt.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_tail_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_tail, ItemsWorn._TAIL.Replace(":", ""));
                label_locationText.Text = ItemsWorn._TAIL.Replace(":", "");
            }
        }

        private void listBox_tail_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_tail.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_tail.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        //Waist
        //////////////////////////////
        private void listBox_waist_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_waist, ItemsWorn._WAIST.Replace(":", ""));
                label_locationText.Text = ItemsWorn._WAIST.Replace(":", "");
            }
        }

        private void listBox_waist_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_waist.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_waist.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_belt_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_belt, ItemsWorn._BELT.Replace(":", ""));
                label_locationText.Text = ItemsWorn._BELT.Replace(":", "");
            }
        }

        private void listBox_belt_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_belt.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_belt.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        //Legs
        /////////////////////////////
        private void listBox_pants_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_pants, ItemsWorn._PANTS.Replace(":", ""));
                label_locationText.Text = ItemsWorn._PANTS.Replace(":", "");
            }
        }

        private void listBox_pants_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_pants.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_pants.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }
        private void listBox_legArmor_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_legArmor, ItemsWorn._LEGARMOR.Replace(":", ""));
                label_locationText.Text = ItemsWorn._LEGARMOR.Replace(":", "");
            }
        }

        private void listBox_legArmor_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_legArmor.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_legArmor.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_thigh_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_thigh, ItemsWorn._THIGH.Replace(":", ""));
                label_locationText.Text = ItemsWorn._THIGH.Replace(":", "");
            }
        }

        private void listBox_thigh_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_thigh.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_thigh.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_kneeWeapon_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_kneeWeapon, ItemsWorn._KNEEWEAPON.Replace(":", ""));
                label_locationText.Text = ItemsWorn._KNEEWEAPON.Replace(":", "");
            }
        }

        private void listBox_kneeWeapon_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_kneeWeapon.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_kneeWeapon.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_ankle_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_ankle, ItemsWorn._ANKLE.Replace(":", ""));
                label_locationText.Text = ItemsWorn._ANKLE.Replace(":", "");
            }
        }

        private void listBox_ankle_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_ankle.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_ankle.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_footWeapon_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_footWeapon, ItemsWorn._FOOTWEAPON.Replace(":", ""));
                label_locationText.Text = ItemsWorn._FOOTWEAPON.Replace(":", "");
            }
        }

        private void listBox_footWeapon_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_footWeapon.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_footWeapon.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        private void listBox_feet_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_feet, ItemsWorn._WORNFEET.Replace(":", ""));
                label_locationText.Text = ItemsWorn._WORNFEET.Replace(":", "");
            }
        }

        private void listBox_feet_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_feet.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_feet.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

        //Ground
        /////////////////////////////
        private void listBox_atFeet_OnMouseOver(object sender, EventArgs e)
        {

            if (sender is ListBox)
            {
                toolTip1.SetToolTip(listBox_atFeet, ItemsWorn._ATFEET.Replace(":", ""));
                label_locationText.Text = ItemsWorn._ATFEET.Replace(":", "");
            }
        }

        private void listBox_atFeet_MouseDoubleClick(object sender, MouseEventArgs e_)
        {
            if (sender is ListBox)
            {
                int index = this.listBox_atFeet.IndexFromPoint(e_.Location);
                string temp_string = "";

                if (index >= 0)
                {
                    temp_string = listBox_atFeet.Items[index].ToString();

                    //Toggle Search or Container View based on checkbox status
                    if (!checkBox_showContainers.Checked)
                    {
                        Open_URL_Link(temp_string, index);
                    }
                    //Toggle Container View based on checkbox status
                    else if (checkBox_showContainers.Checked)
                    {
                        //Open Container Form with TreeView
                        Open_Container_Window(temp_string);
                    }
                }
            }

        }

#endregion

        //Open a link to elanthipedia searching for the item that was double-clicked on. 
        private void Open_URL_Link(string temp_string, int index)
        {
            string updated_string = string.Join(" ", temp_string.Split().Skip(1));

            string url_string = "https://elanthipedia.play.net/index.php?search=" + updated_string;

            if (index != System.Windows.Forms.ListBox.NoMatches)
            {

                try
                {
                    System.Diagnostics.Process.Start(url_string);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to open the default browser.");
                }
            }

        }

        //Open form "Form_Container" with treeview of items in worn container from main form
        private void Open_Container_Window(string temp_string)
        {
            //Make temp TreeNode for item clicked
            TreeNode containerItem_Name = new TreeNode();
            containerItem_Name.Text = temp_string;

            //Add Item to master treenode (make sure to clear first)
            container_treeNode.Clear();
            container_treeNode.Add(containerItem_Name);

            //Loop through container list and add to container_treeNode
#if DEBUG
            foreach (My_Character character in _character_list_XML.My_Character)
#else
            foreach (My_Character character in Plugin_Code._character_list_XML.My_Character)
#endif
            {
                //Yeah, another recursion problem - oh well, only go to level 4 in worn containers
                //If we have a character, get the container as ItemData using the passed string temp_string
                    if (character.Character_Name == selected_Character)
                    {
                    ItemData temp_Item = character.Containers.Container_items.ItemData.Find(i => i.Container_name == temp_string);

                    //If we found it, populate the container_treeNode at first level with all items from container temp_string
                    if (temp_Item != null)
                        {
                            // Populate level 1 and 2
                            foreach (ItemData theItem in temp_Item.Container_items.ItemData)
                            {
                                TreeNode temp = new TreeNode();
                                temp.Text = theItem.Container_name;
                                container_treeNode[0].Nodes.Add(temp);

                                //Populate level 3
                                foreach (ItemData subItem in theItem.Container_items.ItemData)
                                {
                                    TreeNode temp2 = new TreeNode();
                                    temp2.Text = subItem.Container_name;
                                    container_treeNode[0].LastNode.Nodes.Add(temp2);

                                    int indexSecondLevel = container_treeNode[0].LastNode.Index;

                                    //Populate level 4
                                    foreach (ItemData subItem3 in subItem.Container_items.ItemData)
                                        {
                                            TreeNode temp3 = new TreeNode();
                                            temp3.Text = subItem3.Container_name;

                                             container_treeNode[0].Nodes[indexSecondLevel].LastNode.Nodes.Add(temp3);
                                            
                                         }

                                }

                            }
                        }

                    }
            }

            //Spawn new Form with TreeView, displaying container_treeNode
            Form_ContainerView container_Form = new Form_ContainerView();
            container_Form.treeView_Container.Nodes.AddRange(container_treeNode.ToArray());
            container_Form.treeView_Container.ExpandAll();
            container_Form.Text = "Container: " + container_treeNode[0].Text;
            container_Form.ShowDialog();
        }

        //Function to update photo on main form based on character race and gender
        private void Update_Photo(string gender, string race)
        {
            if (race == "Human")
                if (gender == "Male")
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Human_Male_Small;
                }
                else
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Human_Female_Small;
                }

            else if (race == "Elf")
                if (gender == "Male")
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Elf_Male_Small;
                }
                else
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Elf_Female_Small;
                }

            else if (race == "Kaldar")
                if (gender == "Male")
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Kaldar_Male_Small;
                }
                else
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Kaldar_Female_Small;
                }

            else if (race == "Dwarf")
                if (gender == "Male")
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Dwarf_Male_Small;
                }
                else
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Dwarf_Female_Small;
                }
            else if (race == "Elothean")
                if (gender == "Male")
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Elothean_Male_Small;
                }
                else
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Elothean_Female_Small;
                }
            else if (race == "Gortog")
                if (gender == "Male")
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Gortog_Male_Small;
                }
                else
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Gortog_Female_Small;
                }
            else if (race == "Skramur")
                if (gender == "Male")
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Skramur_Male_Small;
                }
                else
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Skramur_Female_Small;
                }
            else if (race == "Halfing")
                if (gender == "Male")
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Halfing_Male_Small;
                }
                else
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Halfing_Female_Small;
                }
            else if (race == "Rakash")
                if (gender == "Male")
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Rakash_Male_Small;
                }
                else
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Rakash_Female_Small;
                }
            else if (race == "Prydaen")
                if (gender == "Male")
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Prydaen_Male_Small;
                }
                else
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Prydaen_Female_Small;
                }
            else if (race == "Gnome")
                if (gender == "Male")
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Gnome_Male_Small;
                }
                else
                {
                    pictureBox_male.Image = global::Character_Inventory.Properties.Resources.Gnome_Female_Small;
                }

            pictureBox_male.Update();
        }

    } //end class

} //end namespace
