using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	void OnTriggerEnter (Collider other)
	{
		print ("Hit");
		if (other.gameObject.tag == "Enemy" ||
		    other.gameObject.tag == "Boss")
		{
			other.gameObject.SendMessage ("pistolHit");
			Destroy (gameObject);
		}
	}
}
