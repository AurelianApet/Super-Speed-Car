using UnityEngine;
using System.Collections;

public class SmokeController : MonoBehaviour
{
		public ParticleEmitter[] smoke;

		void Start ()
		{
				smoke = this.GetComponentsInChildren <ParticleEmitter> (true);
		}
	
		public void activateSmoke ()
		{
				if (ProfileManager.setttings.Quality > 0) {
						for (int i=0; i<smoke.Length; i++) {
								smoke [i].emit = true;
						}
				}
		}
	
		public void deactivateSmoke ()
		{
				for (int i=0; i<smoke.Length; i++) {
						smoke [i].emit = false;
				}
		}
}
