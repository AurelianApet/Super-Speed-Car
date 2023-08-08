using UnityEngine;
using System.Collections;

public class EnvironmentEffectController : MonoBehaviour
{
		void Start ()
		{
				if (ProfileManager.setttings.Quality == 0) {
						this.gameObject.SetActive (false);
				}
		}

		public void ChangeQualitySettings ()
		{	
				if (ProfileManager.setttings.Quality == 0) {
						this.gameObject.SetActive (false);
				} else {
						this.gameObject.SetActive (true);
				}
		}
}
