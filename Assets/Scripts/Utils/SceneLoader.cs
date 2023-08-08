using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
	public static bool isLoadMultiplayerScene = false;
	public static string scene = "MainMenu";
	public static int prefix = 1;

	//
	public dfSprite[] loading;
	public dfPanel[] gameModePanel;
	public dfLabel gameModeName;
	public dfLabel gameModeDesc;
	public dfLabel mapName;
	public dfLabel mission_1;
	public dfLabel mission_2;

	//
	public dfLabel classicLaps;
	public dfLabel classicOpponents;

	//
	public dfLabel checkPointsOpponents;
	public dfLabel checkPointsLaps;
	public dfLabel checkPoints;

	//
	public dfLabel eliminationOpponents;

	//
	public dfLabel timeTrial_1;
	public dfLabel timeTrial_2;
	public dfLabel timeTrial_3;

	//
	public dfLabel tip;

	//
	public dfTextureSprite starMain_1;
	public dfTextureSprite starMain_2;
	public dfTextureSprite starMain_3;
	public dfTextureSprite starMission_1;
	public dfTextureSprite starMission_2;

	void Start ()
	{
		if (isLoadMultiplayerScene == false) {
			Application.LoadLevelAsync (scene);
		} else {
			if (GameData.isWifiMode == true) {
				NetworkLevelLoader.Instance.LoadLevel (scene, prefix);
			} else {
				Application.LoadLevelAsync (scene);
			}
		}

		isLoadMultiplayerScene = false; 
		this.loading [Random.Range (0, loading.Length)].IsVisible = true;

		if (scene == "Map_1_Egypt" || scene == "Map_2_India" || scene == "Map_3_Brazil" || scene == "Map_4_China" ||
			scene == "Map_5_HaNoi" || scene == "Map_6_Philippines" || scene == "Map_7_ThaiLand" || scene == "Map_8_USA") {
			this.updateInfo ();

		} else {
			gameModeName.Text = string.Empty;
			gameModeDesc.Text = string.Empty;

			mapName.Text = string.Empty;

			mission_1.Text = string.Empty;
			mission_2.Text = string.Empty;
		}
		
		tip.Text = getTip ();

		if (GameData.level > -1) {
			if (ProfileManager.userProfile.MapProfile [GameData.level].FirstMission == false) {
				starMission_1.Color = new Color (0.3f, 0.3f, 0.3f, 1);
			}

			if (ProfileManager.userProfile.MapProfile [GameData.level].SecondMission == false) {
				starMission_2.Color = new Color (0.3f, 0.3f, 0.3f, 1);
			}

			switch (ProfileManager.userProfile.MapProfile [GameData.level].MainMission) {
			case 3:
				break;

			case 2:
				starMain_3.Color = new Color (0.3f, 0.3f, 0.3f, 1);
				break;

			case 1:
				starMain_2.Color = new Color (0.3f, 0.3f, 0.3f, 1);
				starMain_3.Color = new Color (0.3f, 0.3f, 0.3f, 1);
				break;

			default:
				starMain_1.Color = new Color (0.3f, 0.3f, 0.3f, 1);
				starMain_2.Color = new Color (0.3f, 0.3f, 0.3f, 1);
				starMain_3.Color = new Color (0.3f, 0.3f, 0.3f, 1);
				break;
			}
		} else {
//						starMain_1.Color = Color.gray;
//						starMain_2.Color = Color.gray;
//						starMain_3.Color = Color.gray;

			starMission_1.IsVisible = false;
			starMission_2.IsVisible = false;
		}
	}

	void updateInfo ()
	{
		switch (GameData.selectedMode) {
		case GameData.GAME_MODE.CLASSIC:
			gameModePanel [0].gameObject.SetActive (true);
			gameModeName.Text = "Classic";
			gameModeDesc.Text = "Finish  in  3  lead  positions";

			classicLaps.Text = GameData.numberRaces + "  laps";
			classicOpponents.Text = GameData.numberPlayers + "  opponents";
			break;			
			
		case GameData.GAME_MODE.ELIMINATION:
			gameModePanel [1].gameObject.SetActive (true);			
			gameModeName.Text = "Elimination";
			gameModeDesc.Text = "Don't  get  eliminated  and  finish  in  3  lead  positions";
			
			eliminationOpponents.Text = GameData.numberPlayers + "  opponents";
			break;

		case GameData.GAME_MODE.CHECK_POINT:
			gameModePanel [2].gameObject.SetActive (true);
			gameModeName.Text = "Check  point";
			gameModeDesc.Text = "Earn  enough  check  points  and  finish  in  3  lead  positions";

			checkPointsOpponents.Text = GameData.numberPlayers + "  opponents";
			checkPointsLaps.Text = GameData.numberRaces + "  laps";
			checkPoints.Text = GameData.numberCheckpoints + "  check  points";
			break;

		case GameData.GAME_MODE.TIME_TRIAL:
			gameModePanel [3].gameObject.SetActive (true);
			gameModeName.Text = "Time  trial";
			gameModeDesc.Text = "Finish  in  allowed  time  to  win";

			timeTrial_1.Text = "1st:  " + GameData.durationFirst + "  seconds";
			timeTrial_2.Text = "2nd:  " + GameData.durationSecond + "  seconds";
			timeTrial_3.Text = "3rd:  " + GameData.durationThird + "  seconds";
			break;

		default:
			break;
		}

		switch (GameData.selectedMap) {
		case GameData.MAP_NAME.EGYPT:
			mapName.Text = "Egypt";
			break;

		case GameData.MAP_NAME.INDIA:
			mapName.Text = "India";
			break;

		case GameData.MAP_NAME.BRAZIL:
			mapName.Text = "Brazil";
			break;

		case GameData.MAP_NAME.CHINA:
			mapName.Text = "China";
			break;

		case GameData.MAP_NAME.VIET_NAM:
			mapName.Text = "Viet  Nam";
			break;

		case GameData.MAP_NAME.THAILAND:
			mapName.Text = "Thai  land";
			break;

		case GameData.MAP_NAME.USA:
			mapName.Text = "United  States  of  America";
			break;

		default:
			break;
		}

		mission_1.Text = MissionDescription.getFirstMission (GameData.level).ToUpper ();
		mission_2.Text = MissionDescription.getSecondMission (GameData.level).ToUpper ();
	}

	public static string getTip ()
	{
		int tipID = Random.Range (0, 20);

		switch (tipID) {
		case 0:
			return "The green bar at the top of the play screen indicates remaining nitro";

		case 1:
			return "To cancel nitro boost, press the brake";

		case 2:
			return "Fill up your nitro tank by performing several in-game actions, ie drifts, fly, hit obstacles...";

		case 3:
			return "You will see nitro items appearing in different places on the tracks";

		case 4:
			return "Tap the brake while steering to start drifting. Use drifts to navigate difficult curves";

		case 5:
			return "Stop a drift by using nitro or keeping the car straight";

		case 6:
			return "Beside Classic mode, the game includes Elimination, Time trial, and Checkpoint";

		case 7:
			return "Upgrading speed increase the max speed of the car";

		case 8:
			return "Upgrade nitro to increase the duration usage of nitro";

		case 9:
			return "Upgrade car handling to keep the highest speed possible while steering";

		case 10:
			return "Upgrade acceleration for your car to accelerate much faster";

		case 11:
			return "Most tracks have shortcuts, you better use them to win the game with difficult races";

		case 12:
			return "There are 2 control types: Tilt or Touch.  Choose the one you feel the most comfortable";

		case 13:
			return "There are two Nitro types: The red nitro generates more power than the green one";

		case 14:
			return "There are two types of coin items, the gold coin counts more than the green one";

		case 15:
			return "Before starting a race, Purchase power-up car options to obtain more advantages";

		case 16:
			return "Purchase in-game supporting items on the top right corner";

		case 17:
			return "You can bring up to 3 items into a race. These items is located at top right corner of the screen";

		case 18:
			return "Sometime the police cars will chase you, try to use nitro to outdistance them.";

		case 19:
			return "If you get caught by police, you will be respawned after 3 seconds";

		default:
			return "You can bring up to 3 items into a race. These items is located at top right corner of the screen";
		}
	}
}