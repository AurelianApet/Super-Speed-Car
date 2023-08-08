using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

public class UserProfile : Profile
{
	public static string DEFAULT_NAME = "NO NAME";
	public static int NUMBER_CAR = 15;
	public static int NUMBER_MAP = 124;

	//
	public static string SELECTED_CAR = "selectedCar";
	public static string PLAYER_NAME = "playerName";
	public static string IS_HAS_NAME = "isHasName";
	public static string MONEY = "money";
	public static string DIAMOND = "diamond";
	public static string SCORE = "score";
	public static string SECOND_SLOT = "secondSlot";
	public static string THIRD_SLOT = "thirdSlot";
	public static string SELECTED_LEVEL = "selectedLevel";
	public static string FACEBOOK_ID = "facebookID";
	public static string USE_FACEBOOK_AVATAR = "useFacebookAvatar";
	public static string NATION_ID = "nationID";
	public static string AVATAR_ID = "avatarID";
	public static string VIP_LEVEL = "vip";
	public static string LAST_BUY_VIP = "lastBuyVip";
	public static string POWER_UP = "powerUp";
	public static string IP_HISTORY = "ipHistory";
	public static string BOUGHT_AVATAR_1 = "boughtAvatar_1";
	public static string BOUGHT_AVATAR_2 = "boughtAvatar_2";
	public static string BOUGHT_POWER_UPS = "boughtPowerUp";

	//
	public static string LAST_SELECTED_LEVEL_IN_SEASON = "lastSelected";
		
	//
	private CarProfile[] carProfile;
	
	public CarProfile[] CarProfile {
		get {
			return carProfile;
		}
		set {
			carProfile = value;
		}
	}

	private MapProfile[] mapProfile;
	
	public MapProfile[] MapProfile {
		get {
			return mapProfile;
		}
		set {
			mapProfile = value;
		}
	}

	private string playerName;

	public string PlayerName {
		get {
			return playerName;
		}
		set {
			playerName = value;
			this.setString (PLAYER_NAME, this.playerName);
		}
	}

	private bool isHasName;

	public bool IsHasName {
		get {
			return isHasName;
		}
		set {
			isHasName = value;
			this.setBool (IS_HAS_NAME, this.isHasName);
		}
	}

	private int selectedCar;
	
	public int SelectedCar {
		get {
			return selectedCar;
		}
		set {
			if (selectedCar != value) {
				selectedCar = value;
				this.setInt (SELECTED_CAR, this.selectedCar);
			}
		}
	}

	private int money;

	public int Money {
		get {
			return money;
		}
		set {
			money = value;
			this.setInt (MONEY, this.money);
		}
	}

	private int diamond;

	public int Diamond {
		get {
			return diamond;
		}
		set {
			diamond = value;
			this.setInt (DIAMOND, this.diamond);
		}
	}

	private int score;

	public int Score {
		get {
			return score;
		}
		set {
			score = value;
			this.setInt (SCORE, this.score);
		}
	}

	private bool isSecondSlotUnlocked;

	public bool IsSecondSlotUnlocked {
		get {
			return isSecondSlotUnlocked;
		}
		set {
			isSecondSlotUnlocked = value;
			this.setBool (SECOND_SLOT, this.isSecondSlotUnlocked);
		}
	}

	private bool isThirdSlotUnlocked;

	public bool IsThirdSlotUnlocked {
		get {
			return isThirdSlotUnlocked;
		}
		set {
			isThirdSlotUnlocked = value;
			this.setBool (THIRD_SLOT, this.isThirdSlotUnlocked);
		}
	}

	private int selectedLevel;

	public int SelectedLevel {
		get {
			return selectedLevel;
		}
		set {
			selectedLevel = value;
			this.setInt (SELECTED_LEVEL, this.selectedLevel);
		}
	}

	private string facebookID;

	public string FacebookID {
		get {
			return facebookID;
		}
		set {
			facebookID = value;
			this.setString (FACEBOOK_ID, value);
		}
	}

	private bool useFacebookAvatar;

	public bool UseFacebookAvatar {
		get {
			return useFacebookAvatar;
		}
		set {
			useFacebookAvatar = value;			
			this.setBool (USE_FACEBOOK_AVATAR, value);
		}
	}

	private int nation;

	public int Nation {
		get {
			return nation;
		}
		set {
			nation = value;
			this.setInt (NATION_ID, value);
		}
	}

	private int avatarID;

	public int AvatarID {
		get {
			return avatarID;
		}
		set {
			avatarID = value;
			this.setInt (AVATAR_ID, value);
		}
	}

	private int vipLevel;

	public int VipLevel {
		get {
			return vipLevel;
		}
		set {
			vipLevel = value;
			this.setInt (VIP_LEVEL, value);
		}
	}

	private DateTime lastBuyVip;

	public DateTime LastBuyVip {
		get {
			return lastBuyVip;
		}
		set {
			lastBuyVip = value;			
			this.setString (LAST_BUY_VIP, value.ToString ());
		}
	}

	private int avatarBought_1;

	public int AvatarBought_1 {
		get {
			return avatarBought_1;
		}
		set {
			avatarBought_1 = value;
			this.setInt (BOUGHT_AVATAR_1, value);
		}
	}

	private int avatarBought_2;

	public int AvatarBought_2 {
		get {
			return avatarBought_2;
		}
		set {
			avatarBought_2 = value;
			this.setInt (BOUGHT_AVATAR_2, value);
		}
	}

	private int boughtPowerUp;

	public int BoughtPowerUp {
		get {
			return boughtPowerUp;
		}
		set {
			boughtPowerUp = value;
			this.setInt (BOUGHT_POWER_UPS, value);
		}
	}

	//
	private string powerUpData;
	public List<BasePowerUpData> powerUpList;

	//
	private string ipHistory;
	public List<string> ipHistoryList;

	//
	private int[] lastSelectedLevelInSeason;

	public UserProfile ()
	{
		carProfile = new CarProfile[NUMBER_CAR];
		for (int i=0; i<carProfile.Length; i++) {
			carProfile [i] = new CarProfile (i);
		}

		mapProfile = new MapProfile[NUMBER_MAP];
		for (int i=0; i<mapProfile.Length; i++) {
			mapProfile [i] = new MapProfile (i);
		}

		this.powerUpList = new List<BasePowerUpData> ();

		this.ipHistoryList = new List<string> ();
		this.ipHistoryList.Add ("192.168.0.1");
		this.ipHistoryList.Add ("192.168.0.2");
		this.ipHistoryList.Add ("192.128.0.1");
		this.ipHistoryList.Add ("192.128.0.2");

		this.lastSelectedLevelInSeason = new int[8];
		for (int i=0; i<lastSelectedLevelInSeason.Length; i++) {
			lastSelectedLevelInSeason [i] = SeasonDescription.getFirstLevelInSeason (i + 1);
		}
	}

	public override void saveDefaultValue ()
	{
		this.SelectedCar = 0;
		this.PlayerName = DEFAULT_NAME;
		this.IsHasName = false;
		this.Money = 1000;
		this.Diamond = 2;
		this.Score = 0;
		this.IsSecondSlotUnlocked = false;
		this.IsThirdSlotUnlocked = false;
		this.SelectedLevel = 0;
				
		this.FacebookID = "0";
		this.UseFacebookAvatar = true;
		RankingMenu.detectLanguage ();
		this.AvatarID = 0;

		this.VipLevel = 0;
		this.LastBuyVip = DateTime.Now;

		this.AvatarBought_1 = 0;
		this.AvatarBought_2 = 0;
		this.BoughtPowerUp = 0;

		this.savePowerUp ();
		this.saveIPHistory ();

		for (int i=0; i<lastSelectedLevelInSeason.Length; i++) {
			this.setInt (LAST_SELECTED_LEVEL_IN_SEASON + "_" + i, lastSelectedLevelInSeason [i]);
		}

		for (int i=0; i<carProfile.Length; i++) {
			carProfile [i].saveDefaultValue ();
		}

		for (int i=0; i<mapProfile.Length; i++) {
			mapProfile [i].saveDefaultValue ();
		}
	}
	
	public override void load ()
	{
		this.selectedCar = this.getInt (SELECTED_CAR);
		this.playerName = this.getString (PLAYER_NAME);
		this.isHasName = this.getBool (IS_HAS_NAME);
		this.money = this.getInt (MONEY);
		this.diamond = this.getInt (DIAMOND);
		this.score = this.getInt (SCORE);
		this.isSecondSlotUnlocked = this.getBool (SECOND_SLOT);
		this.isThirdSlotUnlocked = this.getBool (THIRD_SLOT);
		this.selectedLevel = this.getInt (SELECTED_LEVEL);

		this.facebookID = this.getString (FACEBOOK_ID);
		this.useFacebookAvatar = this.getBool (USE_FACEBOOK_AVATAR);
		this.nation = this.getInt (NATION_ID);
		this.avatarID = this.getInt (AVATAR_ID);

		this.vipLevel = this.getInt (VIP_LEVEL);
		this.lastBuyVip = DateTime.Parse (this.getString (LAST_BUY_VIP));

		this.avatarBought_1 = this.getInt (BOUGHT_AVATAR_1);
		this.avatarBought_2 = this.getInt (BOUGHT_AVATAR_2);
		this.boughtPowerUp = this.getInt (BOUGHT_POWER_UPS);

		this.powerUpData = this.getString (POWER_UP);
		try {
			this.powerUpList = JsonConvert.DeserializeObject<List<BasePowerUpData>> (powerUpData);
		} catch (Exception e) {
			Debug.LogException (e);
			this.powerUpList = new List<BasePowerUpData> ();
		}

		this.ipHistory = this.getString (IP_HISTORY);
		try {
			this.ipHistoryList = JsonConvert.DeserializeObject<List<string>> (ipHistory);
		} catch (Exception e) {
			Debug.LogException (e);
			this.ipHistoryList = new List<string> ();
		}

		for (int i=0; i<lastSelectedLevelInSeason.Length; i++) {
			this.lastSelectedLevelInSeason [i] = this.getInt (LAST_SELECTED_LEVEL_IN_SEASON + "_" + i);
		}

		for (int i=0; i<carProfile.Length; i++) {
			carProfile [i].load ();
		}

		for (int i=0; i<mapProfile.Length; i++) {
			mapProfile [i].load ();
		}
	}

	public void savePowerUp ()
	{
		try {
			this.powerUpData = JsonConvert.SerializeObject (powerUpList);
		} catch (Exception e) {
			Debug.LogException (e);
			this.powerUpList = new List<BasePowerUpData> ();
		}
		this.setString (POWER_UP, this.powerUpData);
	}

	public void saveIPHistory ()
	{
		try {
			this.ipHistory = JsonConvert.SerializeObject (ipHistoryList);
		} catch (Exception e) {
			Debug.LogException (e);
			this.ipHistoryList = new List<string> ();
		}
		this.setString (IP_HISTORY, this.ipHistory);
	}

	public void insertIP (string IP)
	{
		foreach (string ip in ipHistoryList) {
			if (IP == ip) {
				return;
			}
		}
		ProfileManager.userProfile.ipHistoryList.Insert (0, IP);
		ProfileManager.userProfile.ipHistoryList.RemoveAt (ProfileManager.userProfile.ipHistoryList.Count - 1);
		ProfileManager.userProfile.saveIPHistory ();
	}

	public bool isLevelUnlocked (int level)
	{
		if (level == 0) {
			return true;

		} else {
			if (MapProfile [level - 1].MainMission > 0) {
				return true;
			} else {
				return false;
			}
		}
	}

	public void saveLastSelectedLevelInSeason (int season, int level)
	{
		lastSelectedLevelInSeason [season - 1] = level;
		this.setInt (LAST_SELECTED_LEVEL_IN_SEASON + "_" + (season - 1), level);
	}

	public int getLastSelectedLevelInSeason (int season)
	{
		return lastSelectedLevelInSeason [season - 1];
	}

	public int getNumberStar ()
	{
		int numberStar = 0;
		
		for (int i=0; i<mapProfile.Length; i++) {
			numberStar += mapProfile [i].MainMission;
			
			if (mapProfile [i].FirstMission == true) {
				numberStar++;
			}
			
			if (mapProfile [i].SecondMission == true) {
				numberStar++;
			}
		}
		
		return numberStar;
	}
	
	public int getNumberCar ()
	{
		int numberCar = 0;
		
		for (int i=0; i<carProfile.Length; i++) {
			if (carProfile [i].IsBought == true) {
				numberCar++;
			}
		}
		
		return numberCar;
	}
	
	public bool isBuyFirstUpgrade ()
	{
		for (int i=0; i<carProfile.Length; i++) {
			if (carProfile [i].Acceleration > 0 || carProfile [i].Speed > 0 || carProfile [i].Nitro > 0 || carProfile [i].Handling > 0) {
				return true;
			}
		}
		
		return false;
	}
	
	public int getNumberFullyUpgradeCars ()
	{
		int numberFullyUpgradeCars = 0;
		
		for (int i=0; i<carProfile.Length; i++) {
			if (carProfile [i].Acceleration == 4 && carProfile [i].Speed == 4 && carProfile [i].Nitro == 4 && carProfile [i].Handling == 4) {
				numberFullyUpgradeCars++;
			}
		}
		
		return numberFullyUpgradeCars;
	}

	public int getPlayedMapsBySeason (int season)
	{
		int result = 0;
		switch (season) {
		case 0:
			for (int i=0; i<10; i++) {
				if (mapProfile [i].MainMission > 0) {
					result++;
				}
			}
			return result;

		case 1:
			for (int i=10; i<22; i++) {
				if (mapProfile [i].MainMission > 0) {
					result++;
				}
			}
			return result;

		case 2:
			for (int i=22; i<36; i++) {
				if (mapProfile [i].MainMission > 0) {
					result++;
				}
			}
			return result;

		case 3:
			for (int i=36; i<52; i++) {
				if (mapProfile [i].MainMission > 0) {
					result++;
				}
			}
			return result;

		case 4:
			for (int i=52; i<70; i++) {
				if (mapProfile [i].MainMission > 0) {
					result++;
				}
			}
			return result;

		case 5:
			for (int i=70; i<88; i++) {
				if (mapProfile [i].MainMission > 0) {
					result++;
				}
			}
			return result;

		case 6:
			for (int i=88; i<108; i++) {
				if (mapProfile [i].MainMission > 0) {
					result++;
				}
			}
			return result;

		case 7:
			for (int i=108; i<mapProfile.Length; i++) {
				if (mapProfile [i].MainMission > 0) {
					result++;
				}
			}
			return result;

		default:
			return result;
		}
	}

	public int getNumberStarsBySeason (int season)
	{
		int result = 0;
		switch (season) {
		case 0:
			for (int i=0; i<10; i++) {
				result += mapProfile [i].MainMission;

				if (ProfileManager.userProfile.mapProfile [i].FirstMission == true) {
					result++;
				}

				if (ProfileManager.userProfile.mapProfile [i].SecondMission == true) {
					result++;
				}
			}
			return result;
			
		case 1:
			for (int i=10; i<22; i++) {
				result += mapProfile [i].MainMission;
				
				if (ProfileManager.userProfile.mapProfile [i].FirstMission == true) {
					result++;
				}
				
				if (ProfileManager.userProfile.mapProfile [i].SecondMission == true) {
					result++;
				}
			}
			return result;
			
		case 2:
			for (int i=22; i<36; i++) {
				result += mapProfile [i].MainMission;
				
				if (ProfileManager.userProfile.mapProfile [i].FirstMission == true) {
					result++;
				}
				
				if (ProfileManager.userProfile.mapProfile [i].SecondMission == true) {
					result++;
				}
			}
			return result;
			
		case 3:
			for (int i=36; i<52; i++) {
				result += mapProfile [i].MainMission;
				
				if (ProfileManager.userProfile.mapProfile [i].FirstMission == true) {
					result++;
				}
				
				if (ProfileManager.userProfile.mapProfile [i].SecondMission == true) {
					result++;
				}
			}
			return result;
			
		case 4:
			for (int i=52; i<70; i++) {
				result += mapProfile [i].MainMission;
				
				if (ProfileManager.userProfile.mapProfile [i].FirstMission == true) {
					result++;
				}
				
				if (ProfileManager.userProfile.mapProfile [i].SecondMission == true) {
					result++;
				}
			}
			return result;
			
		case 5:
			for (int i=70; i<88; i++) {
				result += mapProfile [i].MainMission;
				
				if (ProfileManager.userProfile.mapProfile [i].FirstMission == true) {
					result++;
				}
				
				if (ProfileManager.userProfile.mapProfile [i].SecondMission == true) {
					result++;
				}
			}
			return result;
			
		case 6:
			for (int i=88; i<108; i++) {
				result += mapProfile [i].MainMission;
				
				if (ProfileManager.userProfile.mapProfile [i].FirstMission == true) {
					result++;
				}
				
				if (ProfileManager.userProfile.mapProfile [i].SecondMission == true) {
					result++;
				}
			}
			return result;
			
		case 7:
			for (int i=180; i<mapProfile.Length; i++) {
				result += mapProfile [i].MainMission;
				
				if (ProfileManager.userProfile.mapProfile [i].FirstMission == true) {
					result++;
				}
				
				if (ProfileManager.userProfile.mapProfile [i].SecondMission == true) {
					result++;
				}
			}
			return result;
			
		default:
			return result;
		}
	}

	public bool isSeasonUnlocked (int season)
	{
		switch (season) {
		case 1:
			return true;

		case 2:
			if (this.getNumberStar () >= 30) {
				return true;
			} else {
				return false;
			}

		case 3:
			if (this.getNumberStar () >= 70) {
				return true;
			} else {
				return false;
			}

		case 4:
			if (this.getNumberStar () >= 120) {
				return true;
			} else {
				return false;
			}

		case 5:
			if (this.getNumberStar () >= 210) {
				return true;
			} else {
				return false;
			}

		case 6:
			if (this.getNumberStar () >= 300) {
				return true;
			} else {
				return false;
			}

		case 7:
			if (this.getNumberStar () >= 400) {
				return true;
			} else {
				return false;
			}

		case 8:
			if (this.getNumberStar () >= 500) {
				return true;
			} else {
				return false;
			}

		default:
			return false;
		}
	}

	public int getHighestLevel ()
	{
		int level = 0;
		for (int i=0; i<mapProfile.Length; i++) {
			if (mapProfile [i].MainMission > 0 || mapProfile [i].FirstMission == true || mapProfile [i].SecondMission == true) {
				level = i;
			}
		}

		return level + 1;
	}

	public int getNumberPowerUpByType (BasePowerUp.POWER_UP_TYPE powerUpType, int level)
	{
		int result = 0;

		foreach (BasePowerUpData powerUp in powerUpList) {
			if (powerUp.t == (int)powerUpType && powerUp.l == level) {
				result++;
			}
		}

		return result;
	}

	public void checkVIP ()
	{
		TimeSpan timeSpan = new TimeSpan (DateTime.Now.Ticks - lastBuyVip.Ticks);

		switch (vipLevel) {
		case 1:
			if (timeSpan.TotalHours >= 72) {
				ProfileManager.userProfile.VipLevel = 0;				
				PlayerPrefs.Save ();
				
			}
			break;

		case 2:
			if (timeSpan.TotalHours >= 168) {
				ProfileManager.userProfile.VipLevel = 0;				
				PlayerPrefs.Save ();
				
			}
			break;

		case 3:
			if (timeSpan.TotalHours >= 360) {
				ProfileManager.userProfile.VipLevel = 0;				
				PlayerPrefs.Save ();
				
			}
			break;

		default:
			break;
		}
	}

	public bool isAvatarBought (int id)
	{
		int avatarID = id - 10;

		if (avatarID < 30) {
			if ((this.avatarBought_1 & (1 << avatarID)) != 0) {
				return true;
			} else {
				return false;
			}
		} else {
			if ((this.avatarBought_2 & (1 << avatarID)) != 0) {
				return true;
			} else {
				return false;
			}
		}
	}

	public void boughtAvatar (int id)
	{
		int avatarID = id - 10;

		if (avatarID < 30) {
			this.AvatarBought_1 = this.AvatarBought_1 | (1 << avatarID);
		} else {			
			this.AvatarBought_2 = this.AvatarBought_2 | (1 << avatarID);
		}
	}

	public bool isPowerUpBought (int powerUpID)
	{
		if ((this.boughtPowerUp & (1 << powerUpID)) != 0) {
			return true;
		} else {
			return false;
		}
	}

	public void saveBoughtPowerUp (int powerUpID)
	{
		this.BoughtPowerUp = this.BoughtPowerUp | (1 << powerUpID);
	}
}