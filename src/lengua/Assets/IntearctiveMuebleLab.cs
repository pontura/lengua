using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntearctiveMuebleLab : InteractiveObject
{
	public GameObject closed;
	public GameObject item_libro;
	public GameObject item_veneno;
	public GameObject opened;

	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe()
	{ 
		if (gameProgressValue == 0) {	
			if (Data.Instance.gameProgress.GetData ("llave02").value == 1) {					
				Events.OnTexts (content.llave02_used, "inventary/llave02", OnDone);
				Events.UseItem ("llave02");
				Events.OnSaveNewData ("llave02", 2);
				Events.OnSaveNewData (gameProgressKey, 1);
			}
		} else {
			closed.SetActive (false);
			opened.SetActive (true);

			if (gameProgressValue == 1) {
				item_libro.SetActive (false);
				Events.OnTexts (content.llave02_used, "inventary/libro_lab_2", OnReadComplete);
				Events.OnSaveNewData ("libro_lab_2", 1);
				Events.OnSaveNewData (gameProgressKey, 2);	
			} else if (gameProgressValue == 2) {
				item_veneno.SetActive (false);
				Events.OnTexts (content.llave02_used, "inventary/veneno", null);
				Events.OnSaveNewData ("veneno", 1);
				Events.OnSaveNewData (gameProgressKey, 3);	
			}
		}
	}
	int partsReady;
	public override void OnSetProgress(int value) 
	{	
		if (Data.Instance.gameProgress.GetData (gameProgressKey).value >0) {
			closed.SetActive (false);
			opened.SetActive (true);
			if (Data.Instance.gameProgress.GetData (gameProgressKey).value > 1) {
				item_libro.SetActive (false);
			} 
			if (Data.Instance.gameProgress.GetData (gameProgressKey).value > 2) {
				item_veneno.SetActive (false);
			}
		} else {
			closed.SetActive (true);
			opened.SetActive (false);
		}


	}
	void OnDone()
	{
		closed.SetActive (false);
		opened.SetActive (true);
	}
	public void OnReadComplete()
	{
		Events.OpenTrivia ("libro_lab_2");
	}
}
