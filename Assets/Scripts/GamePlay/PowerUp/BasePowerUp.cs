using UnityEngine;
using System.Collections;

public abstract class BasePowerUp
{
		public enum POWER_UP_TYPE
		{
				ACCELERATION=0,
				HANDLING=1,
				NITRO_MULTIPLIER=2,
				NITRO_RATE=3,
				NITRO_TANK=4,
				POLICE_PREVENT=5
		}

		public enum POWER_STATE
		{
				NOT_ACTIVE,
				ACTIVATING,
				DISABLE
		}
	
		public POWER_STATE powerState = POWER_STATE.NOT_ACTIVE;
		protected float value;

		public float Value {
				get {
						return value;
				}
		}

		//
		protected float duration;

		public float Duration {
				get {
						return duration;
				}
				set {
						duration = value;
						totalTime = duration;
				}
		}
	
		protected int powerUpItemLevel;

		public int PowerUpItemLevel {
				get {
						return powerUpItemLevel;
				}
		}

		float totalTime;

		public virtual void update (CarData carData)
		{
				if (powerState == POWER_STATE.ACTIVATING) {
						if (duration <= 0) {
								this.endPowerUpDuration (carData);
						} else {
								duration -= Time.deltaTime;
						}
				}
		}

		public virtual float getPercent ()
		{
				return duration / totalTime;
		}

		public static BasePowerUp convertToPowerUp (POWER_UP_TYPE type, int powerUpItemLevel)
		{
				switch (type) {
				case POWER_UP_TYPE.ACCELERATION:
						return new AccelerationPowerUp (powerUpItemLevel);

				case POWER_UP_TYPE.HANDLING:
						return new HandlingPowerUp (powerUpItemLevel);

				case POWER_UP_TYPE.NITRO_MULTIPLIER:
						return new NitroMultiplierPowerUp (powerUpItemLevel);

				case POWER_UP_TYPE.NITRO_RATE:
						return new NitroRatePowerUp (powerUpItemLevel);

				case POWER_UP_TYPE.NITRO_TANK:
						return new NitroTankPowerUp (powerUpItemLevel);

				case POWER_UP_TYPE.POLICE_PREVENT:
						return new PolicePreventPowerUp (powerUpItemLevel);

				default:
						return new AccelerationPowerUp (powerUpItemLevel);
				}
		}
	
		public abstract void usePowerUp (CarData carData);
	
		public abstract void endPowerUpDuration (CarData carData);

		public abstract POWER_UP_TYPE getPowerUpType ();
}
