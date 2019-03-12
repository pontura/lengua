using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveFichero : InteractiveObject {

	public GameObject cerrado;
	public GameObject abierto;

	void OnEnable()
	{
		if (gameProgressValue == 0) {
			cerrado.SetActive (true);
			abierto.SetActive (false);
		}
		gameProgressKey = "fichero_llave";
	}
	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe() 
	{ 
		
		if (gameProgressValue == 0) {
			Events.OnTip(content.fichero_1);
			//Events.OnSaveNewData (gameProgressKey, 1);
		} else if (gameProgressValue == 1) {			
			Events.OnTexts (content.fichero_con_llave, "inventary/fichero_llave", FicheroOpened);
			return;
		} else {
			Events.OnTip (content.fichero_done);		
		}
		SetState ();
	}
	void FicheroOpened() 
	{
		Events.OnSaveNewData ("cuaderno_ingreso", 1);
		Events.OnTexts (content.fichero_con_llave2, "inventary/cuadernoIngreso", OpenLibro);
		Events.UseItem (gameProgressKey);
		SetState ();
	}
	void OpenLibro()
	{
		Events.OnSaveNewData (gameProgressKey, 2);
		Events.OpenTrivia ("cuaderno_ingreso");
	}
	void SetState()
	{
		if (gameProgressValue == 0) {
			cerrado.SetActive (true);
			abierto.SetActive (false);
		} else  {
			cerrado.SetActive (false);
			abierto.SetActive (true);
		}
	}
}
