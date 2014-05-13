using UnityEngine;
using System.Collections;

public class DrawHealthBars : MonoBehaviour {
	public int levelType = 1;		/* 1 = ground, 2 = space */
	void OnGUI ()
	{
		if (levelType == 1)
		{
			GUI.Label (new Rect (50, 50, PlayerControl.playerHealth * 50, 30), 
			           "Health: " + PlayerControl.playerHealth, 
			           "button");	
		}
		else
		{
			GUI.Label (new Rect (50, 50, SpaceFighterControl.spaceFighterHealth * 50, 30), 
			           "Health: " + SpaceFighterControl.spaceFighterHealth, 
			           "button");		
		}
	}
}
  