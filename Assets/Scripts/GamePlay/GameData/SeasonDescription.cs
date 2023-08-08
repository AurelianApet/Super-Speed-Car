using UnityEngine;
using System.Collections;

public class SeasonDescription
{
		public static int getSeason (int level)
		{
				if (level == -1) {
						return 0;
			
				} else {
						if (level >= 1 && level <= 10) {
								return 1;
				
						} else if (level >= 11 && level <= 22) {
								return 2;
				
						} else if (level >= 23 && level <= 36) {
								return 3;
				
						} else if (level >= 37 && level <= 52) {
								return 4;
				
						} else if (level >= 53 && level <= 70) {
								return 5;
				
						} else if (level >= 71 && level <= 88) {
								return 6;
				
						} else if (level >= 89 && level <= 106) {
								return 7;
				
						} else if (level >= 107 && level <= 124) {
								return 8;
				
						} else {
								return 1;
						}
				}
		}

		public static int getNumberLevelBySeason (int season)
		{
				switch (season) {
				case 1:
						return 10;
			
				case 2:
						return 12;
			
				case 3:
						return 14;
			
				case 4:
						return 16;
			
				case 5:
						return 18;
			
				case 6:
						return 18;
			
				case 7:
						return 18;
			
				case 8:
						return 18;
			
				default:
						return 10;
				}		
		}

		public static int getNumberLevelBySeasonAccumulate (int season)
		{
				switch (season) {
				case 1:
						return 10;
			
				case 2:
						return 22;
			
				case 3:
						return 36;
			
				case 4:
						return 52;
			
				case 5:
						return 70;
			
				case 6:
						return 88;
			
				case 7:
						return 106;
			
				case 8:
						return 124;
			
				default:
						return 10;
				}		
		}
	
		public static int getFirstLevelInSeason (int season)
		{
				switch (season) {
				case 1:
						return 0;
			
				case 2:
						return 10;
			
				case 3:
						return 22;
			
				case 4:
						return 36;
			
				case 5:
						return 52;
			
				case 6:
						return 70;
			
				case 7:
						return 88;
			
				case 8:
						return 106;
			
				default:
						return 1;
				}		
		}
	
		public static int getNumberStarsToUnlock (int season)
		{
				switch (season) {
				case 1:
						return 0;
			
				case 2:
						return 30;
			
				case 3:
						return 70;
			
				case 4:
						return 120;
			
				case 5:
						return 210;
			
				case 6:
						return 300;
			
				case 7:
						return 400;
			
				case 8:
						return 500;
			
				default:
						return 0;
				}
		}
}