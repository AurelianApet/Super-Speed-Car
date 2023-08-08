using UnityEngine;
using System.Collections;

public class AllCarDescription
{
	public static float getCarSpeed (GameData.CAR_NAME carName, int upgradeLevel)
	{
		switch (carName) {
		case GameData.CAR_NAME.ASTON_MARTIN_DB9:
			switch (upgradeLevel) {
			case 0:				
				return 250;
			case 1:
				return 255;
			case 2:
				return 260;
			case 3:
				return 270;
			case 4:
				return 280;
			default:
				return 200;
			}
			
		case GameData.CAR_NAME.AUDI_R8:
			switch (upgradeLevel) {
			case 0:				
				return 265;
			case 1:
				return 270;
			case 2:
				return 280;
			case 3:
				return 290;
			case 4:
				return 305;
			default:
				return 200;
			}
			
		case GameData.CAR_NAME.BMW_i8:
			switch (upgradeLevel) {
			case 0:				
				return 255;
			case 1:
				return 260;
			case 2:
				return 270;
			case 3:
				return 280;
			case 4:
				return 290;
			default:
				return 200;
			}
			
		case GameData.CAR_NAME.BUGATTI_VEYRON:
			switch (upgradeLevel) {
			case 0:				
				return 380;
			case 1:
				return 390;
			case 2:
				return 400;
			case 3:
				return 410;
			case 4:
				return 420;
			default:
				return 200;
			}
			
		case GameData.CAR_NAME.FERRARI_458_ITALIA:
			switch (upgradeLevel) {
			case 0:				
				return 285;
			case 1:
				return 296;
			case 2:
				return 309;
			case 3:
				return 320;
			case 4:
				return 333;
			default:
				return 200;
			}
			
		case GameData.CAR_NAME.FERRARI_FXX:
			switch (upgradeLevel) {
			case 0:				
				return 320;
			case 1:
				return 330;
			case 2:
				return 340;
			case 3:
				return 350;
			case 4:
				return 365;
			default:
				return 200;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_LP560:
			switch (upgradeLevel) {
			case 0:				
				return 290;
			case 1:				
				return 305;
			case 2:
				return 320;
			case 3:
				return 338;
			case 4:
				return 360;
			default:
				return 200;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO:
			switch (upgradeLevel) {
			case 0:				
				return 290;
			case 1:
				return 300;
			case 2:
				return 316;
			case 3:
				return 330;
			case 4:
				return 350;
			default:
				return 200;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_VENENO:
			switch (upgradeLevel) {
			case 0:				
				return 330;
			case 1:
				return 340;
			case 2:
				return 355;
			case 3:
				return 370;
			case 4:
				return 385;
			default:
				return 200;
			}
			
		case GameData.CAR_NAME.MARUSSIA_B2:
			switch (upgradeLevel) {
			case 0:				
				return 270;
			case 1:
				return 280;
			case 2:
				return 291;
			case 3:
				return 315;
			case 4:
				return 327;
			default:
				return 200;
			}
			
		case GameData.CAR_NAME.MASERATI_GRAN_TURISMO:
			switch (upgradeLevel) {
			case 0:				
				return 270;
			case 1:
				return 280;
			case 2:
				return 291;
			case 3:
				return 315;
			case 4:
				return 327;
			default:
				return 200;
			}
			
		case GameData.CAR_NAME.MERCEDES_BENZ_SLS:
			switch (upgradeLevel) {
			case 0:				
				return 280;
			case 1:
				return 290;
			case 2:
				return 311;
			case 3:
				return 322;
			case 4:
				return 335;
			default:
				return 200;
			}
			
		case GameData.CAR_NAME.PAGANI_ZONDA:
			switch (upgradeLevel) {
			case 0:				
				return 350;
			case 1:
				return 360;
			case 2:
				return 370;
			case 3:
				return 385;
			case 4:
				return 400;
			default:
				return 200;
			}
			
		case GameData.CAR_NAME.POLICE:
			switch (upgradeLevel) {
			case 0:				
				return 300;
			case 1:
				return 310;
			case 2:
				return 320;
			case 3:
				return 335;
			case 4:
				return 350;
			default:
				return 200;
			}
			
		case GameData.CAR_NAME.PORSCHE_911:
			switch (upgradeLevel) {
			case 0:				
				return 285;
			case 1:
				return 300;
			case 2:
				return 311;
			case 3:
				return 328;
			case 4:
				return 340;
			default:
				return 200;
			}
			
		default:
			return 200;
		}
	}
	
	public static float getCarAcceleration (GameData.CAR_NAME carName, int upgradeLevel)
	{
		switch (carName) {
		case GameData.CAR_NAME.ASTON_MARTIN_DB9:
			switch (upgradeLevel) {
			case 0:				
				return 0.85f;
			case 1:
				return 0.9f;
			case 2:
				return 0.95f;
			case 3:
				return 1f;
			case 4:
				return 1.05f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.AUDI_R8:
			switch (upgradeLevel) {
			case 0:				
				return 1f;
			case 1:
				return 1.05f;
			case 2:
				return 1.1f;
			case 3:
				return 1.15f;
			case 4:
				return 1.2f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.BMW_i8:
			switch (upgradeLevel) {
			case 0:				
				return 0.9f;
			case 1:
				return 0.95f;
			case 2:
				return 1f;
			case 3:
				return 1.05f;
			case 4:
				return 1.1f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.BUGATTI_VEYRON:
			switch (upgradeLevel) {
			case 0:				
				return 1f;
			case 1:
				return 1.1f;
			case 2:
				return 1.2f;
			case 3:
				return 1.3f;
			case 4:
				return 1.4f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.FERRARI_458_ITALIA:
			switch (upgradeLevel) {
			case 0:				
				return 0.9f;
			case 1:
				return 0.95f;
			case 2:
				return 1f;
			case 3:
				return 1.1f;
			case 4:
				return 1.2f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.FERRARI_FXX:
			switch (upgradeLevel) {
			case 0:				
				return 1;
			case 1:
				return 1.2f;
			case 2:
				return 1.4f;
			case 3:
				return 1.6f;
			case 4:
				return 1.7f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_LP560:
			switch (upgradeLevel) {
			case 0:				
				return 1;
			case 1:
				return 1.1f;
			case 2:
				return 1.2f;
			case 3:
				return 1.3f;
			case 4:
				return 1.4f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO:
			switch (upgradeLevel) {
			case 0:				
				return 0.9f;
			case 1:
				return 0.95f;
			case 2:
				return 1;
			case 3:
				return 1.1f;
			case 4:
				return 1.2f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_VENENO:
			switch (upgradeLevel) {
			case 0:				
				return 1.2f;
			case 1:
				return 1.3f;
			case 2:
				return 1.4f;
			case 3:
				return 1.5f;
			case 4:
				return 1.6f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.MARUSSIA_B2:
			switch (upgradeLevel) {
			case 0:				
				return 0.9f;
			case 1:
				return 1;
			case 2:
				return 1.1f;
			case 3:
				return 1.15f;
			case 4:
				return 1.2f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.MASERATI_GRAN_TURISMO:
			switch (upgradeLevel) {
			case 0:				
				return 0.9f;
			case 1:
				return 0.95f;
			case 2:
				return 1;
			case 3:
				return 1.1f;
			case 4:
				return 1.15f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.MERCEDES_BENZ_SLS:
			switch (upgradeLevel) {
			case 0:				
				return 0.9f;
			case 1:
				return 1f;
			case 2:
				return 1.1f;
			case 3:
				return 1.2f;
			case 4:
				return 1.3f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.PAGANI_ZONDA:
			switch (upgradeLevel) {
			case 0:				
				return 1.3f;
			case 1:
				return 1.4f;
			case 2:
				return 1.5f;
			case 3:
				return 1.6f;
			case 4:
				return 1.7f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.POLICE:
			switch (upgradeLevel) {
			case 0:				
				return 1;
			case 1:
				return 1.1f;
			case 2:
				return 1.2f;
			case 3:
				return 1.3f;
			case 4:
				return 1.4f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.PORSCHE_911:
			switch (upgradeLevel) {
			case 0:				
				return 0.9f;
			case 1:
				return 1;
			case 2:
				return 1.1f;
			case 3:
				return 1.2f;
			case 4:
				return 1.3f;
			default:
				return 1;
			}
			
		default:
			return 1;
		}
	}
	
	public static float getCarHandling (GameData.CAR_NAME carName, int upgradeLevel)
	{
		switch (carName) {
		case GameData.CAR_NAME.ASTON_MARTIN_DB9:
			switch (upgradeLevel) {
			case 0:				
				return 0.7f;
			case 1:
				return 0.75f;
			case 2:
				return 0.8f;
			case 3:
				return 0.85f;
			case 4:
				return 0.9f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.AUDI_R8:
			switch (upgradeLevel) {
			case 0:				
				return 0.7f;
			case 1:
				return 0.8f;
			case 2:
				return 0.85f;
			case 3:
				return 0.9f;
			case 4:
				return 0.95f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.BMW_i8:
			switch (upgradeLevel) {
			case 0:				
				return 0.72f;
			case 1:
				return 0.77f;
			case 2:
				return 0.82f;
			case 3:
				return 0.87f;
			case 4:
				return 0.92f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.BUGATTI_VEYRON:
			switch (upgradeLevel) {
			case 0:				
				return 0.5f;
			case 1:
				return 0.6f;
			case 2:
				return 0.65f;
			case 3:
				return 0.7f;
			case 4:
				return 0.75f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.FERRARI_458_ITALIA:
			switch (upgradeLevel) {
			case 0:				
				return 0.77f;
			case 1:
				return 0.82f;
			case 2:
				return 0.87f;
			case 3:
				return 0.92f;
			case 4:
				return 0.97f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.FERRARI_FXX:
			switch (upgradeLevel) {
			case 0:				
				return 0.8f;
			case 1:
				return 0.85f;
			case 2:
				return 0.9f;
			case 3:
				return 0.95f;
			case 4:
				return 1;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_LP560:
			switch (upgradeLevel) {
			case 0:				
				return 0.74f;
			case 1:
				return 0.79f;
			case 2:
				return 0.84f;
			case 3:
				return 0.89f;
			case 4:
				return 0.94f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO:
			switch (upgradeLevel) {
			case 0:				
				return 0.7f;
			case 1:
				return 0.75f;
			case 2:
				return 0.8f;
			case 3:
				return 0.85f;
			case 4:
				return 0.9f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_VENENO:
			switch (upgradeLevel) {
			case 0:				
				return 0.6f;
			case 1:
				return 0.65f;
			case 2:
				return 0.7f;
			case 3:
				return 0.75f;
			case 4:
				return 0.8f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.MARUSSIA_B2:
			switch (upgradeLevel) {
			case 0:				
				return 0.71f;
			case 1:
				return 0.76f;
			case 2:
				return 0.81f;
			case 3:
				return 0.86f;
			case 4:
				return 0.91f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.MASERATI_GRAN_TURISMO:
			switch (upgradeLevel) {
			case 0:				
				return 0.71f;
			case 1:
				return 0.76f;
			case 2:
				return 0.81f;
			case 3:
				return 0.86f;
			case 4:
				return 0.91f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.MERCEDES_BENZ_SLS:
			switch (upgradeLevel) {
			case 0:				
				return 0.73f;
			case 1:
				return 0.78f;
			case 2:
				return 0.83f;
			case 3:
				return 0.88f;
			case 4:
				return 0.93f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.PAGANI_ZONDA:
			switch (upgradeLevel) {
			case 0:				
				return 0.8f;
			case 1:
				return 0.85f;
			case 2:
				return 0.9f;
			case 3:
				return 0.95f;
			case 4:
				return 1;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.POLICE:
			switch (upgradeLevel) {
			case 0:				
				return 0.77f;
			case 1:
				return 0.82f;
			case 2:
				return 0.87f;
			case 3:
				return 0.92f;
			case 4:
				return 0.97f;
			default:
				return 1;
			}
			
		case GameData.CAR_NAME.PORSCHE_911:
			switch (upgradeLevel) {
			case 0:				
				return 0.75f;
			case 1:
				return 0.8f;
			case 2:
				return 0.85f;
			case 3:
				return 0.9f;
			case 4:
				return 0.95f;
			default:
				return 1;
			}
			
		default:
			return 1;
		}
	}
	
	public static float getCarNitro (GameData.CAR_NAME carName, int upgradeLevel)
	{
		switch (carName) {
		case GameData.CAR_NAME.ASTON_MARTIN_DB9:
			switch (upgradeLevel) {
			case 0:				
				return 5;
			case 1:
				return 6;
			case 2:
				return 7;
			case 3:
				return 8;
			case 4:
				return 9;
			default:
				return 10;
			}
			
		case GameData.CAR_NAME.AUDI_R8:
			switch (upgradeLevel) {
			case 0:				
				return 6;
			case 1:
				return 7;
			case 2:
				return 8;
			case 3:
				return 9;
			case 4:
				return 10;
			default:
				return 10;
			}
			
		case GameData.CAR_NAME.BMW_i8:
			switch (upgradeLevel) {
			case 0:				
				return 5;
			case 1:
				return 6;
			case 2:
				return 7;
			case 3:
				return 8;
			case 4:
				return 9;
			default:
				return 10;
			}
			
		case GameData.CAR_NAME.BUGATTI_VEYRON:
			switch (upgradeLevel) {
			case 0:				
				return 10;
			case 1:
				return 11;
			case 2:
				return 13;
			case 3:
				return 14;
			case 4:
				return 15;
			default:
				return 10;
			}
			
		case GameData.CAR_NAME.FERRARI_458_ITALIA:
			switch (upgradeLevel) {
			case 0:				
				return 7;
			case 1:
				return 8;
			case 2:
				return 9;
			case 3:
				return 10;
			case 4:
				return 11;
			default:
				return 10;
			}
			
		case GameData.CAR_NAME.FERRARI_FXX:
			switch (upgradeLevel) {
			case 0:				
				return 10;
			case 1:
				return 11;
			case 2:
				return 12;
			case 3:
				return 13;
			case 4:
				return 14;
			default:
				return 10;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_LP560:
			switch (upgradeLevel) {
			case 0:				
				return 9;
			case 1:
				return 10;
			case 2:
				return 11;
			case 3:
				return 12;
			case 4:
				return 13;
			default:
				return 10;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO:
			switch (upgradeLevel) {
			case 0:				
				return 9;
			case 1:
				return 10;
			case 2:
				return 11;
			case 3:
				return 12;
			case 4:
				return 13;
			default:
				return 10;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_VENENO:
			switch (upgradeLevel) {
			case 0:				
				return 10;
			case 1:
				return 11;
			case 2:
				return 12;
			case 3:
				return 13;
			case 4:
				return 15;
			default:
				return 10;
			}
			
		case GameData.CAR_NAME.MARUSSIA_B2:
			switch (upgradeLevel) {
			case 0:				
				return 7;
			case 1:
				return 8;
			case 2:
				return 9;
			case 3:
				return 10;
			case 4:
				return 11;
			default:
				return 10;
			}
			
		case GameData.CAR_NAME.MASERATI_GRAN_TURISMO:
			switch (upgradeLevel) {
			case 0:				
				return 6;
			case 1:
				return 7;
			case 2:
				return 8;
			case 3:
				return 9;
			case 4:
				return 10;
			default:
				return 10;
			}
			
		case GameData.CAR_NAME.MERCEDES_BENZ_SLS:
			switch (upgradeLevel) {
			case 0:				
				return 8;
			case 1:
				return 9;
			case 2:
				return 10;
			case 3:
				return 11;
			case 4:
				return 12;
			default:
				return 10;
			}
			
		case GameData.CAR_NAME.PAGANI_ZONDA:
			switch (upgradeLevel) {
			case 0:				
				return 11;
			case 1:
				return 12;
			case 2:
				return 13;
			case 3:
				return 14;
			case 4:
				return 15;
			default:
				return 10;
			}
			
		case GameData.CAR_NAME.POLICE:
			switch (upgradeLevel) {
			case 0:				
				return 9;
			case 1:
				return 10;
			case 2:
				return 11;
			case 3:
				return 12;
			case 4:
				return 13;
			default:
				return 10;
			}
			
		case GameData.CAR_NAME.PORSCHE_911:
			switch (upgradeLevel) {
			case 0:				
				return 8;
			case 1:
				return 9;
			case 2:
				return 10;
			case 3:
				return 11;
			case 4:
				return 12;
			default:
				return 10;
			}
			
		default:
			return 10;
		}
	}
	
	public static float getCarPrice (GameData.CAR_NAME carName)
	{
		switch (carName) {
		case GameData.CAR_NAME.ASTON_MARTIN_DB9:
			return 0;//Free
			
		case GameData.CAR_NAME.AUDI_R8:
			return 15;//Cash
			
		case GameData.CAR_NAME.BMW_i8:
			return 40550;// Coin
			
		case GameData.CAR_NAME.BUGATTI_VEYRON:
			return 800;// cash
			
		case GameData.CAR_NAME.FERRARI_458_ITALIA:
			return 87200;// Coin
			
		case GameData.CAR_NAME.FERRARI_FXX:
			return 385600;// Coin
			
		case GameData.CAR_NAME.LAMBORGHINI_LP560:
			return 150000;// Coin
			
		case GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO:
			return 155;//Cash
			
		case GameData.CAR_NAME.LAMBORGHINI_VENENO:
			return 500;//Cash
			
		case GameData.CAR_NAME.MARUSSIA_B2:
			return 75450;// Coin
			
		case GameData.CAR_NAME.MASERATI_GRAN_TURISMO:
			return 68120;// Coin
			
		case GameData.CAR_NAME.MERCEDES_BENZ_SLS:
			return 110540;// Coin
			
		case GameData.CAR_NAME.PAGANI_ZONDA:
			return 680;// cash
			
		case GameData.CAR_NAME.POLICE:
			return 255600;// Coin
			
		case GameData.CAR_NAME.PORSCHE_911:
			return 92550;// Coin      

            default:
			return 10000;// Coin
		}
	}
	
	public static int getCarSpeedUpgradePrice (GameData.CAR_NAME carName, int upgradeLevel)
	{
		switch (carName) {
		case GameData.CAR_NAME.ASTON_MARTIN_DB9:
			switch (upgradeLevel) {
			case 1:
				return 400;
			case 2:
				return 2500;
			case 3:
				return 5500;
			case 4:
				return 7300;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.AUDI_R8:
			switch (upgradeLevel) {
			case 1:
				return 500;
			case 2:
				return 2000;
			case 3:
				return 5000;
			case 4:
				return 8200;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.BMW_i8:
			switch (upgradeLevel) {
			case 1:
				return 400;
			case 2:
				return 2500;
			case 3:
				return 4600;
			case 4:
				return 7800;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.BUGATTI_VEYRON:
			switch (upgradeLevel) {
			case 1:
				return 1350;
			case 2:
				return 6550;
			case 3:
				return 9650;
			case 4:
				return 12250;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.FERRARI_458_ITALIA:
			switch (upgradeLevel) {
			case 1:
				return 600;
			case 2:
				return 3000;
			case 3:
				return 5700;
			case 4:
				return 9800;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.FERRARI_FXX:
			switch (upgradeLevel) {
			case 1:
				return 1200;
			case 2:
				return 6000;
			case 3:
				return 9500;
			case 4:
				return 12000;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_LP560:
			switch (upgradeLevel) {
			case 1:
				return 800;
			case 2:
				return 5500;
			case 3:
				return 8500;
			case 4:
				return 11800;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO:
			switch (upgradeLevel) {
			case 1:
				return 800;
			case 2:
				return 5500;
			case 3:
				return 8500;
			case 4:
				return 11800;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_VENENO:
			switch (upgradeLevel) {
			case 1:
				return 1350;
			case 2:
				return 6150;
			case 3:
				return 9500;
			case 4:
				return 12000;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.MARUSSIA_B2:
			switch (upgradeLevel) {
			case 1:
				return 600;
			case 2:
				return 3000;
			case 3:
				return 5700;
			case 4:
				return 9700;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.MASERATI_GRAN_TURISMO:
			switch (upgradeLevel) {
			case 1:
				return 600;
			case 2:
				return 3000;
			case 3:
				return 5500;
			case 4:
				return 9700;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.MERCEDES_BENZ_SLS:
			switch (upgradeLevel) {
			case 1:
				return 800;
			case 2:
				return 4500;
			case 3:
				return 8500;
			case 4:
				return 11800;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.PAGANI_ZONDA:
			switch (upgradeLevel) {
			case 1:
				return 1350;
			case 2:
				return 6150;
			case 3:
				return 9650;
			case 4:
				return 12000;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.POLICE:
			switch (upgradeLevel) {
			case 1:
				return 800;
			case 2:
				return 6000;
			case 3:
				return 8500;
			case 4:
				return 12300;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.PORSCHE_911:
			switch (upgradeLevel) {
			case 1:
				return 600;
			case 2:
				return 3200;
			case 3:
				return 5700;
			case 4:
				return 9800;
			default:
				return 0;
			}
			
		default:
			return 200;
		}
	}

	public static int getCarHandlingUpgradePrice (GameData.CAR_NAME carName, int upgradeLevel)
	{
		switch (carName) {
		case GameData.CAR_NAME.ASTON_MARTIN_DB9:
			switch (upgradeLevel) {
			case 1:
				return 200;
			case 2:
				return 1900;
			case 3:
				return 4550;
			case 4:
				return 7060;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.AUDI_R8:
			switch (upgradeLevel) {
			case 1:
				return 200;
			case 2:
				return 2200;
			case 3:
				return 4500;
			case 4:
				return 8500;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.BMW_i8:
			switch (upgradeLevel) {
			case 1:
				return 200;
			case 2:
				return 2200;
			case 3:
				return 4050;
			case 4:
				return 7560;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.BUGATTI_VEYRON:
			switch (upgradeLevel) {
			case 1:
				return 1300;
			case 2:
				return 4550;
			case 3:
				return 9750;
			case 4:
				return 13650;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.FERRARI_458_ITALIA:
			switch (upgradeLevel) {
			case 1:
				return 300;
			case 2:
				return 3500;
			case 3:
				return 6850;
			case 4:
				return 9250;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.FERRARI_FXX:
			switch (upgradeLevel) {
			case 1:
				return 1000;
			case 2:
				return 4000;
			case 3:
				return 9500;
			case 4:
				return 13500;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_LP560:
			switch (upgradeLevel) {
			case 1:
				return 600;
			case 2:
				return 4500;
			case 3:
				return 6500;
			case 4:
				return 12000;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO:
			switch (upgradeLevel) {
			case 1:
				return 500;
			case 2:
				return 4500;
			case 3:
				return 6500;
			case 4:
				return 10000;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_VENENO:
			switch (upgradeLevel) {
			case 1:
				return 1300;
			case 2:
				return 4250;
			case 3:
				return 9500;
			case 4:
				return 13500;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.MARUSSIA_B2:
			switch (upgradeLevel) {
			case 1:
				return 300;
			case 2:
				return 3500;
			case 3:
				return 6850;
			case 4:
				return 9000;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.MASERATI_GRAN_TURISMO:
			switch (upgradeLevel) {
			case 1:
				return 300;
			case 2:
				return 3500;
			case 3:
				return 6500;
			case 4:
				return 9000;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.MERCEDES_BENZ_SLS:
			switch (upgradeLevel) {
			case 1:
				return 500;
			case 2:
				return 3500;
			case 3:
				return 6500;
			case 4:
				return 10000;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.PAGANI_ZONDA:
			switch (upgradeLevel) {
			case 1:
				return 1300;
			case 2:
				return 4250;
			case 3:
				return 9750;
			case 4:
				return 13500;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.POLICE:
			switch (upgradeLevel) {
			case 1:
				return 600;
			case 2:
				return 4500;
			case 3:
				return 6500;
			case 4:
				return 12700;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.PORSCHE_911:
			switch (upgradeLevel) {
			case 1:
				return 300;
			case 2:
				return 3750;
			case 3:
				return 6850;
			case 4:
				return 9250;
			default:
				return 0;
			}
			
		default:
			return 200;
		}
	}

	public static int getCarAccelerationUpgradePrice (GameData.CAR_NAME carName, int upgradeLevel)
	{
		switch (carName) {
		case GameData.CAR_NAME.ASTON_MARTIN_DB9:
			switch (upgradeLevel) {
			case 1:
				return 200;
			case 2:
				return 2900;
			case 3:
				return 4700;
			case 4:
				return 7700;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.AUDI_R8:
			switch (upgradeLevel) {
			case 1:
				return 300;
			case 2:
				return 2800;
			case 3:
				return 5800;
			case 4:
				return 8700;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.BMW_i8:
			switch (upgradeLevel) {
			case 1:
				return 200;
			case 2:
				return 2200;
			case 3:
				return 4200;
			case 4:
				return 8200;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.BUGATTI_VEYRON:
			switch (upgradeLevel) {
			case 1:
				return 1150;
			case 2:
				return 5550;
			case 3:
				return 9550;
			case 4:
				return 13100;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.FERRARI_458_ITALIA:
			switch (upgradeLevel) {
			case 1:
				return 400;
			case 2:
				return 3200;
			case 3:
				return 6800;
			case 4:
				return 9560;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.FERRARI_FXX:
			switch (upgradeLevel) {
			case 1:
				return 1100;
			case 2:
				return 5500;
			case 3:
				return 9000;
			case 4:
				return 12800;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_LP560:
			switch (upgradeLevel) {
			case 1:
				return 550;
			case 2:
				return 4400;
			case 3:
				return 7250;
			case 4:
				return 11200;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO:
			switch (upgradeLevel) {
			case 1:
				return 600;
			case 2:
				return 4400;
			case 3:
				return 7200;
			case 4:
				return 11200;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_VENENO:
			switch (upgradeLevel) {
			case 1:
				return 1150;
			case 2:
				return 5500;
			case 3:
				return 9110;
			case 4:
				return 12800;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.MARUSSIA_B2:
			switch (upgradeLevel) {
			case 1:
				return 400;
			case 2:
				return 3200;
			case 3:
				return 6800;
			case 4:
				return 9550;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.MASERATI_GRAN_TURISMO:
			switch (upgradeLevel) {
			case 1:
				return 400;
			case 2:
				return 3200;
			case 3:
				return 6800;
			case 4:
				return 9550;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.MERCEDES_BENZ_SLS:
			switch (upgradeLevel) {
			case 1:
				return 600;
			case 2:
				return 4400;
			case 3:
				return 7200;
			case 4:
				return 11200;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.PAGANI_ZONDA:
			switch (upgradeLevel) {
			case 1:
				return 1150;
			case 2:
				return 5500;
			case 3:
				return 9550;
			case 4:
				return 12800;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.POLICE:
			switch (upgradeLevel) {
			case 1:
				return 550;
			case 2:
				return 4400;
			case 3:
				return 7250;
			case 4:
				return 11700;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.PORSCHE_911:
			switch (upgradeLevel) {
			case 1:
				return 400;
			case 2:
				return 3500;
			case 3:
				return 6800;
			case 4:
				return 9560;
			default:
				return 0;
			}
			
		default:
			return 200;
		}
	}

	public static int getCarNitroUpgradePrice (GameData.CAR_NAME carName, int upgradeLevel)
	{
		switch (carName) {
		case GameData.CAR_NAME.ASTON_MARTIN_DB9:
			switch (upgradeLevel) {
			case 1:
				return 300;
			case 2:
				return 2000;
			case 3:
				return 4900;
			case 4:
				return 7250;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.AUDI_R8:
			switch (upgradeLevel) {
			case 1:
				return 400;
			case 2:
				return 1900;
			case 3:
				return 3900;
			case 4:
				return 6000;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.BMW_i8:
			switch (upgradeLevel) {
			case 1:
				return 300;
			case 2:
				return 3500;
			case 3:
				return 5400;
			case 4:
				return 7500;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.BUGATTI_VEYRON:
			switch (upgradeLevel) {
			case 1:
				return 1310;
			case 2:
				return 6700;
			case 3:
				return 9350;
			case 4:
				return 14500;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.FERRARI_458_ITALIA:
			switch (upgradeLevel) {
			case 1:
				return 500;
			case 2:
				return 3000;
			case 3:
				return 6700;
			case 4:
				return 9700;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.FERRARI_FXX:
			switch (upgradeLevel) {
			case 1:
				return 1200;
			case 2:
				return 6100;
			case 3:
				return 8800;
			case 4:
				return 13000;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_LP560:
			switch (upgradeLevel) {
			case 1:
				return 700;
			case 2:
				return 4250;
			case 3:
				return 8200;
			case 4:
				return 12000;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO:
			switch (upgradeLevel) {
			case 1:
				return 700;
			case 2:
				return 4250;
			case 3:
				return 8200;
			case 4:
				return 12000;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.LAMBORGHINI_VENENO:
			switch (upgradeLevel) {
			case 1:
				return 1310;
			case 2:
				return 6340;
			case 3:
				return 8800;
			case 4:
				return 13000;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.MARUSSIA_B2:
			switch (upgradeLevel) {
			case 1:
				return 500;
			case 2:
				return 3000;
			case 3:
				return 6700;
			case 4:
				return 9500;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.MASERATI_GRAN_TURISMO:
			switch (upgradeLevel) {
			case 1:
				return 500;
			case 2:
				return 3000;
			case 3:
				return 6400;
			case 4:
				return 9500;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.MERCEDES_BENZ_SLS:
			switch (upgradeLevel) {
			case 1:
				return 700;
			case 2:
				return 4250;
			case 3:
				return 8000;
			case 4:
				return 11500;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.PAGANI_ZONDA:
			switch (upgradeLevel) {
			case 1:
				return 1310;
			case 2:
				return 6340;
			case 3:
				return 9100;
			case 4:
				return 13000;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.POLICE:
			switch (upgradeLevel) {
			case 1:
				return 700;
			case 2:
				return 4250;
			case 3:
				return 8200;
			case 4:
				return 12000;
			default:
				return 0;
			}
			
		case GameData.CAR_NAME.PORSCHE_911:
			switch (upgradeLevel) {
			case 1:
				return 500;
			case 2:
				return 3150;
			case 3:
				return 6700;
			case 4:
				return 9700;
			default:
				return 0;
			}
			
		default:
			return 200;
		}
	}
}