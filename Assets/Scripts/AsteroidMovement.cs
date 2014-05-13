using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {
	public GameObject asteroidExplosionPrefab;
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "playerLaser")
		{
			/* destroy the asteroid and instantiate an explosion */
			GameObject asteroidExplosion = Instantiate (asteroidExplosionPrefab,
			                                            transform.position,
			                                            Quaternion.identity) as GameObject;
			Destroy (gameObject);
		}
	}

	void Update () {
		transform.Translate (Vector3.forward * 0.1f, Space.World);
		transform.Rotate (0.5f, 0.5f, 0);
	}
}
  