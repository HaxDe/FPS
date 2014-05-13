using UnityEngine;
using System.Collections;

public class RenderZeppelinUI : MonoBehaviour {
	public GUISkin leftBroadsideSkin;
	public GUISkin rightBroadsideSkin;
	public GUISkin leftBroadsideCDSkin;
	public GUISkin rightBroadsideCDSkin;

	public int defWidth = 1024;
	public int defHeight = 768;

	void OnGUI () 
	{
		if (ZeppelinSteeringWheel.isControllingZeppelin)
		{
			int widthScale = Screen.width / defWidth;
			int heightScale = Screen.height / defHeight;

			/* render the left broadside icon */
			if (ZeppelinControl.isLBroadSCD)
				GUI.skin = leftBroadsideCDSkin;
			else
				GUI.skin = leftBroadsideSkin;
			if (GUI.Button (new Rect (225 * widthScale,
			                          800 * heightScale,
			                          50,
			                          50), ""))
			{

			}

			/* render the right broadside icon */
			if (ZeppelinControl.isRBroadSCD)
				GUI.skin = rightBroadsideCDSkin;
			else
				GUI.skin = rightBroadsideSkin;
			if (GUI.Button (new Rect (285 * widthScale,
			                          800 * heightScale,
			                          50,
			                          50), ""))
			{
				
			}
		}  
	}
}
