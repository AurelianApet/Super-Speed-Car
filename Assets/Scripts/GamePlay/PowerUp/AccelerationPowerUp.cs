using UnityEngine;
using System.Collections;

public class AccelerationPowerUp : BasePowerUp
{
		public AccelerationPowerUp (int upgradeLevel)
		{
				this.powerUpItemLevel = upgradeLevel;
				this.value = 100f;

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
				carData.AccelerationMultiplier = this.value;
		}

		public override void endPowerUpDuration (CarData carData)
		{
				powerState = BasePowerUp.POWER_STATE.DISABLE;
				carData.AccelerationMultiplier = 1f;
		}

		public override string ToString ()
		{
				return "Accel " + Duration + "s";
		}

		public override POWER_UP_TYPE getPowerUpType ()
		{
				return BasePowerUp.POWER_UP_TYPE.ACCELERATION;
		}
}
