using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePizarron : InteractiveObject
{
	public GameObject incomplete;
	public GameObject state1;
	public GameObject state2;
	public GameObject complete;

	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe()
	{ 
		if (gameProgressValue == 0) {	
			if (Data.Instance.gameProgress.GetData ("letra2").value == 1) {					
				Events.OnTexts (content.letra2_inserted, "inventary/letra2", OnDone);
			} else if (Data.Instance.gameProgress.GetData ("h").value == 1) {					
				Events.OnTexts (content.h_inserted, "inventary/h", OnDone);
			} else {
				Events.OnTip (content.pizarron);
			}
			OnSetProgress (gameProgressValue);

		} else {
			incomplete.SetActive (false);
			state1.SetActive (false);
			state2.SetActive (false);
			complete.SetActive (true);
			//Events.OnTip (content.mapReady);
		}
	}
	int partsReady;
	public override void OnSetProgress(int value) 
	{	
		if (Data.Instance.gameProgress.GetData ("letra2").value == 1) {
			Events.OnSaveNewData ("letra2", 2);
			Events.UseItem ("letra2");
			state1.SetActive (true);
			partsReady++;
		}
		if (Data.Instance.gameProgress.GetData ("h").value == 1) {
			Events.OnSaveNewData ("h", 2);
			Events.UseItem ("h");
			state2.SetActive (true);
			partsReady++;
		}

		if (partsReady < 2) {
			incomplete.SetActive (true);
			complete.SetActive (false);
		} else {
			Events.OnSaveNewData (gameProgressKey, 1);
			incomplete.SetActive (false);
			complete.SetActive (true);
			Events.OnSaveNewData ("cuadernoLab3", 1);
			Events.OnTexts (content.cuadernoLab3, "inventary/cuadernoLab3", OnReadComplete);
			return;
		}

	}
	void OnDone()
	{
	}
	public void OnReadComplete()
	{
		Events.OpenTrivia ("cuadernoLab3");
	}
}
