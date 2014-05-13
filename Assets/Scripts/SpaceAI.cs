using UnityEngine;
using System.Collections;

public class SpaceAI : MonoBehaviour {
	/* similar to AI but tailored for space combat */
	public Transform target;	

	public float moveSpeed = 0.5f;
	public float targetDistance = 10.0f;	/* stop all of the enemies from melding together (visually disgusting much?) */
	public float maxDistance = 250.0f;

	public GameObject fighterBoltPrefab;
	public Transform fighterBoltSpawnPos;

	public int waitTime;

	void Start ()
	{
		waitTime = Random.Range (25, 150);
	}

	/* get ReactionBox to call this method */
	void CombatPlayer () {
		transform.LookAt (target);
		waitTime--;

		if (waitTime <= 0)
		{
			waitTime = Random.Range (25, 150);

			GameObject fighterBolt = Instantiate (fighterBoltPrefab,
			                                      fighterBoltSpawnPos.position,
			                                      fighterBoltSpawnPos.rotation) as GameObject;
			print (fighterBolt.gameObject.name);
		}

		if (Vector3.Distance (transform.position, target.position) > targetDistance)
		{
			transform.Translate (transform.forward * moveSpeed);
		}
	}
 
	void Update ()
	{
		if (Vector3.Distance (transform.position, target.position) < maxDistance)
		{
			CombatPlayer ();
		}
	}
}
 