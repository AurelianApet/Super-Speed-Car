using UnityEngine;
using System.Collections;

public class TrailController : MonoBehaviour
{
		TrailRenderer[] trail;

		//
		float lastDeactivate;
		bool isDeactivate;
	
		void Start ()
		{
				trail = this.GetComponentsInChildren <TrailRenderer> (true);
		}

		void Update ()
		{
				if (this.isDeactivate == true) {
						if (Time.timeSinceLevelLoad - lastDeactivate > 10) {
								for (int i=0; i<trail.Length; i++) {
										trail [i].enabled = false;
								}
						}
				}
		}
	
		public void activateTrail ()
		{
				if (ProfileManager.setttings.Quality > 0) {
						this.isDeactivate = false;
						for (int i=0; i<trail.Length; i++) {
								trail [i].enabled = true;
						}
				}
		}

		public void makeTrail (Vector3 left, Vector3 right)
		{
				trail [0].transform.position = left;
				trail [1].transform.position = right;
		}
	
		public void deactivateTrail ()
		{
				this.isDeactivate = true;
				this.lastDeactivate = Time.timeSinceLevelLoad;
		}

		public void clearAllTrail ()
		{
				for (int i=0; i<trail.Length; i++) {
						trail [i].enabled = false;
				}
		}
}
