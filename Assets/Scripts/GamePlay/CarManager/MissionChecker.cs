using UnityEngine;
using System.Collections;

public class MissionChecker
{
		public static void checkMission (Game game)
		{
				GameData.FirstMission = false;
				GameData.SecondMission = false;

				int map = GameData.level + 1;
				switch (map) {
				case 1:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}

						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 2) {
								GameData.SecondMission = true;
						}
						break;

				case 2:
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 1.2f) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 2) {
								GameData.SecondMission = true;
						}
						break;

				case 3:
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 3) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 250) {
								GameData.SecondMission = true;
						}
						break;

				case 4:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 3) {
								GameData.SecondMission = true;
						}
						break;

				case 5:
						if (game.carManager.MainPlayer.carData.TotalNitroUsingDuration >= 25) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 1.5f) {
								GameData.SecondMission = true;
						}
						break;

				case 6:
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 250) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 3) {
								GameData.SecondMission = true;
						}
						break;
			
				case 7:
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 2) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 5) {
								GameData.SecondMission = true;
						}
						break;
			
				case 8:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 3) {
								GameData.SecondMission = true;
						}
						break;
			
				case 9:
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 2) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 250) {
								GameData.SecondMission = true;
						}
						break;
			
				case 10:
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 2) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 3) {
								GameData.SecondMission = true;
						}
						break;
				//--------------------------------------------------------------------------------				
				case 11:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 3) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isPoliceCaught == false) {
								GameData.SecondMission = true;
						}
						break;
			
				case 12:
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 2) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 3) {
								GameData.SecondMission = true;
						}
						break;
			
				case 13:
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 8) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNitroUsingDuration >= 30) {
								GameData.SecondMission = true;
						}
						break;
			
				case 14:
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 7) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 3) {
								GameData.SecondMission = true;
						}
						break;
			
				case 15:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 2) {
								GameData.SecondMission = true;
						}
						break;
			
				case 16:
						if (GameData.isGoShortCut == false) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 5) {
								GameData.SecondMission = true;
						}
						break;
			
				case 17:
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 300) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 18:
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 2) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f >= 200) {
								GameData.SecondMission = true;
						}
						break;
			
				case 19:
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 3) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 20:
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 3) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isUseNitro == false) {
								GameData.SecondMission = true;
						}
						break;

				case 21:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 4) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f >= 220) {
								GameData.SecondMission = true;
						}
						break;
			
				case 22:
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 4) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 8) {
								GameData.SecondMission = true;
						}
						break;
				//--------------------------------------------------------------------------------				
				case 23:
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 3) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 24:
						if (GameData.maxVelocityLimit * 3.6f >= 280) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 2) {
								GameData.SecondMission = true;
						}
						break;
			
				case 25:
						if (GameData.isPoliceCaught == false) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 26:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 4) {
								GameData.SecondMission = true;
						}
						break;
			
				case 27:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 6) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 4) {
								GameData.SecondMission = true;
						}
						break;
			
				case 28:
						if (GameData.isGoShortCut == false) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 3) {
								GameData.SecondMission = true;
						}
						break;
			
				case 29:
						if (GameData.maxVelocityLimit * 3.6f >= 280) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 10) {
								GameData.SecondMission = true;
						}
						break;
			
				case 30:
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 15) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 4) {
								GameData.SecondMission = true;
						}
						break;

				case 31:
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 450) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 3) {
								GameData.SecondMission = true;
						}
						break;
			
				case 32:
						if (GameData.isPoliceCaught == false) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 33:
						if (GameData.isUseNitro == false) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 500) {
								GameData.SecondMission = true;
						}
						break;
			
				case 34:
						if (GameData.maxVelocityLimit * 3.6f >= 250) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isUseNitro == false) {
								GameData.SecondMission = true;
						}
						break;
			
				case 35:
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 3) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 5) {
								GameData.SecondMission = true;
						}
						break;
			
				case 36:
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 4) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 5) {
								GameData.SecondMission = true;
						}
						break;
				//--------------------------------------------------------------------------------				
				case 37:
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 5) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == false) {
								GameData.SecondMission = true;
						}
						break;
			
				case 38:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 7) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 4) {
								GameData.SecondMission = true;
						}
						break;
			
				case 39:
						if (game.carManager.MainPlayer.carData.TotalNitroUsingDuration >= 35) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 3) {
								GameData.SecondMission = true;
						}
						break;
			
				case 40:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 4) {
								GameData.SecondMission = true;
						}
						break;

				case 41:
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 2) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f >= 280) {
								GameData.SecondMission = true;
						}
						break;
			
				case 42:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 4) {
								GameData.SecondMission = true;
						}
						break;
			
				case 43:
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 5) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 10) {
								GameData.SecondMission = true;
						}
						break;
			
				case 44:
						if (GameData.isPoliceCaught == false) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f >= 300) {
								GameData.SecondMission = true;
						}
						break;
			
				case 45:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 6) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 46:
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 3) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 6) {
								GameData.SecondMission = true;
						}
						break;
			
				case 47:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 5) {
								GameData.SecondMission = true;
						}
						break;
			
				case 48:
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 5) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 15) {
								GameData.SecondMission = true;
						}
						break;
			
				case 49:
						if (GameData.isPoliceCaught == false) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 50:
						if (game.carManager.MainPlayer.carData.TotalNitroUsingDuration >= 35) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f >= 300) {
								GameData.SecondMission = true;
						}
						break;

				case 51:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 6) {
								GameData.SecondMission = true;
						}
						break;
			
				case 52:
						if (game.carManager.MainPlayer.carData.TotalFlyTime > 5) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f >= 280) {
								GameData.SecondMission = true;
						}
						break;
				//--------------------------------------------------------------------------------				
				case 53:
						if (GameData.maxVelocityLimit * 3.6f >= 320) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 6) {
								GameData.SecondMission = true;
						}
						break;
			
				case 54:
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 15) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 55:
						if (GameData.maxVelocityLimit * 3.6f > 340) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 6) {
								GameData.SecondMission = true;
						}
						break;
			
				case 56:
						if (GameData.isGoShortCut == false) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 7) {
								GameData.SecondMission = true;
						}
						break;
			
				case 57:
						if (GameData.isUseNitro == false) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f >= 350) {
								GameData.SecondMission = true;
						}
						break;
			
				case 58:
						if (game.carManager.MainPlayer.carData.TotalNitroUsingDuration >= 35) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 500) {
								GameData.SecondMission = true;
						}
						break;
			
				case 59:
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 7) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 17) {
								GameData.SecondMission = true;
						}
						break;
			
				case 60:
						if (GameData.isPoliceCaught == false) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;

				case 61:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 6) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isUseNitro == false) {
								GameData.SecondMission = true;
						}
						break;
			
				case 62:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 7) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f >= 350) {
								GameData.SecondMission = true;
						}
						break;
			
				case 63:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 500) {
								GameData.SecondMission = true;
						}
						break;
			
				case 64:
						if (GameData.isUseNitro == false) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 18) {
								GameData.SecondMission = true;
						}
						break;
			
				case 65:
						if (GameData.isPoliceCaught == false) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 66:
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 7) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f > 360) {
								GameData.SecondMission = true;
						}
						break;
			
				case 67:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isPoliceCaught == false) {
								GameData.SecondMission = true;
						}
						break;
			
				case 68:
						if (game.carManager.MainPlayer.carData.TotalNitroUsingDuration >= 37) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 3) {
								GameData.SecondMission = true;
						}
						break;
			
				case 69:
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 5) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f > 380) {
								GameData.SecondMission = true;
						}
						break;
			
				case 70:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 8) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
				//--------------------------------------------------------------------------------				
				case 71:
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 20) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f >= 380) {
								GameData.SecondMission = true;
						}
						break;
			
				case 72:
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 8) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 4) {
								GameData.SecondMission = true;
						}
						break;
			
				case 73:
						if (GameData.isPoliceCaught == false) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 74:
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 7) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 3) {
								GameData.SecondMission = true;
						}
						break;
			
				case 75:
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 8) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f > 400) {
								GameData.SecondMission = true;
						}
						break;
			
				case 76:
						if (game.carManager.MainPlayer.carData.TotalNitroUsingDuration >= 38) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 8) {
								GameData.SecondMission = true;
						}
						break;
			
				case 77:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 8) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f > 400) {
								GameData.SecondMission = true;
						}
						break;
			
				case 78:
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 15) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f > 420) {
								GameData.SecondMission = true;
						}
						break;
			
				case 79:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 8) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 80:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 550) {
								GameData.SecondMission = true;
						}
						break;

				case 81:
						if (GameData.maxVelocityLimit * 3.6f > 420) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 82:
						if (GameData.isPoliceCaught == false) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isUseNitro == false) {
								GameData.SecondMission = true;
						}
						break;
			
				case 83:
						if (GameData.isUseNitro == false) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 18) {
								GameData.SecondMission = true;
						}
						break;
			
				case 84:
						if (GameData.maxVelocityLimit * 3.6f > 430) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 10) {
								GameData.SecondMission = true;
						}
						break;
			
				case 85:
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 600) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isPoliceCaught == false) {
								GameData.SecondMission = true;
						}
						break;
			
				case 86:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 8) {
								GameData.SecondMission = true;
						}
						break;
			
				case 87:
						if (game.carManager.MainPlayer.carData.TotalNitroUsingDuration >= 40) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 88:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 8) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isPoliceCaught == false) {
								GameData.SecondMission = true;
						}
						break;
				//--------------------------------------------------------------------------------				
				case 89:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isUseNitro == false) {
								GameData.SecondMission = true;
						}
						break;
			
				case 90:
						if (GameData.maxVelocityLimit * 3.6f > 420) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 7) {
								GameData.SecondMission = true;
						}
						break;

				case 91:
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 20) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 92:
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 10) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f >= 420) {
								GameData.SecondMission = true;
						}
						break;
			
				case 93:
						if (GameData.isUseNitro == false) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 20) {
								GameData.SecondMission = true;
						}
						break;
			
				case 94:
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 10) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 650) {
								GameData.SecondMission = true;
						}
						break;
			
				case 95:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 8) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 96:
						if (GameData.isPoliceCaught == false) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f > 420) {
								GameData.SecondMission = true;
						}
						break;
			
				case 97:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f > 400) {
								GameData.SecondMission = true;
						}
						break;
			
				case 98:
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 12) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 800) {
								GameData.SecondMission = true;
						}
						break;
			
				case 99:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 6) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 100:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 4) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f > 450) {
								GameData.SecondMission = true;
						}
						break;

				case 101:
						if (GameData.maxVelocityLimit * 3.6f > 440) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 700) {
								GameData.SecondMission = true;
						}
						break;
			
				case 102:
						if (game.carManager.MainPlayer.carData.TotalNitroUsingDuration >= 20) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 103:
						if (GameData.isPoliceCaught == false) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 9) {
								GameData.SecondMission = true;
						}
						break;
			
				case 104:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f >= 440) {
								GameData.SecondMission = true;
						}
						break;
			
				case 105:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 8) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 800) {
								GameData.SecondMission = true;
						}
						break;
			
				case 106:
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 20) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isUseNitro == false) {
								GameData.SecondMission = true;
						}
						break;
				//--------------------------------------------------------------------------------				
				case 107:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f > 440) {
								GameData.SecondMission = true;
						}
						break;
			
				case 108:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 8) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 750) {
								GameData.SecondMission = true;
						}
						break;
			
				case 109:
						if (GameData.maxVelocityLimit * 3.6f > 450) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalObstacleCollision >= 10) {
								GameData.SecondMission = true;
						}
						break;
			
				case 110:
						if (game.carManager.MainPlayer.carData.TotalNitroUsingDuration >= 35) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;

				case 111:
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 20) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f > 440) {
								GameData.SecondMission = true;
						}
						break;
			
				case 112:
						if (GameData.isPoliceCaught == false) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 113:
						if (GameData.maxVelocityLimit * 3.6f >= 450) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == false) {
								GameData.SecondMission = true;
						}
						break;
			
				case 114:
						if (GameData.isPoliceCaught == false) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 6) {
								GameData.SecondMission = true;
						}
						break;
			
				case 115:
						if (game.carManager.MainPlayer.carData.TotalDriftTime >= 20) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 116:
						if (GameData.isGoShortCut == false) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalDollarEarned >= 700) {
								GameData.SecondMission = true;
						}
						break;
			
				case 117:
						if (game.carManager.MainPlayer.carData.TotalFlyTime >= 2) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f > 380) {
								GameData.SecondMission = true;
						}
						break;
			
				case 118:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 10) {
								GameData.FirstMission = true;
						}
			
						if (GameData.maxVelocityLimit * 3.6f > 450) {
								GameData.SecondMission = true;
						}
						break;
			
				case 119:
						if (GameData.isPoliceCaught == false) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;
			
				case 120:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 7) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;

				case 121:
						if (GameData.maxVelocityLimit * 3.6f > 460) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isPoliceCaught == false) {
								GameData.SecondMission = true;
						}
						break;
			
				case 122:
						if (GameData.isGoShortCut == true) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 7) {
								GameData.SecondMission = true;
						}
						break;
			
				case 123:
						if (GameData.isPoliceCaught == false) {
								GameData.FirstMission = true;
						}
			
						if (game.carManager.MainPlayer.carData.TotalNitroUsingDuration >= 40) {
								GameData.SecondMission = true;
						}
						break;
			
				case 124:
						if (game.carManager.MainPlayer.carData.TotalNumberNitroEarned >= 6) {
								GameData.FirstMission = true;
						}
			
						if (GameData.isGoShortCut == true) {
								GameData.SecondMission = true;
						}
						break;

				default:
						break;
				}
		}
}