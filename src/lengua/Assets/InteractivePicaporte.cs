using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePicaporte : InteractiveObject {
	

	public GameObject prototipoDone;
	public GameObject state_romper;
	public GameObject state_ganar;
	public GameObject state_abrir;
	public GameObject state_abierta;
    public GameObject state_cerrada;

    void Awake() {
        if (Data.Instance.gameProgress.GetData("cutscenes").value > 0) {
            state_romper.SetActive(false);
            state_ganar.SetActive(false);
            state_abrir.SetActive(false);
            state_abierta.SetActive(false);
            state_cerrada.SetActive(true);
        }
    }

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
			Events.OnSaveNewData ("picaporte", 4);
			OnSetProgress(3);
			Events.ChangeRoom (Room.types.BIBLIOTECA, new Vector2(-8.51f, 2.3f));
		} else if (gameProgressValue == 4) {	
			OnSetProgress(4);
			Events.ChangeRoom (Room.types.BIBLIOTECA, new Vector2(-8.51f, 2.3f));
		} 
	}

	public override void OnSetProgress(int value) 
	{	
		state_abierta.SetActive (false);
        
        
        if (value == 2) {
			state_romper.SetActive (false);
			state_ganar.SetActive (true);
			state_abrir.SetActive (false);
			state_abierta.SetActive (false);
            state_cerrada.SetActive(false);
        } else if (value == 3) {
			state_abrir.SetActive (true);
			state_ganar.SetActive (false);
			state_romper.SetActive (false);
			state_abierta.SetActive (false);
            state_cerrada.SetActive(false);
        } else if (value == 4) {
			state_abrir.SetActive (false);
			state_ganar.SetActive (false);
			state_romper.SetActive (false);
			state_abierta.SetActive (true);
            state_cerrada.SetActive(false);
        }
	}
	void OnRepaired()
	{
		Events.OnSaveNewData ("picaporte", 2);
		Events.OnTip (content.picaporte_4);
		Events.OnTip(content.picaporte_4);
	}
}
