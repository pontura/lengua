using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePicaporte : InteractiveObject {
	

	public GameObject prototipoDone;
	public GameObject state0;
	public GameObject state1;
	public GameObject state2;

	public override void OnClicked() 
	{ 
		
	}
	public override void OnCharacterReachMe()
	{ 
		if (gameProgressValue == 2) {			
			Events.OnSaveNewData ("picaporte", 3);
			OnSetProgress (3);
		} else if (Data.Instance.gameProgress.GetData ("destornillador").value == 1) {
			Events.OnSaveNewData ("destornillador", 2);
			Events.UseItem ("destornillador");
			Events.OnTexts (content.picaporte_3, "inventary/destornillador", OnRepaired);
		} else if (gameProgressValue == 0) {
			Events.OnTip (content.picaporte_1);
			Events.OnSaveNewData ("picaporte", 1);
		} else if (gameProgressValue == 1) {
			Events.OnTip (content.picaporte_2);
		} else if (gameProgressValue == 3) {			
			Events.OnSaveNewData ("picaporte", 3);
			OnSetProgress(3);
			Data.Instance.LoadScene ("ProtoDone");
		} 
	}
	public override void OnSetProgress(int value) 
	{
		Reset ();
		if(value < 2 )
			state0.SetActive (true);
		else if(value == 2)
			state1.SetActive (true);
		else if(value == 3)
			state2.SetActive (true);
	}
	void OnRepaired()
	{
		Events.OnSaveNewData ("picaporte", 2);
		Events.OnTip (content.picaporte_4);
		Events.OnTip(content.picaporte_4);
	}
	void Reset()
	{
		state0.SetActive (false);
		state1.SetActive (false);
		state2.SetActive (false);
	}
}
