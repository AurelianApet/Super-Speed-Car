using UnityEngine;
using System.Collections;

public class HighScoreUserInfo
{
		public string user_id;
		public string username;
		public string score;
		public string level;
		public string nation;
		public string rank;

		public static implicit operator HighScoreUserInfo (bool value)
		{
				if (value == false) {
						return null;
				} else {
						return new HighScoreUserInfo ();
				}
		}

		public override string ToString ()
		{
				return username + "(ID:" + user_id + ",Score:" + score + ",Level:" + level + ",Nation:" + nation + ",Rank:" + rank + ")";
		}
}