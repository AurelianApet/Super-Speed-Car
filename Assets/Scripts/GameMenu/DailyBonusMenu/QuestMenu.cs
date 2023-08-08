using UnityEngine;
using System.Collections;
using System;

public class QuestMenu : BaseHeaderMenu
{
		public enum QUEST_TYPE
		{
				FLY,
				USE_NITRO,
				GO_SHORTCUT,
				DRIFT,
				EARN_COINS,
				EARN_NITRO,
				MAX_SPEED,
				DESTROY_OBSTACLES
		}

		//
		public AudioSource audioSource;
		public AudioSource click;

		//
		public dfButton vipButton;
		public QuestItem[] questItemList;
		public dfSprite vipQuest;
		public dfLabel questRemainingTime;

		void Start ()
		{
				ProfileManager.init ();	

				audioSource.volume = ProfileManager.setttings.MusicVolume / 100f;
				audioSource.Play ();
		
				click.volume = ProfileManager.setttings.SoundVolume / 100f;

				if (ProfileManager.userProfile.VipLevel == 0) {
						vipQuest.Opacity = 0.5f;
						vipButton.IsVisible = true;
				} else {			
						vipButton.IsVisible = false;
				}
		}

		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.Escape)) {
						AutoFade.LoadLevel ("MainMenu");
			
				} else {
						this.updateInfo ();

						TimeSpan timeSpan = new TimeSpan (ProfileManager.questProfile.LastGenQuest.Ticks - DateTime.Now.Ticks + TimeSpan.FromHours (24).Ticks);
						questRemainingTime.Text = "Remaining Time: " + timeSpan.Days + "d " 
								+ timeSpan.Hours + "h " + timeSpan.Minutes + "m " + timeSpan.Seconds + "s";			
			
						questItemList [0].updateData (ProfileManager.questProfile.dailyQuest.data);
						questItemList [1].updateData (ProfileManager.questProfile.vipQuest.data);
						questItemList [2].updateData (ProfileManager.questProfile.randomQuest.data);
				}
		}

		public void back ()
		{
				click.Play ();
				AutoFade.LoadLevel ("MainMenu");
		}

		public void receiveDaily ()
		{
				click.Play ();
				if (ProfileManager.questProfile.dailyQuest.data.receive == false) {
						ProfileManager.questProfile.dailyQuest.data.receive = true;
						ProfileManager.questProfile.dailyQuest.save ();

						ProfileManager.userProfile.Money += ProfileManager.questProfile.dailyQuest.data.money;
						ProfileManager.userProfile.Diamond += ProfileManager.questProfile.dailyQuest.data.cash;
						PlayerPrefs.Save ();
				}
		}

		public void receiveVip ()
		{
				click.Play ();
				if (ProfileManager.questProfile.vipQuest.data.receive == false) {
						ProfileManager.questProfile.vipQuest.data.receive = true;
						ProfileManager.questProfile.vipQuest.save ();

						ProfileManager.userProfile.Money += ProfileManager.questProfile.vipQuest.data.money;
						ProfileManager.userProfile.Diamond += ProfileManager.questProfile.vipQuest.data.cash;
						PlayerPrefs.Save ();
				}
		}

		public void receiveRandom ()
		{
				click.Play ();
				if (ProfileManager.questProfile.randomQuest.data.receive == false) {
						ProfileManager.questProfile.randomQuest.data.receive = true;
						ProfileManager.questProfile.randomQuest.save ();

						ProfileManager.userProfile.Money += ProfileManager.questProfile.randomQuest.data.money;
						ProfileManager.userProfile.Diamond += ProfileManager.questProfile.randomQuest.data.cash;
						PlayerPrefs.Save ();
				}
		}

		public static string getQuestContent (QuestProfileData questData)
		{
				switch ((QUEST_TYPE)questData.id) {
				case QUEST_TYPE.FLY:
						return "Fly for " + questData.aim + " seconds";

				case QUEST_TYPE.USE_NITRO:
						return "Use nitro for " + questData.aim + " seconds";

				case QUEST_TYPE.GO_SHORTCUT:
						return "Go shortcut " + questData.aim + " times";

				case QUEST_TYPE.DRIFT:
						return "Drift for " + questData.aim + " seconds";

				case QUEST_TYPE.EARN_COINS:
						return "Earn " + questData.aim + " coins";

				case QUEST_TYPE.EARN_NITRO:
						return "Earn " + questData.aim + " nitro";

				case QUEST_TYPE.MAX_SPEED:
						return "Reach " + questData.aim + " km/h";

				case QUEST_TYPE.DESTROY_OBSTACLES:
						return "Destroy " + questData.aim + " obstacles";

				default:
						return "Fly 120 seconds";
				}
		}
}