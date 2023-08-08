using UnityEngine;
using System.Collections;

public class NitroRatePowerUp : BasePowerUp
{
		float nitroRate;

		public NitroRatePowerUp (int upgradeLevel)
		{
				this.powerUpItemLevel = upgradeLevel;
				this.Duration = 20f;

				switch (upgradeLevel) {
				case 0:
						this.value = 0.85f;
						break;
			
				case 1:
						this.value = 0.70f;
						break;
			
				case 2:
						this.value = 0.55f;
						break;
			
				case 3:
						this.value = 0.40f;
						break;
			
				case 4:
						this.value = 0.25f;
						break;
			
				default:
						break;
				}
		}

		public override void usePowerUp (CarData carData)
		{
				powerState = BasePowerUp.POWER_STATE.ACTIVATING;
				nitroRate = carData.NitroRate;
				carData.NitroRate = value * nitroRate;
		}
	
		public override void endPowerUpDuration (CarData carData)
		{
				powerState = BasePowerUp.POWER_STATE.DISABLE;
				carData.NitroRate = nitroRate;
		}

		public override string ToString ()
		{
				return "Nrate x" + value + " " + Duration + "s";
		}

		public override POWER_UP_TYPE getPowerUpType ()
		{
				return BasePowerUp.POWER_UP_TYPE.NITRO_RATE;
		}
}
