using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveCajoneraMapoteca : InteractiveObject
{
	public GameObject closed;
	public GameObject state1;
	public GameObject state2;
	public GameObject state3;
	public GameObject state4;

	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe()
	{ 
		Debug.Log ("_picaporte: OnCharacterReachMe" + gameProgressValue);

		if (gameProgressValue == 0) {			
			Events.OnSaveNewData (gameProgressKey, 1);
			Events.OnTip (content.cajoneraVacia);
		} else if (gameProgressValue == 1) {
			Events.OnSaveNewData (gameProgressKey, 2);
			Events.OnSaveNewData ("minimap_1", 1);
			Events.OnTexts (content.minimap_1, "inventary/minimap_1", OnRepaired);
		} else if (gameProgressValue == 2) {
			Events.OnSaveNewData (gameProgressKey, 3);
			Events.OnTip (content.cajoneraVacia);
		} else if (gameProgressValue == 3) {			
			Events.OnSaveNewData (gameProgressKey, 4);
			Events.OnSaveNewData ("cuadernoMapoteca1", 1);
			Events.OnTexts (content.minimap_1, "inventary/cuadernoMapoteca1", OnRepaired);
		} 
		OnSetProgress (gameProgressValue);
	}

	public override void OnSetProgress(int value) 
	{	
		closed.SetActive (false);
		state1.SetActive (false);
		state2.SetActive (false);
		state3.SetActive (false);
		state4.SetActive (false);

		if (value == 0) 
			closed.SetActive (true);
		else  if (value == 1)
			state1.SetActive (true);
		else  if (value == 2)
			state2.SetActive (true);
		else  if (value == 3)
			state3.SetActive (true);
		else  if (value == 4)
			state4.SetActive (true);
	}
	void OnRepaired()
	{
	}
}
