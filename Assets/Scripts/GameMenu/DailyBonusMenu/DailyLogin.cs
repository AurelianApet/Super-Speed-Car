using UnityEngine;
using System.Collections;
using System;

public class DailyLogin : MonoBehaviour
{
		public dfButton[] dayImageList;
		public dfButton[] dayList;
		public dfButton collectButton;
		public dfTweenFloat[] tweenFloatAnimation;
		public AudioSource click;
		public dfLabel[] dailyRewardLabel;

		void Awake ()
		{
				ProfileManager.init ();

				if (ProfileManager.dailyBonusProfile.NumberLogin > 0) {
						TimeSpan timeSpan = new TimeSpan (DateTime.Now.Ticks - ProfileManager.dailyBonusProfile.LastLogin.Ticks);

						if (timeSpan.TotalHours <= 48) {
								if (timeSpan.TotalHours >= 24) {
										if (ProfileManager.dailyBonusProfile.NumberLogin < 7) {
												ProfileManager.dailyBonusProfile.NumberLogin++;
										} else {
												ProfileManager.dailyBonusProfile.NumberLogin = 7;
										}
					
										DailyLogin.receiveReward ();
					
										ProfileManager.dailyBonusProfile.LastLogin = DateTime.Now;
								} else {
										Application.LoadLevel ("MainMenu");
								}
						} else {
								ProfileManager.dailyBonusProfile.NumberLogin = 1;
								DailyLogin.receiveReward ();
				
								ProfileManager.dailyBonusProfile.LastLogin = DateTime.Now;
						}
				} else {
						ProfileManager.dailyBonusProfile.NumberLogin = 1;
						DailyLogin.receiveReward ();
			
						ProfileManager.dailyBonusProfile.LastLogin = DateTime.Now;
				}			

				this.updateLabel ();
				PlayerPrefs.Save ();

				click.volume = ProfileManager.setttings.SoundVolume / 100f;
		}

		void Start ()
		{
				int i;
				for (i=0; i<ProfileManager.dailyBonusProfile.NumberLogin; i++) {
						dayImageList [i].IsEnabled = true;
						dayList [i].IsEnabled = true;
				}
				tweenFloatAnimation [ProfileManager.dailyBonusProfile.NumberLogin - 1].Play ();

				for (i=ProfileManager.dailyBonusProfile.NumberLogin; i<dayImageList.Length; i++) {
						dayImageList [i].IsEnabled = false;
						dayList [i].IsEnabled = false;
				}

				collectButton.Position = new Vector3 (dayImageList [ProfileManager.dailyBonusProfile.NumberLogin - 1].Position.x,
		                                      collectButton.Position.y, collectButton.Position.z);
		}
	
		public void receiveDailyLoginReward ()
		{
				click.Play ();

				AutoFade.LoadLevel ("MainMenu");
		}

		public void updateLabel ()
		{
				int titleID = RewardData.getTitleID (ProfileManager.userProfile.Score);

				dailyRewardLabel [0].Text = (500 + 100 * titleID) + "\ncoins";
				dailyRewardLabel [1].Text = (750 + 200 * titleID) + "\ncoins";

				dailyRewardLabel [2].Text = "Acceleration\n" + (10 + (titleID / 2) * 5) + "s";
				dailyRewardLabel [3].Text = "Nitro\n" + (20 * (titleID / 3 + 1)) + "%";
				dailyRewardLabel [4].Text = "Police\nlicense " + (10 + (titleID / 2) * 5) + "s";
				dailyRewardLabel [5].Text = "Nitro\n" + (20 * (titleID / 2 + 1)) + "%";

				dailyRewardLabel [6].Text = "Reward\nX2";
		}

		public static void receiveReward ()
		{
				int titleID = RewardData.getTitleID (ProfileManager.userProfile.Score);

				switch (ProfileManager.dailyBonusProfile.NumberLogin) {
				case 1:
						ProfileManager.userProfile.Money += 500 + 100 * titleID;
						break;
			
				case 2:
						ProfileManager.userProfile.Money += 750 + 200 * titleID;
						break;
			
				case 3:
						ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new AccelerationPowerUp (titleID / 2)));
						ProfileManager.userProfile.savePowerUp ();
						break;
			
				case 4:
						ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroTankPowerUp (titleID / 3)));			
						ProfileManager.userProfile.savePowerUp ();
						break;
			
				case 5:
						ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new PolicePreventPowerUp (titleID / 2)));
						ProfileManager.userProfile.savePowerUp ();
						break;
			
				case 6:
						ProfileManager.userProfile.powerUpList.Add (BasePowerUpData.convertToBasePowerUpData (new NitroTankPowerUp (titleID / 2)));
						ProfileManager.userProfile.savePowerUp ();
						break;
			
				case 7:
						GameData.IsDoubleReward = true;
						ProfileManager.userProfile.saveBoughtPowerUp (1);
						break;
			
				default:
						break;
				}
		}
}