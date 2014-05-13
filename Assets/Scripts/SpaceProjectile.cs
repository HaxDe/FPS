using UnityEngine;
using System.Collections;

public class SpaceProjectile : MonoBehaviour {
	void Update () {
		transform.Translate (Vector3.forward * 3.0f, Space.Self);
		Destroy (gameObject, 4.0f);
	}
}
