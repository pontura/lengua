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
		if (Data.Instance.gameProgress.GetData ("rueda").value == 1) {
			gameProgressValue++;
			Events.OnSaveNewData (gameProgressKey, gameProgressValue);
			Events.OnSaveNewData ("rueda", 2);
			Events.UseItem ("rueda");
			Events.OnTexts (content.escalera_2, "inventary/rueda", RuedaDone);
		}   else if(gameProgressValue == 1){
			Events.OnTip (content.escalera_2);
		} else if(gameProgressValue == 0) {
			Events.OnTip (content.escalera_1);
		}
	}
	public void RuedaDone()
	{
		assets[1].SetActive (true);
		iTween.MoveTo (gameObject, iTween.Hash ("x", transform.localPosition.x-1 , "islocal", true, "time", 4 ,"looptype","none"));
	}
	public override void OnSetProgress(int value) 
	{
		ResetAll ();

		if(gameProgressValue == 1 || gameProgressValue == 0) {
			assets [gameProgressValue].SetActive (true);
		}

	}
	void ResetAll()
	{
		foreach (GameObject go in assets)
			go.SetActive (false);
	}

}
