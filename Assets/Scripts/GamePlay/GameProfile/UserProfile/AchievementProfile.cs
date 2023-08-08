using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementProfile : Profile
{
		//--------------------------------------------------------------------------------
		public static string NUMBER_FACEBOOK_SHARE = "numberShare";
		public static string NUMBER_QUICK_RACE_WIN = "numberQuickRaceWin";

		//--------------------------------------------------------------------------------
		public static string WIN_WITHOUT_USING_NITRO = "winWithoutUsingNitro";
		public static string MAX_SPEED_REACH = "maxSpeedReach";
		public static string NUMBER_DESTROYED_OBSTACLES = "numberDestroyedObstacles";
		public static string DOLLAR_EARNED = "earnedDollar";
		public static string DRIFT_DURATION = "driftDuration";
		public static string FLY_DURATION = "flyDuration";

		//--------------------------------------------------------------------------------
		public static string NITRO_USING_DURATION = "nitroUsingDuration";
		public static string COIN_EARN = "coinEarn";
		public static string MULTIPLAYER_WIN = "multiplayerWin";
		public static string MULTIPLAYER_LOSE = "multiplayerLose";

		//--------------------------------------------------------------------------------

		public static string  IS_GET_REWARD_CAR = "carReward";
		public static string  IS_GET_REWARD_CHALLENGE = "challengeReward";
		public static string  IS_GET_REWARD_SKILL = "skillReward";
		public static string  IS_GET_REWARD_STAR = "starReward";

		//--------------------------------------------------------------------------------

		public static string  NUMBER_PLAY_CAREER = "numberPlayCareer";
		public static string  NUMBER_PLAY_CLASSIC = "numberPlayClassic";
		public static string  NUMBER_PLAY_TIME_TRIAL = "numberPlayTimeTrial";
		public static string  NUMBER_PLAY_CHECK_POINT = "numberPlayCheckPoint";
		public static string  NUMBER_PLAY_ELIMINATION = "numberPlayElimination";
		public static string  NUMBER_PLAY_MULTIPLAYER = "numberPlayMultiplayer";

		//--------------------------------------------------------------------------------
		private int numberFacebookShare;

		public int NumberFacebookShare {
				get {
						return numberFacebookShare;
				}
				set {
						numberFacebookShare = value;
						this.setInt (NUMBER_FACEBOOK_SHARE, value);
				}
		}

		private int numberQuickRaceWin;

		public int NumberQuickRaceWin {
				get {
						return numberQuickRaceWin;
				}
				set {
						numberQuickRaceWin = value;
						this.setInt (NUMBER_QUICK_RACE_WIN, value);
				}
		}

		//--------------------------------------------------------------------------------
		private bool winWithoutUsingNitro;

		public bool WinWithoutUsingNitro {
				get {
						return winWithoutUsingNitro;
				}
				set {
						winWithoutUsingNitro = value;
						this.setBool (WIN_WITHOUT_USING_NITRO, value);
				}
		}

		private float maxSpeedReach;

		public float MaxSpeedReach {
				get {
						return maxSpeedReach;
				}
				set {
						maxSpeedReach = value;
						this.setFloat (MAX_SPEED_REACH, value);
				}
		}

		private int numberDestroyedObstacles;

		public int NumberDestroyedObstacles {
				get {
						return numberDestroyedObstacles;
				}
				set {
						numberDestroyedObstacles = value;
						this.setInt (NUMBER_DESTROYED_OBSTACLES, value);
				}
		}

		private int dollarEarned;

		public int DollarEarned {
				get {
						return dollarEarned;
				}
				set {
						dollarEarned = value;
						this.setInt (DOLLAR_EARNED, value);
				}
		}

		private float driftDuration;

		public float DriftDuration {
				get {
						return driftDuration;
				}
				set {
						driftDuration = value;
						this.setFloat (DRIFT_DURATION, value);
				}
		}

		private float flyDuration;

		public float FlyDuration {
				get {
						return flyDuration;
				}
				set {
						flyDuration = value;
						this.setFloat (FLY_DURATION, value);
				}
		}

		private int carReward;

		private int CarReward {
				get {
						return carReward;
				}
				set {
						carReward = value;
						this.setInt (IS_GET_REWARD_CAR, value);
				}
		}

		private int challengeReward;

		private int ChallengeReward {
				get {
						return challengeReward;
				}
				set {
						challengeReward = value;
						this.setInt (IS_GET_REWARD_CHALLENGE, value);
				}
		}

		private int skillReward;

		private int SkillReward {
				get {
						return skillReward;
				}
				set {
						skillReward = value;
						this.setInt (IS_GET_REWARD_SKILL, value);
				}
		}

		private int starReward;

		private int StarReward {
				get {
						return starReward;
				}
				set {
						starReward = value;
						this.setInt (IS_GET_REWARD_STAR, value);
				}
		}

		private float nitroUsingDuration;

		public float NitroUsingDuration {
				get {
						return nitroUsingDuration;
				}
				set {
						nitroUsingDuration = value;
						this.setFloat (NITRO_USING_DURATION, value);
				}
		}

		private float coinEarn;

		public float CoinEarn {
				get {
						return coinEarn;
				}
				set {
						coinEarn = value;
						this.setFloat (COIN_EARN, value);
				}
		}

		private float multiplayerWin;

		public float MultiplayerWin {
				get {
						return multiplayerWin;
				}
				set {
						multiplayerWin = value;
						this.setFloat (MULTIPLAYER_WIN, value);
				}
		}

		private float multiplayerLose;

		public float MultiplayerLose {
				get {
						return multiplayerLose;
				}
				set {
						multiplayerLose = value;
						this.setFloat (MULTIPLAYER_LOSE, value);
				}
		}

		private int numberPlayCareer;

		public int NumberPlayCareer {
				get {
						return numberPlayCareer;
				}
				set {
						numberPlayCareer = value;
						this.setInt (NUMBER_PLAY_CAREER, value);
				}
		}

		private int numberPlayClassic;

		public int NumberPlayClassic {
				get {
						return numberPlayClassic;
				}
				set {
						numberPlayClassic = value;
						this.setInt (NUMBER_PLAY_CLASSIC, value);
				}
		}

		private int numberPlayCheckPoint;

		public int NumberPlayCheckPoint {
				get {
						return numberPlayCheckPoint;
				}
				set {
						numberPlayCheckPoint = value;
						this.setInt (NUMBER_PLAY_CHECK_POINT, value);
				}
		}

		private int numberPlayTimeTrial;

		public int NumberPlayTimeTrial {
				get {
						return numberPlayTimeTrial;
				}
				set {
						numberPlayTimeTrial = value;
						this.setInt (NUMBER_PLAY_TIME_TRIAL, value);
				}
		}

		private int numberPlayElimination;

		public int NumberPlayElimination {
				get {
						return numberPlayElimination;
				}
				set {
						numberPlayElimination = value;
						this.setInt (NUMBER_PLAY_ELIMINATION, value);
				}
		}

		private int numberPlayMultiplayer;

		public int NumberPlayMultiplayer {
				get {
						return numberPlayMultiplayer;
				}
				set {
						numberPlayMultiplayer = value;
						this.setInt (NUMBER_PLAY_MULTIPLAYER, value);
				}
		}

		public override void saveDefaultValue ()
		{
				this.NumberFacebookShare = 0;
				this.NumberQuickRaceWin = 0;

				this.CarReward = 0;
				this.ChallengeReward = 0;
				this.SkillReward = 0;
				this.StarReward = 0;

				this.NitroUsingDuration = 0;
				this.CoinEarn = 0;
				this.MultiplayerWin = 0;
				this.MultiplayerLose = 0;

				this.WinWithoutUsingNitro = false;
				this.NumberDestroyedObstacles = 0;
				this.MaxSpeedReach = 0;
				this.DollarEarned = 0;
				this.DriftDuration = 0;
				this.FlyDuration = 0;

				this.NumberPlayCareer = 0;
				this.NumberPlayClassic = 0;
				this.NumberPlayCheckPoint = 0;
				this.NumberPlayTimeTrial = 0;
				this.NumberPlayElimination = 0;
				this.NumberPlayMultiplayer = 0;
		}
	
		public override void load ()
		{
				this.numberFacebookShare = this.getInt (NUMBER_FACEBOOK_SHARE);
				this.numberQuickRaceWin = this.getInt (NUMBER_QUICK_RACE_WIN);

				this.carReward = this.getInt (IS_GET_REWARD_CAR);
				this.challengeReward = this.getInt (IS_GET_REWARD_CHALLENGE);
				this.skillReward = this.getInt (IS_GET_REWARD_SKILL);
				this.starReward = this.getInt (IS_GET_REWARD_STAR);

				this.nitroUsingDuration = this.getInt (NITRO_USING_DURATION);
				this.coinEarn = this.getInt (COIN_EARN);
				this.multiplayerWin = this.getInt (MULTIPLAYER_WIN);
				this.multiplayerLose = this.getInt (MULTIPLAYER_LOSE);
	
				this.winWithoutUsingNitro = this.getBool (WIN_WITHOUT_USING_NITRO);
				this.numberDestroyedObstacles = this.getInt (NUMBER_DESTROYED_OBSTACLES);
				this.maxSpeedReach = this.getFloat (MAX_SPEED_REACH);
				this.dollarEarned = this.getInt (DOLLAR_EARNED);
				this.driftDuration = this.getFloat (DRIFT_DURATION);
				this.flyDuration = this.getFloat (FLY_DURATION);

				this.numberPlayCareer = this.getInt (NUMBER_PLAY_CAREER);
				this.numberPlayClassic = this.getInt (NUMBER_PLAY_CLASSIC);
				this.numberPlayCheckPoint = this.getInt (NUMBER_PLAY_CHECK_POINT);
				this.numberPlayTimeTrial = this.getInt (NUMBER_PLAY_TIME_TRIAL);
				this.numberPlayElimination = this.getInt (NUMBER_PLAY_ELIMINATION);
				this.numberPlayMultiplayer = this.getInt (NUMBER_PLAY_MULTIPLAYER);
		}

		public void saveGetRewardAchievement (GameData.ACHIEVEMENT_TYPE achievementType, int achievementID)
		{
				switch (achievementType) {
				case GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT:
						this.CarReward = this.CarReward | (1 << achievementID);
						break;

				case GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT:
						this.ChallengeReward = this.ChallengeReward | (1 << achievementID);
						break;

				case GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT:
						this.SkillReward = this.SkillReward | (1 << achievementID);
						break;

				case GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT:
						this.StarReward = this.StarReward | (1 << achievementID);
						break;

				default:
						break;
				}
		}

		public bool isGetReward (GameData.ACHIEVEMENT_TYPE achievementType, int achievementID)
		{
				switch (achievementType) {
				case GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT:		
						if ((this.CarReward & (1 << achievementID)) != 0) {
								return true;
						} else {
								return false;
						}

				case GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT:
						if ((this.ChallengeReward & (1 << achievementID)) != 0) {
								return true;
						} else {
								return false;
						}
			
				case GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT:
						if ((this.SkillReward & (1 << achievementID)) != 0) {
								return true;
						} else {
								return false;
						}
			
				case GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT:
						if ((this.StarReward & (1 << achievementID)) != 0) {
								return true;
						} else {
								return false;
						}
			
				default:
						return false;
				}
		}

		public void resetGift ()
		{
				this.NumberPlayCareer = 0;
				this.NumberPlayClassic = 0;
				this.NumberPlayTimeTrial = 0;
				this.NumberPlayElimination = 0;
				this.NumberPlayCheckPoint = 0;
				this.NumberPlayMultiplayer = 0;

				ProfileManager.dailyBonusProfile.resetReceiveGift (11);
				ProfileManager.dailyBonusProfile.resetReceiveGift (12);
				ProfileManager.dailyBonusProfile.resetReceiveGift (13);
				ProfileManager.dailyBonusProfile.resetReceiveGift (14);
				ProfileManager.dailyBonusProfile.resetReceiveGift (15);
				ProfileManager.dailyBonusProfile.resetReceiveGift (16);
		}
}