using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePicaporte : InteractiveObject {
	

	public GameObject prototipoDone;
	public GameObject state_romper;
	public GameObject state_ganar;
	public GameObject state_abrir;

	public override void OnClicked() 
	{ 
		
	}
	public override void OnCharacterReachMe()
	{ 
		Debug.Log ("_picaporte: OnCharacterReachMe" + gameProgressValue);

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
			Events.ChangeRoom (Room.types.BIBLIOTECA);
			Events.ForceCharacterPosition(new Vector3(0,0,0));
		} 
	}

	public override void OnSetProgress(int value) 
	{	
	
		if (value == 2) {
			state_romper.SetActive (false);
			state_ganar.SetActive (true);
			state_abrir.SetActive (false);
		} else if (value == 3) {
			state_abrir.SetActive (true);
			state_ganar.SetActive (false);
			state_romper.SetActive (false);
		}
	}
	void OnRepaired()
	{
		Events.OnSaveNewData ("picaporte", 2);
		Events.OnTip (content.picaporte_4);
		Events.OnTip(content.picaporte_4);
	}
}
