using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMap : InteractiveObject
{
	public GameObject incomplete;
	public GameObject minimap1;
	public GameObject minimap2;
	public GameObject minimap3;
	public GameObject complete;

	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe()
	{ 
		if (gameProgressValue == 0) {	
			if (Data.Instance.gameProgress.GetData ("minimap_1").value == 1) {					
				Events.OnTexts (content.minimap_1_inserted, "inventary/minimap_1", OnDone);
			} else if (Data.Instance.gameProgress.GetData ("minimap_2").value == 1) {					
				Events.OnTexts (content.minimap_2_inserted, "inventary/minimap_2", OnDone);
			} else if (Data.Instance.gameProgress.GetData ("minimap_3").value == 1) {	
				Events.OnTexts (content.minimap_3_inserted, "inventary/minimap_3", OnDone);
			} else {
				Events.OnTip (content.map);
			}
			OnSetProgress (gameProgressValue);

		} else {
			incomplete.SetActive (false);
			minimap1.SetActive (false);
			minimap2.SetActive (false);
			minimap3.SetActive (false);
			complete.SetActive (true);
			Events.OnTip (content.mapReady);
		}
	}
	int partsReady;
	public override void OnSetProgress(int value) 
	{	
		if (Data.Instance.gameProgress.GetData ("minimap_1").value == 1) {
			Events.OnSaveNewData ("minimap_1", 2);
			Events.UseItem ("minimap_1");
			minimap1.SetActive (true);
			partsReady++;
		}
		if (Data.Instance.gameProgress.GetData ("minimap_2").value == 1) {
			Events.OnSaveNewData ("minimap_2", 2);
			Events.UseItem ("minimap_2");
			minimap2.SetActive (true);
			partsReady++;
		}
		if (Data.Instance.gameProgress.GetData ("minimap_3").value == 1) {
			Events.OnSaveNewData ("minimap_3", 2);
			Events.UseItem ("minimap_3");
			minimap3.SetActive (true);
			partsReady++;
		}

		if (partsReady < 3) {
			incomplete.SetActive (true);
			complete.SetActive (false);
		} else {
			Events.OnSaveNewData (gameProgressKey, 1);
			incomplete.SetActive (false);
			complete.SetActive (true);
			Events.OnSaveNewData ("libro_mapoteca_3", 1);
			Events.OnTexts (content.libro_mapoteca_3, "inventary/libro_mapoteca_3", OnReadComplete);
			return;
		}

	}
	void OnDone()
	{
	}
	public void OnReadComplete()
	{
		Events.OpenTrivia ("libro_mapoteca_3");
	}
}
