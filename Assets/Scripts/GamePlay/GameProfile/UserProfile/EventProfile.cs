using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

public class EventProfile : Profile
{
	public static int NUMBER_EVENT = 18;
	public static string EVENT_DATA = "eventData";

	//
	private string eventProfileData;
	public List<EventProfileData> eventProfileList;

	public EventProfile ()
	{
		this.eventProfileList = new List<EventProfileData> ();
	}

	public override void saveDefaultValue ()
	{
		this.saveEventProfileData ();
	}

	public override void load ()
	{
		this.eventProfileData = this.getString (EVENT_DATA);
		try {
			this.eventProfileList = JsonConvert.DeserializeObject<List<EventProfileData>> (eventProfileData);
		} catch (Exception e) {
			Debug.LogException (e);
			this.eventProfileList = new List<EventProfileData> ();
		}
	}

	public void saveEventProfileData ()
	{
		try {
			this.eventProfileData = JsonConvert.SerializeObject (eventProfileList);
		} catch (Exception e) {
			Debug.LogException (e);
			this.eventProfileList = new List<EventProfileData> ();
		}
		this.setString (EVENT_DATA, this.eventProfileData);
	}

	public void generateEventData ()
	{
		int numberEventNeedGenerated = 3 - getNumberUnfinishedEvent ();

		ID_Pool iDPool = new ID_Pool ();
		iDPool.customInit (NUMBER_EVENT);

		for (int i=0; i<NUMBER_EVENT; i++) {
			if (isHasEvent (i) == false) {
				iDPool.customAdd (i);
			}
		}

		for (int i=0; i<numberEventNeedGenerated; i++) {
			EventProfileData eventData = new EventProfileData ();
			eventData.id = iDPool.allocateID ();
			eventData.finish = 0;
			DateTime time = DateTime.Now;
			eventData.start = time.ToString ();
			eventData.end = time.AddHours (UnityEngine.Random.Range (12, 48)).ToString ();

			eventProfileList.Add (eventData);
		}

		this.saveEventProfileData ();
		PlayerPrefs.Save ();
	}

	public int getNumberUnfinishedEvent ()
	{
		int result = 0;

		foreach (EventProfileData eventProfileData in eventProfileList) {
			if (eventProfileData.finish == 0 || eventProfileData.finish > 3) {
				result++;
			}
		}

		return result;
	}

	public bool isHasEvent (int eventID)
	{
		foreach (EventProfileData eventProfileData in eventProfileList) {
			if (eventProfileData.id == eventID) {
				return true;
			}
		}

		return false;
	}

	public void finishEvent (int eventID, int order)
	{
		foreach (EventProfileData eventProfileData in eventProfileList) {
			if (eventProfileData.id == eventID) {
				if (eventProfileData.finish == 0) {
					eventProfileData.finish = order;

				} else if (eventProfileData.finish > order) {
					eventProfileData.finish = order;
				}
			}
		}
	}

	public void updateEventProfileData ()
	{
		List<EventProfileData> removedEventProfileList = new List<EventProfileData> ();

		for (int i=0; i<eventProfileList.Count; i++) {
			try {
				DateTime endTime = DateTime.Parse (ProfileManager.eventProfile.eventProfileList [i].end);

				if (DateTime.Compare (endTime, DateTime.Now) < 0) {
					if (ProfileManager.eventProfile.eventProfileList [i].finish == 0 || ProfileManager.eventProfile.eventProfileList [i].finish > 3) {
						removedEventProfileList.Add (ProfileManager.eventProfile.eventProfileList [i]);
					} 
				}
			} catch {
			}
		}

		foreach (EventProfileData eventProfileData in removedEventProfileList) {
			eventProfileList.Remove (eventProfileData);
		}

		saveEventProfileData ();
		PlayerPrefs.Save ();
	}
}