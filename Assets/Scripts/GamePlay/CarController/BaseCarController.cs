using UnityEngine;
using System.Collections;

public abstract class BaseCarController
{
		public CarData carData;
		public HandlingInfo handlingInfo;
		public Game game;

		public BaseCarController (CarData carData)
		{
				this.carData = carData;
				this.handlingInfo = new HandlingInfo ();

				game = GameObject.FindObjectOfType<Game> ();
		}

		public abstract void getHandlingInput ();
	
		public void useBrake (bool isBrakeUsing)
		{
				if (isBrakeUsing == true) {
						this.handlingInfo.throttle = -0.5f;
						this.useNitro (false);
				} else {
						this.handlingInfo.throttle = 1;
				}
				this.carData.useBrake (isBrakeUsing);
		}

		public bool isBrakeUsing ()
		{
				if (handlingInfo.throttle < 0) {
						return true;
				} else {
						return false;
				}
		}
	
		public void useNitro (bool isNitroUsing)
		{
				this.carData.useNitro (isNitroUsing);
		}

		public bool isNitroUsing ()
		{
				if (carData.NitroBar > 10) {
						return handlingInfo.isNitroUsing;
				} else {
						return false;
				}
		}

		public void steerLeft ()
		{
				this.handlingInfo.steer = 0 - (ProfileManager.setttings.Sensitivity + 50) / 200;
		}
	
		public void steerRight ()
		{
				this.handlingInfo.steer = (ProfileManager.setttings.Sensitivity + 50) / 200;
		}

		public void stopSteer ()
		{
				this.handlingInfo.steer = 0;
		}

		public float SignedAngleBetween (Vector3 a, Vector3 b, Vector3 n)
		{
				// angle in [0,180]
				float angle = Vector3.Angle (a, b);
				float sign = Mathf.Sign (Vector3.Dot (n, Vector3.Cross (a, b)));
		
				// angle in [-179,180]
				float signed_angle = angle * sign;
		
				// angle in [0,360]
				float angle360 = ((signed_angle) + 360) % 360;
		
				return angle360;
		}
}
