using UnityEngine;
using System.Collections;

public class NitroController : MonoBehaviour
{
		ParticleEmitter[] nitro;
	
		void Start ()
		{
				nitro = this.GetComponentsInChildren <ParticleEmitter> (true);
		}
	
		public void activateNitro ()
		{
				for (int i=0; i<nitro.Length; i++) {
						nitro [i].emit = true;
				}
		}
	
		public void deactivateNitro ()
		{
				for (int i=0; i<nitro.Length; i++) {
						nitro [i].emit = false;
				}
		}

		public Vector3 getLeftNitro ()
		{
				return nitro [0].transform.position;
		}

		public Vector3 getRightNitro ()
		{
				return nitro [1].transform.position;
		}

		public void clearAllNitro ()
		{
				this.deactivateNitro ();
				for (int i=0; i<nitro.Length; i++) {
						nitro [i].ClearParticles ();
				}
		}
}
