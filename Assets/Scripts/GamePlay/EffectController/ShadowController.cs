using UnityEngine;
using System.Collections;

public class ShadowController : MonoBehaviour
{
	public Projector shadowProjector;
	int quality;

	void Start ()
	{
		quality = ProfileManager.setttings.Quality;
		if (ProfileManager.setttings.Quality > 0) {
			this.shadowProjector.enabled = true;
		} else {
			this.shadowProjector.enabled = false;
		}
	}

	void FixedUpdate ()
	{
		if (quality != ProfileManager.setttings.Quality) {
			quality = ProfileManager.setttings.Quality;

			if (ProfileManager.setttings.Quality > 0) {
				this.shadowProjector.enabled = true;
			} else {
				this.shadowProjector.enabled = false;
			}
		}
	}
}
