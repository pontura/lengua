using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMinotauro : InteractiveObject {
	
	public GameObject state1;
	public GameObject state2;
	public GameObject state3;

	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe()
	{ 
		if (Data.Instance.gameProgress.GetData ("cuerno1").value == 1) {
			gameProgressValue++;
			Events.OnSaveNewData (gameProgressKey, gameProgressValue);
			Events.OnSaveNewData ("cuerno1", 2);
			Events.UseItem ("cuerno1");
			Events.OnTexts (content.minotauro_1, "inventary/cuerno", CheckIfDone);
		} else if (Data.Instance.gameProgress.GetData ("cuerno2").value == 1) {
			gameProgressValue++;
			Events.OnSaveNewData (gameProgressKey, gameProgressValue);
			Events.OnSaveNewData ("cuerno2", 2);
			Events.UseItem ("cuerno2");
			Events.OnTexts (content.minotauro_2, "inventary/cuerno", CheckIfDone);
		} else if (gameProgressValue < 2) {
			Events.OnTip (content.minotauro_0);
		} else {
			Events.OnTip (content.minotauro_2);
		}
	}
	void CheckIfDone()
	{
		if (gameProgressValue == 2) {
			Events.OnSaveNewData ("libro_biblioteca_2", 1);
			Events.OnTexts (content.libro_biblioteca_2, "inventary/libro_biblioteca_2", OnReadComplete);
			gameProgressValue++;
		}
	}
	public override void OnSetProgress(int value)
	{	

		if (value == 0) {
			state1.SetActive (true);
			state2.SetActive (false);
			state3.SetActive (false);
		} else if (value == 1) {
			state1.SetActive (false);
			state2.SetActive (true);
			state3.SetActive (false);
		} else if (value > 1) {
			state1.SetActive (false);
			state2.SetActive (false);
			state3.SetActive (true);
		} 
	}
	public void OnReadComplete()
	{
		Events.OpenTrivia ("libro_biblioteca_2");
	}
}
