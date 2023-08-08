using UnityEngine;
using System.Collections;

public class LightBlastController : MonoBehaviour
{
		public ParticleSystem lightBlast;
		ParticleSystem[] lightBlastSystem;

		void Start ()
		{
				lightBlast.Stop ();

				lightBlast.playbackSpeed = 5;

				lightBlastSystem = this.GetComponentsInChildren<ParticleSystem> ();

				for (int i=0; i<lightBlastSystem.Length; i++) {
						lightBlastSystem [i].playbackSpeed = 5;
				}
		}

		public void activateLightBlast ()
		{
				lightBlast.Stop ();
				lightBlast.Clear ();
				lightBlast.time = 0;
				lightBlast.Play ();

				for (int i=0; i<lightBlastSystem.Length; i++) {
						lightBlastSystem [i].Stop ();
						lightBlastSystem [i].Clear ();
						lightBlastSystem [i].time = 0;
						lightBlastSystem [i].Play ();
				}
		}
}
