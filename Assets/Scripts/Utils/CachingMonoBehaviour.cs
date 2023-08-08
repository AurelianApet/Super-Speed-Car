using UnityEngine;
using System.Collections;

public class CachingMonoBehaviour : MonoBehaviour
{
	[System.NonSerialized]
	public new Transform
		transform;
	[System.NonSerialized]
	public new Rigidbody
		rigidbody;
	
	void Awake ()
	{
		transform = GetComponent<Transform> ();
		rigidbody = GetComponent<Rigidbody> ();
	}
}