using UnityEngine;
using System.Collections;

public class ZeppelinSteeringWheel : MonoBehaviour {
	private bool isOverWheel = false;

	public int defWidth = 1024;
	public int defHeight = 768;

	public GameObject playerObject;

	public static bool isControllingZeppelin = false;

	public Transform wheelPos;

	void OnGUI ()
	{
		int widthScale = Screen.width / defWidth;
		int heightScale = Screen.height / defHeight;
		if (isOverWheel)
		{
			GUI.Label (new Rect (450 * widthScale,
			                     325 * heightScale,
			                     200,
			                     50),
			           "Hit E to steer the zeppelin.",
			           "button");
		}
	}

	void OnMouseOver ()
	{
		if (Vector3.Distance (transform.position, playerObject.transform.position) < 6)
			isOverWheel = true;
	}

	void OnMouseExit ()
	{
		isOverWheel = false;
	}

	void Update ()
	{
		print (isControllingZeppelin);
		transform.position = wheelPos.position;
		if (isOverWheel &&
		    Input.GetKeyUp (KeyCode.E)) 
		{
			playerObject.SetActive (false);
			isControllingZeppelin = true; 
		}
	}
}
      