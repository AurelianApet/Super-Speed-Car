using UnityEngine;
using System.Collections;
using System;

public class QuestProfile : Profile
{
	//
	public static string DAILY_QUEST = "dailyQuest";
	public static string VIP_QUEST = "vipQuest";
	public static string RANDOM_QUEST = "randomQuest";
	public static string LAST_GEN_QUEST = "lastGenQuest";

	//
	public QuestProfileItem dailyQuest;
	public QuestProfileItem vipQuest;
	public QuestProfileItem randomQuest;

	//
	private DateTime lastGenQuest;

	public DateTime LastGenQuest {
		get {
			return lastGenQuest;
		}
		set {
			lastGenQuest = value;
			this.setString (LAST_GEN_QUEST, this.lastGenQuest.ToString ());
		}
	}

	public QuestProfile ()
	{
		this.dailyQuest = new QuestProfileItem (DAILY_QUEST, 0);
		this.vipQuest = new QuestProfileItem (VIP_QUEST, 1);
		this.randomQuest = new QuestProfileItem (RANDOM_QUEST, 2);
	}

	public override void saveDefaultValue ()
	{
		this.dailyQuest.generateQuest ();
		this.vipQuest.generateQuest ();
		this.randomQuest.generateQuest ();
		this.LastGenQuest = DateTime.Now;
	}
	
	public override void load ()
	{		
		try {
			this.lastGenQuest = DateTime.Parse (this.getString (LAST_GEN_QUEST));
			TimeSpan timeSpan = new TimeSpan (DateTime.Now.Ticks - lastGenQuest.Ticks);

			if (timeSpan.TotalHours >= 24) {
				this.dailyQuest.generateQuest ();
				this.vipQuest.generateQuest ();
				this.randomQuest.generateQuest ();
				this.LastGenQuest = DateTime.Now;
				ProfileManager.achievementProfile.resetGift ();

				PlayerPrefs.Save ();

			} else {			
				this.dailyQuest.load ();
				this.vipQuest.load ();
				this.randomQuest.load ();
			}
		} catch {
			this.dailyQuest.generateQuest ();
			this.vipQuest.generateQuest ();
			this.randomQuest.generateQuest ();
			this.LastGenQuest = DateTime.Now;
			
			PlayerPrefs.Save ();
		}
	}

	public int getNumberUnfinishedQuest ()
	{
		int result = 0;

		if (dailyQuest.isComplete () == false) {
			result++;
		}

		if (vipQuest.isComplete () == false) {
			result++;
		}

		if (randomQuest.isComplete () == false) {
			result++;
		}
		
		return result;
	}

	public void updateQuest (Game game)
	{
		dailyQuest.updateQuest (game);
		vipQuest.updateQuest (game);
		randomQuest.updateQuest (game);
	}
}