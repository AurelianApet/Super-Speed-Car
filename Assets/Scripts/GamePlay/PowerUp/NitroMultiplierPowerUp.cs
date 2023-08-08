using UnityEngine;
using System.Collections;

public class NitroMultiplierPowerUp : BasePowerUp
{
		public NitroMultiplierPowerUp (int upgradeLevel)
		{
				this.powerUpItemLevel = upgradeLevel;
				this.value = 1.3f;

				switch (upgradeLevel) {
				case 0:
						this.Duration = 5;
						break;
			
				case 1:
						this.Duration = 10;
						break;
			
				case 2:
						this.Duration = 15;
						break;
			
				case 3:
						this.Duration = 20;
						break;
			
				case 4:
						this.Duration = 25;
						break;
			
				default:
						break;
				}
		}

		public override void usePowerUp (CarData carData)
		{
				powerState = BasePowerUp.POWER_STATE.ACTIVATING;
				carData.NitroMultiplier = value;

				if (carData.CarController.isNitroUsing () == true) {
						carData.CarController.useNitro (true);
				}
		}
	
		public override void endPowerUpDuration (CarData carData)
		{
				powerState = BasePowerUp.POWER_STATE.DISABLE;
				carData.NitroMultiplier = 1.2f;
		}

		public override string ToString ()
		{
				return "Nitro x" + value + " " + Duration + "s";
		}

		public override POWER_UP_TYPE getPowerUpType ()
		{
				return BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER;
		}
}
