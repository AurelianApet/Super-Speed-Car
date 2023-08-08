using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShopScripts : BaseHeaderMenu
{
		//
		static string NitroTankInfo = "Fill your nitro tank";
		static string NitroRateInfo = "Increase nitro using duration in 20 seconds";
		static string NitroMultiInfo = "Increase max speed when using nitro in a short period";
		static string PoliceInfo = "Don't let police catch in a short period";
		static string AccelationInfo = "Maximize acceleration in a short period";
		static string HandlingInfo = "Maximize handling in a short period";
		public GameObject[] cars;
		private int carIndex = 0;
		public dfPanel[] panel;
		public Color[] colors;
		public Material[] HighColorMaterial, colorMaterial, lowMaterial;
		public dfButton btnBack, btnBuy, btnBuyCar, btnUpgrade, btnNext, btnPrev, btnItems, btnColor /*, btnNextItems, btnPrevItems*/;
		public dfTweenGroup grTank, grRate, grMulti, grAcc, grHandling, grPolice;
		public dfTweenVector3 labelFly, panelErrorFly;
		public dfTweenFloat acclerationTween, SpeedTween, HandlingTween, NitroTween;
		public MainMenuSound sound;
		public dfLabel moneyText, starText;
		public dfLabel[] LabelUpdatePrice;
		public dfLabel[] LabelIndicatorOfCar;
		public dfLabel[] LabelUpdateLevel;
		public dfLabel  labelErrorDes, labelInfo;
		public dfButton labelBuycar, labelUpgrade, labelColor, labelItems;
		public dfRichTextLabel labelItemsInfo;
		private int index = 0;
		public dfPanel panelBlack, panelGrey, panelBlue, panelGreen, panelYellow, panelWhite, panelRed, panelError, panelUpgrade, panelColor, panelItems, panelBuyCar, panelNamOfCar, panelLabelCarIndicator;
		public GameObject[] NameOfCar;
		public dfSprite[] progressIndicator;
		public dfSprite[] IndicatorUpdate;
		public dfTweenGroup group;
		public dfButton btnNitroTank, btnNitroRate, btnNitroMulti, btnPolice, btnAcceleration, btnHanlding;
		public dfButton btnRace;
		public dfButton btnSpecial;
		public Texture2D[] iconPrice;
		public dfTextureSprite price;
		public dfLabel[] colorPrice;

		//
		public FreeLookCam freeLookCam;
		public dfButton buyCarButtonPanel;
		public dfPanel buttonPanel;
		public dfPanel windowsPanel;
		public dfButton viewCarButton;
		public dfButton turnOnLightButton;
		public dfLabel changeLightLabel;
		public GameObject cameraPath;
		public dfButton[] btnColors;

		void Start ()
		{
				ProfileManager.init ();

				//Playing background music
				sound.mainMusic.volume = ProfileManager.setttings.MusicVolume / 100f;
				sound.mainMusic.Play ();

				btnBuy.IsEnabled = false;
				labelBuycar.IsEnabled = false;

				#region Load Car Profile
				//SetActive Your Car
				carIndex = toShopCarID (ProfileManager.userProfile.SelectedCar);
				cars [carIndex].SetActive (true);
				colorMaterial [carIndex].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
				lowMaterial [carIndex].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
				//Color of high quality car
				if (carIndex == 14) {
						if (ProfileManager.userProfile.CarProfile [toShopCarID (carIndex)].Color == 2) {
								HighColorMaterial [15].SetColor ("_Color", new Color32 (0, 18, 60, 255));
								HighColorMaterial [14].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
						} else {
								HighColorMaterial [15].SetColor ("_Color", colors [0]);
								HighColorMaterial [14].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
						}
				} else {
						HighColorMaterial [carIndex].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
				}
				#endregion

				#region Load Name Of Car
				for (int i = 0; i < NameOfCar.Length; i++) {
						if (i == carIndex)
								NameOfCar [i].SetActive (true);
						else
								NameOfCar [i].SetActive (false);
				}
				#endregion

				#region Load Info Of Car
				LoadCarIndicator ();

				acclerationTween.EndValue = AllCarDescription.getCarAcceleration (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration) / 1.6f;
				SpeedTween.EndValue = AllCarDescription.getCarSpeed (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed) / 420f;
				HandlingTween.EndValue = AllCarDescription.getCarHandling (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling) / 1f;
				NitroTween.EndValue = AllCarDescription.getCarNitro (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro) / 25f;

				acclerationTween.Play ();
				SpeedTween.Play ();
				HandlingTween.Play ();
				NitroTween.Play ();
		
				LoadCarPrice ();
				LoadUpdateLevel ();
				#endregion

				if (carIndex == 0 || ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].IsBought) {
						if (MainMenu.isLoadingShop) {
								btnRace.IsEnabled = false;
						} else {
								btnRace.IsEnabled = true;
						}
				} else {
						btnRace.IsEnabled = false;		
						
				}
				starText.Text = ProfileManager.userProfile.getNumberStar ().ToString ();
				LoadColor ();
				GameData.resetData ();
				LevelLoader.isLoading = false;
				
				if (ProfileManager.offerProfile.offerProfileList.Count > 0) {
						btnSpecial.IsVisible = true;
				} else {
						btnSpecial.IsVisible = false;
				}
		}

		void Update ()
		{
				if (carIndex == 0)
						btnBuyCar.IsVisible = false;

				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].IsBought) {	
						if (ProfileManager.userProfile.SelectedCar != toGamePlayCarID (carIndex)) {
								ProfileManager.userProfile.SelectedCar = toGamePlayCarID (carIndex);
						}
						colorMaterial [carIndex].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
						lowMaterial [carIndex].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
						btnUpgrade.IsEnabled = true;
						if (MainMenu.isLoadingShop) {
								btnRace.IsEnabled = false;
						} else {
								btnRace.IsEnabled = true;
								btnSpecial.IsVisible = false;
						}
				} else {
						btnUpgrade.IsEnabled = false;
						btnRace.IsEnabled = false;
				}
				if (Input.GetKeyUp (KeyCode.Escape)) {
						if (freeLookCam.IsAutoRotation == true) {
								AutoFade.LoadLevel ("Load");
						} else {
								changeView (freeLookCam.IsAutoRotation);
						}
				} else {
						this.updateInfo ();
				}
				#region Set Car Price
				if (carIndex == 13 || carIndex == 14) {
            btnBuyCar.Text = string.Format("{0:n00}", (int)AllCarDescription.getCarPrice(GameData.getCarNameShop(carIndex))); //+ " usd";
            price.IsVisible = true;
            price.Texture = iconPrice[1];
        } else if (carIndex == 2 || carIndex == 8 || carIndex == 12) {
						price.IsVisible = true;
						price.Texture = iconPrice [1];
						btnBuyCar.Text = string.Format ("{0:n00}", (int)AllCarDescription.getCarPrice (GameData.getCarNameShop (carIndex)));
				} else {
						price.IsVisible = true;
						btnBuyCar.Text = string.Format ("{0:n00}", (int)AllCarDescription.getCarPrice (GameData.getCarNameShop (carIndex)));
						price.Texture = iconPrice [0];
				}
				#endregion
				if (sound.mainMusic.isPlaying)
						sound.mainMusic.volume = ProfileManager.setttings.MusicVolume / 100f;

				moneyText.Text = string.Format ("{0:n00}", ProfileManager.userProfile.Money);

#if UNITY_EDITOR
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						PrevCar ();
				} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
						NextCar ();
				}
#endif
				if (Input.GetKeyUp (KeyCode.Escape)) {
						sound.BackSound ();
				}

				ColorSelected ();
				LoadCarIndicator ();
				LoadColor ();
				LoadCarPrice ();
				for (int i = 0; i<btnColors.Length; i++) {
						if (carIndex == 10)
								btnColors [i].IsVisible = false;
						else
								btnColors [i].IsVisible = true;
				}
				for (int i = 0; i<colorPrice.Length; i++) {
						if (carIndex == 10)
								colorPrice [i].IsVisible = false;
				}

		}

	#region Load Color Bought
		void LoadColor ()
		{
				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].isColorBought (1)) {
						colorPrice [0].IsVisible = false;
				} else {
						colorPrice [0].IsVisible = true;
				}
				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].isColorBought (2))
						colorPrice [1].IsVisible = false;
				else 
						colorPrice [1].IsVisible = true;
		
				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].isColorBought (3))
						colorPrice [2].IsVisible = false;
				else 
						colorPrice [2].IsVisible = true;
		
				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].isColorBought (4))
						colorPrice [3].IsVisible = false;
				else 
						colorPrice [3].IsVisible = true;
		
				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].isColorBought (5))
						colorPrice [4].IsVisible = false;
				else 
						colorPrice [4].IsVisible = true;
		
				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].isColorBought (6))
						colorPrice [5].IsVisible = false;
				else 
						colorPrice [5].IsVisible = true;
		}
	#endregion

    #region ColorSelected
		void ColorSelected ()
		{
				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color == 0) {
						panelBlack.BackgroundSprite = "choose";
						panelGrey.BackgroundSprite = "none";
						panelBlue.BackgroundSprite = "none";
						panelGreen.BackgroundSprite = "none";
						panelYellow.BackgroundSprite = "none";
						panelWhite.BackgroundSprite = "none";
						panelRed.BackgroundSprite = "none";
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color == 1) {
						panelGrey.BackgroundSprite = "choose";
						panelBlack.BackgroundSprite = "none";
						panelBlue.BackgroundSprite = "none";
						panelGreen.BackgroundSprite = "none";
						panelYellow.BackgroundSprite = "none";
						panelWhite.BackgroundSprite = "none";
						panelRed.BackgroundSprite = "none";
						colorPrice [0].IsVisible = false;
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color == 2) {
						panelBlue.BackgroundSprite = "choose";
						panelGrey.BackgroundSprite = "none";
						panelBlack.BackgroundSprite = "none";
						panelGreen.BackgroundSprite = "none";
						panelYellow.BackgroundSprite = "none";
						panelWhite.BackgroundSprite = "none";
						panelRed.BackgroundSprite = "none";
						colorPrice [1].IsVisible = false;
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color == 3) {
						panelGreen.BackgroundSprite = "choose";
						panelBlue.BackgroundSprite = "none";
						panelGrey.BackgroundSprite = "none";
						panelBlack.BackgroundSprite = "none";
						panelYellow.BackgroundSprite = "none";
						panelWhite.BackgroundSprite = "none";
						panelRed.BackgroundSprite = "none";
						colorPrice [2].IsVisible = false;
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color == 4) {
						panelYellow.BackgroundSprite = "choose";
						panelGreen.BackgroundSprite = "none";
						panelBlue.BackgroundSprite = "none";
						panelGrey.BackgroundSprite = "none";
						panelBlack.BackgroundSprite = "none";
						panelWhite.BackgroundSprite = "none";
						panelRed.BackgroundSprite = "none";
						colorPrice [3].IsVisible = false;
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color == 5) {
						panelWhite.BackgroundSprite = "choose";
						panelYellow.BackgroundSprite = "none";
						panelGreen.BackgroundSprite = "none";
						panelBlue.BackgroundSprite = "none";
						panelGrey.BackgroundSprite = "none";
						panelBlack.BackgroundSprite = "none";
						panelRed.BackgroundSprite = "none";
						colorPrice [4].IsVisible = false;
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color == 6) {
						panelRed.BackgroundSprite = "choose";
						panelWhite.BackgroundSprite = "none";
						panelYellow.BackgroundSprite = "none";
						panelGreen.BackgroundSprite = "none";
						panelBlue.BackgroundSprite = "none";
						panelGrey.BackgroundSprite = "none";
						panelBlack.BackgroundSprite = "none";
						colorPrice [5].IsVisible = false;
				}
		}
    #endregion

    #region Change Car Color
		public void ChangeCarColor (dfControl control, dfMouseEventArgs mouseEvent)
		{
				if (control.name == "Button Black") {
						ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color = 0;
						colorMaterial [carIndex].SetColor ("_Color", colors [0]);
						lowMaterial [carIndex].SetColor ("_Color", colors [0]);
						if (carIndex == 14) {
								HighColorMaterial [14].SetColor ("_Color", colors [0]);
								HighColorMaterial [15].SetColor ("_Color", colors [0]);
						} else {

								HighColorMaterial [carIndex].SetColor ("_Color", colors [0]);
						}
				} else if (control.name == "Button Grey") {
						if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].isColorBought (1) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].boughtColor (1);
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color = 1;

										colorMaterial [carIndex].SetColor ("_Color", colors [1]);
										lowMaterial [carIndex].SetColor ("_Color", colors [1]);
										if (carIndex == 14) {
												HighColorMaterial [14].SetColor ("_Color", colors [1]);
												HighColorMaterial [15].SetColor ("_Color", colors [0]);
										} else {
												HighColorMaterial [carIndex].SetColor ("_Color", colors [1]);
										}
								} else {
										ShowError ();
										labelErrorDes.Text = "You need " + (2 - ProfileManager.userProfile.Diamond) + " cash more. ";
								}
						} else {
								ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color = 1;
								colorMaterial [carIndex].SetColor ("_Color", colors [1]);
								lowMaterial [carIndex].SetColor ("_Color", colors [1]);
								if (carIndex == 14) {
										HighColorMaterial [14].SetColor ("_Color", colors [1]);
										HighColorMaterial [15].SetColor ("_Color", colors [0]);
								} else {
										HighColorMaterial [carIndex].SetColor ("_Color", colors [1]);
								}
						}
				} else if (control.name == "Button Blue") {
						if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].isColorBought (2) == false) {
								
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].boughtColor (2);
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color = 2;
										colorMaterial [carIndex].SetColor ("_Color", colors [2]);
										lowMaterial [carIndex].SetColor ("_Color", colors [2]);
										if (carIndex == 14) {
												HighColorMaterial [14].SetColor ("_Color", new Color32 (0, 18, 60, 255));
												HighColorMaterial [15].SetColor ("_Color", colors [2]);
										} else {
												HighColorMaterial [carIndex].SetColor ("_Color", colors [2]);
										}
								} else {
										ShowError ();
										labelErrorDes.Text = "You need " + (2 - ProfileManager.userProfile.Diamond) + " cash more. ";
								}
						} else {
								ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color = 2;
								colorMaterial [carIndex].SetColor ("_Color", colors [2]);
								lowMaterial [carIndex].SetColor ("_Color", colors [2]);
								if (carIndex == 14) {
										HighColorMaterial [14].SetColor ("_Color", new Color32 (0, 18, 60, 255));
										HighColorMaterial [15].SetColor ("_Color", colors [2]);
								} else {
										HighColorMaterial [carIndex].SetColor ("_Color", colors [2]);
								}
						}
				} else if (control.name == "Button Green") {
						if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].isColorBought (3) == false) {
								if (ProfileManager.userProfile.Diamond >= 3) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].boughtColor (3);
										ProfileManager.userProfile.Diamond -= 3;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color = 3;
										colorMaterial [carIndex].SetColor ("_Color", colors [3]);
										lowMaterial [carIndex].SetColor ("_Color", colors [3]);
										if (carIndex == 14) {
												HighColorMaterial [14].SetColor ("_Color", colors [3]);
												HighColorMaterial [15].SetColor ("_Color", colors [0]);
										} else {
												HighColorMaterial [carIndex].SetColor ("_Color", colors [3]);
										}
								} else {
										ShowError ();
										labelErrorDes.Text = "You need " + (3 - ProfileManager.userProfile.Diamond) + " cash more. ";
								}
						} else {
								ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color = 3;
								colorMaterial [carIndex].SetColor ("_Color", colors [3]);
								lowMaterial [carIndex].SetColor ("_Color", colors [3]);
								if (carIndex == 14) {
										HighColorMaterial [14].SetColor ("_Color", colors [3]);
										HighColorMaterial [15].SetColor ("_Color", colors [0]);
								} else {
										HighColorMaterial [carIndex].SetColor ("_Color", colors [3]);
								}
						}
				} else if (control.name == "Button Yellow") {
						if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].isColorBought (4) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].boughtColor (4);
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color = 4;
										colorMaterial [carIndex].SetColor ("_Color", colors [4]);
										lowMaterial [carIndex].SetColor ("_Color", colors [4]);
										if (carIndex == 14) {
												HighColorMaterial [14].SetColor ("_Color", colors [4]);
												HighColorMaterial [15].SetColor ("_Color", colors [0]);
										} else {
												HighColorMaterial [carIndex].SetColor ("_Color", colors [4]);
										}
								} else {
										ShowError ();
										labelErrorDes.Text = "You need " + (2 - ProfileManager.userProfile.Diamond) + " cash more. ";
								}
						} else {
								ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color = 4;
								colorMaterial [carIndex].SetColor ("_Color", colors [4]);
								lowMaterial [carIndex].SetColor ("_Color", colors [4]);
								if (carIndex == 14) {
										HighColorMaterial [14].SetColor ("_Color", colors [4]);
										HighColorMaterial [15].SetColor ("_Color", colors [0]);
								} else {
										HighColorMaterial [carIndex].SetColor ("_Color", colors [4]);
								}
						}
				} else if (control.name == "Button White") {
						if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].isColorBought (5) == false) {
								if (ProfileManager.userProfile.Diamond >= 3) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].boughtColor (5);
										ProfileManager.userProfile.Diamond -= 3;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color = 5;
										colorMaterial [carIndex].SetColor ("_Color", colors [5]);
										lowMaterial [carIndex].SetColor ("_Color", colors [5]);
										if (carIndex == 14) {
												HighColorMaterial [14].SetColor ("_Color", colors [5]);
												HighColorMaterial [15].SetColor ("_Color", colors [0]);
										} else {
												HighColorMaterial [carIndex].SetColor ("_Color", colors [5]);
										}
								} else {
										ShowError ();
										labelErrorDes.Text = "You need " + (3 - ProfileManager.userProfile.Diamond) + " cash more. ";
								}
						} else {
								ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color = 5;
								colorMaterial [carIndex].SetColor ("_Color", colors [5]);
								lowMaterial [carIndex].SetColor ("_Color", colors [5]);
								if (carIndex == 14) {
										HighColorMaterial [14].SetColor ("_Color", colors [5]);
										HighColorMaterial [15].SetColor ("_Color", colors [0]);
								} else {
										HighColorMaterial [carIndex].SetColor ("_Color", colors [5]);
								}
						}
				} else if (control.name == "Button Red") {
						if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].isColorBought (6) == false) {
								if (ProfileManager.userProfile.Diamond >= 3) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].boughtColor (6);
										ProfileManager.userProfile.Diamond -= 3;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color = 6;
										colorMaterial [carIndex].SetColor ("_Color", colors [6]);
										lowMaterial [carIndex].SetColor ("_Color", colors [6]);
										if (carIndex == 14) {
												HighColorMaterial [14].SetColor ("_Color", colors [6]);
												HighColorMaterial [15].SetColor ("_Color", colors [0]);
										} else {
												HighColorMaterial [carIndex].SetColor ("_Color", colors [6]);
										}
								} else {
										ShowError ();
										labelErrorDes.Text = "You need " + (3 - ProfileManager.userProfile.Diamond) + " cash more. ";
								}
						} else {
								ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color = 6;
								colorMaterial [carIndex].SetColor ("_Color", colors [6]);
								lowMaterial [carIndex].SetColor ("_Color", colors [6]);
								if (carIndex == 14) {
										HighColorMaterial [14].SetColor ("_Color", colors [6]);
										HighColorMaterial [15].SetColor ("_Color", colors [0]);
								} else {
										HighColorMaterial [carIndex].SetColor ("_Color", colors [6]);
								}
						}
				}
				PlayerPrefs.Save ();
		}
    #endregion

    #region OnClick Event
		public void OnClick (dfControl control, dfMouseEventArgs mouseEvent)
		{

				if (control.name == "Button Next") {
						NextCar ();
						sound.ButtonClick ();
				} else if (control.name == "Button Prev") {
						PrevCar ();
						sound.ButtonClick ();
				} else if (control.name == "Button Next Items") {
						NextItems ();
						sound.ButtonClick ();
				} else if (control.name == "Button Prev Items") {
						PreviousItems ();
						sound.ButtonClick ();
				} else if (control.name == "Button Back") {
						sound.BackSound ();

						if (freeLookCam.IsAutoRotation == true) {
								AutoFade.LoadLevel ("Load");
								PlayerPrefs.Save ();

						} else {
								changeView (freeLookCam.IsAutoRotation);
						}

				} else if (control.name == "Button Color") {
						sound.ButtonClick ();

						labelColor.IsEnabled = false;
						labelItems.IsEnabled = true;
						labelUpgrade.IsEnabled = true;
						labelBuycar.IsEnabled = true;

						btnColor.IsEnabled = false;
						btnItems.IsEnabled = true;
						btnUpgrade.IsEnabled = true;
						btnBuy.IsEnabled = true;

						panelColor.IsVisible = true;
						panelItems.IsVisible = false;
						panelUpgrade.IsVisible = false;
						panelBuyCar.IsVisible = false;
						panelNamOfCar.IsVisible = true;
						panelLabelCarIndicator.IsVisible = false;

//						btnNext.IsVisible = false;
//						btnPrev.IsVisible = false;
						cars [carIndex].SetActive (true);

						viewCarButton.IsVisible = true;

//						btnBuyCar.IsVisible = false;
				} else if (control.name == "Button Upgrade") {
						sound.ButtonClick ();

						labelColor.IsEnabled = true;
						labelItems.IsEnabled = true;
						labelUpgrade.IsEnabled = false;
						labelBuycar.IsEnabled = true;

						btnColor.IsEnabled = true;
						btnItems.IsEnabled = true;
						btnUpgrade.IsEnabled = false;
						btnBuy.IsEnabled = true;

						panelColor.IsVisible = false;
						panelItems.IsVisible = false;
						panelUpgrade.IsVisible = true;
						panelBuyCar.IsVisible = false;
						panelNamOfCar.IsVisible = true;

						btnNext.IsVisible = false;
						btnPrev.IsVisible = false;
						cars [carIndex].SetActive (true);
						panelLabelCarIndicator.IsVisible = true;
						LoadUpdateCarIndicator ();

						viewCarButton.IsVisible = false;
				} else if (control.name == "Button Buy Car") {
						sound.ButtonClick ();

						labelColor.IsEnabled = true;
						labelItems.IsEnabled = true;
						labelUpgrade.IsEnabled = true;
						labelBuycar.IsEnabled = false;

						btnColor.IsEnabled = true;
						btnItems.IsEnabled = true;
						btnUpgrade.IsEnabled = true;
						btnBuy.IsEnabled = false;

						panelColor.IsVisible = false;
						panelItems.IsVisible = false;
						panelUpgrade.IsVisible = false;
						panelBuyCar.IsVisible = true;
						panelNamOfCar.IsVisible = true;

						btnNext.IsVisible = true;
						btnPrev.IsVisible = true;
						cars [carIndex].SetActive (true);
						panelLabelCarIndicator.IsVisible = true;

						viewCarButton.IsVisible = true;
						if (carIndex == 0)
								btnBuyCar.IsVisible = false;
						else
								btnBuyCar.IsVisible = true;
				} else if (control.name == "Button Items") {
						sound.ButtonClick ();

						labelColor.IsEnabled = true;
						labelItems.IsEnabled = false;
						labelUpgrade.IsEnabled = true;
						labelBuycar.IsEnabled = true;

						btnColor.IsEnabled = true;
						btnItems.IsEnabled = false;
						btnUpgrade.IsEnabled = true;
						btnBuy.IsEnabled = true;

						panelColor.IsVisible = false;
						panelItems.IsVisible = true;
						panelUpgrade.IsVisible = false;
						panelBuyCar.IsVisible = false;
						panelNamOfCar.IsVisible = false;

						btnNext.IsVisible = false;
						btnPrev.IsVisible = false;
//						cars [carIndex].SetActive (false);

						panel [0].IsVisible = true;
						panel [1].IsVisible = false;
						panel [2].IsVisible = false;
						panel [3].IsVisible = false;
						panel [4].IsVisible = false;
						panel [5].IsVisible = false;
						btnNitroTank.IsEnabled = false;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = true;
						labelItemsInfo.Text = NitroTankInfo;
						labelFly.Play ();
						grTank.Play ();
						labelInfo.Text = "Extra Nitro Tank";
						index = 0;

						viewCarButton.IsVisible = false;

						btnBuyCar.IsVisible = false;

				} else if (control.name == "Button Race") {
						sound.ButtonClick ();
						AutoFade.LoadLevel ("PowerUpMenu");
				} else if (control.name == "Button Special") {
						sound.ButtonClick ();
						OfferMenu.previousLevel = Application.loadedLevelName;
						AutoFade.LoadLevel ("OfferMenu");
				} else if (control.name == "Button Nitro Tank") {
						sound.ButtonClick ();
						labelItemsInfo.Text = NitroTankInfo;
						labelFly.Play ();
						grTank.Play ();

						panel [0].IsVisible = true;
						panel [1].IsVisible = false;
						panel [2].IsVisible = false;
						panel [3].IsVisible = false;
						panel [4].IsVisible = false;
						panel [5].IsVisible = false;
						btnNitroTank.IsEnabled = false;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = true;
						index = 0;
						labelInfo.Text = "Extra Nitro Tank";

				} else if (control.name == "Button Nitro Rate") {
						sound.ButtonClick ();
						labelItemsInfo.Text = NitroRateInfo;
						labelFly.Play ();
						grRate.Play ();

						panel [0].IsVisible = false;
						panel [1].IsVisible = true;
						panel [2].IsVisible = false;
						panel [3].IsVisible = false;
						panel [4].IsVisible = false;
						panel [5].IsVisible = false;

						btnNitroTank.IsEnabled = true;
						btnNitroRate.IsEnabled = false;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = true;
						index = 1;
						labelInfo.Text = "High Quality Nitro";

				} else if (control.name == "Button Nitro Multi") {
						sound.ButtonClick ();
						labelItemsInfo.Text = NitroMultiInfo;
						labelFly.Play ();
						grMulti.Play ();

						panel [0].IsVisible = false;
						panel [1].IsVisible = false;
						panel [2].IsVisible = true;
						panel [3].IsVisible = false;
						panel [4].IsVisible = false;
						panel [5].IsVisible = false;

						btnNitroTank.IsEnabled = true;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = false;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = true;
						index = 2;
						labelInfo.Text = "Advanced Cooler";

				} else if (control.name == "Button Police") {
						sound.ButtonClick ();
						labelItemsInfo.Text = PoliceInfo;
						labelFly.Play ();
						grPolice.Play ();

						panel [0].IsVisible = false;
						panel [1].IsVisible = false;
						panel [2].IsVisible = false;
						panel [3].IsVisible = true;
						panel [4].IsVisible = false;
						panel [5].IsVisible = false;

						btnNitroTank.IsEnabled = true;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = false;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = true;
						index = 3;
						labelInfo.Text = "Police License";

				} else if (control.name == "Button Acceleration") {
						sound.ButtonClick ();
						labelItemsInfo.Text = AccelationInfo;
						labelFly.Play ();
						grAcc.Play ();

						panel [0].IsVisible = false;
						panel [1].IsVisible = false;
						panel [2].IsVisible = false;
						panel [3].IsVisible = false;
						panel [4].IsVisible = true;
						panel [5].IsVisible = false;

						btnNitroTank.IsEnabled = true;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = false;
						btnHanlding.IsEnabled = true;
						index = 4;
						labelInfo.Text = "Engine Tuning";
				} else if (control.name == "Button Handling") {
						sound.ButtonClick ();

						labelItemsInfo.Text = HandlingInfo;
						labelFly.Play ();
						grHandling.Play ();

						panel [0].IsVisible = false;
						panel [1].IsVisible = false;
						panel [2].IsVisible = false;
						panel [3].IsVisible = false;
						panel [4].IsVisible = false;
						panel [5].IsVisible = true;

						btnNitroTank.IsEnabled = true;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = false;
						index = 5;
						labelInfo.Text = "Wheel Tuning";
				}
		}
    #endregion

	#region Next Items
		void NextItems ()
		{
				panel [index].IsVisible = false;
				index++;
				index %= panel.Length;
				panel [index].IsVisible = true;
				if (index == 0) {
						btnNitroTank.IsEnabled = false;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = true;

						labelItemsInfo.Text = NitroTankInfo;
						labelInfo.Text = "Extra Nitro Tank";
						labelFly.Play ();
						grTank.Play ();
				} else if (index == 1) {
						btnNitroTank.IsEnabled = true;
						btnNitroRate.IsEnabled = false;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = true;

						labelItemsInfo.Text = NitroRateInfo;
						labelInfo.Text = "High Quality Nitro";
						labelFly.Play ();
						grRate.Play ();
				} else if (index == 2) {
						btnNitroTank.IsEnabled = true;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = false;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = true;

						labelItemsInfo.Text = NitroMultiInfo;
						labelInfo.Text = "Advanced Cooler";
						labelFly.Play ();
						grMulti.Play ();
				} else if (index == 3) {
						btnNitroTank.IsEnabled = true;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = false;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = true;

						labelItemsInfo.Text = PoliceInfo;
						labelInfo.Text = "Police License";
						labelFly.Play ();
						grPolice.Play ();
				} else if (index == 4) {
						btnNitroTank.IsEnabled = true;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = false;
						btnHanlding.IsEnabled = true;

						labelItemsInfo.Text = AccelationInfo;
						labelInfo.Text = "Engine Tuning";
						labelFly.Play ();
						grAcc.Play ();
				} else if (index == 5) {
						btnNitroTank.IsEnabled = true;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = false;

						labelItemsInfo.Text = HandlingInfo;
						labelInfo.Text = "Wheel Tuning";
						labelFly.Play ();
						grHandling.Play ();
				}
		}
	#endregion
	
	#region Previous Items
		void PreviousItems ()
		{
				panel [index].IsVisible = false;
				index--;
				if (index < 0)
						index = panel.Length - 1;
				panel [index].IsVisible = true;
				if (index == 0) {
						btnNitroTank.IsEnabled = false;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = true;
			
						labelItemsInfo.Text = NitroTankInfo;
						labelInfo.Text = "Extra Nitro Tank";
						labelFly.Play ();
						grTank.Play ();
				} else if (index == 1) {
						btnNitroTank.IsEnabled = true;
						btnNitroRate.IsEnabled = false;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = true;
			
						labelItemsInfo.Text = NitroRateInfo;
						labelInfo.Text = "High Quality Nitro";
						labelFly.Play ();
						grRate.Play ();
				} else if (index == 2) {
						btnNitroTank.IsEnabled = true;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = false;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = true;
			
						labelItemsInfo.Text = NitroMultiInfo;
						labelInfo.Text = "Advanced Cooler";
						labelFly.Play ();
						grMulti.Play ();
				} else if (index == 3) {
						btnNitroTank.IsEnabled = true;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = false;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = true;
			
						labelItemsInfo.Text = PoliceInfo;
						labelInfo.Text = "Police License";
						labelFly.Play ();
						grPolice.Play ();
				} else if (index == 4) {
						btnNitroTank.IsEnabled = true;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = false;
						btnHanlding.IsEnabled = true;
			
						labelItemsInfo.Text = AccelationInfo;
						labelInfo.Text = "Engine Tuning";
						labelFly.Play ();
						grAcc.Play ();
				} else if (index == 5) {
						btnNitroTank.IsEnabled = true;
						btnNitroRate.IsEnabled = true;
						btnNitroMulti.IsEnabled = true;
						btnPolice.IsEnabled = true;
						btnAcceleration.IsEnabled = true;
						btnHanlding.IsEnabled = false;
			
						labelItemsInfo.Text = HandlingInfo;
						labelInfo.Text = "Wheel Tuning";
						labelFly.Play ();
						grHandling.Play ();
				}
		}
	#endregion

    #region Next Car
		void NextCar ()
		{
				transform.eulerAngles = new Vector3 (0, 0, 0);
				cars [carIndex].SetActive (false);
				carIndex = (carIndex + 1) % cars.Length;
				cars [carIndex].SetActive (true);

				for (int i = 0; i < NameOfCar.Length; i++) {
						if (i == carIndex)
								NameOfCar [i].SetActive (true);
						else
								NameOfCar [i].SetActive (false);
				}			

				//Color of high quality car
				colorMaterial [toShopCarID (carIndex)].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
				lowMaterial [toShopCarID (carIndex)].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);

				if (carIndex == 14) {
						if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color == 2) {
								HighColorMaterial [15].SetColor ("_Color", new Color32 (0, 18, 60, 255));
								HighColorMaterial [14].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
						} else {
								HighColorMaterial [15].SetColor ("_Color", colors [0]);
								HighColorMaterial [14].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
						}
				} else {
						HighColorMaterial [carIndex].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
				}
		
				acclerationTween.EndValue = AllCarDescription.getCarAcceleration (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration) / 1.6f;
				SpeedTween.EndValue = AllCarDescription.getCarSpeed (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed) / 420f;
				HandlingTween.EndValue = AllCarDescription.getCarHandling (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling) / 1f;
				NitroTween.EndValue = AllCarDescription.getCarNitro (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro) / 25f;
		
				LoadCarIndicator ();

				acclerationTween.Play ();
				SpeedTween.Play ();
				HandlingTween.Play ();
				NitroTween.Play ();

				LoadUpdateLevel ();
				LoadCarPrice ();
		}
    #endregion

    #region Previous Car
		void PrevCar ()
		{
				transform.eulerAngles = new Vector3 (0, 0, 0);
				cars [carIndex].SetActive (false);
				carIndex--;
				if (carIndex < 0)
						carIndex = cars.Length - 1;
				cars [carIndex].SetActive (true);

				for (int i = 0; i < NameOfCar.Length; i++) {
						if (i == carIndex)
								NameOfCar [i].SetActive (true);
						else
								NameOfCar [i].SetActive (false);
				}

				//Color of high quality car
				colorMaterial [toShopCarID (carIndex)].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
				lowMaterial [toShopCarID (carIndex)].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);

				if (carIndex == 14) {
						if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color == 2) {
								HighColorMaterial [15].SetColor ("_Color", new Color32 (0, 18, 60, 255));
								HighColorMaterial [14].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
						} else {
								HighColorMaterial [15].SetColor ("_Color", colors [0]);
								HighColorMaterial [14].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
						}
				} else {
						HighColorMaterial [carIndex].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
				}

				acclerationTween.EndValue = AllCarDescription.getCarAcceleration (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration) / 1.6f;
				SpeedTween.EndValue = AllCarDescription.getCarSpeed (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed) / 420f;
				HandlingTween.EndValue = AllCarDescription.getCarHandling (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling) / 1f;
				NitroTween.EndValue = AllCarDescription.getCarNitro (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro) / 25f;
		
				LoadCarIndicator ();

				acclerationTween.Play ();
				SpeedTween.Play ();
				HandlingTween.Play ();
				NitroTween.Play ();

				LoadUpdateLevel ();
				LoadCarPrice ();
		}
    #endregion

    #region Load Car Indicator
		void LoadCarIndicator ()
		{			

				LabelIndicatorOfCar [1].Text = AllCarDescription.getCarSpeed (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed) + " Km/h";
				LabelIndicatorOfCar [2].Text = AllCarDescription.getCarHandling (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling) + " Gs";
				LabelIndicatorOfCar [3].Text = AllCarDescription.getCarNitro (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro) + " s";

				switch (carIndex) {
				case 0:
						if (ProfileManager.userProfile.CarProfile [0].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "4.15 s";
						} else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "4.1 s";
						} else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "4.02 s";
						} else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "4 s";
						} else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "3.96 s";
						}
						break;
				case 1:
						if (ProfileManager.userProfile.CarProfile [2].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "4.44 s";
						} else if (ProfileManager.userProfile.CarProfile [2].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "4.37 s";
						} else if (ProfileManager.userProfile.CarProfile [2].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "4.2 s";
						} else if (ProfileManager.userProfile.CarProfile [2].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "4.1 s";
						} else if (ProfileManager.userProfile.CarProfile [2].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "4 s";
						}
						break;
				case 2:
						if (ProfileManager.userProfile.CarProfile [1].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "4.8 s";
						} else if (ProfileManager.userProfile.CarProfile [1].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "4.6 s";
						} else if (ProfileManager.userProfile.CarProfile [1].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "4.34 s";
						} else if (ProfileManager.userProfile.CarProfile [1].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "4.2 s";
						} else if (ProfileManager.userProfile.CarProfile [1].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "4.1 s";
						}
						break;
				case 3:
						if (ProfileManager.userProfile.CarProfile [10].Acceleration == 0)
								LabelIndicatorOfCar [0].Text = "4.7 s";
						else if (ProfileManager.userProfile.CarProfile [10].Acceleration == 1)
								LabelIndicatorOfCar [0].Text = "4.56 s";
						else if (ProfileManager.userProfile.CarProfile [10].Acceleration == 2)
								LabelIndicatorOfCar [0].Text = "4.39 s";
						else if (ProfileManager.userProfile.CarProfile [10].Acceleration == 3)
								LabelIndicatorOfCar [0].Text = "4.1 s";
						else if (ProfileManager.userProfile.CarProfile [10].Acceleration == 4)
								LabelIndicatorOfCar [0].Text = "4 s";
						break;
				case 4:
						if (ProfileManager.userProfile.CarProfile [9].Acceleration == 0)
								LabelIndicatorOfCar [0].Text = "3.2 s";
						else if (ProfileManager.userProfile.CarProfile [9].Acceleration == 1)
								LabelIndicatorOfCar [0].Text = "3.11 s";
						else if (ProfileManager.userProfile.CarProfile [9].Acceleration == 2)
								LabelIndicatorOfCar [0].Text = "3 s";
						else if (ProfileManager.userProfile.CarProfile [9].Acceleration == 3)
								LabelIndicatorOfCar [0].Text = "2.96 s";
						else if (ProfileManager.userProfile.CarProfile [9].Acceleration == 4)
								LabelIndicatorOfCar [0].Text = "2.87 s";
						break;
				case 5:
						if (ProfileManager.userProfile.CarProfile [4].Acceleration == 0)
								LabelIndicatorOfCar [0].Text = "3.4 s";
						else if (ProfileManager.userProfile.CarProfile [4].Acceleration == 1)
								LabelIndicatorOfCar [0].Text = "3.29 s";
						else if (ProfileManager.userProfile.CarProfile [4].Acceleration == 2)
								LabelIndicatorOfCar [0].Text = "3.2 s";
						else if (ProfileManager.userProfile.CarProfile [4].Acceleration == 3)
								LabelIndicatorOfCar [0].Text = "3.08 s";
						else if (ProfileManager.userProfile.CarProfile [4].Acceleration == 4)
								LabelIndicatorOfCar [0].Text = "2.93 s";
						break;
				case 6:
						if (ProfileManager.userProfile.CarProfile [14].Acceleration == 0)
								LabelIndicatorOfCar [0].Text = "3.1 s";
						else if (ProfileManager.userProfile.CarProfile [14].Acceleration == 1)
								LabelIndicatorOfCar [0].Text = "3.02 s";
						else if (ProfileManager.userProfile.CarProfile [14].Acceleration == 2)
								LabelIndicatorOfCar [0].Text = "2.96 s";
						else if (ProfileManager.userProfile.CarProfile [14].Acceleration == 3)
								LabelIndicatorOfCar [0].Text = "2.87 s";
						else if (ProfileManager.userProfile.CarProfile [14].Acceleration == 4)
								LabelIndicatorOfCar [0].Text = "2.78 s";

						break;
				case 7:
						if (ProfileManager.userProfile.CarProfile [11].Acceleration == 0)
								LabelIndicatorOfCar [0].Text = "3.2 s";
						else if (ProfileManager.userProfile.CarProfile [11].Acceleration == 1)
								LabelIndicatorOfCar [0].Text = "3.12 s";
						else if (ProfileManager.userProfile.CarProfile [11].Acceleration == 2)
								LabelIndicatorOfCar [0].Text = "3 s";
						else if (ProfileManager.userProfile.CarProfile [11].Acceleration == 3)
								LabelIndicatorOfCar [0].Text = "2.94 s";
						else if (ProfileManager.userProfile.CarProfile [11].Acceleration == 4)
								LabelIndicatorOfCar [0].Text = "2.88 s";
						break;
				case 8:
						if (ProfileManager.userProfile.CarProfile [7].Acceleration == 0)
								LabelIndicatorOfCar [0].Text = "2.5 s";
						else if (ProfileManager.userProfile.CarProfile [7].Acceleration == 1)
								LabelIndicatorOfCar [0].Text = "2.37 s";
						else if (ProfileManager.userProfile.CarProfile [7].Acceleration == 2)
								LabelIndicatorOfCar [0].Text = "2.2 s";
						else if (ProfileManager.userProfile.CarProfile [7].Acceleration == 3)
								LabelIndicatorOfCar [0].Text = "2.1 s";
						else if (ProfileManager.userProfile.CarProfile [7].Acceleration == 4)
								LabelIndicatorOfCar [0].Text = "2 s";
						break;
				case 9:
						if (ProfileManager.userProfile.CarProfile [6].Acceleration == 0)
								LabelIndicatorOfCar [0].Text = "3.7 s";
						else if (ProfileManager.userProfile.CarProfile [6].Acceleration == 1)
								LabelIndicatorOfCar [0].Text = "3.5 s";
						else if (ProfileManager.userProfile.CarProfile [6].Acceleration == 2)
								LabelIndicatorOfCar [0].Text = "3.32 s";
						else if (ProfileManager.userProfile.CarProfile [6].Acceleration == 3)
								LabelIndicatorOfCar [0].Text = "3.1 s";
						else if (ProfileManager.userProfile.CarProfile [6].Acceleration == 4)
								LabelIndicatorOfCar [0].Text = "3.03 s";

						break;
				case 10:
						if (ProfileManager.userProfile.CarProfile [13].Acceleration == 0)
								LabelIndicatorOfCar [0].Text = "3.7 s";
						else if (ProfileManager.userProfile.CarProfile [13].Acceleration == 1)
								LabelIndicatorOfCar [0].Text = "3.5 s";
						else if (ProfileManager.userProfile.CarProfile [13].Acceleration == 2)
								LabelIndicatorOfCar [0].Text = "3.32 s";
						else if (ProfileManager.userProfile.CarProfile [13].Acceleration == 3)
								LabelIndicatorOfCar [0].Text = "3.21 s";
						else if (ProfileManager.userProfile.CarProfile [13].Acceleration == 4)
								LabelIndicatorOfCar [0].Text = "3 s";
						break;
				case 11:
						if (ProfileManager.userProfile.CarProfile [5].Acceleration == 0)
								LabelIndicatorOfCar [0].Text = "2.8 s";
						else if (ProfileManager.userProfile.CarProfile [5].Acceleration == 1)
								LabelIndicatorOfCar [0].Text = "2.6 s";
						else if (ProfileManager.userProfile.CarProfile [5].Acceleration == 2)
								LabelIndicatorOfCar [0].Text = "2.4 s";
						else if (ProfileManager.userProfile.CarProfile [5].Acceleration == 3)
								LabelIndicatorOfCar [0].Text = "2.26 s";
						else if (ProfileManager.userProfile.CarProfile [5].Acceleration == 4)
								LabelIndicatorOfCar [0].Text = "2.1 s";
						break;
				case 12:
						if (ProfileManager.userProfile.CarProfile [8].Acceleration == 0)
								LabelIndicatorOfCar [0].Text = "2.8 s";
						else if (ProfileManager.userProfile.CarProfile [8].Acceleration == 1)
								LabelIndicatorOfCar [0].Text = "2.65 s";
						else if (ProfileManager.userProfile.CarProfile [8].Acceleration == 2)
								LabelIndicatorOfCar [0].Text = "2.47 s";
						else if (ProfileManager.userProfile.CarProfile [8].Acceleration == 3)
								LabelIndicatorOfCar [0].Text = "2.3 s";
						else if (ProfileManager.userProfile.CarProfile [8].Acceleration == 4)
								LabelIndicatorOfCar [0].Text = "2.1 s";
						break;
				case 13:
						if (ProfileManager.userProfile.CarProfile [12].Acceleration == 0)
								LabelIndicatorOfCar [0].Text = "3.2 s";
						else if (ProfileManager.userProfile.CarProfile [12].Acceleration == 1)
								LabelIndicatorOfCar [0].Text = "3 s";
						else if (ProfileManager.userProfile.CarProfile [12].Acceleration == 2)
								LabelIndicatorOfCar [0].Text = "2.87 s";
						else if (ProfileManager.userProfile.CarProfile [12].Acceleration == 3)
								LabelIndicatorOfCar [0].Text = "2.6 s";
						else if (ProfileManager.userProfile.CarProfile [12].Acceleration == 4)
								LabelIndicatorOfCar [0].Text = "2.49 s";
						break;
				case 14:
						if (ProfileManager.userProfile.CarProfile [3].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "2.6 s";
						} else if (ProfileManager.userProfile.CarProfile [3].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "2.41 s";
						} else if (ProfileManager.userProfile.CarProfile [3].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "2.3 s";
						} else if (ProfileManager.userProfile.CarProfile [3].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "2.12 s";
						} else if (ProfileManager.userProfile.CarProfile [3].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "1.96 s";
						}

						break;
				default:
						if (ProfileManager.userProfile.CarProfile [0].Acceleration == 0)
								LabelIndicatorOfCar [0].Text = "4.15 s";
						else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 1)
								LabelIndicatorOfCar [0].Text = "4.1 s";
						else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 2)
								LabelIndicatorOfCar [0].Text = "4.02 s";
						else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 3)
								LabelIndicatorOfCar [0].Text = "4.4 s";
						else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 4)
								LabelIndicatorOfCar [0].Text = "3.96 s";
						break;
				}
		}
    #endregion

	#region Load Update Car Indicator
		void LoadUpdateCarIndicator ()
		{
				IndicatorUpdate [0].FillAmount = AllCarDescription.getCarAcceleration (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration) / 1.6f;
				IndicatorUpdate [1].FillAmount = AllCarDescription.getCarSpeed (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed) / 420f;
				IndicatorUpdate [2].FillAmount = AllCarDescription.getCarHandling (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling) / AllCarDescription.getCarHandling (GameData.getCarNameShop (carIndex), 4);
				IndicatorUpdate [3].FillAmount = AllCarDescription.getCarNitro (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro) / AllCarDescription.getCarNitro (GameData.getCarNameShop (carIndex), 4);

				IndicatorUpdate [4].FillAmount = AllCarDescription.getCarAcceleration (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1) / 1.6f;
				IndicatorUpdate [5].FillAmount = AllCarDescription.getCarSpeed (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1) / 420f;
				IndicatorUpdate [6].FillAmount = AllCarDescription.getCarHandling (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1) / AllCarDescription.getCarHandling (GameData.getCarNameShop (carIndex), 4);
				IndicatorUpdate [7].FillAmount = AllCarDescription.getCarNitro (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1) / AllCarDescription.getCarNitro (GameData.getCarNameShop (carIndex), 4);
		
				LabelIndicatorOfCar [1].Text = AllCarDescription.getCarSpeed (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed) + " Km/h";
				LabelIndicatorOfCar [2].Text = AllCarDescription.getCarHandling (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling) + " Gs";
				LabelIndicatorOfCar [3].Text = AllCarDescription.getCarNitro (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro) + " s";

				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed < 4) {
						LabelIndicatorOfCar [5].Text = "> " + AllCarDescription.getCarSpeed (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1) + " Km/h";
		
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed >= 4) {
						LabelIndicatorOfCar [5].Text = AllCarDescription.getCarSpeed (GameData.getCarNameShop (carIndex), 4) + " Km/h";
				} else {
						LabelIndicatorOfCar [5].Text = AllCarDescription.getCarSpeed (GameData.getCarNameShop (carIndex), 4) + " Km/h";
				}

				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling < 4) {
						LabelIndicatorOfCar [6].Text = "> " + AllCarDescription.getCarHandling (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1) + " Gs";

				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling >= 4) {
						LabelIndicatorOfCar [6].Text = AllCarDescription.getCarHandling (GameData.getCarNameShop (carIndex), 4) + " Gs";
				} else {
						LabelIndicatorOfCar [6].Text = AllCarDescription.getCarHandling (GameData.getCarNameShop (carIndex), 4) + " Gs";
				}

				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro < 4) {
						LabelIndicatorOfCar [7].Text = "> " + AllCarDescription.getCarNitro (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1) + " s";
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro >= 4) {
						LabelIndicatorOfCar [7].Text = AllCarDescription.getCarNitro (GameData.getCarNameShop (carIndex), 4) + " s";
				} else {
						LabelIndicatorOfCar [7].Text = AllCarDescription.getCarNitro (GameData.getCarNameShop (carIndex), 4) + " s";
				}


				switch (carIndex) {
				case 0:
						if (ProfileManager.userProfile.CarProfile [0].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "4.15 s";
								LabelIndicatorOfCar [4].Text = "> 4.1 s";
						} else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "4.1 s";
								LabelIndicatorOfCar [4].Text = "> 4.02 s";
						} else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "4.02 s";
								LabelIndicatorOfCar [4].Text = "> 4 s";
						} else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "4 s";
								LabelIndicatorOfCar [4].Text = "> 3.96 s";
						} else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "3.96 s";
								LabelIndicatorOfCar [4].Text = "3.96 s";
						}
						break;
				case 1:
			
						if (ProfileManager.userProfile.CarProfile [2].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "4.44 s";
								LabelIndicatorOfCar [4].Text = "> 4.37 s";
						} else if (ProfileManager.userProfile.CarProfile [2].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "4.37 s";
								LabelIndicatorOfCar [4].Text = "> 4.2 s";
						} else if (ProfileManager.userProfile.CarProfile [2].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "4.2 s";
								LabelIndicatorOfCar [4].Text = "> 4.1 s";
						} else if (ProfileManager.userProfile.CarProfile [2].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "4.1 s";
								LabelIndicatorOfCar [4].Text = "> 4" +
										"s";
						} else if (ProfileManager.userProfile.CarProfile [2].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "4 s";
								LabelIndicatorOfCar [4].Text = "4 s";
						}
						break;
				case 2:
						if (ProfileManager.userProfile.CarProfile [1].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "4.8 s";
								LabelIndicatorOfCar [4].Text = "> 4.6 s";
						} else if (ProfileManager.userProfile.CarProfile [1].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "4.6 s";
								LabelIndicatorOfCar [4].Text = "> 4.34 s";
						} else if (ProfileManager.userProfile.CarProfile [1].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "4.34 s";
								LabelIndicatorOfCar [4].Text = "> 4.2 s";
						} else if (ProfileManager.userProfile.CarProfile [1].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "4.2 s";
								LabelIndicatorOfCar [4].Text = "> 4.1 s";
						} else if (ProfileManager.userProfile.CarProfile [1].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "4.1 s";
								LabelIndicatorOfCar [4].Text = "4.1 s";
						}
						break;
				case 3:
						if (ProfileManager.userProfile.CarProfile [10].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "4.7 s";
								LabelIndicatorOfCar [4].Text = "> 4.56 s";
						} else if (ProfileManager.userProfile.CarProfile [10].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "4.56 s";
								LabelIndicatorOfCar [4].Text = "> 4.39 s";
						} else if (ProfileManager.userProfile.CarProfile [10].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "4.39 s";
								LabelIndicatorOfCar [4].Text = "> 4.1 s";
						} else if (ProfileManager.userProfile.CarProfile [10].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "4.1 s";
								LabelIndicatorOfCar [4].Text = "> 4 s";
						} else if (ProfileManager.userProfile.CarProfile [10].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "4 s";
								LabelIndicatorOfCar [4].Text = "4 s";
						}
						break;
				case 4:
						if (ProfileManager.userProfile.CarProfile [9].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "3.2 s";
								LabelIndicatorOfCar [4].Text = "> 3.11 s";
						} else if (ProfileManager.userProfile.CarProfile [9].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "3.11 s";
								LabelIndicatorOfCar [4].Text = "> 3 s";
						} else if (ProfileManager.userProfile.CarProfile [9].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "3 s";
								LabelIndicatorOfCar [4].Text = "> 2.96 s";
						} else if (ProfileManager.userProfile.CarProfile [9].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "2.96 s";
								LabelIndicatorOfCar [4].Text = "> 2.87 s";
						} else if (ProfileManager.userProfile.CarProfile [9].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "2.87 s";
								LabelIndicatorOfCar [4].Text = "2.87 s";
						}
						break;
				case 5:
						if (ProfileManager.userProfile.CarProfile [4].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "3.4 s";
								LabelIndicatorOfCar [4].Text = "> 3.29 s";
						} else if (ProfileManager.userProfile.CarProfile [4].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "3.29 s";
								LabelIndicatorOfCar [4].Text = "> 3.2 s";
						} else if (ProfileManager.userProfile.CarProfile [4].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "3.2 s";
								LabelIndicatorOfCar [4].Text = "> 3.08 s";
						} else if (ProfileManager.userProfile.CarProfile [4].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "3.08 s";
								LabelIndicatorOfCar [4].Text = "> 2.93 s";
						} else if (ProfileManager.userProfile.CarProfile [4].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "2.93 s";
								LabelIndicatorOfCar [4].Text = "2.93 s";
						}
						break;
				case 6:
						if (ProfileManager.userProfile.CarProfile [14].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "3.1 s";
								LabelIndicatorOfCar [4].Text = "> 3.02 s";
						} else if (ProfileManager.userProfile.CarProfile [14].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "3.02 s";
								LabelIndicatorOfCar [4].Text = "> 2.96 s";
						} else if (ProfileManager.userProfile.CarProfile [14].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "2.96 s";
								LabelIndicatorOfCar [4].Text = "> 2.87 s";
						} else if (ProfileManager.userProfile.CarProfile [14].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "2.87 s";
								LabelIndicatorOfCar [4].Text = "> 2.78 s";
						} else if (ProfileManager.userProfile.CarProfile [14].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "2.78 s";
								LabelIndicatorOfCar [4].Text = "2.78 s";
						}
						break;
				case 7:
						if (ProfileManager.userProfile.CarProfile [11].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "3.2 s";
								LabelIndicatorOfCar [4].Text = "> 3.12 s";
						} else if (ProfileManager.userProfile.CarProfile [11].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "3.12 s";
								LabelIndicatorOfCar [4].Text = "> 3 s";
						} else if (ProfileManager.userProfile.CarProfile [11].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "3 s";
								LabelIndicatorOfCar [4].Text = "> 2.94 s";
						} else if (ProfileManager.userProfile.CarProfile [11].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "2.94 s";
								LabelIndicatorOfCar [4].Text = "> 2.88 s";
						} else if (ProfileManager.userProfile.CarProfile [11].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "2.88 s";
								LabelIndicatorOfCar [4].Text = "2.88 s";
						}
						break;
				case 8:
						if (ProfileManager.userProfile.CarProfile [7].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "2.5 s";
								LabelIndicatorOfCar [4].Text = "> 2.37 s";
						} else if (ProfileManager.userProfile.CarProfile [7].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "2.37 s";
								LabelIndicatorOfCar [4].Text = "> 2.2 s";
						} else if (ProfileManager.userProfile.CarProfile [7].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "2.2 s";
								LabelIndicatorOfCar [4].Text = "> 2.1 s";
						} else if (ProfileManager.userProfile.CarProfile [7].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "2.1 s";
								LabelIndicatorOfCar [4].Text = "> 2 s";
						} else if (ProfileManager.userProfile.CarProfile [7].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "2 s";
								LabelIndicatorOfCar [4].Text = "2 s";
						}
						break;
				case 9:
						if (ProfileManager.userProfile.CarProfile [6].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "3.7 s";
								LabelIndicatorOfCar [4].Text = "> 3.5 s";
						} else if (ProfileManager.userProfile.CarProfile [6].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "3.5 s";
								LabelIndicatorOfCar [4].Text = "> 3.32 s";
						} else if (ProfileManager.userProfile.CarProfile [6].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "3.32 s";
								LabelIndicatorOfCar [4].Text = "> 3.1 s";
						} else if (ProfileManager.userProfile.CarProfile [6].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "3.1 s";
								LabelIndicatorOfCar [4].Text = "> 3.03 s";
						} else if (ProfileManager.userProfile.CarProfile [6].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "3.03 s";
								LabelIndicatorOfCar [4].Text = "3.03 s";
						}
						break;
				case 10:
						if (ProfileManager.userProfile.CarProfile [13].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "3.7 s";
								LabelIndicatorOfCar [4].Text = "> 3.5 s";
						} else if (ProfileManager.userProfile.CarProfile [13].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "3.5 s";
								LabelIndicatorOfCar [4].Text = "> 3.32 s";
						} else if (ProfileManager.userProfile.CarProfile [13].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "3.32 s";
								LabelIndicatorOfCar [4].Text = "> 3.21 s";
						} else if (ProfileManager.userProfile.CarProfile [13].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "3.21 s";
								LabelIndicatorOfCar [4].Text = "> 3 s";
						} else if (ProfileManager.userProfile.CarProfile [13].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "3 s";
								LabelIndicatorOfCar [4].Text = "3 s";
						}
						break;
				case 11:
						if (ProfileManager.userProfile.CarProfile [5].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "2.8 s";
								LabelIndicatorOfCar [4].Text = "> 2.6 s";
						} else if (ProfileManager.userProfile.CarProfile [5].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "2.6 s";
								LabelIndicatorOfCar [4].Text = "> 2.4 s";
						} else if (ProfileManager.userProfile.CarProfile [5].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "2.4 s";
								LabelIndicatorOfCar [4].Text = "> 2.26 s";
						} else if (ProfileManager.userProfile.CarProfile [5].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "2.26 s";
								LabelIndicatorOfCar [4].Text = "> 2.1 s";
						} else if (ProfileManager.userProfile.CarProfile [5].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "2.1 s";
								LabelIndicatorOfCar [4].Text = "2.1 s";
						}
						break;
				case 12:
						if (ProfileManager.userProfile.CarProfile [8].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "2.8 s";
								LabelIndicatorOfCar [4].Text = "> 2.65 s";
						} else if (ProfileManager.userProfile.CarProfile [8].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "2.65 s";
								LabelIndicatorOfCar [4].Text = "> 2.47 s";
						} else if (ProfileManager.userProfile.CarProfile [8].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "2.47 s";
								LabelIndicatorOfCar [4].Text = "> 2.3 s";
						} else if (ProfileManager.userProfile.CarProfile [8].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "2.3 s";
								LabelIndicatorOfCar [4].Text = "> 2.1 s";
						} else if (ProfileManager.userProfile.CarProfile [8].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "2.1 s";
								LabelIndicatorOfCar [4].Text = "2.1 s";
						}
						break;
				case 13:
						if (ProfileManager.userProfile.CarProfile [12].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "3.2 s";
								LabelIndicatorOfCar [4].Text = "> 3 s";
						} else if (ProfileManager.userProfile.CarProfile [12].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "3 s";
								LabelIndicatorOfCar [4].Text = "> 2.87 s";
						} else if (ProfileManager.userProfile.CarProfile [12].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "2.87 s";
								LabelIndicatorOfCar [4].Text = "> 2.6 s";
						} else if (ProfileManager.userProfile.CarProfile [12].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "2.6 s";
								LabelIndicatorOfCar [4].Text = "> 2.49 s";
						} else if (ProfileManager.userProfile.CarProfile [12].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "2.49 s";
								LabelIndicatorOfCar [4].Text = "2.49 s";
						}
						break;
				case 14:
						if (ProfileManager.userProfile.CarProfile [3].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "2.6 s";
								LabelIndicatorOfCar [4].Text = "> 2.41 s";
						} else if (ProfileManager.userProfile.CarProfile [3].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "2.41 s";
								LabelIndicatorOfCar [4].Text = "> 2.3 s";
						} else if (ProfileManager.userProfile.CarProfile [3].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "2.3 s";
								LabelIndicatorOfCar [4].Text = "> 2.12 s";
						} else if (ProfileManager.userProfile.CarProfile [3].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "2.12 s";
								LabelIndicatorOfCar [4].Text = "> 1.96 s";
						} else if (ProfileManager.userProfile.CarProfile [3].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "1.96 s";
								LabelIndicatorOfCar [4].Text = "1.96 s";
						}
						break;
				default:
						if (ProfileManager.userProfile.CarProfile [0].Acceleration == 0) {
								LabelIndicatorOfCar [0].Text = "4.15 s";
								LabelIndicatorOfCar [4].Text = "> 4.1 s";
						} else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 1) {
								LabelIndicatorOfCar [0].Text = "4.1 s";
								LabelIndicatorOfCar [4].Text = "> 4.02 s";
						} else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 2) {
								LabelIndicatorOfCar [0].Text = "4.02 s";
								LabelIndicatorOfCar [4].Text = "> 4 s";
						} else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 3) {
								LabelIndicatorOfCar [0].Text = "4 s";
								LabelIndicatorOfCar [4].Text = "> 3.96 s";
						} else if (ProfileManager.userProfile.CarProfile [0].Acceleration == 4) {
								LabelIndicatorOfCar [0].Text = "3.96 s";
								LabelIndicatorOfCar [4].Text = "3.96 s";
						}
						break;
				}
		}
	#endregion

    #region Update Car Indicator
		public void UpdateCarIndicator (dfControl control, dfMouseEventArgs mouseEvent)
		{
				if (control.name == "Panel Acceleration") {
						#region Update Acceleration
						UpdateAcclerationIndicator ();
						#endregion
				} else if (control.name == "Panel Speed") {
						#region Update Speed
						UpdateSpeedIndicator ();
						#endregion
				} else if (control.name == "Panel Handling") {
						#region Update Handling
						UpdateHandlingIndicator ();
						#endregion
				} else if (control.name == "Panel Nitro") {
						#region Update Nitro
						UpdateNitroIndicator ();
						#endregion
				}
				LoadUpdateCarIndicator ();
		}
    #endregion

    #region Buy Car
		public void BuyCar (dfControl control, dfMouseEventArgs mouseEvent)
		{
				sound.ButtonClick ();
				//if (carIndex == 13 || carIndex == 14) {
				//		colorMaterial [carIndex].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
				//		lowMaterial [carIndex].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);

				//		Debug.Log ("Buy real USD");

				//		if (carIndex == 13) {
				//				KORPaymentHandler.purchaseProduct (KORPaymentHandler.CAR_PAGANI_ZONDA);
				//		} else if (carIndex == 14) {
				//				KORPaymentHandler.purchaseProduct (KORPaymentHandler.CAR_BUGATTI_VEYRON);
				//		}

				//} else 
                if (carIndex == 2 || carIndex == 8 || carIndex == 12 || carIndex == 13 || carIndex == 14) {
						float price = AllCarDescription.getCarPrice (GameData.getCarNameShop (carIndex));
						if (ProfileManager.userProfile.Diamond >= price) {
								ProfileManager.userProfile.SelectedCar = toGamePlayCarID (carIndex);
								ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].IsBought = true;
								ProfileManager.userProfile.Diamond -= int.Parse (price.ToString ());
								btnBuyCar.IsVisible = false;
								btnRace.IsEnabled = true;
								colorMaterial [carIndex].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
								lowMaterial [carIndex].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", (AllCarDescription.getCarPrice (GameData.getCarNameShop (carIndex))) - ProfileManager.userProfile.Diamond) + " cash more. ";
						}
				} else {
						float price = AllCarDescription.getCarPrice (GameData.getCarNameShop (carIndex));
			
						if (ProfileManager.userProfile.Money >= price) {
								ProfileManager.userProfile.SelectedCar = toGamePlayCarID (carIndex);
								ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].IsBought = true;
								ProfileManager.userProfile.Money -= int.Parse (price.ToString ());
								btnBuyCar.IsVisible = false;
								btnRace.IsEnabled = true;
								colorMaterial [carIndex].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
								lowMaterial [carIndex].SetColor ("_Color", colors [ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Color]);
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", (AllCarDescription.getCarPrice (GameData.getCarNameShop (carIndex))) - ProfileManager.userProfile.Money) + " coin more.";
						}
				}
		}
    #endregion

    #region Load Car Price
		void LoadCarPrice ()
		{
				if (carIndex == 0)
						btnBuyCar.IsVisible = false;
				else
						btnBuyCar.IsVisible = true;

				if (freeLookCam.IsAutoRotation == true) {
						if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].IsBought)
								btnBuyCar.IsVisible = false;
						else
								btnBuyCar.IsVisible = true;
				} else {
						btnBuyCar.IsVisible = false;
				}
		}
    #endregion

    #region Load Car Update Level
		void LoadUpdateLevel ()
		{
				LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
				LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
				LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
				LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));

				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration == 1) {
						LabelUpdateLevel [0].Text = "Level 2";
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration == 2) {
						LabelUpdateLevel [0].Text = "Level 3";
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration == 3) {
						LabelUpdateLevel [0].Text = "Level 4";
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration == 4) {
						LabelUpdateLevel [0].Text = "Max";
						LabelUpdatePrice [0].Text = "";
				} else {
						LabelUpdateLevel [0].Text = "Level 1";
				}

				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed == 1) {
						LabelUpdateLevel [1].Text = "Level 2";
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed == 2) {
						LabelUpdateLevel [1].Text = "Level 3";
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed == 3) {
						LabelUpdateLevel [1].Text = "Level 4";
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed == 4) {
						LabelUpdateLevel [1].Text = "Max";
						LabelUpdatePrice [1].Text = "";
				} else {
						LabelUpdateLevel [1].Text = "Level 1";
				}

				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling == 1) {
						LabelUpdateLevel [2].Text = "Level 2";
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling == 2) {
						LabelUpdateLevel [2].Text = "Level 3";
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling == 3) {
						LabelUpdateLevel [2].Text = "Level 4";
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling == 4) {
						LabelUpdateLevel [2].Text = "Max";
						LabelUpdatePrice [2].Text = "";
				} else {
						LabelUpdateLevel [2].Text = "Level 1";
				}

				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro == 1) {
						LabelUpdateLevel [3].Text = "Level 2";
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro == 2) {
						LabelUpdateLevel [3].Text = "Level 3";
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro == 3) {
						LabelUpdateLevel [3].Text = "Level 4";
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro == 4) {
						LabelUpdateLevel [3].Text = "Max";
						LabelUpdatePrice [3].Text = "";
				} else {
						LabelUpdateLevel [3].Text = "Level 1";
				}
		}
    #endregion

	#region Get Car Index
		int toShopCarID (int PlayerID)
		{
				switch (PlayerID) {
				case 0:
						return 0;
				case 1:
						return 2;
				case 2:
						return 1;
				case 3:
						return 14;
				case 4:
						return 5;
				case 5:
						return 11;
				case 6:
						return 9;
				case 7:
						return 8;
				case 8:
						return 12;
				case 9:
						return 4;
				case 10:
						return 3;
				case 11:
						return 7;
				case 12:
						return 13;
				case 13:
						return 10;
				case 14:
						return 3;
				default:
						return 0;
				}
		}
	#endregion

	#region Update Acceleration Indicator
		void UpdateAcclerationIndicator ()
		{
				sound.ButtonClick ();
				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration == 0) {
						LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										LabelUpdateLevel [0].Text = "Level 2";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 1;
										LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										LabelUpdateLevel [0].Text = "Level 2";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 1;
										LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 1;
										LabelUpdateLevel [0].Text = "Level 2";
										LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
								} else {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 1;
										LabelUpdateLevel [0].Text = "Level 2";
										LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
								}
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration == 1) {
						LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 2;
										LabelUpdateLevel [0].Text = "Level 3";
										LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 2;
										LabelUpdateLevel [0].Text = "Level 3";
										LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 2;
										LabelUpdateLevel [0].Text = "Level 3";
										LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
								} else {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 2;
										LabelUpdateLevel [0].Text = "Level 3";
										LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
								}
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration == 2) {
						LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 3;
										LabelUpdateLevel [0].Text = "Level 4";
										LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 3;
										LabelUpdateLevel [0].Text = "Level 4";
										LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 3;
										LabelUpdateLevel [0].Text = "Level 4";
										LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
					
								} else {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 3;
										LabelUpdateLevel [0].Text = "Level 4";
										LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
								}
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration == 3) {
						LabelUpdatePrice [0].Text = string.Format ("{0:n00}", AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 4;
										LabelUpdateLevel [0].Text = "Max";
										LabelUpdatePrice [0].Text = string.Empty;
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 4;
										LabelUpdateLevel [0].Text = "Max";
										LabelUpdatePrice [0].Text = string.Empty;
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 4;
										LabelUpdateLevel [0].Text = "Max";
										LabelUpdatePrice [0].Text = string.Empty;
								} else {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration = 4;
										LabelUpdateLevel [0].Text = "Max";
										LabelUpdatePrice [0].Text = string.Empty;
								}	
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarAccelerationUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Acceleration == 4) {
						LabelUpdateLevel [0].Text = "Max";
						LabelUpdatePrice [0].Text = string.Empty;
				}
		}
	#endregion
	
	#region Update Speed Indicator
		void UpdateSpeedIndicator ()
		{
				sound.ButtonClick ();
				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed == 0) {
						LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 1;
										LabelUpdateLevel [1].Text = "Level 2";
										LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 1;
										LabelUpdateLevel [1].Text = "Level 2";
										LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 1;
										LabelUpdateLevel [1].Text = "Level 2";
										LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
								} else {
					
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 1;
										LabelUpdateLevel [1].Text = "Level 2";
										LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
								}
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed == 1) {
						LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										LabelUpdateLevel [1].Text = "Level 3";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 2;
										LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										LabelUpdateLevel [1].Text = "Level 3";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 2;
										LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										LabelUpdateLevel [1].Text = "Level 3";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 2;
										LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
								} else {
					
										LabelUpdateLevel [1].Text = "Level 3";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 2;
										LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
								}
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed == 2) {
						LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										LabelUpdateLevel [1].Text = "Level 4";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 3;
										LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										LabelUpdateLevel [1].Text = "Level 4";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 3;
										LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										LabelUpdateLevel [1].Text = "Level 4";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 3;
										LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
								} else {
					
										LabelUpdateLevel [1].Text = "Level 4";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 3;
										LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
								}			
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed == 3) {
						LabelUpdatePrice [1].Text = string.Format ("{0:n00}", AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										LabelUpdateLevel [1].Text = "Max";
										LabelUpdatePrice [1].Text = string.Empty;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 4;
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										LabelUpdateLevel [1].Text = "Max";
										LabelUpdatePrice [1].Text = string.Empty;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 4;
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										LabelUpdateLevel [1].Text = "Max";
										LabelUpdatePrice [1].Text = string.Empty;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 4;
								} else {
										LabelUpdateLevel [1].Text = "Max";
										LabelUpdatePrice [1].Text = string.Empty;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed = 4;
								}			
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarSpeedUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Speed == 4) {
						LabelUpdateLevel [1].Text = "Max";
						LabelUpdatePrice [1].Text = string.Empty;
				}
		}
	#endregion
	
	#region Update Handling Indicator
		void UpdateHandlingIndicator ()
		{
				sound.ButtonClick ();
				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling == 0) {
						LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 1;
										LabelUpdateLevel [2].Text = "Level 2";
										LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 1;
										LabelUpdateLevel [2].Text = "Level 2";
										LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 1;
										LabelUpdateLevel [2].Text = "Level 2";
										LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
								} else {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 1;
										LabelUpdateLevel [2].Text = "Level 2";
										LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
								}			
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling == 1) {
						LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										LabelUpdateLevel [2].Text = "Level 3";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 2;
										LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										LabelUpdateLevel [2].Text = "Level 3";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 2;
										LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										LabelUpdateLevel [2].Text = "Level 3";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 2;
										LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
								} else {
										LabelUpdateLevel [2].Text = "Level 3";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 2;
										LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
								}			
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling == 2) {
						LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										LabelUpdateLevel [2].Text = "Level 4";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 3;
										LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										LabelUpdateLevel [2].Text = "Level 4";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 3;
										LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										LabelUpdateLevel [2].Text = "Level 4";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 3;
										LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
								} else {
										LabelUpdateLevel [2].Text = "Level 4";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 3;
										LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
								}			
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling == 3) {
						LabelUpdatePrice [2].Text = string.Format ("{0:n00}", AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										LabelUpdateLevel [2].Text = "Max";
										LabelUpdatePrice [2].Text = string.Empty;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 4;
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										LabelUpdateLevel [2].Text = "Max";
										LabelUpdatePrice [2].Text = string.Empty;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 4;
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										LabelUpdateLevel [2].Text = "Max";
										LabelUpdatePrice [2].Text = string.Empty;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 4;
								} else {
										LabelUpdateLevel [2].Text = "Max";
										LabelUpdatePrice [2].Text = string.Empty;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling = 4;
								}			
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarHandlingUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Handling == 4) {
						LabelUpdateLevel [2].Text = "Max";
						LabelUpdatePrice [2].Text = string.Empty;
				}
		}
	#endregion
	
	#region Update Nitro Indicator
		void UpdateNitroIndicator ()
		{
				sound.ButtonClick ();
				if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro == 0) {
						LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 1;
										LabelUpdateLevel [3].Text = "Level 2";
										LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 1;
										LabelUpdateLevel [3].Text = "Level 2";
										LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 1;
										LabelUpdateLevel [3].Text = "Level 2";
										LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
								} else {
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 1;
										LabelUpdateLevel [3].Text = "Level 2";
										LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
								}			
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro == 1) {
						LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										LabelUpdateLevel [3].Text = "Level 3";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 2;
										LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										LabelUpdateLevel [3].Text = "Level 3";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 2;
										LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										LabelUpdateLevel [3].Text = "Level 3";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 2;
										LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
								} else {
										LabelUpdateLevel [3].Text = "Level 3";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 2;
										LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
								}
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro == 2) {
						LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										LabelUpdateLevel [3].Text = "Level 4";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 3;
										LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										LabelUpdateLevel [3].Text = "Level 4";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 3;
										LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										LabelUpdateLevel [3].Text = "Level 4";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 3;
										LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
								} else {
										LabelUpdateLevel [3].Text = "Level 4";
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 3;
										LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
								}
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro == 3) {
						LabelUpdatePrice [3].Text = string.Format ("{0:n00}", AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1));
						if (ProfileManager.userProfile.Money >= AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1)) {
								ProfileManager.userProfile.Money -= AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1);
								if (carIndex == 0 || carIndex == 1 || carIndex == 2) {
										LabelUpdateLevel [3].Text = "Max";
										LabelUpdatePrice [3].Text = string.Empty;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 4;
								} else if (carIndex == 3 || carIndex == 4 || carIndex == 5 || carIndex == 6) {
										LabelUpdateLevel [3].Text = "Max";
										LabelUpdatePrice [3].Text = string.Empty;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 4;
								} else if (carIndex == 7 || carIndex == 8 || carIndex == 9 || carIndex == 10) {
										LabelUpdateLevel [3].Text = "Max";
										LabelUpdatePrice [3].Text = string.Empty;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 4;
								} else {
										LabelUpdateLevel [3].Text = "Max";
										LabelUpdatePrice [3].Text = string.Empty;
										ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro = 4;
								}			
						} else {
								ShowError ();
								labelErrorDes.Text = "You need " + string.Format ("{0:n00}", ((AllCarDescription.getCarNitroUpgradePrice (GameData.getCarNameShop (carIndex), ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro + 1)) - ProfileManager.userProfile.Money)) + " coins more.";
						}
				} else if (ProfileManager.userProfile.CarProfile [toGamePlayCarID (carIndex)].Nitro == 4) {
						LabelUpdateLevel [3].Text = "Max";
						LabelUpdatePrice [3].Text = string.Empty;
				}
		}
	#endregion
	
		void OnDestroy ()
		{
				PlayerPrefs.Save ();
				MainMenu.isLoadingShop = false;
		}

		void ShowError ()
		{
				panelErrorFly.Play ();
				panelError.IsVisible = true;
				viewCarButton.IsVisible = false;
		}

		int toGamePlayCarID (int carShopID)
		{
				switch (carShopID) {
				case 0:
						return 0;

				case 1:
						return 2;

				case 2:
						return 1;

				case 3:
						return 10;

				case 4:
						return 9;

				case 5:
						return 4;

				case 6:
						return 14;

				case 7:
						return 11;

				case 8:
						return 7;

				case 9:
						return 6;

				case 10:
						return 13;

				case 11:
						return 5;

				case 12:
						return 8;

				case 13:
						return 12;

				case 14:
						return 3;

				default:
						return 0;
				}
		}

		public void viewCar ()
		{
				changeView (freeLookCam.IsAutoRotation);
		}

		public void changeView (bool value)
		{
				if (value == true) {
						viewCarButton.IsVisible = false;

						freeLookCam.IsAutoRotation = false;
			
						buyCarButtonPanel.IsVisible = false;
						buttonPanel.IsVisible = false;
						windowsPanel.IsVisible = false;

						cameraPath.SetActive (false);
			
						freeLookCam.resetCamera ();
						freeLookCam.pivotGameObject.transform.localPosition = new Vector3 (0, 0.5f, 9);

						turnOnLightButton.IsVisible = true;
			
				} else {			
						viewCarButton.IsVisible = true;

						freeLookCam.IsAutoRotation = true;
			
						buyCarButtonPanel.IsVisible = true;
						buttonPanel.IsVisible = true;
						windowsPanel.IsVisible = true;
			
						freeLookCam.pivotGameObject.transform.localPosition = new Vector3 (0, 1.5f, 6);
						cameraPath.SetActive (true);

						turnOnLightButton.IsVisible = false;
				}
		}

		public void CloseError ()
		{
				sound.ButtonClick ();
				if (btnColor.IsEnabled == false || btnBuy.IsEnabled == false) {
						viewCarButton.IsVisible = true;
				} else {
						viewCarButton.IsVisible = false;
				}

				panelError.IsVisible = false;
		}

		public void changeLight ()
		{
				sound.ButtonClick ();
				freeLookCam.flareLayer.enabled = !freeLookCam.flareLayer.enabled;

				if (freeLookCam.flareLayer.enabled == true) {
						changeLightLabel.Text = "LIGHT: ON";
				} else {
						changeLightLabel.Text = "LIGHT: OFF";
				}
		}
}