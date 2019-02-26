using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveCaballo : InteractiveObject
{
	public GameObject incomplete;
	public GameObject part1;
	public GameObject part2;
	public GameObject complete;

	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe()
	{ 
		if (gameProgressValue == 0) {	
			if (Data.Instance.gameProgress.GetData ("cola").value == 1) {					
				Events.OnTexts (content.cola_inserted, "inventary/cola", OnDone);
			} else if (Data.Instance.gameProgress.GetData ("montura").value == 1) {					
				Events.OnTexts (content.montura_inserted, "inventary/montura", OnDone);
			} else {
				Events.OnTip (content.estatuaIncompleta);
			}
			OnSetProgress (gameProgressValue);

		} else {
			incomplete.SetActive (false);
			part1.SetActive (false);
			part2.SetActive (false);
			complete.SetActive (true);
			Events.OnTip (content.mapReady);
		}
	}
	int partsReady;
	public override void OnSetProgress(int value) 
	{	
		if (Data.Instance.gameProgress.GetData ("cola").value == 1) {
			Events.OnSaveNewData ("cola", 2);
			Events.UseItem ("cola");
			part1.SetActive (true);
			partsReady++;
		}
		if (Data.Instance.gameProgress.GetData ("montura").value == 1) {
			Events.OnSaveNewData ("montura", 2);
			Events.UseItem ("montura");
			part2.SetActive (true);
			partsReady++;
		}

		if (partsReady < 2) {
			incomplete.SetActive (true);
			complete.SetActive (false);
		} else {
			Events.OnSaveNewData (gameProgressKey, 1);
			incomplete.SetActive (false);
			complete.SetActive (true);
			Events.OnSaveNewData ("libro_patio_3", 1);
			Events.OnTexts (content.libro_patio_3, "inventary/libro_patio_3", OnReadComplete);
			return;
		}

	}
	void OnDone()
	{
	}
	public void OnReadComplete()
	{
		Events.OpenTrivia ("libro_patio_3");
	}
}
