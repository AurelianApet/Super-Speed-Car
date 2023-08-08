using UnityEngine;
using System.Collections;

public class LoadingIndicatorRotation : MonoBehaviour
{
		void FixedUpdate ()
		{
				this.transform.Rotate (new Vector3 (0, 0, -5));	
		}
}
