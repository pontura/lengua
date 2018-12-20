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
			Events.OnTip(content.fichero_1);
			//Events.OnSaveNewData (gameProgressKey, 1);
		} else if (gameProgressValue == 1) {			
			Events.OnTexts (content.fichero_con_llave, "inventary/fichero_llave", FicheroOpened);
		} else {
			Events.OnTip (content.fichero_done);		
		}
	}
	void FicheroOpened() 
	{
		Events.OnSaveNewData ("cuaderno_ingreso", 1);
		Events.OnTexts (content.fichero_con_llave2, "inventary/cuadernoIngreso", OpenLibro);
		Events.UseItem (gameProgressKey);
	}
	void OpenLibro()
	{
		Events.OnSaveNewData (gameProgressKey, 2);
		Events.OpenTrivia ("cuaderno_ingreso");
	}
}
