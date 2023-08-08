using UnityEngine;
using System.Collections;

public class OrderInfo
{
		public int id;
		public int carID;
		public string playerName;

		public override string ToString ()
		{
				return string.Format (id + "_" + carID + "_" + playerName);
		}
}
