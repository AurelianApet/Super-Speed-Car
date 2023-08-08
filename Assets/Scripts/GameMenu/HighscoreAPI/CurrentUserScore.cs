using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CurrentUserScore
{
		public HighScoreUserInfo user;
		public List<HighScoreUserInfo> prev_user;
		public List<HighScoreUserInfo> next_user;

		public static implicit operator CurrentUserScore (bool value)
		{
				if (value == false) {
						return null;
				} else {
						return new CurrentUserScore ();
				}
		}
}
