using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserScoreCollections
{
		public bool success;
		public string info;
		public List<UserScore> top_list;
		public CurrentUserScore user_score;

		public void printInfo ()
		{
				if (ServerHighscore.isLogDebug == true) {
						Debug.Log ("Result:" + success);
						Debug.Log ("Info:" + info);
		
						if (success == true) {
								if (user_score != null) {
										if (user_score.user != null) {
												Debug.Log ("Current:" + user_score.user);	
										} else {
												Debug.Log ("Current:null");
										}
				
										Debug.Log ("Prev:" + user_score.prev_user.Count + " users");
										foreach (HighScoreUserInfo prev in user_score.prev_user) {				
												Debug.Log (prev);				
										}

										Debug.Log ("Next:" + user_score.next_user.Count + " users");
										foreach (HighScoreUserInfo next in user_score.next_user) {				
												Debug.Log (next);				
										}
								}

								Debug.Log ("Top List:" + top_list.Count + " users");
								foreach (UserScore score in top_list) {				
										Debug.Log (score);				
								}
						}
				}
		}
}