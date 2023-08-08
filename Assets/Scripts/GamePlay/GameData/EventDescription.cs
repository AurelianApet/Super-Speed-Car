using UnityEngine;
using System.Collections;

public class EventDescription
{
	public static GameData.MAP_NAME getEventMap (int eventID)
	{
		switch (eventID) {
		case 0:
			return GameData.MAP_NAME.USA;

		case 1:
			return GameData.MAP_NAME.INDIA;

		case 2:
			return GameData.MAP_NAME.VIET_NAM;

		case 3:
			return GameData.MAP_NAME.CHINA;

		case 4:
			return GameData.MAP_NAME.USA;

		case 5:
			return GameData.MAP_NAME.EGYPT;

		case 6:
			return GameData.MAP_NAME.PHILIPPINES;

		case 7:
			return GameData.MAP_NAME.THAILAND;

		case 8:
			return GameData.MAP_NAME.BRAZIL;

		case 9:
			return GameData.MAP_NAME.VIET_NAM;

		case 10:
			return GameData.MAP_NAME.EGYPT;

		case 11:
			return GameData.MAP_NAME.PHILIPPINES;

		case 12:
			return GameData.MAP_NAME.VIET_NAM;

		case 13:
			return GameData.MAP_NAME.THAILAND;

		case 14:
			return GameData.MAP_NAME.CHINA;

		case 15:
			return GameData.MAP_NAME.EGYPT;

		case 16:
			return GameData.MAP_NAME.INDIA;

		case 17:
			return GameData.MAP_NAME.BRAZIL;

		default:
			return GameData.MAP_NAME.USA;
		}
	}

	public static string getEventName (int eventID)
	{
		switch (eventID) {
		case 0:
			return "USA International";
			
		case 1:
			return "Wonderful Taj Mahal";
			
		case 2:
			return "Welcome to Viet Nam";
			
		case 3:
			return "The Great Wall";
			
		case 4:
			return "Amazing Win";
			
		case 5:
			return "Huge Pyramid";
			
		case 6:
			return "First birthday";
			
		case 7:
			return "New car, new challenge";
			
		case 8:
			return "Coast to coast";
			
		case 9:
			return "Season passed";
			
		case 10:
			return "Sphinx";
			
		case 11:
			return "Don't stop";
			
		case 12:
			return "Passion";
			
		case 13:
			return "The mirage";
			
		case 14:
			return "Moment of peace";
			
		case 15:
			return "Sand of the desert";
			
		case 16:
			return "Old memories";
			
		case 17:
			return "Enjoy Holidays";
			
		default:
			return string.Empty;
		}
	}

	public static EventReward getEventReward (int eventID)
	{
		switch (eventID) {
		case 0:
			return new EventReward (2000, 1500, 500);
			
		case 1:
			return new EventReward (3500, 2500, 750);
			
		case 2:
			return new EventReward (1050, 650, 250);
			
		case 3:
			return new EventReward (3500, 2000, 1000);
			
		case 4:
			return new EventReward (2500, 1000, 600);
			
		case 5:
			return new EventReward (3500, 2450, 1000);
			
		case 6:
			return new EventReward (3500, 1500, 1100);
			
		case 7:
			return new EventReward (3200, 2000, 1100);
			
		case 8:
			return new EventReward (3500, 2100, 1000);
			
		case 9:
			return new EventReward (3000, 2100, 750);
			
		case 10:
			return new EventReward (1100, 700, 350);
			
		case 11:
			return new EventReward (1000, 600, 370);
			
		case 12:
			return new EventReward (1800, 1250, 800);
			
		case 13:
			return new EventReward (1200, 700, 400);
			
		case 14:
			return new EventReward (1650, 1300, 950);
			
		case 15:
			return new EventReward (3500, 2000, 1000);
			
		case 16:
			return new EventReward (1700, 1300, 900);
			
		case 17:
			return new EventReward (1750, 1400, 1000);
			
		default:
			return new EventReward (8000, 3500, 900);
		}
	}
}