using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePicaporte : InteractiveObject {

	public GameObject state0;
	public GameObject state1;

	public override void OnClicked() 
	{ 
		
	}
	public override void OnCharacterReachMe() 
	{ 
		if(gameProgressValue== 0)
			Events.OnTip (content.picaporte_roto);
		else if(gameProgressValue == 1)
			Events.OnTip (content.picaporte_bien);
	}
	public override void OnSetProgress(int value) 
	{
		Reset ();
		if(value == 0)
			state0.SetActive (true);
		else
			state1.SetActive (true);
	}
	void Reset()
	{
		state0.SetActive (false);
		state1.SetActive (false);
	}
}
