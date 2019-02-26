using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveGenericGrabbable : InteractiveObject {

	public GameObject asset;
	public GameObject readyAsset;
	public bool itemRewardIsBook;

	public override void OnCharacterReachMe() 
	{ 
		
		if (gameProgressValue == 0) {
			Events.OnSaveNewData (gameProgressKey, 1);
			if(itemRewardIsBook)
				Events.OnTexts (content.GetValue (gameProgressKey), "inventary/" + gameProgressKey, OnDone);
			else
				Events.OnTexts (content.GetValue (gameProgressKey), "inventary/" + gameProgressKey, null);
		}
	}
	void OnDone()
	{
		Events.OpenTrivia (gameProgressKey);
	}
	public override void OnSetProgress(int value) 
	{
		if (value == 0) {
			if (readyAsset != null)
				readyAsset.SetActive (false);
			asset.SetActive (true);
		}else {
			if (readyAsset != null)
				readyAsset.SetActive (true);
			asset.SetActive (false);
			SetCollider (false);
		}
	}
}