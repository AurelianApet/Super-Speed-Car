using UnityEngine;
using System.Collections;

public class RewardData
{
		static int reward;

		public static int getReward (int level, GameData.GAME_MODE gameMode, GameData.MAP_NAME mapName, int rank, bool isPreComleted)
		{
				reward = 0;
				int season = SeasonDescription.getSeason (level);

				if (season != 0) {
						reward = (int)((getRewardByMode (gameMode, rank) + getRewardByMap (mapName, rank)) * (1 + season * 0.2f));
				} else {
						reward = getRewardByMode (gameMode, rank) + getRewardByMap (mapName, rank);
				}

				if (isPreComleted == true) {
						reward = (int)(reward * 0.4f);
				}

				return reward;
		}

		static int getRewardByMode (GameData.GAME_MODE gameMode, int rank)
		{
				switch (gameMode) {
				case GameData.GAME_MODE.CLASSIC:
						switch (rank) {
						case 1:
								return 600;
					
						case 2:
								return 400;
					
						case 3:
								return 200;
					
						default:
								return 0;
						}				
				case GameData.GAME_MODE.TIME_TRIAL:
						switch (rank) {
						case 1:
								return 750;
					
						case 2:
								return 500;
					
						case 3:
								return 300;
					
						default:
								return 0;
						}						
				case GameData.GAME_MODE.CHECK_POINT:
						switch (rank) {
						case 1:
								return 650;
					
						case 2:
								return 450;
					
						case 3:
								return 250;
					
						default:
								return 0;
						}		
				case GameData.GAME_MODE.ELIMINATION:
						switch (rank) {
						case 1:
								return 850;
					
						case 2:
								return 550;
					
						case 3:
								return 350;
					
						default:
								return 0;
						}		
				default:
						return 0;
				}	
		}

		static int getRewardByMap (GameData.MAP_NAME mapName, int rank)
		{
				switch (mapName) {
				case GameData.MAP_NAME.EGYPT:
						switch (rank) {
						case 1:
								return 750;
					
						case 2:
								return 450;
					
						case 3:
								return 200;
					
						default:
								return 0;
						}		
				case GameData.MAP_NAME.INDIA:
						switch (rank) {
						case 1:
								return 800;
					
						case 2:
								return 550;
					
						case 3:
								return 350;
					
						default:
								return 0;
						}		

				case GameData.MAP_NAME.BRAZIL:
						switch (rank) {
						case 1:
								return 500;
					
						case 2:
								return 350;
					
						case 3:
								return 250;
					
						default:
								return 0;
						}		

				case GameData.MAP_NAME.CHINA:
						switch (rank) {
						case 1:
								return 750;
					
						case 2:
								return 400;
					
						case 3:
								return 200;
					
						default:
								return 0;
						}		

				case GameData.MAP_NAME.VIET_NAM:
						switch (rank) {
						case 1:
								return 750;
					
						case 2:
								return 450;
					
						case 3:
								return 200;
					
						default:
								return 0;
						}		

				case GameData.MAP_NAME.PHILIPPINES:
						switch (rank) {
						case 1:
								return 750;
					
						case 2:
								return 400;
					
						case 3:
								return 200;
					
						default:
								return 0;
						}		

				case GameData.MAP_NAME.THAILAND:
						switch (rank) {
						case 1:
								return 850;
					
						case 2:
								return 550;
					
						case 3:
								return 350;
					
						default:
								return 0;
						}		

				case GameData.MAP_NAME.USA:
						switch (rank) {
						case 1:
								return 750;
					
						case 2:
								return 450;
					
						case 3:
								return 200;
					
						default:
								return 0;
						}		

				default:
						return 0;
				}
		}

		public static int getTitleLevel (int score)
		{
				if (score < 20000) {
						return 20000;
			
				} else if (score < 50000) {
						return 50000;
			
				} else if (score < 200000) {
						return 200000;
			
				} else if (score < 400000) {
						return 400000;
			
				} else if (score < 700000) {
						return 700000;
			
				} else if (score < 2000000) {
						return 2000000;
			
				} else if (score < 5000000) {
						return 5000000;
			
				} else if (score < 9000000) {
						return 9000000;
			
				} else if (score < 16000000) {
						return 16000000;
			
				} else {
						return 9;
				}
		}

		public static int getTitleID (int score)
		{
				if (score < 20000) {
						return 0;

				} else if (score < 50000) {
						return 1;

				} else if (score < 200000) {
						return 2;

				} else if (score < 400000) {
						return 3;

				} else if (score < 700000) {
						return 4;

				} else if (score < 2000000) {
						return 5;

				} else if (score < 5000000) {
						return 6;

				} else if (score < 9000000) {
						return 7;

				} else if (score < 16000000) {
						return 8;

				} else {
						return 9;
				}
		}

		public static string getTitleText (int id)
		{
				switch (id) {
				case 0:
						return "Beginner";

				case 1:
						return "Amateur";

				case 2:
						return "Mechanic";

				case 3:
						return "Professional";

				case 4:
						return "Bad boy";

				case 5:
						return "Dare devil";

				case 6:
						return "Master";

				case 7:
						return "Grand master";

				case 8:
						return "King";

				case 9:
						return "Overlord";

				default:
						return "Beginner";
				}
		}

		public static float getTitleProgress (int score)
		{
				if (score < 20000) {
						return score / 20000f;
			
				} else if (score < 50000) {
						return score / 50000f;
			
				} else if (score < 200000) {
						return score / 200000f;
			
				} else if (score < 400000) {
						return score / 400000f;
			
				} else if (score < 700000) {
						return score / 700000f;
			
				} else if (score < 2000000) {
						return score / 2000000f;
			
				} else if (score < 5000000) {
						return score / 5000000f;
			
				} else if (score < 9000000) {
						return score / 9000000f;
			
				} else if (score < 16000000) {
						return score / 16000000f;
			
				} else {
						return 1;
				}
		}

		public static int getAchievementReward (GameData.ACHIEVEMENT_TYPE achievementType, int id)
		{
				switch (achievementType) {
				case GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT:
						switch (id) {
						case 0:
								return 1000;

						case 1:
								return 1500;

						case 2:
								return 5000;

						case 3:
								return 6000;

						case 4:
								return 300;

						case 5:
								return 500;

						case 6:
								return 2000;

						case 7:
								return 5000;

						case 8:
								return 6500;

						case 9:
								return 8000;

						default:
								return 0;
						}

				case GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT:
						switch (id) {
						case 0:
								return 550;
				
						case 1:
								return 700;
				
						case 2:
								return 1000;
				
						case 3:
								return 3000;
				
						case 4:
								return 5000;
				
						case 5:
								return 6000;
				
						case 6:
								return 8000;
				
						case 7:
								return 10000;
				
						case 8:
								return 12000;
				
						case 9:
								return 14000;

						case 10:
								return 16000;

						case 11:
								return 20000;

						case 12:
								return 40000;
				
						default:
								return 0;
						}

				case GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT:
						switch (id) {
						case 0:
								return 250;
				
						case 1:
								return 300;
				
						case 2:
								return 400;
				
						case 3:
								return 350;
				
						case 4:
								return 400;
				
						case 5:
								return 450;
				
						case 6:
								return 250;
				
						case 7:
								return 300;
				
						case 8:
								return 350;
				
						case 9:
								return 250;
				
						case 10:
								return 300;
				
						case 11:
								return 350;
				
						case 12:
								return 400;
				
						case 13:
								return 150;

						case 14:
								return 200;
				
						case 15:
								return 250;
				
						case 16:
								return 300;
				
						default:
								return 0;
						}

				case GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT:
						switch (id) {
						case 0:
								return 100;
				
						case 1:
								return 150;
				
						case 2:
								return 200;
				
						case 3:
								return 300;
				
						case 4:
								return 400;
				
						case 5:
								return 550;
				
						case 6:
								return 750;
				
						case 7:
								return 950;
				
						case 8:
								return 1050;
				
						case 9:
								return 1200;
				
						case 10:
								return 1550;
				
						case 11:
								return 2000;
				
						case 12:
								return 2550;
				
						case 13:
								return 6550;

						case 14:
								return 7000;
				
						case 15:
								return 7250;
				
						default:
								return 0;
						}

				default:
						return 0;
				}
		}
}