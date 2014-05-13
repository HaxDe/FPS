using UnityEngine;
using System.Collections;

public class ZepCam : MonoBehaviour {
	void Update () {
		if (ZeppelinSteeringWheel.isControllingZeppelin)
			GetComponent <AudioListener> ().enabled = true;
		else
			GetComponent <AudioListener> ().enabled = false;
	}
}
