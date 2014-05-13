 using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	private int waitTime = 75;	/* determine whether to shoot or not */	

	public int health = 2; 
	 
	public AudioSource pistolSound;

	public int enemyType = 1;	/* 1 = ground, 2 = space */
	public string enemyName;

	public GameObject bloodPSPrefab;

	/* ReactionBox will call this method if the player is in the danger zone */
	void CombatPlayer ()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		transform.LookAt (player.transform);
		waitTime--; 
		if (waitTime <= 0)
		{
			/* shoot a bullet */
			RaycastHit hit;
			pistolSound.Play ();
			animation.Play ("FireGun");
			if (Physics.Raycast (transform.position, transform.forward, out hit, 65))
			{
				if (hit.transform.gameObject.tag == "Player")
					hit.transform.gameObject.SendMessage ("playerPistolHit");
			}
			waitTime = 75;
		}
	}

	void Bleed (Vector3 bleedPos)
	{
		GameObject bloodPS = Instantiate (bloodPSPrefab,
		                                  bleedPos,
		                                  Quaternion.identity) as GameObject;
		print (bloodPS.transform.position);
	}

	/* different methods for taking damage from different weapons */
	void pistolHit ()
	{
		health -= 1;
	}
 
	void OnTriggerStay (Collider other)
	{
		switch (other.gameObject.tag)
		{
		case "pistolBullet":
			pistolHit ();
			break;
		}
	} 

	void Update ()
	{
		if (health <= 0)
		{
			if (!animation.IsPlaying ("Death") && health < 0)
				Destroy (gameObject);
			health--;
			animation.Play ("Death");
		}  
	} 
}
    