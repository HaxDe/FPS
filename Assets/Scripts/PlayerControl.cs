using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public GameObject pistolBulletPrefab;
	public GameObject pistolMuzzleFlashPrefab;

	public GameObject cameraObject;

	public GameObject currentGun;	/* the gun we are holding */
	public int currentGunNum;		/* current number from 1 to 6 to choose which gun to wield */

	/* items mapped to keys from 1 to 6 */
	public GameObject pistol;
	public GameObject rifle;
	public GameObject item4;
	public GameObject item5;
	public GameObject item6;

	public GameObject pistolMuzzleFlashSP;

	public GameObject bloodPSPrefab;
	
	public Transform spawnPos;
	public Transform gunSpawnPos;
	public Transform cameraTransform;
	public Transform zepTransform;
	public Transform holdPos;

	public Transform pistolBulletSpawnPos;	

	public static int playerHealth = 5;
	 
	public static int currentPopUp = 1;

	public static bool isViewingPopUp = false;

	public AudioSource pistolSound;
	 
	public GameObject gunCam;
	public GameObject gunModel;

	public GameObject zepObject;

	public Transform returnPos;

	public Transform camReturnPos;

	public bool isOverWheel = false;

	public int defWidth = 1024;
	public int defHeight = 768;

	public static int zeppelinHealth = 500;

	void Start ()
	{
		currentPopUp = 1;
		isViewingPopUp = false;  
		/* start with the pistol */
		currentGunNum = 1;
		Destroy (currentGun);
		currentGun = Instantiate (pistol,
		                          gunSpawnPos.position,
		                          gunSpawnPos.rotation) as GameObject;
		currentGun.name = "Pistol"; 
		currentGun.transform.parent = Camera.main.transform;
		gunModel = GameObject.FindGameObjectWithTag ("PistolWithHand");
		//	gunModel.layer = 9;
		currentGun.layer = 9;
		gunModel.layer = 9;
		//currentGun.layer = 9;
		currentGun.animation.Play ("WithdrawGun");
	} 

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
	 
	/* freezeThaw: Put an end to being flung across maps */
	void freezeThaw ()
	{
		if (GetComponent <CharacterController> ().velocity.x != 0 ||
		    GetComponent <CharacterController> ().velocity.y != 0 ||
		    GetComponent <CharacterController> ().velocity.z != 0)
			transform.position = holdPos.position;
	}

	void OnTriggerEnter (Collider other)
	{
		switch (other.gameObject.tag)
		{
		case "popUpBox":
			other.gameObject.SetActive (false);	/* deactivate the pop up box so we don't trigger it again */
			isViewingPopUp = true;
			break;
		case "levelEnd":
			if (GameObject.FindGameObjectsWithTag ("Boss") == null)
			{
				/* go on to the next level */
			}
			break;
		}
	}

	/* different methods for taking damage from different weapons */
	void playerPistolHit ()
	{
		playerHealth -= 1;
	}

	void Update () 
	{
		if (!isViewingPopUp && !ZeppelinSteeringWheel.isControllingZeppelin)
		{
			Screen.lockCursor = true;
			cameraObject.GetComponent <SmoothFollow>().enabled = false;
			currentGun.SetActive (true);
			GetComponent <CharacterMotor>().enabled = true;
			GetComponent <FPSInputController>().enabled = true;
			GetComponent <MouseLook>().enabled = true;
			cameraObject.GetComponent <MouseLook>().enabled = true;
			Time.timeScale = 1;
			RaycastHit firstHit;
			LayerMask firstMask = 1;
			
			/* are we about to click the zeppelin steering wheel and start driving the zep? */
			if (Physics.Raycast (transform.position, transform.forward, out firstHit, 6, firstMask.value))
			{ 
				if (firstHit.transform.gameObject.tag == "ZepWheel")
					isOverWheel = true;
			} 
			else
			{
				isOverWheel = false;
			}

			if (isOverWheel &&
			    Input.GetKeyDown (KeyCode.E))
			{
				transform.parent = zepObject.transform;
				gameObject.SetActive (false);
				ZeppelinSteeringWheel.isControllingZeppelin = true;
			}

			if (Input.GetKeyDown (KeyCode.Alpha1))
			{
				currentGunNum = 1;
				Destroy (currentGun);
				currentGun = Instantiate (pistol,
				                          gunSpawnPos.position,
				                          gunSpawnPos.rotation) as GameObject;
				currentGun.name = "Pistol"; 
				currentGun.transform.parent = Camera.main.transform;
				gunModel = GameObject.FindGameObjectWithTag ("PistolWithHand");
				currentGun.layer = 9;
				gunModel.layer = 9;
				currentGun.animation.Play ("WithdrawGun");
			}
			else if (Input.GetKeyDown (KeyCode.Alpha2))
			{  
				currentGunNum = 2; 
				Destroy (currentGun);
			}  
			  
			if (Input.GetMouseButtonDown (0) && !currentGun.animation.IsPlaying ("FireGun"))
			{  
				RaycastHit hit;
				LayerMask gunMask = 1;
				/* play the pistol sound */     
				pistolSound.Play ();
				if (Physics.Raycast (transform.position, transform.forward, out hit, 150, gunMask.value))
				{
					/* get the AI to call pistolHit */
					if (hit.transform.gameObject.tag == "Enemy")
					{
						hit.transform.gameObject.SendMessage ("pistolHit");
						/* instantiate a blood effect */
						GameObject bloodPS = Instantiate (bloodPSPrefab,
						                                  hit.point,
						                                  Quaternion.identity) as GameObject;
						print (bloodPS.transform.position);
					}
				}
	 			print (hit.point); 

				/*pistolSound.Play ();
				GameObject pistolBullet = Instantiate (pistolBulletPrefab,
				                                       pistolBulletSpawnPos.position,
				                                       pistolBulletSpawnPos.rotation) as GameObject;
				GameObject pistolMuzzleFlash = Instantiate (pistolMuzzleFlashPrefab,
				                                       		pistolBulletSpawnPos.position,
				                                       		pistolBulletSpawnPos.rotation) as GameObject;
				pistolMuzzleFlash.transform.parent = transform;
				pistolBullet.rigidbody.AddRelativeForce (Vector3.forward * 12000);*/
			} 
		}
		else  
		{    
			GetComponent <CharacterMotor>().enabled = false;
			GetComponent <FPSInputController>().enabled = false;
			GetComponent <MouseLook>().enabled = false;
			cameraObject.GetComponent <MouseLook>().enabled = false; 
			Screen.lockCursor = false;
		}
	}             
}             
  