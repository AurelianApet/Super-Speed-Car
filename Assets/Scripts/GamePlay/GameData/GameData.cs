using UnityEngine;
using System.Collections;

public class GameData
{
		public static Vector2 SCALE = new Vector2 (800f / Screen.width, 480f / Screen.height);
		public static Matrix4x4 MATRIX_SCALING = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,
	                                                        new Vector3 (Screen.width / 800f, Screen.height / 480f, 1f));
		public static bool isLoginLeaderboard = false;
		//--------------------------------------------------------------------------------
		public enum CAR_NAME
		{
				ASTON_MARTIN_DB9,
				AUDI_R8,
				BMW_i8,
				BUGATTI_VEYRON,
				FERRARI_458_ITALIA,
				FERRARI_FXX,
				LAMBORGHINI_LP560,
				LAMBORGHINI_SESTO_ELEMENTO,
				LAMBORGHINI_VENENO,
				MARUSSIA_B2,
				MASERATI_GRAN_TURISMO,
				MERCEDES_BENZ_SLS,
				PAGANI_ZONDA,
				POLICE,
				PORSCHE_911,
		}

		public enum MAP_NAME
		{
				EGYPT,
				INDIA,
				BRAZIL,
				CHINA,
				VIET_NAM,
				PHILIPPINES,
				THAILAND,
				USA
		}

		public enum GAME_MODE
		{
				CLASSIC,
				TIME_TRIAL,
				CHECK_POINT,
				ELIMINATION
		}

		public enum ITEM_TYPE
		{
				BLUE_NITRO,
				RED_NITRO,
				GREEN_DOLLAR,
				GOLD_DOLLAR
		}

		public enum PATH_CHANGER_DIRECTION
		{
				OUT_IN,
				IN_OUT,
				OUT_OUT,
				IN_IN
		}

		public enum ACHIEVEMENT_TYPE
		{
				CAR_ACHIEVEMENT,
				CHALLENGE_ACHIEVEMENT,
				SKILL_ACHIEVEMENT,
				STAR_ACHIEVEMENT
		}

		//--------------------------------------------------------------------------------
		public static MAP_NAME selectedMap = MAP_NAME.USA;
		public static GAME_MODE selectedMode = GAME_MODE.CLASSIC;

		//--------------------------------------------------------------------------------
		public static bool isSinglePlayer = true;
		public static bool isWifiMode = true;

		//--------------------------------------------------------------------------------
		public static int numberRaces = 2;

		//--------------------------------------------------------------------------------
		public static float durationFirst = 80;
		public static float durationSecond = 100;
		public static float durationThird = 120;
		
		//--------------------------------------------------------------------------------
		public static int numberCheckpoints = 4;

		//--------------------------------------------------------------------------------
		public static float timeBetweenEliminate = 25;

		//--------------------------------------------------------------------------------
		public static int numberPlayers = 6;
		public static int level = -1;
		public static int selectedEvent = -1;

		//--------------------------------------------------------------------------------
		public static int reward = 0;
		public static int score = 0;

		//--------------------------------------------------------------------------------
		public static int rank = 4;
		public static bool FirstMission = false;
		public static bool SecondMission = false;

		//--------------------------------------------------------------------------------
		public static bool isPoliceCaught = true;
		public static bool isGoShortCut = false;
		public static float maxVelocityLimit = 0;
		public static bool isUseNitro = false;
		public static int numberGoShortCut = 0;

		//--------------------------------------------------------------------------------
		static bool isDoubleNitro = false;

		public static bool IsDoubleNitro {
				get {
						if (GameData.isSinglePlayer == true) {
								return isDoubleNitro;
						} else {
								return false;
						}
				}
				set {
						isDoubleNitro = value;
				}
		}

		static bool isDoubleReward = false;

		public static bool IsDoubleReward {
				get {
						if (GameData.isSinglePlayer == true) {
								return isDoubleReward;
						} else {
								return false;
						}
				}
				set {
						isDoubleReward = value;
				}
		}

		static bool isNitroFull = false;

		public static bool IsNitroFull {
				get {
						if (GameData.isSinglePlayer == true) {
								return isNitroFull;
						} else {
								return false;
						}
				}
				set {
						isNitroFull = value;
				}
		}

		static bool isTuningKit = false;

		public static bool IsTuningKit {
				get {
						if (GameData.isSinglePlayer == true) {
								return isTuningKit;
						} else {
								return false;
						}
				}
				set {
						isTuningKit = value;
				}
		}

		//--------------------------------------------------------------------------------
		static bool isStartFirst = false;

		public static bool IsStartFirst {
				get {
						if (GameData.isSinglePlayer == true) {
								return isStartFirst;
						} else {
								return false;
						}
				}
				set {
						isStartFirst = value;
				}
		}

		static bool isAutoSteer = false;

		public static bool IsAutoSteer {
				get {
						if (GameData.isSinglePlayer == true) {
								return isAutoSteer;
						} else {
								return false;
						}
				}
				set {
						isAutoSteer = value;
				}
		}

		static bool isProtectedFromCrash = false;

		public static bool IsProtectedFromCrash {
				get {
						if (GameData.isSinglePlayer == true) {
								return isProtectedFromCrash;
						} else {
								return false;
						}
				}
				set {
						isProtectedFromCrash = value;
				}
		}

		static bool isDoubleScore = false;

		public static bool IsDoubleScore {
				get {
						if (GameData.isSinglePlayer == true) {
								return isDoubleScore;
						} else {
								return false;
						}
				}
				set {
						isDoubleScore = value;
				}
		}

		//--------------------------------------------------------------------------------
		public static BasePowerUp firstPowerUp;
		public static BasePowerUp secondPowerUp;
		public static BasePowerUp thirdPowerUp;

		//--------------------------------------------------------------------------------
		public static int betValue;

		//--------------------------------------------------------------------------------
		public static int buyType = 0;		

		//--------------------------------------------------------------------------------

		public static string getMapPath (MAP_NAME mapName)
		{
				switch (mapName) {
				case MAP_NAME.EGYPT:
						return "Map_1_Egypt";

				case MAP_NAME.INDIA:
						return "Map_2_India";

				case MAP_NAME.BRAZIL:
						return "Map_3_Brazil";

				case MAP_NAME.CHINA:
						return "Map_4_China";

				case MAP_NAME.VIET_NAM:
						return "Map_5_HaNoi";

				case MAP_NAME.PHILIPPINES:
						return "Map_6_Philippines";

				case MAP_NAME.THAILAND:
						return "Map_7_ThaiLand";

				case MAP_NAME.USA:
						return "Map_8_USA";

				default:
						return "Map_1_Egypt";
				}
		}

		public static string getMapPath (int mapID)
		{
				switch (mapID) {
				case 0:
						return "Map_1_Egypt";
			
				case 1:
						return "Map_2_India";
			
				case 2:
						return "Map_3_Brazil";
			
				case 3:
						return "Map_4_China";
			
				case 4:
						return "Map_5_HaNoi";
			
				case 5:
						return "Map_6_Philippines";
			
				case 6:
						return "Map_7_ThaiLand";
			
				case 7:
						return "Map_8_USA";
			
				default:
						return "Map_1_Egypt";
				}
		}
	
		public static string getCarPrefab (CAR_NAME carName)
		{
				switch (carName) {
				case CAR_NAME.ASTON_MARTIN_DB9:
						return "Prefabs/Cars/Aston_Martin_DB9";

				case CAR_NAME.AUDI_R8:
						return "Prefabs/Cars/Audi_R8";

				case CAR_NAME.BUGATTI_VEYRON:
						return "Prefabs/Cars/Bugatti_Veyron";
			
				case CAR_NAME.FERRARI_FXX:
						return "Prefabs/Cars/Ferrari_FXX";

				case CAR_NAME.BMW_i8:
						return "Prefabs/Cars/BMW_i8";

				case CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO:
						return "Prefabs/Cars/Lamborghini_Sesto_Elemento";

				case CAR_NAME.FERRARI_458_ITALIA:
						return "Prefabs/Cars/Ferrari_458";

				case CAR_NAME.LAMBORGHINI_LP560:
						return "Prefabs/Cars/Lamborghini_LP560";

				case CAR_NAME.LAMBORGHINI_VENENO:
						return "Prefabs/Cars/Lamborghini_Veneno";

				case CAR_NAME.MARUSSIA_B2:
						return "Prefabs/Cars/Marussia_B2";

				case CAR_NAME.MASERATI_GRAN_TURISMO:
						return "Prefabs/Cars/Maserati_GranTurismo";

				case CAR_NAME.MERCEDES_BENZ_SLS:
						return "Prefabs/Cars/Mercedes_Benz_SLS";

				case CAR_NAME.PAGANI_ZONDA:
						return "Prefabs/Cars/Pagani_Zonda";

				case CAR_NAME.POLICE:
						return "Prefabs/Cars/Police";

				case CAR_NAME.PORSCHE_911:
						return "Prefabs/Cars/Porsche_911";

				default:
						return "Prefabs/Cars/Aston_Martin_DB9";
				}
		}

		public static CAR_NAME getCarName (int id)
		{
				switch (id) {
				case 0:
						return CAR_NAME.ASTON_MARTIN_DB9;

				case 1:
						return CAR_NAME.AUDI_R8;

				case 2:
						return CAR_NAME.BMW_i8;

				case 3:
						return CAR_NAME.BUGATTI_VEYRON;

				case 4:
						return CAR_NAME.FERRARI_458_ITALIA;

				case 5:
						return CAR_NAME.FERRARI_FXX;

				case 6:
						return CAR_NAME.LAMBORGHINI_LP560;

				case 7:
						return CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO;

				case 8:
						return CAR_NAME.LAMBORGHINI_VENENO;

				case 9:
						return CAR_NAME.MARUSSIA_B2;

				case 10:
						return CAR_NAME.MASERATI_GRAN_TURISMO;

				case 11:
						return CAR_NAME.MERCEDES_BENZ_SLS;

				case 12:
						return CAR_NAME.PAGANI_ZONDA;

				case 13:
						return CAR_NAME.POLICE;

				case 14:
						return CAR_NAME.PORSCHE_911;

				default:
						return CAR_NAME.ASTON_MARTIN_DB9;
				}
		}

		public static CAR_NAME getCarNameShop (int id)
		{
				switch (id) {
				case 0:
						return CAR_NAME.ASTON_MARTIN_DB9;

				case 1:
						return CAR_NAME.BMW_i8;

				case 2:
						return CAR_NAME.AUDI_R8;

				case 3:
						return CAR_NAME.MASERATI_GRAN_TURISMO;

				case 4:
						return CAR_NAME.MARUSSIA_B2;

				case 5:
						return CAR_NAME.FERRARI_458_ITALIA;

				case 6:
						return CAR_NAME.PORSCHE_911;

				case 7:
						return CAR_NAME.MERCEDES_BENZ_SLS;

				case 8:
						return CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO;

				case 9:
						return CAR_NAME.LAMBORGHINI_LP560;

				case 10:
						return CAR_NAME.POLICE;

				case 11:
						return CAR_NAME.FERRARI_FXX;

				case 12:
						return CAR_NAME.LAMBORGHINI_VENENO;

				case 13:
						return CAR_NAME.PAGANI_ZONDA;

				case 14:
						return CAR_NAME.BUGATTI_VEYRON;

				default:
						return CAR_NAME.ASTON_MARTIN_DB9;
				}
		}

		public static void resetData ()
		{
				if (GameData.firstPowerUp != null) {
						if (GameData.firstPowerUp.powerState != BasePowerUp.POWER_STATE.NOT_ACTIVE) {
								firstPowerUp = null;
						}
				}

				if (GameData.secondPowerUp != null) {
						if (GameData.secondPowerUp.powerState != BasePowerUp.POWER_STATE.NOT_ACTIVE) {
								secondPowerUp = null;
						}
				}

				if (GameData.thirdPowerUp != null) {
						if (GameData.thirdPowerUp.powerState != BasePowerUp.POWER_STATE.NOT_ACTIVE) {
								thirdPowerUp = null;
						}
				}

				rank = 4;			

				isPoliceCaught = false;
				isGoShortCut = false;
				maxVelocityLimit = 0;
				isUseNitro = false;
				numberGoShortCut = 0;

				if (GameData.level > -1) {
						if (ProfileManager.userProfile.MapProfile [GameData.level].FirstMission == true) {
								FirstMission = true;
						} else {
								FirstMission = false;
						}

						if (ProfileManager.userProfile.MapProfile [GameData.level].SecondMission == true) {
								SecondMission = true;
						} else {
								SecondMission = false;
						}
				} else {
						FirstMission = false;
						SecondMission = false;
				}
		}

		public static bool isPowerUsing ()
		{
				if (firstPowerUp != null) {
						if (firstPowerUp.powerState == BasePowerUp.POWER_STATE.ACTIVATING) {
								return true;
						}
				}

				if (secondPowerUp != null) {
						if (secondPowerUp.powerState == BasePowerUp.POWER_STATE.ACTIVATING) {
								return true;
						}
				}

				if (thirdPowerUp != null) {
						if (thirdPowerUp.powerState == BasePowerUp.POWER_STATE.ACTIVATING) {
								return true;
						}
				}

				return false;
		}

		public static void resetGlobalPowerUp ()
		{
				if (GameData.isSinglePlayer == true) {
						isNitroFull = false;
						isDoubleNitro = false;
						isDoubleReward = false;
						isTuningKit = false;

						isStartFirst = false;
						isAutoSteer = false;
						isProtectedFromCrash = false;
						isDoubleScore = false;

						ProfileManager.userProfile.BoughtPowerUp = 0;			
				}
		}

		public static int getCarRank (GameData.CAR_NAME selectedCar)
		{
				switch (selectedCar) {
				case CAR_NAME.ASTON_MARTIN_DB9:
						return 0;
			
				case CAR_NAME.AUDI_R8:
						return 0;
			
				case CAR_NAME.BUGATTI_VEYRON:
						return 2;
			
				case CAR_NAME.FERRARI_FXX:
						return 2;
			
				case CAR_NAME.BMW_i8:
						return 0;
			
				case CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO:
						return 1;
			
				case CAR_NAME.FERRARI_458_ITALIA:
						return 1;
			
				case CAR_NAME.LAMBORGHINI_LP560:
						return 2;
			
				case CAR_NAME.LAMBORGHINI_VENENO:
						return 2;
			
				case CAR_NAME.MARUSSIA_B2:
						return 0;
			
				case CAR_NAME.MASERATI_GRAN_TURISMO:
						return 0;
			
				case CAR_NAME.MERCEDES_BENZ_SLS:
						return 1;
			
				case CAR_NAME.PAGANI_ZONDA:
						return 2;
			
				case CAR_NAME.POLICE:
						return 1;
			
				case CAR_NAME.PORSCHE_911:
						return 1;
			
				default:
						return 0;
				}
		}
}