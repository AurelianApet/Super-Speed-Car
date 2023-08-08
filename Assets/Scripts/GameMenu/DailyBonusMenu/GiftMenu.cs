using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GiftMenu : BaseHeaderMenu
{
		public dfPanel earnCoin, dailyPanel;
		public dfButton btnEarnCoin, btnDaily;

		//
		public dfButton[] dayImageList;
		public dfButton[] dayList;
		public dfTweenFloat[] tweenFloatAnimation;

		//
		public AudioSource audioSource;
		public AudioSource click;

		//
		public dfPanel[] giftPanel;
		public dfButton[] receiveRewardButton;

		//
		public dfLabel[] giftQuestLabel;
		public dfLabel[] dailyRewardLabel;

		//
		public static bool isWatchRamboTrailer = false;
		public static bool isWatchKORTrailer = false;
		public static bool isVisitFanpage = false;

		void Start ()
		{
				ProfileManager.init ();

				if (ProfileManager.dailyBonusProfile.NumberLogin == 0) {
						ProfileManager.dailyBonusProfile.NumberLogin = 1;
				}

				earnCoin.IsVisible = true;
				dailyPanel.IsVisible = false;
				btnEarnCoin.IsEnabled = false;
				btnDaily.IsEnabled = true;

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

				audioSource.volume = ProfileManager.setttings.MusicVolume / 100f;
				audioSource.Play ();
		
				click.volume = ProfileManager.setttings.SoundVolume / 100f;

				this.updateLabel ();

				//if (FB.IsInitialized == false) {
				//		FB.Init (OnInitComplete, OnHideUnity);
			
				//} else {
				//		this.OnInitComplete ();
				//}
		}
	
		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.Escape)) {
						AutoFade.LoadLevel ("MainMenu");
			
				} else {
						this.updateInfo ();
						this.checkGift ();
				}
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

		public void EarnCoinClick ()
		{
				click.Play ();

				earnCoin.IsVisible = true;
				dailyPanel.IsVisible = false;
				btnEarnCoin.IsEnabled = false;
				btnDaily.IsEnabled = true;
		}

		public void DailyPanelOnClick ()
		{
				click.Play ();

				dailyPanel.IsVisible = true;
				earnCoin.IsVisible = false;
				btnEarnCoin.IsEnabled = true;
				btnDaily.IsEnabled = false;
		}

		public void Back ()
		{
				click.Play ();
				AutoFade.LoadLevel ("MainMenu");
		}

		public void checkGift ()
		{
//		check login facebook
				//if (FB.IsLoggedIn == true) {
				//		if (ProfileManager.dailyBonusProfile.isReceiveGift (0) == true) {
				//				receiveRewardButton [0].IsVisible = false;
				//				giftPanel [0].IsVisible = false;
				//		} else {
				//				receiveRewardButton [0].IsVisible = true;
				//				receiveRewardButton [0].IsEnabled = true;
				//		}
		
				//		if (ProfileManager.dailyBonusProfile.InviteFriend == true) {
				//				if (ProfileManager.dailyBonusProfile.isReceiveGift (1) == true) {
				//						receiveRewardButton [1].IsVisible = false;
				//				} else {
				//						receiveRewardButton [1].IsVisible = true;
				//						receiveRewardButton [1].IsEnabled = true;
				//				}
				//		} else {
				//				giftPanel [1].IsVisible = true;
				//				receiveRewardButton [1].IsEnabled = false;
				//		}

				//		if (ProfileManager.dailyBonusProfile.LikeFanPage == true) {
				//				if (ProfileManager.dailyBonusProfile.isReceiveGift (2) == true) {
				//						receiveRewardButton [2].IsVisible = false;
				//				} else {
				//						receiveRewardButton [2].IsVisible = true;
				//						receiveRewardButton [2].IsEnabled = true;
				//				}
				//		} else {
				//				giftPanel [2].IsVisible = true;
				//				receiveRewardButton [2].IsEnabled = false;
				//		}
				//} else {
						receiveRewardButton [0].IsEnabled = false;

						giftPanel [1].IsVisible = false;
						giftPanel [2].IsVisible = false;
			//	}
		
				if (ProfileManager.dailyBonusProfile.FirstCash == true) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (3) == true) {
								receiveRewardButton [3].IsVisible = false;
								giftPanel [3].IsVisible = false;
						} else {
								receiveRewardButton [3].IsVisible = true;
								receiveRewardButton [3].IsEnabled = true;
						}
				} else {
						receiveRewardButton [3].IsEnabled = false;
				}
		
				if (ProfileManager.dailyBonusProfile.FirstMoney == true) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (4) == true) {
								receiveRewardButton [4].IsVisible = false;
								giftPanel [4].IsVisible = false;
						} else {
								receiveRewardButton [4].IsVisible = true;
								receiveRewardButton [4].IsEnabled = true;
						}
				} else {
						receiveRewardButton [4].IsEnabled = false;
				}

				if (isWatchRamboTrailer == true) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (5) == true) {
								receiveRewardButton [5].IsVisible = false;
						} else {
								receiveRewardButton [5].IsVisible = true;
								receiveRewardButton [5].IsEnabled = true;
						}
				} else {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (5) == true) {
								receiveRewardButton [5].IsVisible = false;
						} else {
								receiveRewardButton [5].IsVisible = true;
								receiveRewardButton [5].IsEnabled = false;
						}
				}

				if (isWatchKORTrailer == true) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (6) == true) {
								receiveRewardButton [6].IsVisible = false;
						} else {
								receiveRewardButton [6].IsVisible = true;
								receiveRewardButton [6].IsEnabled = true;
						}
				} else {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (6) == true) {
								receiveRewardButton [6].IsVisible = false;
						} else {
								receiveRewardButton [6].IsVisible = true;
								receiveRewardButton [6].IsEnabled = false;
						}
				}

				if (isVisitFanpage == true) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (7) == true) {
								receiveRewardButton [7].IsVisible = false;
						} else {
								receiveRewardButton [7].IsVisible = true;
								receiveRewardButton [7].IsEnabled = true;
						}
				} else {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (7) == true) {
								receiveRewardButton [7].IsVisible = false;
						} else {
								receiveRewardButton [7].IsVisible = true;
								receiveRewardButton [7].IsEnabled = false;
						}
				}

				giftQuestLabel [0].Text = ProfileManager.achievementProfile.NumberPlayCareer + "/" + 10;
				if (ProfileManager.achievementProfile.NumberPlayCareer >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (11) == true) {
								receiveRewardButton [11].IsVisible = false;
								giftPanel [11].IsVisible = false;
						}
				} else {
						receiveRewardButton [11].IsEnabled = false;
				}

				giftQuestLabel [1].Text = ProfileManager.achievementProfile.NumberPlayClassic + "/" + 10;
				if (ProfileManager.achievementProfile.NumberPlayClassic >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (12) == true) {
								receiveRewardButton [12].IsVisible = false;
								giftPanel [12].IsVisible = false;
						}
				} else {
						receiveRewardButton [12].IsEnabled = false;
				}

				giftQuestLabel [2].Text = ProfileManager.achievementProfile.NumberPlayTimeTrial + "/" + 10;
				if (ProfileManager.achievementProfile.NumberPlayTimeTrial >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (13) == true) {
								receiveRewardButton [13].IsVisible = false;
								giftPanel [13].IsVisible = false;
						}
				} else {
						receiveRewardButton [13].IsEnabled = false;
				}

				giftQuestLabel [3].Text = ProfileManager.achievementProfile.NumberPlayElimination + "/" + 10;
				if (ProfileManager.achievementProfile.NumberPlayElimination >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (14) == true) {
								receiveRewardButton [14].IsVisible = false;
								giftPanel [14].IsVisible = false;
						}
				} else {
						receiveRewardButton [14].IsEnabled = false;
				}

				giftQuestLabel [4].Text = ProfileManager.achievementProfile.NumberPlayCheckPoint + "/" + 10;
				if (ProfileManager.achievementProfile.NumberPlayCheckPoint >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (15) == true) {
								receiveRewardButton [15].IsVisible = false;
								giftPanel [15].IsVisible = false;
						}
				} else {
						receiveRewardButton [15].IsEnabled = false;
				}

				giftQuestLabel [5].Text = ProfileManager.achievementProfile.NumberPlayMultiplayer + "/" + 10;
				if (ProfileManager.achievementProfile.NumberPlayMultiplayer >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (16) == true) {
								receiveRewardButton [16].IsVisible = false;
								giftPanel [16].IsVisible = false;
						}
				} else {
						receiveRewardButton [16].IsEnabled = false;
				}
		}
	
		//--------------------------------------------------------------------------------
		//public void loginFacebook ()
		//{//		check login facebook
		//		click.Play ();
		//		if (FB.IsLoggedIn == true) {
		//				if (ProfileManager.dailyBonusProfile.isReceiveGift (0) == false) {
		//						ProfileManager.dailyBonusProfile.receiveGift (0);
		//						ProfileManager.userProfile.Money += 1000;
		//						PlayerPrefs.Save ();
		//				}
		//		} else {
		//				FB.Login ("email,publish_actions", LoginCallback);
		//		}
		//}
	
		//public void inviteFriends ()
		//{//		check login facebook
		//		click.Play ();
		//		if (FB.IsLoggedIn == true) {
		//				if (ProfileManager.dailyBonusProfile.InviteFriend == true) {
		//						if (ProfileManager.dailyBonusProfile.isReceiveGift (1) == false) {					
		//								ProfileManager.dailyBonusProfile.receiveGift (1);
		//								ProfileManager.userProfile.Money += 2000;
		//								PlayerPrefs.Save ();
		//						} else {
		//								FB.AppRequest ("Mời bạn bè chơi cùng", null, null, null, null, "{}", "Thêm bạn, thêm vui", friendSelectorCallback);
		//						}
		//				} else {			
		//						FB.AppRequest ("Mời bạn bè chơi cùng", null, null, null, null, "{}", "Thêm bạn, thêm vui", friendSelectorCallback);
		//				}
		//		} else {
		//				FB.Login ("publish_actions", LoginCallback);
		//		}
		//}
	
		//public void likeFanPage ()
		//{//		check login facebook
		//		click.Play ();
		//		if (FB.IsLoggedIn == true) {
		//				if (ProfileManager.dailyBonusProfile.LikeFanPage == true) {
		//						if (ProfileManager.dailyBonusProfile.isReceiveGift (2) == false) {
		//								ProfileManager.userProfile.Money += 500;			
		//								ProfileManager.dailyBonusProfile.receiveGift (2);
		//								PlayerPrefs.Save ();
		//						} else {
		//								ProfileManager.dailyBonusProfile.LikeFanPage = true;
		//								Application.OpenURL ("https://www.facebook.com/pages/SplayGame/1568552953375678?sk=timeline&ref=page_internal");
		//						}
		//				} else {
		//						ProfileManager.dailyBonusProfile.LikeFanPage = true;
		//						Application.OpenURL ("https://www.facebook.com/pages/SplayGame/1568552953375678?sk=timeline&ref=page_internal");
		//				}
		//		} else {
		//				FB.Login ("publish_actions", LoginCallback);
		//		}
		//}
	
		public void receiveGiftBuyCashFirstTime ()
		{
				click.Play ();
				if (ProfileManager.dailyBonusProfile.FirstCash == true) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (3) == false) {
								ProfileManager.userProfile.Money += 5000;			
								ProfileManager.dailyBonusProfile.receiveGift (3);
								PlayerPrefs.Save ();
						}
				}
		}
	
		public void receiveGiftBuyCoinFirstTime ()
		{
				click.Play ();
				if (ProfileManager.dailyBonusProfile.FirstMoney == true) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (4) == false) {
								ProfileManager.userProfile.Money += 5000;			
								ProfileManager.dailyBonusProfile.receiveGift (4);
								PlayerPrefs.Save ();
						}
				}
		}
	
		public void watchTrailerSuperSpyCat ()
		{
				click.Play ();
				if (isWatchRamboTrailer == true) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (5) == false) {
								ProfileManager.userProfile.Money += 500;			
								ProfileManager.dailyBonusProfile.receiveGift (5);
								PlayerPrefs.Save ();
						} else {				
								Application.OpenURL ("https://www.youtube.com/watch?v=fW8gE-9VFYc");
						}
				} else {
						isWatchRamboTrailer = true;
			
						Application.OpenURL ("https://www.youtube.com/watch?v=fW8gE-9VFYc");
				}
		}
	
		public void watchTrailerKOR ()
		{
				click.Play ();
				if (isWatchKORTrailer == true) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (6) == false) {
								ProfileManager.userProfile.Money += 500;			
								ProfileManager.dailyBonusProfile.receiveGift (6);
								PlayerPrefs.Save ();
						} else {				
								Application.OpenURL ("https://www.youtube.com/watch?v=FbVBlizDOvg");
						}
				} else {			
						isWatchKORTrailer = true;
			
						Application.OpenURL ("https://www.youtube.com/watch?v=FbVBlizDOvg");
				}
		}
	
		public void visitFanPage ()
		{
				click.Play ();
				if (isVisitFanpage == true) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (7) == false) {
								ProfileManager.userProfile.Money += 500;			
								ProfileManager.dailyBonusProfile.receiveGift (7);
								PlayerPrefs.Save ();
						} else {				
								Application.OpenURL ("https://www.facebook.com/pages/SplayGame/1568552953375678?sk=timeline&ref=page_internal");
						}
				} else {
						isVisitFanpage = true;			
			
						Application.OpenURL ("https://www.facebook.com/pages/SplayGame/1568552953375678?sk=timeline&ref=page_internal");
				}	
		}
	
		public void rateGame ()
		{
				click.Play ();
				Application.OpenURL ("market://details?id=com.dev.game.racing.car.speed.drift.KingOfRacing.Reborn");
		}

		public void moreGames_1 ()
		{
				click.Play ();
				Application.OpenURL ("market://details?id=com.dev.superskycat");
		}
	
		public void moreGames_2 ()
		{
				click.Play ();
				Application.OpenURL ("market://details?id=com.splaygame.happyfarm");
		}

		public void receiveGiftCareer ()
		{
				click.Play ();
				if (ProfileManager.achievementProfile.NumberPlayCareer >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (11) == false) {
								ProfileManager.userProfile.Money += 3000;			
								ProfileManager.dailyBonusProfile.receiveGift (11);
								PlayerPrefs.Save ();
						}
				}
		}

		public void receiveGiftClassic ()
		{
				click.Play ();
				if (ProfileManager.achievementProfile.NumberPlayClassic >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (12) == false) {
								ProfileManager.userProfile.Money += 3000;			
								ProfileManager.dailyBonusProfile.receiveGift (12);
								PlayerPrefs.Save ();
						}
				}
		}

		public void receiveGiftTimeTrial ()
		{
				click.Play ();
				if (ProfileManager.achievementProfile.NumberPlayTimeTrial >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (13) == false) {
								ProfileManager.userProfile.Money += 3000;			
								ProfileManager.dailyBonusProfile.receiveGift (13);
								PlayerPrefs.Save ();
						}
				}
		}

		public void receiveGiftElimination ()
		{
				click.Play ();
				if (ProfileManager.achievementProfile.NumberPlayElimination >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (14) == false) {
								ProfileManager.userProfile.Money += 3000;			
								ProfileManager.dailyBonusProfile.receiveGift (14);
								PlayerPrefs.Save ();
						}
				}
		}

		public void receiveGiftCheckPoint ()
		{
				click.Play ();
				if (ProfileManager.achievementProfile.NumberPlayCheckPoint >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (15) == false) {
								ProfileManager.userProfile.Money += 3000;			
								ProfileManager.dailyBonusProfile.receiveGift (15);
								PlayerPrefs.Save ();
						}
				}
		}

		public void receiveGiftMultiplayer ()
		{
				click.Play ();
				if (ProfileManager.achievementProfile.NumberPlayMultiplayer >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (16) == false) {
								ProfileManager.userProfile.Money += 3000;			
								ProfileManager.dailyBonusProfile.receiveGift (16);
								PlayerPrefs.Save ();
						}
				}
		}

		//--------------------------------------------------------------------------------
		public static int getNumberGift ()
		{
				int result = 0;

				////		check login facebook
				//if (FB.IsLoggedIn == true) {
				//		if (ProfileManager.dailyBonusProfile.isReceiveGift (0) == false) {
				//				result++;
				//		}
			
				//		if (ProfileManager.dailyBonusProfile.InviteFriend == true) {
				//				if (ProfileManager.dailyBonusProfile.isReceiveGift (1) == false) {
				//						result++;
				//				}
				//		}

				//		if (ProfileManager.dailyBonusProfile.LikeFanPage == true) {
				//				if (ProfileManager.dailyBonusProfile.isReceiveGift (2) == false) {
				//						result++;
				//				}
				//		}
				//}
		
				if (ProfileManager.dailyBonusProfile.FirstMoney == true) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (3) == false) {
								result++;
						}
				} 
		
				if (ProfileManager.dailyBonusProfile.FirstCash == true) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (4) == false) {
								result++;
						}
				}

				if (isWatchRamboTrailer == true) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (5) == false) {
								result++;
						}
				}

				if (isWatchKORTrailer == true) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (6) == false) {
								result++;
						}
				}

				if (isVisitFanpage == true) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (7) == false) {
								result++;
						}
				}

				if (ProfileManager.achievementProfile.NumberPlayCareer >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (11) == false) {
								result++;
						}
				}

				if (ProfileManager.achievementProfile.NumberPlayClassic >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (12) == false) {
								result++;
						}
				}

				if (ProfileManager.achievementProfile.NumberPlayTimeTrial >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (13) == false) {
								result++;
						}
				}

				if (ProfileManager.achievementProfile.NumberPlayElimination >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (14) == false) {
								result++;
						}
				}

				if (ProfileManager.achievementProfile.NumberPlayCheckPoint >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (15) == false) {
								result++;
						}
				}

				if (ProfileManager.achievementProfile.NumberPlayMultiplayer >= 10) {
						if (ProfileManager.dailyBonusProfile.isReceiveGift (16) == false) {
								result++;
						}
				}

				return result;
		}

		//void friendSelectorCallback (FBResult result)
		//{
		//		if (result.Error == null || result.Error == string.Empty) {
		//				ProfileManager.dailyBonusProfile.InviteFriend = true;
		//				PlayerPrefs.Save ();
		//		}
		//}

		//void LoginCallback (FBResult result)
		//{
		//		if (result.Error != null) {
			
		//		} else if (!FB.IsLoggedIn) {
			
		//		} else {
		//				ProfileManager.userProfile.FacebookID = FB.UserId;
		//				PlayerPrefs.Save ();
		//		}
		//}

		void OnInitComplete ()
		{
		}
	
		void OnHideUnity (bool isGameShown)
		{
		}
}