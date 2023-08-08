using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using System;

public class QuestProfileItem:Profile
{
	string tag;
	int questType;

	//
	public QuestProfileData data;

	public QuestProfileItem (string tag, int questType)
	{
		this.tag = tag;
		this.questType = questType;

		this.data = new QuestProfileData ();
	}

	public override void saveDefaultValue ()
	{
	}
	
	public override void load ()
	{
		try {
			data = JsonConvert.DeserializeObject<QuestProfileData> (this.getString (tag));		
		} catch (Exception e) {
			Debug.LogException (e);
			this.generateQuest ();
		}
	}

	public void save ()
	{
		try {
			this.setString (tag, JsonConvert.SerializeObject (data));
		} catch (Exception e) {
			Debug.LogException (e);
		}
	}

	public void generateQuest ()
	{
		data.generateQuest (questType);
		this.save ();
	}

	public bool isComplete ()
	{
		if (data.progress == data.aim) {
			return true;
		} else {
			return false;
		}
	}

	public void updateQuest (Game game)
	{
		data.updateQuest (game, questType);
		this.save ();
	}
}