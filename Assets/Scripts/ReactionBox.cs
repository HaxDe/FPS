using UnityEngine;
using System.Collections;

public class ReactionBox : MonoBehaviour {
	public GameObject correspondingChar;
	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player" && !PlayerControl.isViewingPopUp)
		{
			correspondingChar.SendMessage ("CombatPlayer");
		}
	}
}
