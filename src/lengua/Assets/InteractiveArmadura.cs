using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveArmadura : InteractiveObject
{
	public GameObject[] assets;

	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe() 
	{ 
		if (gameProgressValue < 4) {
			gameProgressValue++;
			Events.OnSaveNewData (gameProgressKey, gameProgressValue);
		} else {
			GetComponentInChildren<Collider> ().enabled = false;
		}
	}
	public void OnReadComplete()
	{
		Events.OpenTrivia (gameProgressKey);
	}
	public override void OnSetProgress(int value) 
	{
		print ("value  " + value);
		ResetAll ();
		assets [value].SetActive (true);
	}
	void ResetAll()
	{
		foreach (GameObject go in assets)
			go.SetActive (false);
	}

}
