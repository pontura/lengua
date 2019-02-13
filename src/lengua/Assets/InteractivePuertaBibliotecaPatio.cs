using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePuertaBibliotecaPatio : InteractiveObject
{
	public GameObject closed;
	public GameObject opened;

	public override void OnCharacterReachMe()
	{ 
		if (gameProgressValue == 0) {			
			Events.OnTip (content.puerta_biblioteca_patio);
		} else  {
			Events.OnTip (content.puerta_biblioteca_patio);
		} 
	}
}