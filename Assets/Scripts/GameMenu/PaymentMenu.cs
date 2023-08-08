using UnityEngine;
using System.Collections;
using System;
using OnePF;

public class PaymentMenu : BaseHeaderMenu
{
		public static string previousLevel = "MainMenu";

		//
		public AudioSource audioSource;
		public AudioSource click;

		//
		public dfTabContainer tabContainer;

		//
		public dfButton[] tabButton;

		//
		public dfButton[] vipButton;
		public dfButton[] priceButton;
	
		void Start ()
		{
				ProfileManager.init ();
		
				audioSource.volume = ProfileManager.setttings.MusicVolume / 100f;
				audioSource.Play ();
		
				click.volume = ProfileManager.setttings.SoundVolume / 100f;

				switch (GameData.buyType) {
				case 0:
						this.buyCoin ();
						break;

				case 1:
						this.buyDiamond ();
						break;

				case 2:
						this.buyVIPClick ();
						break;

				default:
						break;
				}
		}
	
		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.Escape)) {
						MainMenu.isLoadingShop = true;
						AutoFade.LoadLevel (PaymentMenu.previousLevel);
			
				} else {
						this.updateInfo ();

						switch (ProfileManager.userProfile.VipLevel) {
						case 1:
								vipButton [0].IsEnabled = false;

								priceButton [0].IsVisible = false;
								break;

						case 2:
								vipButton [0].IsEnabled = false;
								vipButton [1].IsEnabled = false;

								priceButton [0].IsVisible = false;
								priceButton [1].IsVisible = false;
								break;

						case 3:
								vipButton [0].IsEnabled = false;
								vipButton [1].IsEnabled = false;
								vipButton [2].IsEnabled = false;

								priceButton [0].IsVisible = false;
								priceButton [1].IsVisible = false;
								priceButton [2].IsVisible = false;
								break;

						default:
								break;
						}
				}
		}
	
		public void buyCoin ()
		{
				tabContainer.SelectedIndex = 0;

				tabButton [0].IsEnabled = false;
				tabButton [1].IsEnabled = true;
				tabButton [2].IsEnabled = true;
		}
	
		public void buyDiamond ()
		{
				tabContainer.SelectedIndex = 1;

				tabButton [0].IsEnabled = true;
				tabButton [1].IsEnabled = false;
				tabButton [2].IsEnabled = true;
		}
	
		public void buyVIPClick ()
		{
				tabContainer.SelectedIndex = 2;

				tabButton [0].IsEnabled = true;
				tabButton [1].IsEnabled = true;
				tabButton [2].IsEnabled = false;
		}

		//--------------------------------------------------------------------------------
		public void coinPack_1 ()
		{
				Debug.Log ("coin_1");
//				buyProduct (KORPaymentHandler.COIN_PACK_1);
		}

		public void coinPack_2 ()
		{
				Debug.Log ("coin_2");
//				buyProduct (KORPaymentHandler.COIN_PACK_2);
		}

		public void coinPack_3 ()
		{
				Debug.Log ("coin_3");
//				buyProduct (KORPaymentHandler.COIN_PACK_3);
		}

		public void coinPack_4 ()
		{
				Debug.Log ("coin_4");
//				buyProduct (KORPaymentHandler.COIN_PACK_4);
		}

		public void coinPack_5 ()
		{
				Debug.Log ("coin_5");
//				buyProduct (KORPaymentHandler.COIN_PACK_5);
		}

		public void coinPack_6 ()
		{
				Debug.Log ("coin_6");
//				buyProduct (KORPaymentHandler.COIN_PACK_6);
		}

		//--------------------------------------------------------------------------------
		public void cashPack_1 ()
		{
				Debug.Log ("cash_1");
//				buyProduct (KORPaymentHandler.CASH_PACK_1);
		}
	
		public void cashPack_2 ()
		{
				Debug.Log ("cash_2");
//				buyProduct (KORPaymentHandler.CASH_PACK_2);
		}
	
		public void cashPack_3 ()
		{
				Debug.Log ("cash_3");
//				buyProduct (KORPaymentHandler.CASH_PACK_3);
		}
	
		public void cashPack_4 ()
		{
				Debug.Log ("cash_4");
//				buyProduct (KORPaymentHandler.CASH_PACK_4);
		}
	
		public void cashPack_5 ()
		{
				Debug.Log ("cash_5");
//				buyProduct (KORPaymentHandler.CASH_PACK_5);
		}
	
		public void cashPack_6 ()
		{
				Debug.Log ("cash_6");
//				buyProduct (KORPaymentHandler.CASH_PACK_6);
		}

		//--------------------------------------------------------------------------------
		public void vip_1 ()
		{
				if (ProfileManager.userProfile.Money >= 50000) {
						ProfileManager.userProfile.Money -= 50000;
						ProfileManager.userProfile.VipLevel = 1;
						ProfileManager.userProfile.LastBuyVip = DateTime.Now;
						PlayerPrefs.Save ();
				} else {
						this.buyCoin ();
				}
		}
	
		public void vip_2 ()
		{
				if (ProfileManager.userProfile.Money >= 100000) {
						ProfileManager.userProfile.Money -= 100000;
						ProfileManager.userProfile.VipLevel = 2;
						ProfileManager.userProfile.LastBuyVip = DateTime.Now;
						PlayerPrefs.Save ();
				} else {
						this.buyCoin ();
				}
		}
	
		public void vip_3 ()
		{
				if (ProfileManager.userProfile.Money >= 300000) {
						ProfileManager.userProfile.Money -= 300000;
						ProfileManager.userProfile.VipLevel = 3;
						ProfileManager.userProfile.LastBuyVip = DateTime.Now;
						PlayerPrefs.Save ();
				} else {
						this.buyCoin ();
				}
		}

		//--------------------------------------------------------------------------------
	
		public void back ()
		{
						MainMenu.isLoadingShop = true;
				click.Play ();

				AutoFade.LoadLevel (PaymentMenu.previousLevel);
		}

		public void buyProduct (string productName)
		{
//				KORPaymentHandler.purchaseProduct (productName);

				PlayerPrefs.Save ();
		}
}