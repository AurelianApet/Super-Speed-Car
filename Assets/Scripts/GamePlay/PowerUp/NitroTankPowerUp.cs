using UnityEngine;
using System.Collections;

public class NitroTankPowerUp : BasePowerUp
{
		public NitroTankPowerUp (int upgradeLevel)
		{
				this.powerUpItemLevel = upgradeLevel;
				this.Duration = 0;

				switch (upgradeLevel) {
				case 0:
						this.value = 20;
						break;
			
				case 1:
						this.value = 40;
						break;
			
				case 2:
						this.value = 60;
						break;
			
				case 3:
						this.value = 80;
						break;
			
				case 4:
						this.value = 100;
						break;
			
				default:
						break;
				}
		}

		public override void usePowerUp (CarData carData)
		{
				powerState = BasePowerUp.POWER_STATE.ACTIVATING;
				carData.NitroBar += value;
		}
	
		public override void endPowerUpDuration (CarData carData)
		{
				powerState = BasePowerUp.POWER_STATE.DISABLE;
		}

		public override string ToString ()
		{
				return "Nitro " + value + "%";
		}

		public override float getPercent ()
		{
				return 1;
		}

		public override POWER_UP_TYPE getPowerUpType ()
		{
				return BasePowerUp.POWER_UP_TYPE.NITRO_TANK;
		}
}