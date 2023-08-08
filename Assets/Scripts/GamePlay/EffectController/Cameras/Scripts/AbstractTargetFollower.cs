using UnityEngine;

public abstract class AbstractTargetFollower : MonoBehaviour
{
		public enum UpdateType                                  // The available methods of updating are:
		{
				Auto,                                               // Let the script decide how to update
				FixedUpdate,                                        // Update in FixedUpdate (for tracking rigidbodies).
				LateUpdate,                                         // Update in LateUpdate. (for tracking objects that are moved in Update)
		}
	
		[SerializeField]
		public GameObject
				target;              		// The target object to follow
		[SerializeField]
		private UpdateType
				updateType;         		// stores the selected update type
	
	
		virtual protected void Start ()
		{
				// if auto targeting is used, find the object tagged "Player"
				// any class inheriting from this should call base.Start() to perform this action!
//		if (autoTargetPlayer) {
//			FindAndTargetPlayer();
//		}
		
		}
	
		void FixedUpdate ()
		{
		
				// we update from here if updatetype is set to Fixed, or in auto mode,
				// if the target has a rigidbody, and isn't kinematic.
//				if (autoTargetPlayer && (target == null || !target.gameObject.activeSelf)) {
//						FindAndTargetPlayer ();
//				}
				if (updateType == UpdateType.FixedUpdate || updateType == UpdateType.Auto) {
						FollowTarget (Time.deltaTime);
				}
		}
	
		void LateUpdate ()
		{
		
				// we update from here if updatetype is set to Late, or in auto mode,
				// if the target does not have a rigidbody, or - does have a rigidbody but is set to kinematic.
//				if (autoTargetPlayer && (target == null || !target.gameObject.activeSelf)) {
//						FindAndTargetPlayer ();
//				}
				if (updateType == UpdateType.LateUpdate || updateType == UpdateType.Auto && target != null) {
						FollowTarget (Time.deltaTime);
				}
		}
	
		protected abstract void FollowTarget (float deltaTime);
	
		public void FindAndTargetPlayer ()
		{
		
				// only target if we don't already have a target
				if (target == null) {
						// auto target an object tagged player, if no target has been assigned
						var targetObj = GameObject.FindGameObjectWithTag ("Player");	
						if (targetObj) {
								SetTarget (targetObj);
						}
				}
		}
	
		public virtual void SetTarget (GameObject newGameObject)
		{
				target = newGameObject;
		}
	
		public GameObject Target { get { return this.target; } }
	
		public void changeUpdateType (UpdateType type)
		{
				this.updateType = type;
		}
}
