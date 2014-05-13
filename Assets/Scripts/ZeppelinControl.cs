using UnityEngine;
using System.Collections;

public class ZeppelinControl : MonoBehaviour {
	/* allow the player to control the zeppelin */
	public float zeppelinSpeed = 0.1f;
	public float zeppelinRotate = 3.0f;

	public GameObject playerObject;
	public GameObject cannonBallPrefab;

	public Transform [] broadsidePortSpawns = new Transform[6];
	public Transform [] broadsideStarboardSpawns = new Transform[6];

	/* spawn a boundary to stop the player from being flung across the map... -_- */
	public Transform boundarySpawn;
	public GameObject boundaryPrefab;

	public static bool isLBroadSCD = false;
	public static bool isRBroadSCD = false;

	void spawnBoundary ()
	{
		GameObject boundary = Instantiate (boundaryPrefab,
		                                   boundarySpawn.position,
		                                   boundarySpawn.rotation) as GameObject;
		boundary.transform.parent = transform;
	}

	/* two methods for broadside port and broadside starboard
	 * (coordinated cannon fire to the left and right, respectively) */
	void broadsidePort ()
	{
		if (!isLBroadSCD)
		{
			int i;	/* general purpose index */
			for (i = 0; i < 6; i++)
			{
				GameObject cannonBall = Instantiate (cannonBallPrefab,
				                                     broadsidePortSpawns [i].position,
				                                     broadsidePortSpawns [i].rotation) as GameObject;
				cannonBall.rigidbody.AddRelativeForce (Vector3.forward * 12000);
			}
		}
	}

	void broadsideStarboard ()
	{
		if (!isRBroadSCD)
		{
			int i;	/* general purpose index */
			for (i = 0; i < 6; i++)
			{                       
				GameObject cannonBall = Instantiate (cannonBallPrefab,
				                                     broadsideStarboardSpawns [i].position,
				                                     broadsideStarboardSpawns [i].rotation) as GameObject;
				cannonBall.rigidbody.AddRelativeForce (Vector3.forward * 12000);
			}
		}
	}  
	 
	void FixedUpdate () {
		/* always move forward */
		transform.Translate (Vector3.forward * zeppelinSpeed);
		/* but only rotate and use abilities
		 * if the player is controlling the zep */
		if (ZeppelinSteeringWheel.isControllingZeppelin)
		{
			transform.Rotate (0, Input.GetAxis ("InvertedHorizon") * zeppelinRotate, 0);
			transform.Translate (0, Input.GetAxis ("Vertical") * zeppelinSpeed, 0);

			if (Input.GetKeyDown (KeyCode.Alpha1)) 
			{
				broadsidePort ();
			}
			else if (Input.GetKeyDown (KeyCode.Alpha2))
			{
				broadsideStarboard ();
			}    
			
			if (Input.GetKeyDown (KeyCode.Escape))
			{
				playerObject.transform.parent = null;
				playerObject.SetActive (true);
				playerObject.SendMessage ("freezeThaw");
				Screen.lockCursor = true;
				ZeppelinSteeringWheel.isControllingZeppelin = false;
				spawnBoundary (); 
			}
		}
	}
}
       