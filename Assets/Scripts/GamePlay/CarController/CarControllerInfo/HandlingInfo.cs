using UnityEngine;
using System.Collections;

public class HandlingInfo
{
		public float throttle;
		public float steer;
		public bool isNitroUsing;

		public override string ToString ()
		{
				return string.Format (throttle + "_" + steer + "_" + isNitroUsing);
		}
}
