using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class FreeLookCam : PivotBasedCameraRig
{
		// This script is designed to be placed on the root object of a camera rig,
		// comprising 3 gameobjects, each parented to the next:
	
		// 	Camera Rig
		// 		Pivot
		// 			Camera
	
		[SerializeField]
		private float
				moveSpeed = 1f;      // How fast the rig will move to keep up with the target's position.
		[Range(0f,10f)]
		[SerializeField]
		private float
				turnSpeed = 1.5f;    // How fast the rig will rotate from user input.
		[SerializeField]
		private float
				turnSmoothing = 0.1f;// How much smoothing to apply to the turn input, to reduce mouse-turn jerkiness
//		[SerializeField]
//		private float
//				tiltMax = 75f;       // The maximum value of the x axis rotation of the pivot.
//		[SerializeField]
//		private float
//				tiltMin = 45f;       // The minimum value of the x axis rotation of the pivot.
		[SerializeField]
		private bool
				lockCursor = false;   // Whether the cursor should be hidden and locked.

	
		private float lookAngle;                            // The rig's y axis rotation.
		private float tiltAngle;                            // The pivot's x axis rotation.

		private const float LookDistance = 100f;            // How far in front of the pivot the character's look target is.
		private float smoothX = 0;
		private float smoothY = 0;
		private float smoothXvelocity = 0;
		private float smoothYvelocity = 0;

		//
		bool isAutoRotation = true;

		public bool IsAutoRotation {
				get {
						return isAutoRotation;
				}
				set {
						isAutoRotation = value;

						if (value == false) {
								lastChangeView = Time.timeSinceLevelLoad;
						}
				}
		}

		public GameObject pivotGameObject;
		public GameObject cameraRig;
		public Behaviour flareLayer;

		//
		Vector3 initialPosition;
		float lastChangeView;

		protected override void Awake ()
		{
				base.Awake ();
				// Lock or unlock the cursor.
				Screen.lockCursor = lockCursor;

				// find the camera in the object hierarchy
				cam = GetComponentInChildren<Camera> ().transform;
				pivot = cam.parent;

				initialPosition = cameraRig.transform.localPosition;
		}

		protected override void Update ()
		{
				base.Update ();

				if (isAutoRotation == false) {
						HandleRotationMovement ();
						if (lockCursor && Input.GetMouseButtonUp (0)) {
								Screen.lockCursor = lockCursor;
						}
				} 
		}

		void OnDisable ()
		{
				Screen.lockCursor = false;
		}
	
		protected override void FollowTarget (float deltaTime)
		{
				// Move the rig towards target position.
				transform.position = Vector3.Lerp (transform.position, target.transform.position, deltaTime * moveSpeed);
		}
	
		void HandleRotationMovement ()
		{
				float x = 0;
				float y = 0;

				if (Time.timeSinceLevelLoad - lastChangeView > 2) {
						x = Mathf.Clamp (Input.GetAxis ("Mouse X") * 2, -1f, 1f);
						y = Mathf.Clamp (Input.GetAxis ("Mouse Y"), -0.1f, 0.1f);
				} else {
						x = 1f;
				}
		
				// smooth the user input
				if (turnSmoothing > 0) {
						smoothX = Mathf.SmoothDamp (smoothX, x, ref smoothXvelocity, turnSmoothing);
						smoothY = Mathf.SmoothDamp (smoothY, y, ref smoothYvelocity, turnSmoothing);
				} else {
						smoothX = x;
						smoothY = y;
				}
		
				// Adjust the look angle by an amount proportional to the turn speed and horizontal input.
				lookAngle += smoothX * turnSpeed;

				tiltAngle -= smoothY * turnSpeed;
				tiltAngle = Mathf.Clamp (tiltAngle, -5, 5);
		
				// Rotate the rig (the root object) around Y axis only:
				transform.rotation = Quaternion.Euler (0f, lookAngle, 0f);

				pivot.localRotation = Quaternion.Euler (tiltAngle, 0f, 0f);		
		}

		public void resetCamera ()
		{
				cameraRig.transform.localPosition = initialPosition;
				cameraRig.transform.localRotation = Quaternion.identity;
		}
}