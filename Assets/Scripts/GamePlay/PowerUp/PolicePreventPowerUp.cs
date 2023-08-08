using UnityEngine;
using System.Collections;

public class PolicePreventPowerUp : BasePowerUp
{
		public PolicePreventPowerUp (int upgradeLevel)
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
				carData.CarController.game.carManager.uncaught ();
		}
	
		public override void endPowerUpDuration (CarData carData)
		{
				powerState = BasePowerUp.POWER_STATE.DISABLE;
		}

		public override void update (CarData carData)
		{
				if (powerState == POWER_STATE.ACTIVATING) {
						if (duration <= 0) {
								this.endPowerUpDuration (carData);
						} else {
								carData.WantedBar = 0;
								duration -= Time.deltaTime;
						}
				}
		}

		public override string ToString ()
		{
				return "Police " + Duration + " s";
		}

		public override POWER_UP_TYPE getPowerUpType ()
		{
				return BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT;
		}
}
