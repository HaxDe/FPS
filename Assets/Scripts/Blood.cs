using UnityEngine;
using System.Collections;

public class Blood : MonoBehaviour {
	public GameObject bloodParticlePrefab;
	private int bloodAmount;	/* amount of blood particles to instantiate */	
	private int instantiateIndex = 0;	/* count to bloodAmount */

	void Start ()
	{
		bloodAmount = Random.Range (3, 5);
	}

	void Update () {
		while (instantiateIndex < bloodAmount)
		{
			instantiateIndex += 1;
			int quatX = Random.Range (1, 360);
			int quatY = Random.Range (1, 360);
			int quatZ = Random.Range (1, 360);
			int quatW = Random.Range (1, 360);

			Quaternion particleRot = new Quaternion (quatX,
			                                         quatY,
			                                         quatZ,
			                                         quatW);

			GameObject bloodParticle = Instantiate (bloodParticlePrefab,
			                                        transform.position,
			                                        particleRot) as GameObject;
			bloodParticle.rigidbody.AddRelativeForce (transform.forward * 50);
		}

		if (instantiateIndex == bloodAmount)
			Destroy (gameObject);
	}
}
    