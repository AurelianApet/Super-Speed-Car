using UnityEngine;
using System.Collections;
using System;

public class DailyBonusProfile : Profile
{	
		public static string LAST_LOGIN = "lastLogin";
		public static string NUMBER_LOGIN = "numberLogin";
		public static string DAILY_GIFT = "dailyGift";
		public static string FIRST_MONEY = "firstMoney";
		public static string FIRST_CASH = "firstCash";
		public static string INVITE_FRIEND = "inviteFriend";
		public static string LIKE_FAN_PAGE = "likeFanPage";

		//	
		private DateTime lastLogin;
	
		public DateTime LastLogin {
				get {
						return lastLogin;
				}
				set {
						lastLogin = value;
						this.setString (LAST_LOGIN, this.lastLogin.ToString ());
				}
		}
	
		private int numberLogin;
	
		public int NumberLogin {
				get {
						return numberLogin;
				}
				set {
						numberLogin = value;
						this.setInt (NUMBER_LOGIN, value);
				}
		}

		private int dailyGift;

		public int DailyGift {
				get {
						return dailyGift;
				}
				set {
						dailyGift = value;
						this.setInt (DAILY_GIFT, value);
				}
		}

		private bool firstMoney;

		public bool FirstMoney {
				get {
						return firstMoney;
				}
				set {
						firstMoney = value;
						this.setBool (FIRST_MONEY, value);
				}
		}

		private bool firstCash;

		public bool FirstCash {
				get {
						return firstCash;
				}
				set {
						firstCash = value;
						this.setBool (FIRST_CASH, value);
				}
		}

		private bool inviteFriend;

		public bool InviteFriend {
				get {
						return inviteFriend;
				}
				set {
						inviteFriend = value;
						this.setBool (INVITE_FRIEND, value);
				}
		}

		private bool likeFanPage;

		public bool LikeFanPage {
				get {
						return likeFanPage;
				}
				set {
						likeFanPage = value;
						this.setBool (LIKE_FAN_PAGE, value);
				}
		}

		public override void saveDefaultValue ()
		{
				this.LastLogin = DateTime.Now;
				this.NumberLogin = 0;
				this.DailyGift = 0;
				this.FirstMoney = false;
				this.FirstCash = false;
				this.InviteFriend = false;
				this.LikeFanPage = false;
		}

		public override void load ()
		{
				try {
						this.lastLogin = DateTime.Parse (this.getString (LAST_LOGIN));
				} catch {
						this.lastLogin = DateTime.Now;
				}
		
				this.numberLogin = this.getInt (NUMBER_LOGIN);
				this.dailyGift = this.getInt (DAILY_GIFT);
				this.firstMoney = this.getBool (FIRST_MONEY);
				this.firstCash = this.getBool (FIRST_CASH);
				this.inviteFriend = this.getBool (INVITE_FRIEND);
				this.likeFanPage = this.getBool (LIKE_FAN_PAGE);
		}

		public bool isReceiveGift (int giftID)
		{
				if ((this.dailyGift & (1 << giftID)) != 0) {
						return true;
				} else {
						return false;
				}
		}

		public void receiveGift (int giftID)
		{
				this.DailyGift = this.DailyGift | (1 << giftID);
		}

		public void resetReceiveGift (int giftID)
		{
				this.DailyGift = this.DailyGift & (0 << giftID);
		}
}