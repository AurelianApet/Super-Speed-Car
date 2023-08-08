using UnityEngine;
using System.Collections;

public class UserScore
{
		public string username;
		public string score;
		public string level;
		public string nation;

		public override string ToString ()
		{
				return username + "(Score:" + score + ",Level:" + level + ",Nation:" + nation + ")";
		}
}