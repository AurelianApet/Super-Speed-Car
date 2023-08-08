using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BaseHeaderMenu : MonoBehaviour
{
	public static FacebookAvatar avatar;
	
	//
	public dfLabel starLabel;
	public dfLabel moneyLabel;
	public dfLabel diamondLabel;
	public dfLabel playerNameLabel;
	
	//
	int star = -1;
	int money = -1;
	int diamond = -1;

	//
	public static bool isJoinInvitedRoom;
	public dfButton messageButton;
	public dfLabel inviteMessage;
	public dfTweenVector3 messageAnimation;
	bool isShowInvite;
	float lastShowInvite;

	void OnEnable ()
	{
		ProfileManager.init ();

		string text = Application.loadedLevelName + ",Level:" + ProfileManager.userProfile.getHighestLevel ();

		GoogleAnalytics.LogScreen (text);
	}
	
	public void addMoney ()
	{
		GameData.buyType = 0;		
		
		if (Application.loadedLevelName != "PaymentMenu" && Application.loadedLevelName != "FreeCoinScene") {
			PaymentMenu.previousLevel = Application.loadedLevelName;
		}
		
		AutoFade.LoadLevel ("PaymentMenu");
	}
	
	public void addDiamond ()
	{
		GameData.buyType = 1;
		
		if (Application.loadedLevelName != "PaymentMenu" && Application.loadedLevelName != "FreeCoinScene") {
			PaymentMenu.previousLevel = Application.loadedLevelName;
		}
		
		AutoFade.LoadLevel ("PaymentMenu");
	}
	
	public void buyVIP ()
	{
		GameData.buyType = 2;
		
		if (Application.loadedLevelName != "PaymentMenu" && Application.loadedLevelName != "FreeCoinScene") {
			PaymentMenu.previousLevel = Application.loadedLevelName;
		}
		
		AutoFade.LoadLevel ("PaymentMenu");
	}
	
	public void freeMoney ()
	{
		if (Application.loadedLevelName != "PaymentMenu" && Application.loadedLevelName != "FreeCoinScene") {
			FreeCoin.previousLevel = Application.loadedLevelName;
		}
		
		AutoFade.LoadLevel ("FreeCoinScene");

//				ProfileManager.userProfile.Money += 100000;
//				ProfileManager.userProfile.Diamond += 1000;
//				PlayerPrefs.Save ();
	}
	
	public void editUserInfo ()
	{
		AutoFade.LoadLevel ("UserInfo");
	}
	
	public void updateInfo ()
	{
		if (star != ProfileManager.userProfile.getNumberStar ()) {
			star = ProfileManager.userProfile.getNumberStar ();			
			starLabel.Text = string.Format ("{0:n00}", star);
			playerNameLabel.Text = ProfileManager.userProfile.PlayerName;
		}

		if (money != ProfileManager.userProfile.Money) {
			money = ProfileManager.userProfile.Money;
			moneyLabel.Text = string.Format ("{0:n00}", money);
			playerNameLabel.Text = ProfileManager.userProfile.PlayerName;
		}

		if (diamond != ProfileManager.userProfile.Diamond) {
			diamond = ProfileManager.userProfile.Diamond;
			diamondLabel.Text = string.Format ("{0:n00}", diamond);
			playerNameLabel.Text = ProfileManager.userProfile.PlayerName;
		}

		if (this.isShowInvite == true) {
			if (Time.realtimeSinceStartup - this.lastShowInvite > 15) {
				this.isShowInvite = false;
				messageButton.IsVisible = false;
				messageAnimation.Stop ();
			}
		}
	}

	public void showInvite ()
	{
		if (this.isShowInvite == false) {
			if (messageButton != null) {
				messageButton.IsVisible = true;
				inviteMessage.Text = KORChat.inviteUser + "\nhas invited you to join an online race";				
				messageAnimation.Play ();

				this.isShowInvite = true;
				this.lastShowInvite = Time.realtimeSinceStartup;
			}
		}
	}

	public void joinInvitedRoom ()
	{
		isJoinInvitedRoom = true;
		AutoFade.LoadLevel ("InternetGameMenu");
	}
}