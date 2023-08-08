using UnityEngine;
using System.Collections;

public class ItemsMenu : MonoBehaviour
{
		public dfButton[] btnEquip;
		public dfLabel[] labelNumberPowerUp;
		public dfPanel panelError/*, panelNotice*/;
		public dfTextureSprite FirstPowerUp, SecondPowerUP, ThirdPowerUp;
		public Texture[] powerImage;
		public dfTextureSprite[] lockItem;
		public dfLabel LabelError/*, LabelNotice*/;

		void Awake ()
		{
				ProfileManager.init ();

				#region Load Nitro Tank
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 0) > 0) {
						btnEquip [0].IsEnabled = true;
						labelNumberPowerUp [0].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 0) + ")";
				} else {
						btnEquip [0].IsEnabled = false;
						labelNumberPowerUp [0].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 0) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 1) > 0) {
						btnEquip [1].IsEnabled = true;
						labelNumberPowerUp [1].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 1) + ")";
				} else {
						btnEquip [1].IsEnabled = false;
						labelNumberPowerUp [1].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 1) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 2) > 0) {
						btnEquip [2].IsEnabled = true;
						labelNumberPowerUp [2].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 2) + ")";
				} else {
						btnEquip [2].IsEnabled = false;
						labelNumberPowerUp [2].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 2) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 3) > 0) {
						btnEquip [3].IsEnabled = true;
						labelNumberPowerUp [3].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 3) + ")";
				} else {
						btnEquip [3].IsEnabled = false;
						labelNumberPowerUp [3].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 3) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 4) > 0) {
						btnEquip [4].IsEnabled = true;
						labelNumberPowerUp [4].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 4) + ")";
				} else {
						btnEquip [4].IsEnabled = false;
						labelNumberPowerUp [4].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 4) + ")";
				}
				#endregion

				#region Load Nitro Rate
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 0) > 0) {
						btnEquip [5].IsEnabled = true;
						labelNumberPowerUp [5].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 0) + ")";
				} else {
						btnEquip [5].IsEnabled = false;
						labelNumberPowerUp [5].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 0) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 1) > 0) {
						btnEquip [6].IsEnabled = true;
						labelNumberPowerUp [6].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 1) + ")";
				} else {
						btnEquip [6].IsEnabled = false;
						labelNumberPowerUp [6].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 1) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 2) > 0) {
						btnEquip [7].IsEnabled = true;
						labelNumberPowerUp [7].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 2) + ")";
				} else {
						btnEquip [7].IsEnabled = false;
						labelNumberPowerUp [7].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 2) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 3) > 0) {
						btnEquip [8].IsEnabled = true;
						labelNumberPowerUp [8].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 3) + ")";
				} else {
						btnEquip [8].IsEnabled = false;
						labelNumberPowerUp [8].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 3) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 4) > 0) {
						btnEquip [9].IsEnabled = true;
						labelNumberPowerUp [9].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 4) + ")";
				} else {
						btnEquip [9].IsEnabled = false;
						labelNumberPowerUp [9].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 4) + ")";
				}
				#endregion

				#region Load Nitro Multi
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 0) > 0) {
						btnEquip [10].IsEnabled = true;
						labelNumberPowerUp [10].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 0) + ")";
				} else {
						btnEquip [10].IsEnabled = false;
						labelNumberPowerUp [10].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 0) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 1) > 0) {
						btnEquip [11].IsEnabled = true;
						labelNumberPowerUp [11].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 1) + ")";
				} else {
						btnEquip [11].IsEnabled = false;
						labelNumberPowerUp [11].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 1) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 2) > 0) {
						btnEquip [12].IsEnabled = true;
						labelNumberPowerUp [12].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 2) + ")";
				} else {
						btnEquip [12].IsEnabled = false;
						labelNumberPowerUp [12].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 2) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 3) > 0) {
						btnEquip [13].IsEnabled = true;
						labelNumberPowerUp [13].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 3) + ")";
				} else {
						btnEquip [13].IsEnabled = false;
						labelNumberPowerUp [13].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 3) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 4) > 0) {
						btnEquip [14].IsEnabled = true;
						labelNumberPowerUp [14].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 4) + ")";
				} else {
						btnEquip [14].IsEnabled = false;
						labelNumberPowerUp [14].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 4) + ")";
				}
				#endregion

				#region Load Police
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 0) > 0) {
						btnEquip [15].IsEnabled = true;
						labelNumberPowerUp [15].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 0) + ")";
				} else {
						btnEquip [15].IsEnabled = false;
						labelNumberPowerUp [15].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 0) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 1) > 0) {
						btnEquip [16].IsEnabled = true;
						labelNumberPowerUp [16].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 1) + ")";
				} else {
						btnEquip [16].IsEnabled = false;
						labelNumberPowerUp [16].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 1) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 2) > 0) {
						btnEquip [17].IsEnabled = true;
						labelNumberPowerUp [17].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 2) + ")";
				} else {
						btnEquip [17].IsEnabled = false;
						labelNumberPowerUp [17].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 2) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 3) > 0) {
						btnEquip [18].IsEnabled = true;
						labelNumberPowerUp [18].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 3) + ")";
				} else {
						btnEquip [18].IsEnabled = false;
						labelNumberPowerUp [18].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 3) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 4) > 0) {
						btnEquip [19].IsEnabled = true;
						labelNumberPowerUp [19].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 4) + ")";
				} else {
						btnEquip [19].IsEnabled = false;
						labelNumberPowerUp [19].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 4) + ")";
				}
				#endregion

				#region Load Acceleration
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 0) > 0) {
						btnEquip [20].IsEnabled = true;
						labelNumberPowerUp [20].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 0) + ")";
				} else {
						btnEquip [20].IsEnabled = false;
						labelNumberPowerUp [20].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 0) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 1) > 0) {
						btnEquip [21].IsEnabled = true;
						labelNumberPowerUp [21].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 1) + ")";
				} else {
						btnEquip [21].IsEnabled = false;
						labelNumberPowerUp [21].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 1) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 2) > 0) {
						btnEquip [22].IsEnabled = true;
						labelNumberPowerUp [22].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 2) + ")";
				} else {
						btnEquip [22].IsEnabled = false;
						labelNumberPowerUp [22].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 2) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 3) > 0) {
						btnEquip [23].IsEnabled = true;
						labelNumberPowerUp [23].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 3) + ")";
				} else {
						btnEquip [23].IsEnabled = false;
						labelNumberPowerUp [23].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 3) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 4) > 0) {
						btnEquip [24].IsEnabled = true;
						labelNumberPowerUp [24].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 4) + ")";
				} else {
						btnEquip [24].IsEnabled = false;
						labelNumberPowerUp [24].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 4) + ")";
				}
				#endregion

				#region Load Handling
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 0) > 0) {
						btnEquip [25].IsEnabled = true;
						labelNumberPowerUp [25].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 0) + ")";
				} else {
						btnEquip [25].IsEnabled = false;
						labelNumberPowerUp [25].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 0) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 1) > 0) {
						btnEquip [26].IsEnabled = true;
						labelNumberPowerUp [26].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 1) + ")";
				} else {
						btnEquip [26].IsEnabled = false;
						labelNumberPowerUp [26].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 1) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 2) > 0) {
						btnEquip [27].IsEnabled = true;
						labelNumberPowerUp [27].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 2) + ")";
				} else {
						btnEquip [27].IsEnabled = false;
						labelNumberPowerUp [27].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 2) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 3) > 0) {
						btnEquip [28].IsEnabled = true;
						labelNumberPowerUp [28].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 3) + ")";
				} else {
						btnEquip [28].IsEnabled = false;
						labelNumberPowerUp [28].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 3) + ")";
				}
				if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 4) > 0) {
						btnEquip [29].IsEnabled = true;
						labelNumberPowerUp [29].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 4) + ")";
				} else {
						btnEquip [29].IsEnabled = false;
						labelNumberPowerUp [29].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 4) + ")";
				}
				#endregion

				if (ProfileManager.userProfile.IsSecondSlotUnlocked == false) {
						lockItem [0].IsVisible = true;
				} else {
						lockItem [0].IsVisible = false;
				}
				if (ProfileManager.userProfile.IsThirdSlotUnlocked == false) {
						lockItem [1].IsVisible = true;
				} else {
						lockItem [1].IsVisible = false;
				}

				if (GameData.firstPowerUp != null) {
						FirstPowerUp.Texture = getPowerUpImage (GameData.firstPowerUp);
				} 
				if (GameData.secondPowerUp != null) {
						SecondPowerUP.Texture = getPowerUpImage (GameData.secondPowerUp);
				} 
				if (GameData.thirdPowerUp != null) {
						ThirdPowerUp.Texture = getPowerUpImage (GameData.thirdPowerUp);
				}
		}

		void Update ()
		{
				if (ProfileManager.userProfile.IsSecondSlotUnlocked == false) {
						lockItem [0].IsVisible = true;
				} else {
						lockItem [0].IsVisible = false;
				}
				if (ProfileManager.userProfile.IsThirdSlotUnlocked == false) {
						lockItem [1].IsVisible = true;
				} else {
						lockItem [1].IsVisible = false;
				}
		}

	#region Buy Items
		public void BuyItemsClick (dfControl control, dfMouseEventArgs mouseEvent)
		{
				if (control.name == "Panel 1") {
						if (ProfileManager.userProfile.Money >= 400) {
								ProfileManager.userProfile.Money -= 400;
								btnEquip [0].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroTankPowerUp (0)));
								ShowNumberOfPowerUpItems (0);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (400 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 2") {
						if (ProfileManager.userProfile.Money >= 600) {
								ProfileManager.userProfile.Money -= 600;
								btnEquip [1].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroTankPowerUp (1)));
								ShowNumberOfPowerUpItems (1);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (600 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 3") {
						if (ProfileManager.userProfile.Money >= 800) {
								ProfileManager.userProfile.Money -= 800;
								btnEquip [2].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroTankPowerUp (2)));
								ShowNumberOfPowerUpItems (2);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (800 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 4") {
						if (ProfileManager.userProfile.Money >= 1000) {
								ProfileManager.userProfile.Money -= 1000;
								btnEquip [3].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroTankPowerUp (3)));
								ShowNumberOfPowerUpItems (3);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1000 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 5") {
						if (ProfileManager.userProfile.Money >= 1200) {
								ProfileManager.userProfile.Money -= 1200;
								btnEquip [4].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroTankPowerUp (4)));
								ShowNumberOfPowerUpItems (4);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1200 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 6") {
						if (ProfileManager.userProfile.Money >= 1250) {
								ProfileManager.userProfile.Money -= 1250;
								btnEquip [5].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroRatePowerUp (0)));
								ShowNumberOfPowerUpItems (5);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1250 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 7") {
						if (ProfileManager.userProfile.Money >= 1450) {
								ProfileManager.userProfile.Money -= 1450;
								btnEquip [6].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroRatePowerUp (1)));
								ShowNumberOfPowerUpItems (6);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1450 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 8") {
						if (ProfileManager.userProfile.Money >= 1600) {
								ProfileManager.userProfile.Money -= 1600;
								btnEquip [7].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroRatePowerUp (2)));
								ShowNumberOfPowerUpItems (7);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1600 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 9") {
						if (ProfileManager.userProfile.Money >= 1850) {
								ProfileManager.userProfile.Money -= 1850;
								btnEquip [8].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroRatePowerUp (3)));
								ShowNumberOfPowerUpItems (8);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1850 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 10") {
						if (ProfileManager.userProfile.Money >= 2000) {
								ProfileManager.userProfile.Money -= 2000;
								btnEquip [9].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroRatePowerUp (4)));
								ShowNumberOfPowerUpItems (9);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 11") {
						if (ProfileManager.userProfile.Money >= 750) {
								ProfileManager.userProfile.Money -= 750;
								btnEquip [10].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroMultiplierPowerUp (0)));
								ShowNumberOfPowerUpItems (10);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (750 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 12") {
						if (ProfileManager.userProfile.Money >= 950) {
								ProfileManager.userProfile.Money -= 950;
								btnEquip [11].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroMultiplierPowerUp (1)));
								ShowNumberOfPowerUpItems (11);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (950 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 13") {
						if (ProfileManager.userProfile.Money >= 1150) {
								ProfileManager.userProfile.Money -= 1150;
								btnEquip [12].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroMultiplierPowerUp (2)));
								ShowNumberOfPowerUpItems (12);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1150 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 14") {
						if (ProfileManager.userProfile.Money >= 1350) {
								ProfileManager.userProfile.Money -= 1350;
								btnEquip [13].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroMultiplierPowerUp (3)));
								ShowNumberOfPowerUpItems (13);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1350 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 15") {
						if (ProfileManager.userProfile.Money >= 1550) {
								ProfileManager.userProfile.Money -= 1550;
								btnEquip [14].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroMultiplierPowerUp (4)));
								ShowNumberOfPowerUpItems (14);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1550 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 16") {
						if (ProfileManager.userProfile.Money >= 1000) {
								ProfileManager.userProfile.Money -= 1000;
								btnEquip [15].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new PolicePreventPowerUp (0)));
								ShowNumberOfPowerUpItems (15);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1000 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 17") {
						if (ProfileManager.userProfile.Money >= 1200) {
								ProfileManager.userProfile.Money -= 1200;
								btnEquip [16].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new PolicePreventPowerUp (1)));
								ShowNumberOfPowerUpItems (16);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1200 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 18") {
						if (ProfileManager.userProfile.Money >= 1400) {
								ProfileManager.userProfile.Money -= 1400;
								btnEquip [17].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new PolicePreventPowerUp (2)));
								ShowNumberOfPowerUpItems (17);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1400 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 19") {
						if (ProfileManager.userProfile.Money >= 1650) {
								ProfileManager.userProfile.Money -= 1650;
								btnEquip [18].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new PolicePreventPowerUp (3)));
								ShowNumberOfPowerUpItems (18);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1650 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 20") {
						if (ProfileManager.userProfile.Money >= 1800) {
								ProfileManager.userProfile.Money -= 1800;
								btnEquip [19].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new PolicePreventPowerUp (4)));
								ShowNumberOfPowerUpItems (19);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1800 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 21") {
						if (ProfileManager.userProfile.Money >= 500) {
								ProfileManager.userProfile.Money -= 500;
								btnEquip [20].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new AccelerationPowerUp (0)));
								ShowNumberOfPowerUpItems (20);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (500 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 22") {
						if (ProfileManager.userProfile.Money >= 700) {
								ProfileManager.userProfile.Money -= 700;
								btnEquip [21].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new AccelerationPowerUp (1)));
								ShowNumberOfPowerUpItems (21);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (700 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 23") {
						if (ProfileManager.userProfile.Money >= 900) {
								ProfileManager.userProfile.Money -= 900;
								btnEquip [22].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new AccelerationPowerUp (2)));
								ShowNumberOfPowerUpItems (22);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (900 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 24") {
						if (ProfileManager.userProfile.Money >= 1100) {
								ProfileManager.userProfile.Money -= 1100;
								btnEquip [23].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new AccelerationPowerUp (3)));
								ShowNumberOfPowerUpItems (23);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1100 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 25") {
						if (ProfileManager.userProfile.Money >= 1250) {
								ProfileManager.userProfile.Money -= 1250;
								btnEquip [24].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new AccelerationPowerUp (4)));
								ShowNumberOfPowerUpItems (24);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1250 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 26") {
						if (ProfileManager.userProfile.Money >= 450) {
								ProfileManager.userProfile.Money -= 450;
								btnEquip [25].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new HandlingPowerUp (0)));
								ShowNumberOfPowerUpItems (25);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (450 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 27") {
						if (ProfileManager.userProfile.Money >= 650) {
								ProfileManager.userProfile.Money -= 650;
								btnEquip [26].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new HandlingPowerUp (1)));
								ShowNumberOfPowerUpItems (26);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (650 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 28") {
						if (ProfileManager.userProfile.Money >= 850) {
								ProfileManager.userProfile.Money -= 850;
								btnEquip [27].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new HandlingPowerUp (2)));
								ShowNumberOfPowerUpItems (27);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (850 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 29") {
						if (ProfileManager.userProfile.Money >= 1050) {
								ProfileManager.userProfile.Money -= 1050;
								btnEquip [28].IsEnabled = true;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new HandlingPowerUp (3)));
								ShowNumberOfPowerUpItems (28);
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1050 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				} else if (control.name == "Panel 30") {
						if (ProfileManager.userProfile.Money >= 1250) {
								ProfileManager.userProfile.Money -= 1250;
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new HandlingPowerUp (4)));
								ShowNumberOfPowerUpItems (29);
								btnEquip [29].IsEnabled = true;
								ProfileManager.userProfile.savePowerUp ();
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", (1250 - ProfileManager.userProfile.Money)) + " coin more. Do you want to buy more coin?";
						}
				}
		}
	#endregion

	#region Equip Items
		public void EquipItemsClick (dfControl control, dfMouseEventArgs mouseEvent)
		{
				if (control.name == "Button Equip Nitro Tank 1") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 0) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new NitroTankPowerUp (0));
										RemoveItems (4, 0);			
										labelNumberPowerUp [0].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 0) + ")";
					
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new NitroTankPowerUp (0));
												RemoveItems (4, 0);			
												labelNumberPowerUp [0].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 0) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new NitroTankPowerUp (0));
												RemoveItems (4, 0);			
												labelNumberPowerUp [0].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 0) + ")";
										}
								}	
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Nitro Tank 2") {

						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 1) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new NitroTankPowerUp (1));
										RemoveItems (4, 1);
										labelNumberPowerUp [1].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 1) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new NitroTankPowerUp (1));
												RemoveItems (4, 1);
												labelNumberPowerUp [1].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 1) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new NitroTankPowerUp (1));
												RemoveItems (4, 1);
												labelNumberPowerUp [1].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 1) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Nitro Tank 3") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 2) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new NitroTankPowerUp (2));
										RemoveItems (4, 2);
										labelNumberPowerUp [2].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 2) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new NitroTankPowerUp (2));
												RemoveItems (4, 2);
												labelNumberPowerUp [2].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 2) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new NitroTankPowerUp (2));
												RemoveItems (4, 2);
												labelNumberPowerUp [2].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 2) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Nitro Tank 4") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 3) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new NitroTankPowerUp (3));
										RemoveItems (4, 3);
										labelNumberPowerUp [3].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 3) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new NitroTankPowerUp (3));
												RemoveItems (4, 3);
												labelNumberPowerUp [3].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 3) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new NitroTankPowerUp (3));
												RemoveItems (4, 3);
												labelNumberPowerUp [3].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 3) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Nitro Tank 5") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 4) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new NitroTankPowerUp (4));
										RemoveItems (4, 4);
										labelNumberPowerUp [4].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 4) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new NitroTankPowerUp (4));
												RemoveItems (4, 4);
												labelNumberPowerUp [4].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 4) + ")";
										} else if (GameData.thirdPowerUp == null) {
												if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
														EquipItems (new NitroTankPowerUp (4));
														RemoveItems (4, 4);
														labelNumberPowerUp [4].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 4) + ")";
												}	
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Nitro Rate 1") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 0) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new NitroRatePowerUp (0));
										RemoveItems (3, 0);
										labelNumberPowerUp [5].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 0) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new NitroRatePowerUp (0));
												RemoveItems (3, 0);
												labelNumberPowerUp [5].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 0) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new NitroRatePowerUp (0));
												RemoveItems (3, 0);
												labelNumberPowerUp [5].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 0) + ")";
										} 
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Nitro Rate 2") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 1) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new NitroRatePowerUp (1));
										RemoveItems (3, 1);
										labelNumberPowerUp [6].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 1) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new NitroRatePowerUp (1));
												RemoveItems (3, 1);
												labelNumberPowerUp [6].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 1) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new NitroRatePowerUp (1));
												RemoveItems (3, 1);
												labelNumberPowerUp [6].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 1) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Nitro Rate 3") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 2) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new NitroRatePowerUp (2));
										RemoveItems (3, 2);
										labelNumberPowerUp [7].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 2) + ")";
				
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new NitroRatePowerUp (2));
												RemoveItems (3, 2);
												labelNumberPowerUp [7].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 2) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new NitroRatePowerUp (2));
												RemoveItems (3, 2);
												labelNumberPowerUp [7].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 2) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Nitro Rate 4") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 3) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new NitroRatePowerUp (3));
										RemoveItems (3, 3);
										labelNumberPowerUp [8].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 3) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new NitroRatePowerUp (3));
												RemoveItems (3, 3);
												labelNumberPowerUp [8].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 3) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new NitroRatePowerUp (3));
												RemoveItems (3, 3);
												labelNumberPowerUp [8].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 3) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Nitro Rate 5") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 4) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new NitroRatePowerUp (4));
										RemoveItems (3, 4);
										labelNumberPowerUp [9].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 4) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new NitroRatePowerUp (4));
												RemoveItems (3, 4);
												labelNumberPowerUp [9].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 4) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new NitroRatePowerUp (4));
												RemoveItems (3, 4);
												labelNumberPowerUp [9].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 4) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Nitro Multi 1") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 0) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new NitroMultiplierPowerUp (0));
										RemoveItems (2, 0);
										labelNumberPowerUp [10].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 0) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new NitroMultiplierPowerUp (0));
												RemoveItems (2, 0);
												labelNumberPowerUp [10].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 0) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new NitroMultiplierPowerUp (0));
												RemoveItems (2, 0);
												labelNumberPowerUp [10].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 0) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Nitro Multi 2") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 1) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new NitroMultiplierPowerUp (1));
										RemoveItems (2, 1);
										labelNumberPowerUp [11].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 1) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new NitroMultiplierPowerUp (1));
												RemoveItems (2, 1);
												labelNumberPowerUp [11].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 1) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new NitroMultiplierPowerUp (1));
												RemoveItems (2, 1);
												labelNumberPowerUp [11].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 1) + ")";
										}
								}

						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Nitro Multi 3") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 2) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new NitroMultiplierPowerUp (2));
										RemoveItems (2, 2);
										labelNumberPowerUp [12].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 2) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new NitroMultiplierPowerUp (2));
												RemoveItems (2, 2);
												labelNumberPowerUp [12].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 2) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new NitroMultiplierPowerUp (2));
												RemoveItems (2, 2);
												labelNumberPowerUp [12].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 2) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Nitro Multi 4") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 3) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new NitroMultiplierPowerUp (3));
										RemoveItems (2, 3);
										labelNumberPowerUp [13].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 3) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new NitroMultiplierPowerUp (3));
												RemoveItems (2, 3);
												labelNumberPowerUp [13].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 3) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new NitroMultiplierPowerUp (3));
												RemoveItems (2, 3);
												labelNumberPowerUp [13].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 3) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Nitro Multi 5") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 4) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new NitroMultiplierPowerUp (4));
										RemoveItems (2, 4);
										labelNumberPowerUp [14].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 4) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new NitroMultiplierPowerUp (4));
												RemoveItems (2, 4);
												labelNumberPowerUp [14].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 4) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new NitroMultiplierPowerUp (4));
												RemoveItems (2, 4);
												labelNumberPowerUp [14].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 4) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Police 1") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 0) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new PolicePreventPowerUp (0));
										RemoveItems (5, 0);
										labelNumberPowerUp [15].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 0) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new PolicePreventPowerUp (0));
												RemoveItems (5, 0);
												labelNumberPowerUp [15].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 0) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new PolicePreventPowerUp (0));
												RemoveItems (5, 0);
												labelNumberPowerUp [15].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 0) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Police 2") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 1) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new PolicePreventPowerUp (1));
										RemoveItems (5, 1);
										labelNumberPowerUp [16].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 1) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new PolicePreventPowerUp (1));
												RemoveItems (5, 1);
												labelNumberPowerUp [16].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 1) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new PolicePreventPowerUp (1));
												RemoveItems (5, 1);
												labelNumberPowerUp [16].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 1) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Police 3") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 2) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new PolicePreventPowerUp (2));
										RemoveItems (5, 2);
										labelNumberPowerUp [17].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 2) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new PolicePreventPowerUp (2));
												RemoveItems (5, 2);
												labelNumberPowerUp [17].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 2) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new PolicePreventPowerUp (2));
												RemoveItems (5, 2);
												labelNumberPowerUp [17].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 2) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Police 4") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 3) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new PolicePreventPowerUp (3));
										RemoveItems (5, 3);
										labelNumberPowerUp [18].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 3) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new PolicePreventPowerUp (3));
												RemoveItems (5, 3);
												labelNumberPowerUp [18].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 3) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new PolicePreventPowerUp (3));
												RemoveItems (5, 3);
												labelNumberPowerUp [18].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 3) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Police 5") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 4) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new PolicePreventPowerUp (4));
										RemoveItems (5, 4);
										labelNumberPowerUp [19].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 4) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new PolicePreventPowerUp (4));
												RemoveItems (5, 4);
												labelNumberPowerUp [19].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 4) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new PolicePreventPowerUp (4));
												RemoveItems (5, 4);
												labelNumberPowerUp [19].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 4) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Acceleration 1") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 0) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new AccelerationPowerUp (0));
										RemoveItems (0, 0);
										labelNumberPowerUp [20].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 0) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new AccelerationPowerUp (0));
												RemoveItems (0, 0);
												labelNumberPowerUp [20].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 0) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new AccelerationPowerUp (0));
												RemoveItems (0, 0);
												labelNumberPowerUp [20].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 0) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Acceleration 2") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 1) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new AccelerationPowerUp (1));
										RemoveItems (0, 1);
										labelNumberPowerUp [21].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 1) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new AccelerationPowerUp (1));
												RemoveItems (0, 1);
												labelNumberPowerUp [21].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 1) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new AccelerationPowerUp (1));
												RemoveItems (0, 1);
												labelNumberPowerUp [21].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 1) + ")";
										}

								} else {
										print ("aaa");
								}
						} 
				} else if (control.name == "Button Equip Acceleration 3") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 2) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new AccelerationPowerUp (2));
										RemoveItems (0, 2);
										labelNumberPowerUp [22].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 2) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new AccelerationPowerUp (2));
												RemoveItems (0, 2);
												labelNumberPowerUp [22].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 2) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new AccelerationPowerUp (2));
												RemoveItems (0, 2);
												labelNumberPowerUp [22].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 2) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Acceleration 4") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 3) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new AccelerationPowerUp (3));
										RemoveItems (0, 3);
										labelNumberPowerUp [23].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 3) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new AccelerationPowerUp (3));
												RemoveItems (0, 3);
												labelNumberPowerUp [23].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 3) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new AccelerationPowerUp (3));
												RemoveItems (0, 3);
												labelNumberPowerUp [23].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 3) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Acceleration 5") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 4) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new AccelerationPowerUp (4));
										RemoveItems (0, 4);
										labelNumberPowerUp [24].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 4) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new AccelerationPowerUp (4));
												RemoveItems (0, 4);
												labelNumberPowerUp [24].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 4) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new AccelerationPowerUp (4));
												RemoveItems (0, 4);
												labelNumberPowerUp [24].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 4) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Handling 1") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 0) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new HandlingPowerUp (0));
										RemoveItems (1, 0);
										labelNumberPowerUp [25].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 0) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new HandlingPowerUp (0));
												RemoveItems (1, 0);
												labelNumberPowerUp [25].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 0) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new HandlingPowerUp (0));
												RemoveItems (1, 0);
												labelNumberPowerUp [25].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 0) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Handling 2") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 1) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new HandlingPowerUp (1));
										RemoveItems (1, 1);
										labelNumberPowerUp [26].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 1) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new HandlingPowerUp (1));
												RemoveItems (1, 1);
												labelNumberPowerUp [26].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 1) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new HandlingPowerUp (1));
												RemoveItems (1, 1);
												labelNumberPowerUp [26].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 1) + ")";
										}
								}
						} else {
								print ("aaa");
						}
				} else if (control.name == "Button Equip Handling 3") {
						if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 2) > 0) {
								if (GameData.firstPowerUp == null) {
										EquipItems (new HandlingPowerUp (2));
										RemoveItems (1, 2);
										labelNumberPowerUp [27].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 2) + ")";
								} else if (GameData.secondPowerUp == null) {
										if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
												EquipItems (new HandlingPowerUp (2));
												RemoveItems (1, 2);
												labelNumberPowerUp [27].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 2) + ")";
										}
								} else if (GameData.thirdPowerUp == null) {
										if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
												EquipItems (new HandlingPowerUp (2));
												RemoveItems (1, 2);
												labelNumberPowerUp [27].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 2) + ")";
										}
								} else {
										print ("aaa");
								}
						} else if (control.name == "Button Equip Handling 4") {
								if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 3) > 0) {
										if (GameData.firstPowerUp == null) {
												EquipItems (new HandlingPowerUp (3));
												RemoveItems (1, 3);
												labelNumberPowerUp [28].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 3) + ")";
										} else if (GameData.secondPowerUp == null) {
												if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
														EquipItems (new HandlingPowerUp (3));
														RemoveItems (1, 3);
														labelNumberPowerUp [28].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 3) + ")";
												}
										} else if (GameData.thirdPowerUp == null) {
												if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
														EquipItems (new HandlingPowerUp (3));
														RemoveItems (1, 3);
														labelNumberPowerUp [28].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 3) + ")";
												}
										}
								} else {
										print ("aaa");
								}
						} else if (control.name == "Button Equip Handling 5") {
								if (ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 4) > 0) {
										if (GameData.firstPowerUp == null) {
												EquipItems (new HandlingPowerUp (4));
												RemoveItems (1, 4);
												labelNumberPowerUp [29].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 4) + ")";
										} else if (GameData.secondPowerUp == null) {
												if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
														EquipItems (new HandlingPowerUp (4));
														RemoveItems (1, 4);
														labelNumberPowerUp [29].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 4) + ")";
												}
										} else if (GameData.thirdPowerUp == null) {
												if (ProfileManager.userProfile.IsThirdSlotUnlocked) {
														EquipItems (new HandlingPowerUp (4));
														RemoveItems (1, 4);
														labelNumberPowerUp [29].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 4) + ")";
												}
										}
								} else {
										print ("aaa");
								}
						}
				}
		}
	#endregion

	#region EquippedItems
		void EquipItems (BasePowerUp powerUp)
		{
				if (GameData.firstPowerUp == null) {
						GameData.firstPowerUp = powerUp;
						FirstPowerUp.Texture = getPowerUpImage (GameData.firstPowerUp);
				} else if (GameData.secondPowerUp == null) {
						GameData.secondPowerUp = powerUp;
						SecondPowerUP.Texture = getPowerUpImage (GameData.secondPowerUp);
				} else if (GameData.thirdPowerUp == null) {
						GameData.thirdPowerUp = powerUp;
						ThirdPowerUp.Texture = getPowerUpImage (GameData.thirdPowerUp);
				} 
		}
	#endregion

	#region Get Power Image
		Texture getPowerUpImage (BasePowerUp powerUp)
		{
				if (powerUp != null) {
						switch (powerUp.getPowerUpType ()) {
						case BasePowerUp.POWER_UP_TYPE.NITRO_TANK:
								switch (powerUp.PowerUpItemLevel) {
								case 0:
										return powerImage [0];
								case 1:
										return powerImage [1];
								case 2:
										return powerImage [2];
								case 3:
										return powerImage [3];
								case 4:
										return powerImage [4];
								default:
										return powerImage [0];
								}
						case BasePowerUp.POWER_UP_TYPE.NITRO_RATE:
								switch (powerUp.PowerUpItemLevel) {
								case 0:
										return powerImage [5];
								case 1:
										return powerImage [6];
								case 2:
										return powerImage [7];
								case 3:
										return powerImage [8];
								case 4:
										return powerImage [9];
								default:
										return powerImage [0];
								}
						case BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER:
								switch (powerUp.PowerUpItemLevel) {
								case 0:
										return powerImage [10];
								case 1:
										return powerImage [11];
								case 2:
										return powerImage [12];
								case 3:
										return powerImage [13];
								case 4:
										return powerImage [14];
								default:
										return powerImage [0];
								}
						case BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT:
								switch (powerUp.PowerUpItemLevel) {
								case 0:
										return powerImage [15];
								case 1:
										return powerImage [16];
								case 2:
										return powerImage [17];
								case 3:
										return powerImage [18];
								case 4:
										return powerImage [19];
								default:
										return powerImage [0];
								}
						case BasePowerUp.POWER_UP_TYPE.ACCELERATION:
								switch (powerUp.PowerUpItemLevel) {
								case 0:
										return powerImage [20];
								case 1:
										return powerImage [21];
								case 2:
										return powerImage [22];
								case 3:
										return powerImage [23];
								case 4:
										return powerImage [24];
								default:
										return powerImage [0];
								}
						case BasePowerUp.POWER_UP_TYPE.HANDLING:
								switch (powerUp.PowerUpItemLevel) {
								case 0:
										return powerImage [25];
								case 1:
										return powerImage [26];
								case 2:
										return powerImage [27];
								case 3:
										return powerImage [28];
								case 4:
										return powerImage [29];
								default:
										return powerImage [0];
								}
						default:
								return powerImage [0];
						}
				} else {
						return powerImage [0];
				}
		}
	#endregion

	#region Remove PowerUp Items
		void RemoveItems (int powerUpType, int powerUpLevel)
		{
				int removeIndex = -1;
				for (int i = 0; i<ProfileManager.userProfile.powerUpList.Count; i++) {
						if (ProfileManager.userProfile.powerUpList [i].t == powerUpType && ProfileManager.userProfile.powerUpList [i].l == powerUpLevel) {
								removeIndex = i;
								break;
						}
				}
				if (removeIndex != -1) {
						ProfileManager.userProfile.powerUpList.RemoveAt (removeIndex);
						ProfileManager.userProfile.savePowerUp ();
				}
				PlayerPrefs.Save ();
		}
	#endregion

	#region UnEquipped Items
		public void UnEquippedItems (dfControl control, dfMouseEventArgs mouseEvent)
		{
				if (control.name == "First powerUp") {
						if (GameData.firstPowerUp != null) {
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (GameData.firstPowerUp));
								FirstPowerUp.Texture = null;
								GameData.firstPowerUp = null;
						}
				} else if (control.name == "Second powerUp") {
						if (GameData.secondPowerUp != null) {
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (GameData.secondPowerUp));
								SecondPowerUP.Texture = null;
								GameData.secondPowerUp = null;
						}
				} else if (control.name == "Third powerUp") {
						if (GameData.thirdPowerUp != null) {
								ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (GameData.thirdPowerUp));
								ThirdPowerUp.Texture = null;
								GameData.thirdPowerUp = null;
						}
				}
				for (int i = 0; i<30; i++) {
						ShowNumberOfPowerUpItems (i);
				}

				if (FirstPowerUp == null || SecondPowerUP == null || ThirdPowerUp == null) {
						print ("You need equip items");
				}
		}
	#endregion

	#region Show Number Of PowerUp Items
		void ShowNumberOfPowerUpItems (int i)
		{
				switch (i) {
				case 0:
						labelNumberPowerUp [0].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 0) + ")";
						break;
				case 1:
						labelNumberPowerUp [1].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 1) + ")";
						break;
				case 2:
						labelNumberPowerUp [2].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 2) + ")";
						break;
				case 3:
						labelNumberPowerUp [3].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 3) + ")";
						break;
				case 4:
						labelNumberPowerUp [4].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 4) + ")";
						break;
				case 5:
						labelNumberPowerUp [5].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 0) + ")";
						break;
				case 6:
						labelNumberPowerUp [6].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 1) + ")";
						break;
				case 7:
						labelNumberPowerUp [7].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 2) + ")";
						break;
				case 8:
						labelNumberPowerUp [8].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 3) + ")";
						break;
				case 9:
						labelNumberPowerUp [9].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_RATE, 4) + ")";
						break;
				case 10:
						labelNumberPowerUp [10].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 0) + ")";
						break;
				case 11:
						labelNumberPowerUp [11].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 1) + ")";
						break;
				case 12:
						labelNumberPowerUp [12].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 2) + ")";
						break;
				case 13:
						labelNumberPowerUp [13].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 3) + ")";
						break;
				case 14:
						labelNumberPowerUp [14].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER, 4) + ")";
						break;
				case 15:
						labelNumberPowerUp [15].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 0) + ")";
						break;
				case 16:
						labelNumberPowerUp [16].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 1) + ")";
						break;
				case 17:
						labelNumberPowerUp [17].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 2) + ")";
						break;
				case 18:
						labelNumberPowerUp [18].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 3) + ")";
						break;
				case 19:
						labelNumberPowerUp [19].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT, 4) + ")";
						break;
				case 20:
						labelNumberPowerUp [20].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 0) + ")";
						break;
				case 21:
						labelNumberPowerUp [21].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 1) + ")";
						break;
				case 22:
						labelNumberPowerUp [22].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 2) + ")";
						break;
				case 23:
						labelNumberPowerUp [23].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 3) + ")";
						break;
				case 24:
						labelNumberPowerUp [24].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.ACCELERATION, 4) + ")";
						break;
				case 25:
						labelNumberPowerUp [25].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 0) + ")";
						break;
				case 26:
						labelNumberPowerUp [26].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 1) + ")";
						break;
				case 27:
						labelNumberPowerUp [27].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 2) + ")";
						break;
				case 28:
						labelNumberPowerUp [28].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 3) + ")";
						break;
				case 29:
						labelNumberPowerUp [29].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.HANDLING, 4) + ")";
						break;
				default:
						labelNumberPowerUp [0].Text = "(" + ProfileManager.userProfile.getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE.NITRO_TANK, 0) + ")";
						break;
				}
		}
	#endregion

	#region Buy Item Slot
		public void BuyItemSlot (dfControl control, dfMouseEventArgs mouseEvent)
		{
				if (control.name == "Lock Second Power Up") {
						if (ProfileManager.userProfile.Diamond >= 10) {
								lockItem [0].IsVisible = false;
								ProfileManager.userProfile.Diamond -= 10;
								ProfileManager.userProfile.IsSecondSlotUnlocked = true;
								SecondPowerUP.IsVisible = true;
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", 10 - ProfileManager.userProfile.Diamond) + " cash more. Do you want to buy more cash?";

						}
				} else if (control.name == "Lock Third Power Up") {
						if (ProfileManager.userProfile.Diamond >= 50) {
//								if (ProfileManager.userProfile.IsSecondSlotUnlocked) {
								lockItem [1].IsVisible = false;
								ProfileManager.userProfile.Diamond -= 50;
								ProfileManager.userProfile.IsThirdSlotUnlocked = true;
								ThirdPowerUp.IsVisible = true;
//								} else {
//										panelNotice.IsVisible = true;
//										LabelNotice.Text = "You have purchase second slot first";
//
//								}
						} else {
								panelError.IsVisible = true;
								LabelError.Text = "You need " + string.Format ("{0:n00}", 50 - ProfileManager.userProfile.Diamond) + " cash more. Do you want to buy more cash?";

						}
				}
				PlayerPrefs.Save ();
		}
	#endregion

//		public void CloseNotice ()
//		{
//				panelNotice.IsVisible = false;
//		}
}
