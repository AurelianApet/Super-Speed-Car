using UnityEngine;
using System.Collections;
using System;

public class BetMenu : BaseHeaderMenu
{
		//
		public AudioSource audioSource;
		public AudioSource click;

		//
		public dfButton[] joinPrimaryButton;
		public dfButton[] joinAverageButton;
		public dfButton[] joinSeniorButton;
		public dfButton[] joinChampionButton;

		//
		public dfLabel timeBeforeEvent;
		public dfLabel eventDuration;
		public dfLabel descriptionLabel;

		//
		public dfLabel dialogMessage;
		public dfPanel dialogPanel;

		//
		TimeSpan timeBeforeEventTime;
		TimeSpan eventDurationTimeSpan;
		bool isBuyVIP;

		void Start ()
		{
				ProfileManager.init ();

				audioSource.volume = ProfileManager.setttings.MusicVolume / 100f;
				audioSource.Play ();

				click.volume = ProfileManager.setttings.SoundVolume / 100f;

				GameData.betValue = 0;
		}

		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.Escape)) {
						AutoFade.LoadLevel ("ChooseOnlineMode");

				} else {
						this.updateInfo ();

						if (InternetGameMenu.isInKingOfDayEvent () == false) {
								if (MainMenu.currentTime.CompareTo (new DateTime (2015, 1, 1)) != 0) {
										timeBeforeEventTime = InternetGameMenu.getTimeBeforeKingOfDay ();

										timeBeforeEvent.Text = "Remaining time to King Of Day event: " + timeBeforeEventTime.Hours + "h " 
												+ timeBeforeEventTime.Minutes + "m " + timeBeforeEventTime.Seconds + "s";
								} else {
										timeBeforeEvent.Text = "King of Day event will be held between 8 and 9 (AM and PM)";
								}

								eventDuration.Text = "Duration: 1 hour";
						} else {
								descriptionLabel.Color = Color.yellow;
								descriptionLabel.Text = "Bet  now  and  receive  up  to  x6  bet  value  and \nx4  score  if  you  finish  first  in  race";

								eventDurationTimeSpan = InternetGameMenu.getKingOfDayDuration ();

								timeBeforeEvent.Text = "Join King Of Day event now to get amazing reward";
								eventDuration.Text = "Duration: " + eventDurationTimeSpan.Minutes + "m " + eventDurationTimeSpan.Seconds + "s";
						}
				}
		}

		public void quit ()
		{
				AutoFade.LoadLevel ("ChooseOnlineMode");
		}

		public void joinPrimary_1 ()
		{
				click.Play ();

				if (ProfileManager.userProfile.Money >= 1000) {
						GameData.betValue = 1000;
						ProfileManager.userProfile.Money -= GameData.betValue;
						PlayerPrefs.Save ();

						AutoFade.LoadLevel ("InternetGameMenu");
				} else {
						dialogPanel.IsVisible = true;
						dialogMessage.Text = "You don't have enough coins to enter this room.\nDo you want to buy more?";
						this.isBuyVIP = false;
				}
		}

		public void joinPrimary_2 ()
		{
				click.Play ();

				if (ProfileManager.userProfile.Money >= 5000) {
						GameData.betValue = 5000;
						ProfileManager.userProfile.Money -= GameData.betValue;
						PlayerPrefs.Save ();

						AutoFade.LoadLevel ("InternetGameMenu");
				} else {
						dialogPanel.IsVisible = true;
						dialogMessage.Text = "You don't have enough coins to enter this room.\nDo you want to buy more?";
						this.isBuyVIP = false;
				}
		}

		public void joinAverage_1 ()
		{
				click.Play ();

				if (ProfileManager.userProfile.Money >= 10000) {
						GameData.betValue = 10000;
						ProfileManager.userProfile.Money -= GameData.betValue;
						PlayerPrefs.Save ();

						AutoFade.LoadLevel ("InternetGameMenu");
				} else {
						dialogPanel.IsVisible = true;
						dialogMessage.Text = "You don't have enough coins to enter this room.\nDo you want to buy more?";
						this.isBuyVIP = false;
				}
		}

		public void joinAverage_2 ()
		{
				click.Play ();
		
				if (ProfileManager.userProfile.Money >= 20000) {
						GameData.betValue = 20000;
						ProfileManager.userProfile.Money -= GameData.betValue;
						PlayerPrefs.Save ();

						AutoFade.LoadLevel ("InternetGameMenu");
				} else {
						dialogPanel.IsVisible = true;
						dialogMessage.Text = "You don't have enough coins to enter this room.\nDo you want to buy more?";
						this.isBuyVIP = false;
				}
		}

		public void joinSenior_1 ()
		{
				click.Play ();

				if (ProfileManager.userProfile.Money >= 50000) {
						GameData.betValue = 50000;
						ProfileManager.userProfile.Money -= GameData.betValue;
						PlayerPrefs.Save ();

						AutoFade.LoadLevel ("InternetGameMenu");
				} else {
						dialogPanel.IsVisible = true;
						dialogMessage.Text = "You don't have enough coins to enter this room.\nDo you want to buy more?";
						this.isBuyVIP = false;
				}
		}

		public void joinSenior_2 ()
		{
				click.Play ();
		
				if (ProfileManager.userProfile.Money >= 100000) {
						GameData.betValue = 100000;
						ProfileManager.userProfile.Money -= GameData.betValue;
						PlayerPrefs.Save ();

						AutoFade.LoadLevel ("InternetGameMenu");
				} else {
						dialogPanel.IsVisible = true;
						dialogMessage.Text = "You don't have enough coins to enter this room.\nDo you want to buy more?";
						this.isBuyVIP = false;
				}
		}

		public void joinChampion_1 ()
		{
				click.Play ();
				if (ProfileManager.userProfile.VipLevel >= 2) {			
						if (ProfileManager.userProfile.Money >= 300000) {
								GameData.betValue = 300000;
								ProfileManager.userProfile.Money -= GameData.betValue;
								PlayerPrefs.Save ();

								AutoFade.LoadLevel ("InternetGameMenu");
						} else {
								dialogPanel.IsVisible = true;
								dialogMessage.Text = "You don't have enough coins to enter this room.\nDo you want to buy more?";
								this.isBuyVIP = false;
						}
				} else {						
						dialogPanel.IsVisible = true;
						dialogMessage.Text = "You have to be VIP 2 at least to enter this room.\nDo you want to become VIP?";
						this.isBuyVIP = true;
				}
		}

		public void joinChampion_2 ()
		{
				click.Play ();

				if (ProfileManager.userProfile.VipLevel >= 2) {
						if (ProfileManager.userProfile.Money >= 500000) {
								GameData.betValue = 500000;
								ProfileManager.userProfile.Money -= GameData.betValue;
								PlayerPrefs.Save ();

								AutoFade.LoadLevel ("InternetGameMenu");
						} else {
								dialogPanel.IsVisible = true;
								dialogMessage.Text = "You don't have enough coins to enter this room.\nDo you want to buy more?";
								this.isBuyVIP = false;
						}
				} else {						
						dialogPanel.IsVisible = true;
						dialogMessage.Text = "You have to be VIP 2 at least to enter this room.\nDo you want to become VIP?";
						this.isBuyVIP = true;
				}
		}

		public void yesOnClick ()
		{
				if (this.isBuyVIP == true) {
						this.buyVIP ();
				} else {
						this.addMoney ();
				}
		}

		public void noOnClick ()
		{
				dialogPanel.IsVisible = false;
		}
}