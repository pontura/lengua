using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveLibro : InteractiveObject {

	public GameObject asset;

//	public override void OnClicked() 
//	{ 
//
//	}
	public override void OnCharacterReachMe() 
	{ 
		if (gameProgressValue == 0) {
			Events.OnSaveNewData (gameProgressKey, 1);
			Events.OnTexts(content.GetValue(gameProgressKey), "inventary/" + gameProgressKey, OnReadComplete);
		}
	}
	public void OnReadComplete()
	{
		Events.OpenTrivia (gameProgressKey);
	}
	public override void OnSetProgress(int value) 
	{
		if (value == 0)
			asset.SetActive (true);
		else {
			asset.SetActive (false);
			SetCollider (false);
		}
	}
}