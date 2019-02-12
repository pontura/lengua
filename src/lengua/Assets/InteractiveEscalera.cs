using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveEscalera : InteractiveObject
{
	public GameObject[] assets;
	void OnEnable()
	{
		OnSetProgress (0); 
	}
	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe() 
	{
//		if (gameProgressValue >0) {
//			gameProgressValue++;
//			Events.OnSaveNewData (gameProgressKey, gameProgressValue);
//		} else {
		Events.OnTip (content.escalera_1);
		//}
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
