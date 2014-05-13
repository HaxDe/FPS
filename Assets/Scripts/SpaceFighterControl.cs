using UnityEngine;
using System.Collections;

public class SpaceFighterControl : MonoBehaviour {
	public float moveSpeed = 0.6f;
	public float rotateSpeed = 3.0f;
	public GameObject actualJet;		/* reference the actual jet to yaw */
	public GameObject beam1;
	public GameObject beam2;
	public static int spaceFighterHealth = 5;

	void Start ()
	{
		beam1.SetActive (false);
		beam2.SetActive (false);
	}

	void Update () {
		transform.Rotate (Input.GetAxis ("Vertical") * rotateSpeed, 
		                  Input.GetAxis ("Yaw") * rotateSpeed, 
		                  Input.GetAxis ("Horizontal") * rotateSpeed);
		if (Input.GetKey (KeyCode.Space))
		{
			if (moveSpeed > 0.05f)
				moveSpeed -= 0.02f;
		}
		else
		{
			if (moveSpeed < 0.6f)
				moveSpeed += 0.02f;
		}

		if (Input.GetKey (KeyCode.F))
		{
			beam1.SetActive (true);
			beam2.SetActive (true);
		}

		if (Input.GetKeyUp (KeyCode.F))
		{
			beam1.SetActive (false);
			beam2.SetActive (false);
		}
		transform.Translate (Vector3.forward * moveSpeed);
	}
}
            