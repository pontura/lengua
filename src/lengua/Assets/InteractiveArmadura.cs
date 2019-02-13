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
		} else if (gameProgressValue == 4) {
			Done ();
		} else {
			GetComponentInChildren<Collider> ().enabled = false;
		}
	}
	void Done()
	{
		Events.OnSaveNewData ("libro_biblioteca_1", 1);
		Events.OnTexts (content.libro_biblioteca_1, "inventary/libro_biblioteca_1", OnReadComplete);
		gameProgressValue++;

	}
	public void OnReadComplete()
	{
		Events.OpenTrivia ("libro_biblioteca_1");
	}
	public override void OnSetProgress(int value) 
	{
		ResetAll ();
		assets [value].SetActive (true);
	}
	void ResetAll()
	{
		foreach (GameObject go in assets)
			go.SetActive (false);
	}

}
