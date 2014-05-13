using UnityEngine;
using System.Collections;

public class GunAnimation : MonoBehaviour {
	void Update () {
		if (Input.GetKey (KeyCode.W) ||
		    Input.GetKey (KeyCode.A) ||
		    Input.GetKey (KeyCode.S) ||
		    Input.GetKey (KeyCode.D) ||
		    Input.GetKey (KeyCode.UpArrow) ||
		    Input.GetKey (KeyCode.LeftArrow) ||
		    Input.GetKey (KeyCode.DownArrow) ||
		    Input.GetKey (KeyCode.RightArrow))
		{
			animation.CrossFade ("Bob");
		}
		else
		{
			animation.CrossFade ("Idle");
		}

		if (Input.GetMouseButtonDown (0))
		{
			animation.Play ("FireGun");
		}
	}
}
  