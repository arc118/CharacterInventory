# CharacterInventory
GeniePlugin to Scan your Worn items and Containers

## V1.0 - Initial Release

### Instructions:
This Plugin is for use with Genie and Dragonrealms MUD only. This version was tested with Genie V3.5.4724.145

### Using the DLL with Genie:
To install this Plugin, place the CharacterInventory.DLL in your Genie "Plugin" folder. When Genie launches, click "Ok" to authorize. 

### Notes on Usage in Genie:
You must be logged in to populate the form and click the "Scan Worn Items" followed by "Scan Containers" button. This will create a file in your Plugin folder called "Character_Inventory.xml" that contains all your characters inventory. 

Once you have clicked "Scan Containers", you will be able to toggle between Worn Items and Containers. Double-clicking on the various items will either launch elanthipedia and conduct a search for your item, or if you toggle "Show Containers Only", will open another window with the containers items. You can then hit the "enter" key to try and find the item on elanthipedia. 

### Notes on Stand-Alone .EXE Usage:
If you like, you can also use the Plugin as a stand-alone executable. Ensure you first populated the "Character_Inventory.xml" file from Genie when you were logged in. Then copy the .XML file to the same folder as the .EXE and you should have the same functionality. 

## Couple other things:
- I have extensively tested this, but if you run into problems let me know on Discord Genie 3 Channel (under Plug-in Development). 
- Since I suck at recursion, I only went four levels deep when scanning a container. I'm not sure what the upper limit is in Dragonrealms for nested containers, but let me know if people nest multiple containers in other containers. 
