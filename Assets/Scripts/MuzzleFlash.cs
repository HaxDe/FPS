using UnityEngine;
using System.Collections;

public class MuzzleFlash : MonoBehaviour {
	void Update () {
		Color fadeColor = new Color (renderer.material.color.r,
		                             renderer.material.color.g,
		                             renderer.material.color.b,
		                             renderer.material.color.a - 0.01f);
		renderer.material.color = fadeColor;
		Destroy (gameObject, 3.0f);
	}
}
