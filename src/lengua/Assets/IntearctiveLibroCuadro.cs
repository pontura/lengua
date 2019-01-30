using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntearctiveLibroCuadro : InteractiveObject {

	public GameObject state1;
	public GameObject state2;

	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe()
	{ 
		if (gameProgressValue == 0) {			
			Events.OnSaveNewData (gameProgressKey, 1);
			Events.OnTexts (content.libroCuadro, "inventary/libroCuadro", OnReadComplete);
		} else if (gameProgressValue == 1) {
			Events.OnTip(content.libroCuadro2);
		}
	}
	public void OnReadComplete()
	{
		Events.OpenTrivia (gameProgressKey);
	}
	public override void OnSetProgress(int value) 
	{
		Reset ();
		if (value == 0) {
			state1.SetActive (true);
		}
		else
			state2.SetActive (true);
	}
	void Reset()
	{
		state1.SetActive (false);
		state2.SetActive (false);
	}
}
