using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Character_Inventory
{
	[XmlRoot(ElementName = "item")]
	public class Item
	{
		[XmlAttribute(AttributeName = "short_desc")]
		public string Short_desc { get; set; }
		[XmlAttribute(AttributeName = "isContainer")]
		public string IsContainer { get; set; } = "false";
		[XmlAttribute(AttributeName = "isFluff")]
		public string IsFluff { get; set; } = "false";
		[XmlAttribute(AttributeName = "isCombat")]
		public string IsCombat { get; set; } = "false";
		[XmlAttribute(AttributeName = "isArmor")]
		public string IsArmor { get; set; } = "false";
		[XmlAttribute(AttributeName = "isWeapon")]
		public string IsWeapon { get; set; } = "false";
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "head")]
	public class Head
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._HEAD;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "1";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "2";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "headarmor")]
	public class Headarmor
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._HEADARMOR;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "2";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "hairTied")]
	public class HairTied
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._TIEDHAIR;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "3";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "hairPlaced")]
	public class HairPlaced
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._PLACEDHAIR;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "4";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "rightEye")]
	public class RightEye
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._RIGHTEYE;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "6";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "leftEye")]
	public class LeftEye
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._LEFTEYE;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "7";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "ear")]
	public class Ear
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._EARS;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "8";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "2";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "earBoth")]
	public class EarBoth
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._BOTHEARS;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "9";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "2";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "nose")]
	public class Nose
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._NOSE;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "10";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "neck")]
	public class Neck
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._NECK;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "11";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "3";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "shouldersOn")]
	public class ShouldersOn
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._SHOULDERSWORN;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "12";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "body")]
	public class Body
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._BODY;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "13";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "32";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "shouldersOver")]
	public class ShouldersOver
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._SHOULDER;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "14";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "3";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "back")]
	public class Back
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._BACK;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "15";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "shirtArmor")]
	public class ShirtArmor
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._SHIRTARMOR;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "16";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "3";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "shirt")]
	public class Shirt
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._SHIRT;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "17";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "armUpper")]
	public class ArmUpper
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._UPPERARM;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "18";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "3";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "armArmor")]
	public class ArmArmor
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._ARMARMOR;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "19";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "elbowWeapon")]
	public class ElbowWeapon
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._ELBOWWEAPON;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "20";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "shieldWorn")]
	public class ShieldWorn
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._ARMSHIELD;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "21";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "wrist")]
	public class Wrist
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._WRIST;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "22";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "4";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "parryStick")]
	public class ParryStick
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._PARRYSTICK;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "23";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "handWeapon")]
	public class HandWeapon
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._HANDWEAPON;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "24";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "hands")]
	public class Hands
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._HANDS;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "25";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "finger")]
	public class Finger
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._FINGER;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "26";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "6";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "waist")]
	public class Waist
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._WAIST;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "27";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "3";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "belt")]
	public class Belt
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._BELT;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "28";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "6";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "tail")]
	public class Tail
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._TAIL;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "29";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "3";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "pants")]
	public class Pants
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._PANTS;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "30";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "legArmor")]
	public class LegArmor
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._LEGARMOR;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "32";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "thigh")]
	public class Thigh
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._THIGH;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "32";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "3";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "kneeWeapon")]
	public class KneeWeapon
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._KNEEWEAPON;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "33";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "ankle")]
	public class Ankle
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._ANKLE;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "34";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "4";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "footWeapon")]
	public class FootWeapon
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._FOOTWEAPON;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "35";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "foot")]
	public class Foot
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._WORNFEET;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "36";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "1";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "ground")]
	public class Ground
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; } = new List<Item>();
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; } = ItemsWorn._ATFEET;
		[XmlAttribute(AttributeName = "slot_location")]
		public string Slot_location { get; set; } = "37";
		[XmlAttribute(AttributeName = "total_slots")]
		public string Total_slots { get; set; } = "0";
		[XmlAttribute(AttributeName = "occupied_slots")]
		public string Occupied_slots { get; set; } = "0";
	}

	[XmlRoot(ElementName = "Worn_Items")]
	public class Worn_Items
	{
		[XmlElement(ElementName = "head")]
		public Head Head { get; set; } = new Head();
		[XmlElement(ElementName = "headarmor")]
		public Headarmor Headarmor { get; set; } = new Headarmor();
		[XmlElement(ElementName = "hairTied")]
		public HairTied HairTied { get; set; } = new HairTied();
		[XmlElement(ElementName = "hairPlaced")]
		public HairPlaced HairPlaced { get; set; } = new HairPlaced();
		[XmlElement(ElementName = "rightEye")]
		public RightEye RightEye { get; set; } = new RightEye();
		[XmlElement(ElementName = "leftEye")]
		public LeftEye LeftEye { get; set; } = new LeftEye();
		[XmlElement(ElementName = "ear")]
		public Ear Ear { get; set; } = new Ear();
		[XmlElement(ElementName = "earBoth")]
		public EarBoth EarBoth { get; set; } = new EarBoth();
		[XmlElement(ElementName = "nose")]
		public Nose Nose { get; set; } = new Nose();
		[XmlElement(ElementName = "neck")]
		public Neck Neck { get; set; } = new Neck();
		[XmlElement(ElementName = "shouldersOn")]
		public ShouldersOn ShouldersOn { get; set; } = new ShouldersOn();
		[XmlElement(ElementName = "body")]
		public Body Body { get; set; } = new Body();
		[XmlElement(ElementName = "shouldersOver")]
		public ShouldersOver ShouldersOver { get; set; } = new ShouldersOver();
		[XmlElement(ElementName = "back")]
		public Back Back { get; set; } = new Back();
		[XmlElement(ElementName = "shirtArmor")]
		public ShirtArmor ShirtArmor { get; set; } = new ShirtArmor();
		[XmlElement(ElementName = "shirt")]
		public Shirt Shirt { get; set; } = new Shirt();
		[XmlElement(ElementName = "armUpper")]
		public ArmUpper ArmUpper { get; set; } = new ArmUpper();
		[XmlElement(ElementName = "armArmor")]
		public ArmArmor ArmArmor { get; set; } = new ArmArmor();
		[XmlElement(ElementName = "elbowWeapon")]
		public ElbowWeapon ElbowWeapon { get; set; } = new ElbowWeapon();
		[XmlElement(ElementName = "shieldWorn")]
		public ShieldWorn ShieldWorn { get; set; } = new ShieldWorn();
		[XmlElement(ElementName = "wrist")]
		public Wrist Wrist { get; set; } = new Wrist();
		[XmlElement(ElementName = "parryStick")]
		public ParryStick ParryStick { get; set; } = new ParryStick();
		[XmlElement(ElementName = "handWeapon")]
		public HandWeapon HandWeapon { get; set; } = new HandWeapon();
		[XmlElement(ElementName = "hands")]
		public Hands Hands { get; set; } = new Hands();
		[XmlElement(ElementName = "finger")]
		public Finger Finger { get; set; } = new Finger();
		[XmlElement(ElementName = "waist")]
		public Waist Waist { get; set; } = new Waist();
		[XmlElement(ElementName = "belt")]
		public Belt Belt { get; set; } = new Belt();
		[XmlElement(ElementName = "tail")]
		public Tail Tail { get; set; } = new Tail();
		[XmlElement(ElementName = "pants")]
		public Pants Pants { get; set; } = new Pants();
		[XmlElement(ElementName = "legArmor")]
		public LegArmor LegArmor { get; set; } = new LegArmor();
		[XmlElement(ElementName = "thigh")]
		public Thigh Thigh { get; set; } = new Thigh();
		[XmlElement(ElementName = "kneeWeapon")]
		public KneeWeapon KneeWeapon { get; set; } = new KneeWeapon();
		[XmlElement(ElementName = "ankle")]
		public Ankle Ankle { get; set; } = new Ankle();
		[XmlElement(ElementName = "footWeapon")]
		public FootWeapon FootWeapon { get; set; } = new FootWeapon();
		[XmlElement(ElementName = "foot")]
		public Foot Foot { get; set; } = new Foot();
		[XmlElement(ElementName = "ground")]
		public Ground Ground { get; set; } = new Ground();
	}

	[XmlRoot(ElementName = "ItemData")]
	public class ItemData
	{
		[XmlElement(ElementName = "container_name")]
		public string Container_name { get; set; }
		[XmlElement(ElementName = "container_items")]
		public Container_items Container_items { get; set; } = new Container_items();

	}

	[XmlRoot(ElementName = "container_items")]
	public class Container_items
	{
		[XmlElement(ElementName = "ItemData")]
		public List<ItemData> ItemData { get; set; } = new List<ItemData>();

	}

	[XmlRoot(ElementName = "Containers")]
	public class Containers
	{
		[XmlElement(ElementName = "container_items")]
		public Container_items Container_items { get; set; } = new Container_items();
	}

	[XmlRoot(ElementName = "My_Character")]
	public class My_Character
	{
		[XmlElement(ElementName = "Character_Name")]
		public string Character_Name { get; set; }
		[XmlElement(ElementName = "Character_Gender")]
		public string Character_Gender { get; set; }
		[XmlElement(ElementName = "Character_Race")]
		public string Character_Race { get; set; }
		[XmlElement(ElementName = "Total_Items")]
		public string Total_Items { get; set; } = "0";
		[XmlElement(ElementName = "Worn_Items")]
		public Worn_Items Worn_Items { get; set; } = new Worn_Items();

		[XmlElement(ElementName = "Containers")]
		public Containers Containers { get; set; } = new Containers();
	}

	[XmlRoot(ElementName = "Character_List")]
	public class Character_List
	{
		[XmlElement(ElementName = "My_Character")]
		public List<My_Character> My_Character { get; set; }
	}
}
