using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSoporteMapas : InteractiveObject
{
	public GameObject state1;
	public GameObject state2;

	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe()
	{ 
		if (gameProgressValue == 0) {			
			Events.OnSaveNewData (gameProgressKey, 2);
			Events.OnSaveNewData ("libro_mapoteca_2", 1);
			Events.OnTexts (content.libro_mapoteca_2, "inventary/libro_mapoteca_2", OnRepaired);
		}
		OnSetProgress (gameProgressValue);
	}

	public override void OnSetProgress(int value) 
	{	
		state1.SetActive (false);
		state2.SetActive (false);

		if (value == 0) 
			state1.SetActive (true);
		else
			state2.SetActive (true);
	}
	void OnRepaired()
	{
	}
}
