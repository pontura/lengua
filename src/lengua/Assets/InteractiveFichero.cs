using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveFichero : InteractiveObject {

	void OnEnable()
	{
		gameProgressKey = "fichero_llave";
	}
	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe() 
	{ 
		if (gameProgressValue == 0) {
			Events.OnTip (content.fichero_1);
			//Events.OnSaveNewData (gameProgressKey, 1);
		} else if (gameProgressValue == 1) {
			Events.OnTip (content.fichero_con_llave);
			Events.OnSaveNewData (gameProgressKey, 2);
			Events.OnSaveNewData ("cuaderno_ingreso", 1);
		} else 
			Events.OnTip (content.fichero_done);
	}
	public override void OnSetProgress(int value) 
	{
//		if (value == 2)
//			SetCollider (false);
	}
}
