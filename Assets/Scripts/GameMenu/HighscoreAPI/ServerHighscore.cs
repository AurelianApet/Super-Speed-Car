using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

public class ServerHighscore:MonoBehaviour
{
	enum SCORE_TYPE
	{
		DAY,
		WEEK,
		MONTH,
		ALL_TIME
	}

	//
	public static bool isLogDebug = false;
	static string GAME_ID = "9";
	static string HASH_KEY = "@#sunnet2014";

	//
	static string postScoreURL = "http://apiscore.yome.vn/api/save-score";
	static string postScoreURLTopDay = "http://apiscore.yome.vn/api/save-day-score?game_id=" + GAME_ID;
	static string changeNameURL = "http://apiscore.yome.vn/api/change-name";

	//	
	static string getScoreURLTopDay = "http://apiscore.yome.vn/api/get-high-day-score?game_id=" + GAME_ID;
	static string getScoreURLTopWeek = "http://apiscore.yome.vn/api/get-high-score-by-time?game_id=" + GAME_ID + "&type=week";
	static string getScoreURLTopMonth = "http://apiscore.yome.vn/api/get-high-score-by-time?game_id=" + GAME_ID + "&type=month";
	static string getScoreURLAllTime = "http://apiscore.yome.vn/api/get-high-score";

	//
	public static UserScoreCollections topKingOfDay;
	public static UserScoreCollections topWeek;
	public static UserScoreCollections topMonth;
	public static UserScoreCollections topAllTime;

	//	
	static int lastPostScore = -1;
	static bool isChangeName = false;

	//--------------------------------------------------------------------------------
	public void postScore (int score, int level, string user_id, string user_name, string nation)
	{
		if (score > lastPostScore) {
			StartCoroutine (postScoreOnline (score.ToString (), level.ToString (), user_id, user_name, GAME_ID, nation, false));	
			lastPostScore = score;
		}
	}

	public void changeName (string user_id, string newName)
	{
		if (isChangeName == false) {
			StartCoroutine (changeNameOnline (user_id, newName, GAME_ID));
			isChangeName = true;
		}
	}

	public void getScoreWeek (string user_id, int numberRow)
	{
		if (topWeek == null) {
			StartCoroutine (getScoreOnline (user_id, GAME_ID, SCORE_TYPE.WEEK, numberRow));
		}
	}
	
	public void getScoreMonth (string user_id, int numberRow)
	{
		if (topMonth == null) {
			StartCoroutine (getScoreOnline (user_id, GAME_ID, SCORE_TYPE.MONTH, numberRow));
		}
	}
	
	public void getScoreAllTime (string user_id, int numberRow)
	{
		if (topAllTime == null) {
			StartCoroutine (getScoreOnline (user_id, GAME_ID, SCORE_TYPE.ALL_TIME, numberRow));
		}
	}

	public void postScoreKingOfDay (int score, int level, string user_id, string user_name, string nation)
	{
		StartCoroutine (postScoreOnline (score.ToString (), level.ToString (), user_id, user_name, GAME_ID, nation, true));	
	}

	public void getScoreKingOfDay (string user_id, int numberRow)
	{
		if (topKingOfDay == null) {
			StartCoroutine (getScoreOnline (user_id, GAME_ID, SCORE_TYPE.DAY, numberRow));
		}
	}

	//--------------------------------------------------------------------------------
	IEnumerator postScoreOnline (string score, string level, string user_id, string user_name, string game_id, string nation, bool isKingOfDay)
	{
		string time = System.DateTime.Now.Ticks.ToString ();
		
		WWWForm form = new WWWForm ();
		
		form.AddField ("TIMESTAMP", time);

		if (isKingOfDay == false) {
			form.AddField ("HASH", sha256 (postScoreURL + time + HASH_KEY));
		} else {
			form.AddField ("HASH", sha256 (postScoreURLTopDay + time + HASH_KEY));
		}
		
		form.AddField ("score", score);
		form.AddField ("level", level);
		form.AddField ("user_id", user_id);
		form.AddField ("username", user_name);
		form.AddField ("game_id", game_id);
		form.AddField ("nation", nation);

		WWW www;
		if (isKingOfDay == false) {
			www = new WWW (postScoreURL, form);
		} else {
			www = new WWW (postScoreURLTopDay, form);
		}
		yield return www;
		
		if (www.error == null) {		
			if (ServerHighscore.isLogDebug == true) {
				Debug.Log ("WWW OK: " + www.text);
			}
		} else {
			if (ServerHighscore.isLogDebug == true) {
				Debug.Log ("WWW Error: " + www.error);
			}
		}
	}
	
	IEnumerator changeNameOnline (string user_id, string newName, string game_id)
	{
		string time = System.DateTime.Now.Ticks.ToString ();
		
		WWWForm form = new WWWForm ();
		
		form.AddField ("TIMESTAMP", time);
		form.AddField ("HASH", sha256 (changeNameURL + time + HASH_KEY));
		
		form.AddField ("user_id", user_id);
		form.AddField ("username", newName);
		form.AddField ("game_id", game_id);
		
		WWW www = new WWW (changeNameURL, form);
		yield return www;
		
		if (www.error == null) {
			if (ServerHighscore.isLogDebug == true) {
				Debug.Log ("WWW OK: " + www.text);
			}
		} else {
			if (ServerHighscore.isLogDebug == true) {
				Debug.Log ("WWW Error: " + www.error);
			}
		}
	}

	IEnumerator getScoreOnline (string user_id, string game_id, SCORE_TYPE scoreType, int numberRow)
	{
		string time = System.DateTime.Now.Ticks.ToString ();
		
		WWWForm form = new WWWForm ();
		
		form.AddField ("TIMESTAMP", time);
		string link = string.Empty;

		switch (scoreType) {
		case SCORE_TYPE.DAY:
			form.AddField ("HASH", sha256 (getScoreURLTopDay + time + HASH_KEY));
			link = getScoreURLTopDay;
			break;

		case SCORE_TYPE.WEEK:
			form.AddField ("HASH", sha256 (getScoreURLTopWeek + time + HASH_KEY));
			link = getScoreURLTopWeek;
			break;

		case SCORE_TYPE.MONTH:
			form.AddField ("HASH", sha256 (getScoreURLTopMonth + time + HASH_KEY));
			link = getScoreURLTopMonth;
			break;

		case SCORE_TYPE.ALL_TIME:
			form.AddField ("HASH", sha256 (getScoreURLAllTime + time + HASH_KEY));
			link = getScoreURLAllTime;
			break;

		default:
			break;
		}

		form.AddField ("user_id", user_id);
		form.AddField ("game_id", game_id);
		form.AddField ("number_highscore", numberRow);

		WWW www = new WWW (link, form);
		yield return www;

		if (www.error == null) {
			if (ServerHighscore.isLogDebug == true) {
				Debug.Log ("WWW OK: " + www.text);
			}
			saveData (scoreType, www.text);

		} else {
			if (ServerHighscore.isLogDebug == true) {
				Debug.Log ("WWW Error: " + www.error);
			}
		}
	}

	void saveData (SCORE_TYPE scoreType, string data)
	{
		switch (scoreType) {
		case SCORE_TYPE.DAY:
			topKingOfDay = JsonConvert.DeserializeObject<UserScoreCollections> (data);
			topKingOfDay.printInfo ();
			break;

		case SCORE_TYPE.WEEK:
			topWeek = JsonConvert.DeserializeObject<UserScoreCollections> (data);
			topWeek.printInfo ();
			break;
			
		case SCORE_TYPE.MONTH:
			topMonth = JsonConvert.DeserializeObject<UserScoreCollections> (data);
			topMonth.printInfo ();
			break;
			
		case SCORE_TYPE.ALL_TIME:
			topAllTime = JsonConvert.DeserializeObject<UserScoreCollections> (data);
			topAllTime.printInfo ();
			break;
			
		default:
			break;
		}		
	}

	static string sha256 (string password)
	{
		SHA256Managed crypt = new SHA256Managed ();
		string hash = string.Empty;
		byte[] crypto = crypt.ComputeHash (Encoding.UTF8.GetBytes (password), 0, Encoding.UTF8.GetByteCount (password));
		foreach (byte bit in crypto) {
			hash += bit.ToString ("x2");
		}
		return hash;
	}
}