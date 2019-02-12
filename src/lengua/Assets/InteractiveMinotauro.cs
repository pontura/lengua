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
		if (Data.Instance.gameProgress.GetData ("cuerno").value == 1) {
			gameProgressValue++;
			Events.OnSaveNewData (gameProgressKey, gameProgressValue);
			Events.OnSaveNewData ("cuerno", 2);
			Events.UseItem ("cuerno");
			Events.OnTip (content.minotauro_1);
		} else if (Data.Instance.gameProgress.GetData ("cuerno2").value == 1) {
			gameProgressValue++;
			Events.OnSaveNewData (gameProgressKey, gameProgressValue);
			Events.OnSaveNewData ("cuerno2", 2);
			Events.UseItem ("cuerno2");
			Events.OnTip (content.minotauro_2);
		} else if (gameProgressValue < 2) {
			Events.OnTip (content.minotauro_0);
		} else {
			Events.OnTip (content.minotauro_2);
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
//	void OnRepaired()
//	{
//		Events.OnSaveNewData ("picaporte", 2);
//		Events.OnTip (content.picaporte_4);
//		Events.OnTip(content.picaporte_4);
//	}
}
