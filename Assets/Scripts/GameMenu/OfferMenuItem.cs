using UnityEngine;
using System.Collections;
using System;

public class OfferMenuItem : MonoBehaviour
{
		public GameData.CAR_NAME carName;
		public dfPanel background;
		public OfferProfileData offerProfileData;

		//
		public dfLabel day;
		public dfLabel hour;
		public dfLabel minute;
		public dfLabel second;

		//
		DateTime endTime = new DateTime (2015, 1, 1);

		public void Update ()
		{
				if (offerProfileData != null) {
						if (MainMenu.currentTime.CompareTo (new DateTime (2015, 1, 1)) != 0) {
								try {
										endTime = DateTime.Parse (offerProfileData.end);
								} catch {
								}
						}

						try {
								TimeSpan timeSpan = new TimeSpan (endTime.Ticks - DateTime.Now.Ticks);
				
								if (DateTime.Compare (endTime, DateTime.Now) > 0) {
										day.Text = timeSpan.Days.ToString ();
										hour.Text = timeSpan.Hours.ToString ();
										minute.Text = timeSpan.Minutes.ToString ();
										second.Text = timeSpan.Seconds.ToString ();
								} else {
										day.Text = string.Empty;
										hour.Text = string.Empty;
										minute.Text = string.Empty;
										second.Text = string.Empty;
								}
						} catch {
						}
				} else {
						day.Text = string.Empty;
						hour.Text = string.Empty;
						minute.Text = string.Empty;
						second.Text = string.Empty;
				}
		}

		public void buyNow ()
		{		
//				switch (carName) {
//				case GameData.CAR_NAME.BUGATTI_VEYRON:
//						ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.BUGATTI_VEYRON].IsBought = true;
//						break;
//			
//				case GameData.CAR_NAME.PAGANI_ZONDA:
//						ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.PAGANI_ZONDA].IsBought = true;
//						break;
//			
//				case GameData.CAR_NAME.LAMBORGHINI_VENENO:
//						ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.LAMBORGHINI_VENENO].IsBought = true;
//						break;
//			
//				case GameData.CAR_NAME.LAMBORGHINI_LP560:
//						ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.LAMBORGHINI_LP560].IsBought = true;
//						break;
//			
//				case GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO:
//						ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO].IsBought = true;
//						break;
//			
//				case GameData.CAR_NAME.MERCEDES_BENZ_SLS:
//						ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.MERCEDES_BENZ_SLS].IsBought = true;
//						break;
//			
//				case GameData.CAR_NAME.PORSCHE_911:
//						ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.PORSCHE_911].IsBought = true;
//						break;
//			
//				case GameData.CAR_NAME.FERRARI_458_ITALIA:
//						ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.FERRARI_458_ITALIA].IsBought = true;
//						break;
//			
//				case GameData.CAR_NAME.MASERATI_GRAN_TURISMO:
//						ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.MASERATI_GRAN_TURISMO].IsBought = true;
//						break;
//			
//				case GameData.CAR_NAME.FERRARI_FXX:
//						ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.FERRARI_FXX].IsBought = true;
//						break;
//			
//				default:
//						break;
//				}

				//switch (carName) {
				//case GameData.CAR_NAME.BUGATTI_VEYRON:
				//		KORPaymentHandler.purchaseProduct (KORPaymentHandler.CAR_BUGATTI_VEYRON_SALE);
				//		break;

				//case GameData.CAR_NAME.PAGANI_ZONDA:
				//		KORPaymentHandler.purchaseProduct (KORPaymentHandler.CAR_PAGANI_ZONDA_SALE);
				//		break;

				//case GameData.CAR_NAME.LAMBORGHINI_VENENO:
				//		KORPaymentHandler.purchaseProduct (KORPaymentHandler.CAR_LAMBORGHINI_VENENO);
				//		break;

				//case GameData.CAR_NAME.LAMBORGHINI_LP560:
				//		KORPaymentHandler.purchaseProduct (KORPaymentHandler.CAR_LAMBORGHINI_LP_560);
				//		break;

				//case GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO:
				//		KORPaymentHandler.purchaseProduct (KORPaymentHandler.CAR_SESTO_ELEMENTO);
				//		break;

				//case GameData.CAR_NAME.MERCEDES_BENZ_SLS:
				//		KORPaymentHandler.purchaseProduct (KORPaymentHandler.CAR_MERCEDEZ_BENZ_SLS);
				//		break;

				//case GameData.CAR_NAME.PORSCHE_911:
				//		KORPaymentHandler.purchaseProduct (KORPaymentHandler.CAR_PORCHE_911);
				//		break;

				//case GameData.CAR_NAME.FERRARI_458_ITALIA:
				//		KORPaymentHandler.purchaseProduct (KORPaymentHandler.CAR_FERRARI_458);
				//		break;

				//case GameData.CAR_NAME.MASERATI_GRAN_TURISMO:
				//		KORPaymentHandler.purchaseProduct (KORPaymentHandler.CAR_MASERATI_GRAN_TURISMO);
				//		break;

				//case GameData.CAR_NAME.FERRARI_FXX:
				//		KORPaymentHandler.purchaseProduct (KORPaymentHandler.CAR_FERRARI_FXX);
				//		break;

				//default:
				//		break;
				//}
		}
}