using UnityEngine;
using System.Collections;

public class Level1PopUps : MonoBehaviour {
	public int defWidth = 1024;
	public int defHeight = 768;
	void OnGUI ()
	{
		int widthScale = Screen.width / defWidth;
		int heightScale = Screen.height / defHeight;

		if (PlayerControl.isViewingPopUp)
		{
			switch (PlayerControl.currentPopUp)
			{
			case 1:
				GUI.Label (new Rect (400 * widthScale,
				                     285 * heightScale,
				                     300,
				                     200),
				           "You have awakened. The Silver Fist base\n" +
				           "you were training at is now in ruins. Last \n" +
				           "night, it was attacked by the rebellion. You\n" +
				           "rummage in your pocket and find a pistol.\n" +
				           "Now, you need to escape.\n\n" +
				           "Use WASD or the arrow keys to move around,\n\n" +
				           "Your pistol is mapped to the 1 key.\n" +
				           "You will unlock more weapons as you\n" +
				           "progess through the story line.",
				           "button");
				if (GUI.Button (new Rect (490 * widthScale,
				                          550 * heightScale,
				                          100,
				                          45),
				            	          "Close"))
				{ 
					PlayerControl.isViewingPopUp = false;
					PlayerControl.currentPopUp += 1;
				}
				break;
			case 2:
				GUI.Label (new Rect (400 * widthScale,
				                     285 * heightScale,
				                     300,
				                     200),
				           "You can earn completion points by\n" +
				           "defeating bosses, finishing levels\n" +
				           "and completing challenge missions\n" +
				           "The rebel captain is up the path.\n" +
				           "Killing him will reward you with 500\n" +
		 		           "completion points.",
				           "button");
				if (GUI.Button (new Rect (490 * widthScale,
				                          550 * heightScale,
				                          100,
				                          45),
				                "Close"))
				{ 
					PlayerControl.isViewingPopUp = false;
					PlayerControl.currentPopUp += 1;
				}
				break;
			}
		}
	}

	void Update () {
	
	}
}
   