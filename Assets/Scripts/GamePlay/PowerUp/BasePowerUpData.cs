using UnityEngine;
using System.Collections;

public class BasePowerUpData
{
		public int t;//type
		public int l;//level

		public static BasePowerUpData convertToBasePowerUpData (BasePowerUp powerUp)
		{
				BasePowerUpData data = new BasePowerUpData ();

				data.t = (int)powerUp.getPowerUpType ();
				data.l = powerUp.PowerUpItemLevel;

				return data;
		}
}
