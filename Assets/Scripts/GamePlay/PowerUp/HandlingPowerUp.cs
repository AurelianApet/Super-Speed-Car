using UnityEngine;
using System.Collections;

public class HandlingPowerUp : BasePowerUp
{
		float initialHandlingFactor;

		public HandlingPowerUp (int upgradeLevel)
		{
				this.powerUpItemLevel = upgradeLevel;

				switch (upgradeLevel) {
				case 0:
						this.Duration = 10;
						break;
			
				case 1:
						this.Duration = 15;
						break;
			
				case 2:
						this.Duration = 20;
						break;
			
				case 3:
						this.Duration = 25;
						break;
			
				case 4:
						this.Duration = 30;
						break;
			
				default:
						break;
				}
		}

		public override void usePowerUp (CarData carData)
		{
				powerState = BasePowerUp.POWER_STATE.ACTIVATING;
				initialHandlingFactor = carData.HandlingFactor;
				carData.HandlingFactor = 1;
		}
	
		public override void endPowerUpDuration (CarData carData)
		{
				powerState = BasePowerUp.POWER_STATE.DISABLE;
				carData.HandlingFactor = initialHandlingFactor;
		}

		public override string ToString ()
		{
				return "Handling " + Duration + "s";
		}

		public override POWER_UP_TYPE getPowerUpType ()
		{
				return BasePowerUp.POWER_UP_TYPE.HANDLING;
		}
}
