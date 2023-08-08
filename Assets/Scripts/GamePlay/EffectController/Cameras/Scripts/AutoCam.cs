using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class AutoCam : PivotBasedCameraRig
{
	public enum SHAKE_STATE
	{
		NO_SHAKE,
		NITRO_SHAKE,
		CRASH_SHAKE
	}

	[SerializeField]
	private float
		moveSpeed = 3;           		// How fast the rig will move to keep up with target's position
	[SerializeField]
	public float
		turnSpeed = 1;           		// How fast the rig will turn to keep up with target's rotation
	[SerializeField]
	private float
		rollSpeed = 0.2f;
	public bool
		followVelocity = false;   		// Whether the rig will rotate in the direction of the target's velocity.
	[SerializeField]
	private bool
		followTilt = true;        		// Whether the rig will tilt (around X axis) with the target.
	[SerializeField]
	private float
		spinTurnLimit = 90;      		// The threshold beyond which the camera stops following the target's rotation. (used in situations where a car spins out, for example)
	[SerializeField]
	private float
		targetVelocityLowerLimit = 4f;	// the minimum velocity above which the camera turns towards the object's velocity. Below this we use the object's forward direction.
	[SerializeField]
	private float
		smoothTurnTime = 0.2f;           // the smoothing for the camera's rotation

	private float lastFlatAngle;                            // The relative angle of the target and the rig from the previous frame.
	private float currentTurnAmount;                        // How much to turn the camera
	private float turnSpeedVelocityChange;                  // The change in the turn speed velocity
	private Vector3 rollUp = Vector3.up;                    // The roll of the camera around the z axis ( generally this will always just be up )

	//
	public Camera mainCamera;
	public Camera childCamera;
	public MobileBloom bloom;
	EnvironmentEffectController[] environmentEffectController;

	//
	SHAKE_STATE shakeState = SHAKE_STATE.NO_SHAKE;
	float lastShake;
	
	protected override void Start ()
	{
		base.Start ();
		
		this.environmentEffectController = GetComponentsInChildren<EnvironmentEffectController> (true);
		this.changeQuality (ProfileManager.setttings.Quality);
	}
	
	protected override void FollowTarget (float deltaTime)
	{	
		// if no target, or no time passed then we quit early, as there is nothing to do
		if (!(deltaTime > 0) || target == null) {
			return;
		}

        
		// initialise some vars, we'll be modifying these in a moment
		var targetForward = target.transform.forward;
		var targetUp = target.transform.up;


		if (followVelocity && Application.isPlaying) {
			// in follow velocity mode, the camera's rotation is aligned towards the object's velocity direction
			// but only if the object is traveling faster than a given threshold.

			if (target.rigidbody.velocity.magnitude > targetVelocityLowerLimit) {
				// velocity is high enough, so we'll use the target's velocty
				targetForward = target.rigidbody.velocity.normalized;
				targetUp = Vector3.up;
			} else {
				targetUp = Vector3.up;
			}

			currentTurnAmount = Mathf.SmoothDamp (currentTurnAmount, 1, ref turnSpeedVelocityChange, smoothTurnTime);
	  

		} else {
			// we're in 'follow rotation' mode, where the camera rig's rotation follows the object's rotation.

			// This section allows the camera to stop following the target's rotation when the target is spinning too fast.
			// eg when a car has been knocked into a spin. The camera will resume following the rotation
			// of the target when the target's angular velocity slows below the threshold.
			var currentFlatAngle = Mathf.Atan2 (targetForward.x, targetForward.z) * Mathf.Rad2Deg;
			if (spinTurnLimit > 0) {
				var targetSpinSpeed = Mathf.Abs (Mathf.DeltaAngle (lastFlatAngle, currentFlatAngle)) / deltaTime;
				var desiredTurnAmount = Mathf.InverseLerp (spinTurnLimit, spinTurnLimit * 0.75f, targetSpinSpeed);
				var turnReactSpeed = (currentTurnAmount > desiredTurnAmount ? .1f : 1f);
				if (Application.isPlaying) {
					currentTurnAmount = Mathf.SmoothDamp (currentTurnAmount, desiredTurnAmount, ref turnSpeedVelocityChange, turnReactSpeed);
				} else {
					// for editor mode, smoothdamp won't work because it uses deltaTime internally
					currentTurnAmount = desiredTurnAmount;
				}

			} else {
				currentTurnAmount = 1;
			}
			lastFlatAngle = currentFlatAngle;
		}

		// camera position moves towards target position:
		transform.position = Vector3.Lerp (transform.position, target.transform.position, deltaTime * moveSpeed);

		// camera's rotation is split into two parts, which can have independend speed settings:
		// rotating towards the target's forward direction (which encompasses its 'yaw' and 'pitch')
		if (!followTilt) {
			targetForward.y = 0;
			if (targetForward.sqrMagnitude < float.Epsilon) {
				targetForward = transform.forward;
			}
		}
		var rollRotation = Quaternion.LookRotation (targetForward, rollUp);

		// and aligning with the target object's up direction (i.e. its 'roll')
		rollUp = rollSpeed > 0 ? Vector3.Slerp (rollUp, targetUp, rollSpeed * deltaTime) : Vector3.up;
		transform.rotation = Quaternion.Lerp (transform.rotation, rollRotation, turnSpeed * currentTurnAmount * deltaTime);

		switch (shakeState) {
		case SHAKE_STATE.NO_SHAKE:
			break;

		case SHAKE_STATE.NITRO_SHAKE:
			transform.position += Random.insideUnitSphere * 0.05f;
			break;

		case SHAKE_STATE.CRASH_SHAKE:
			if (Time.timeSinceLevelLoad - lastShake < 0.3f) {
				transform.position += Random.insideUnitSphere * 0.15f * Mathf.Abs (1 / (1f - (Time.timeSinceLevelLoad - lastShake)));
			} else {
				this.shakeState = SHAKE_STATE.NO_SHAKE;
			}
			break;

		default:
			break;

		}

		if (childCamera != null) {
			this.childCamera.transform.position = this.transform.position;
			this.childCamera.transform.rotation = this.transform.rotation;
			this.childCamera.fieldOfView = this.mainCamera.fieldOfView;
		}
	}

	public void changePivot (Vector3 pos)
	{
		pivot.localPosition = pos;
	}

	public void activateShakeEffect (SHAKE_STATE shakeState)
	{
		this.shakeState = shakeState;
		if (this.shakeState == SHAKE_STATE.CRASH_SHAKE) {
			lastShake = Time.timeSinceLevelLoad;
		}
	}
	
	public void changeQuality (int level)
	{
		switch (level) {
		case 0:
			this.mainCamera.farClipPlane = 1000;
			this.bloom.enabled = false;
			
			for (int i=0; i<environmentEffectController.Length; i++) {
				environmentEffectController [i].ChangeQualitySettings ();
			}
			return;
				
		case 1:
			this.mainCamera.farClipPlane = 2000;
			this.bloom.enabled = false;			
			for (int i=0; i<environmentEffectController.Length; i++) {
				environmentEffectController [i].ChangeQualitySettings ();
			}
			return;
				
		case 2:
			this.mainCamera.farClipPlane = 3000;
			this.bloom.enabled = true;

			for (int i=0; i<environmentEffectController.Length; i++) {
				environmentEffectController [i].ChangeQualitySettings ();
			}

			return;
				
		default:
			this.mainCamera.farClipPlane = 2000;
			this.bloom.enabled = false;			
			for (int i=0; i<environmentEffectController.Length; i++) {
				environmentEffectController [i].ChangeQualitySettings ();
			}
			return;
		}
	}
}