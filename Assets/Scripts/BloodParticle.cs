using UnityEngine;
using System.Collections;

public class BloodParticle : MonoBehaviour {
	void Update () {
		Destroy (gameObject, 0.5f);
	}
}
 