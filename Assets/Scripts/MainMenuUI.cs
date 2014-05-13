using UnityEngine;
using System.Collections;

public class MainMenuUI : MonoBehaviour {

	void OnMouseExit ()
	{
		renderer.material.color = Color.white;
	}

	void OnMouseOver ()
	{
		if (gameObject.name == "NewGameText" ||
		    gameObject.name == "LevelSelectText")
			renderer.material.color = Color.green;
		else if (gameObject.name == "ExitText")
			renderer.material.color = Color.red;
	}

	void OnMouseDown ()
	{
		switch (gameObject.name)
		{
		case "NewGameText":
			/* just load the tutorial level */
			break;
		case "LevelSelectText":
			/* load the level selection level */
			break;
		case "ExitText":
			/* exit the game */
			Application.Quit ();
			break;
		}
	}

	void Update () {
		
	}
}
   