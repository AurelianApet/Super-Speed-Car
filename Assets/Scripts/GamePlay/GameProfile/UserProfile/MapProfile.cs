using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using System;

public class MapProfile : Profile
{
	public static string MAP_TAG = "mapStatus_";

	//
	private int ID;

	public int MainMission {
		get {
			return mapProfileData.m;
		}
		set {
			this.mapProfileData.m = value;
			this.save ();
		}
	}

	public bool FirstMission {
		get {
			if (mapProfileData.f == 1) {
				return true;
			} else {
				return false;
			}
		}
		set {
			if (value == true) {
				this.mapProfileData.f = 1;
			} else {
				this.mapProfileData.f = 0;
			}
			this.save ();
		}
	}

	public bool SecondMission {
		get {
			if (mapProfileData.s == 1) {
				return true;
			} else {
				return false;
			}
		}
		set {
			if (value == true) {
				this.mapProfileData.s = 1;
			} else {
				this.mapProfileData.s = 0;
			}
			this.save ();
		}
	}

	private MapProfileData mapProfileData;

	public MapProfile (int id)
	{
		this.ID = id;
		this.mapProfileData = new MapProfileData ();
	}

	public override void saveDefaultValue ()
	{	
		this.mapProfileData.saveDefaultValue ();
		this.save ();
	}
	
	public override void load ()
	{
		try {
			mapProfileData = JsonConvert.DeserializeObject<MapProfileData> (this.getString (MAP_TAG + ID));
		} catch (Exception e) {
			Debug.LogException (e);
			mapProfileData.saveDefaultValue ();
			this.save ();
		}
	}

	private void save ()
	{
		try {
			this.setString (MAP_TAG + ID, JsonConvert.SerializeObject (mapProfileData));
		} catch (Exception e) {
			Debug.LogException (e);
		}
	}
}
