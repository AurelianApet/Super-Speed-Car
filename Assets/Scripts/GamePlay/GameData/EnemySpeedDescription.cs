using UnityEngine;
using System.Collections;

public class EnemySpeedDescription
{
	public static float getEnemySpeed (int index)
	{
		if (GameData.level == -1) {
			float speed = AllCarDescription.getCarSpeed ((GameData.CAR_NAME)ProfileManager.userProfile.SelectedCar,
			                                   ProfileManager.userProfile.CarProfile [ProfileManager.userProfile.SelectedCar].Speed);

			switch (index) {
			case 1:
				return speed + 50;
				
			case 2:
				return speed + 25;

			case 3:
				return speed + 5;

			case 4:
				return speed - 5;

			case 5:
				return speed - 25;

			default:
				return speed;
			}

		} else {
			int season = SeasonDescription.getSeason (GameData.level + 1);
			switch (season) {
			case 1:
				switch (index) {
				case 1:
					return 220 + Mathf.Pow (GameData.level, 1.9f);
					
				case 2:
					return 210 + Mathf.Pow (GameData.level, 1.9f);
					
				case 3:
					return 200 + Mathf.Pow (GameData.level, 1.9f);
					
				case 4:
					return 190 + Mathf.Pow (GameData.level, 1.9f);
					
				case 5:
					return 180 + Mathf.Pow (GameData.level, 1.9f);
					
				default:
					return 200 + Mathf.Pow (GameData.level, 1.9f);
				}

			case 2:
				switch (index) {
				case 1:
					return 250 + Mathf.Pow (GameData.level - 10, 1.81f);
					
				case 2:
					return 240 + Mathf.Pow (GameData.level - 10, 1.81f);
					
				case 3:
					return 230 + Mathf.Pow (GameData.level - 10, 1.81f);
					
				case 4:
					return 210 + Mathf.Pow (GameData.level - 10, 1.81f);
					
				case 5:
					return 190 + Mathf.Pow (GameData.level - 10, 1.81f);
					
				default:
					return 200 + Mathf.Pow (GameData.level - 10, 1.81f);
				}

			case 3:
				switch (index) {
				case 1:
					return 280 + Mathf.Pow (GameData.level - 22, 1.66f);
					
				case 2:
					return 270 + Mathf.Pow (GameData.level - 22, 1.66f);
					
				case 3:
					return 260 + Mathf.Pow (GameData.level - 22, 1.66f);
					
				case 4:
					return 230 + Mathf.Pow (GameData.level - 22, 1.66f);
					
				case 5:
					return 200 + Mathf.Pow (GameData.level - 22, 1.66f);
					
				default:
					return 200 + Mathf.Pow (GameData.level, 1.9f);
				}

			case 4:
				switch (index) {
				case 1:
					return 300 + Mathf.Pow (GameData.level - 36, 1.58f);
					
				case 2:
					return 290 + Mathf.Pow (GameData.level - 36, 1.58f);
					
				case 3:
					return 280 + Mathf.Pow (GameData.level - 36, 1.58f);
					
				case 4:
					return 250 + Mathf.Pow (GameData.level - 36, 1.58f);
					
				case 5:
					return 220 + Mathf.Pow (GameData.level - 36, 1.58f);
					
				default:
					return 200 + Mathf.Pow (GameData.level, 1.9f);
				}

			case 5:
				switch (index) {
				case 1:
					return 320 + Mathf.Pow (GameData.level - 52, 1.52f);
					
				case 2:
					return 310 + Mathf.Pow (GameData.level - 52, 1.52f);
					
				case 3:
					return 300 + Mathf.Pow (GameData.level - 52, 1.52f);
					
				case 4:
					return 270 + Mathf.Pow (GameData.level - 52, 1.52f);
					
				case 5:
					return 240 + Mathf.Pow (GameData.level - 52, 1.52f);
					
				default:
					return 200 + Mathf.Pow (GameData.level, 1.9f);
				}

			case 6:
				switch (index) {
				case 1:
					return 350 + Mathf.Pow (GameData.level - 70, 1.52f);
					
				case 2:
					return 340 + Mathf.Pow (GameData.level - 70, 1.52f);
					
				case 3:
					return 330 + Mathf.Pow (GameData.level - 70, 1.52f);
					
				case 4:
					return 300 + Mathf.Pow (GameData.level - 70, 1.52f);
					
				case 5:
					return 270 + Mathf.Pow (GameData.level - 70, 1.52f);
					
				default:
					return 200 + Mathf.Pow (GameData.level, 1.9f);
				}

			case 7:
				switch (index) {
				case 1:
					return 380 + Mathf.Pow (GameData.level - 88, 1.52f);
					
				case 2:
					return 370 + Mathf.Pow (GameData.level - 88, 1.52f);
					
				case 3:
					return 360 + Mathf.Pow (GameData.level - 88, 1.52f);
					
				case 4:
					return 330 + Mathf.Pow (GameData.level - 88, 1.52f);
					
				case 5:
					return 300 + Mathf.Pow (GameData.level - 88, 1.52f);
					
				default:
					return 200 + Mathf.Pow (GameData.level, 1.9f);
				}

			case 8:
				switch (index) {
				case 1:					
					return 420 + Mathf.Pow (GameData.level - 106, 1.42f);
					
				case 2:
					return 410 + Mathf.Pow (GameData.level - 106, 1.42f);
					
				case 3:
					return 400 + Mathf.Pow (GameData.level - 106, 1.42f);
					
				case 4:
					return 370 + Mathf.Pow (GameData.level - 106, 1.42f);
					
				case 5:
					return 340 + Mathf.Pow (GameData.level - 106, 1.42f);
					
				default:
					return 200 + Mathf.Pow (GameData.level, 1.9f);
				}

			default:
				return 200;
			}						
		}
	}
}