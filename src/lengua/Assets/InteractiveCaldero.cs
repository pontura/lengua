using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveCaldero : InteractiveObject
{
	public GameObject incomplete;
	public GameObject vaso2;
	public GameObject veneno;
	public GameObject copa;
	public GameObject complete;

	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe()
	{ 
		if (gameProgressValue == 0) {	
			if (Data.Instance.gameProgress.GetData ("vaso2").value == 1) {					
				Events.OnTexts (content.caldero_inserted, "inventary/vaso2", null);
			} else if (Data.Instance.gameProgress.GetData ("veneno").value == 1) {					
				Events.OnTexts (content.caldero_inserted, "inventary/veneno", null);
			} else if (Data.Instance.gameProgress.GetData ("copa").value == 1) {	
				Events.OnTexts (content.caldero_inserted, "inventary/copa", null);
			} else {
				Events.OnTip (content.caldero1);
			}
			OnSetProgress (gameProgressValue);
		} else {
			incomplete.SetActive (false);
			vaso2.SetActive (false);
			veneno.SetActive (false);
			copa.SetActive (false);
			complete.SetActive (true);
			Events.OnTip (content.caldero3);
		}
	}
	public override void OnSetProgress(int value) 
	{	
		if (gameProgressValue == 1) {
			incomplete.SetActive (false);
			complete.SetActive (true);
			return;
		}
		if (Data.Instance.gameProgress.GetData ("vaso2").value == 1) {
			Events.OnSaveNewData ("vaso2", 2);
			Events.UseItem ("vaso2");
			vaso2.SetActive(true);
		}
		if (Data.Instance.gameProgress.GetData ("veneno").value == 1) {
			Events.OnSaveNewData ("veneno", 2);
			Events.UseItem ("veneno");
			veneno.SetActive(true);
		}
		if (Data.Instance.gameProgress.GetData ("copa").value == 1) {
			Events.OnSaveNewData ("copa", 2);
			Events.UseItem ("copa");
			copa.SetActive(true);
		}

		if (Data.Instance.gameProgress.GetData ("copa").value == 2
		&&
			Data.Instance.gameProgress.GetData ("veneno").value == 2
		&&
			Data.Instance.gameProgress.GetData ("vaso2").value == 2
		) {
			incomplete.SetActive (false);
			complete.SetActive (true);
			Events.OnSaveNewData (gameProgressKey, 1);

			Events.OnSaveNewData ("g", 1);
			Events.OnTexts (content.g, "inventary/g", null);

		} else {
			incomplete.SetActive (true);
			complete.SetActive (false);
		}

	}
	void OnDone()
	{
	}
}
