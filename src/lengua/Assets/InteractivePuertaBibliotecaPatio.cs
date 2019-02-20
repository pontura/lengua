using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePuertaBibliotecaPatio : InteractiveObject
{
	public GameObject closed;
	public GameObject opened;

	void OnEnable()
	{
		OnSetProgress (gameProgressValue);
	}
	public override void OnCharacterReachMe()
	{ 
		if (gameProgressValue == 1) {	
			Events.ChangeRoom (Room.types.PATIO, new Vector2 (0, -6));
		} else  if (gameProgressValue == 0) {	
			if (Data.Instance.gameProgress.GetData ("tarjeta").value == 1) {
				Events.UseItem ("tarjeta");
				Events.OnSaveNewData ("tarjeta", 2);
				Events.OnSaveNewData (gameProgressKey, 1);
				OnSetProgress (1);
			} else {
				Events.OnTip (content.puerta_biblioteca_patio);
			}
		} else  {
			Events.OnTip (content.puerta_biblioteca_patio);
		} 
	}
	public override void OnSetProgress(int value) 
	{	
		if (gameProgressValue > 0) {
			closed.SetActive (false);
			opened.SetActive (true);
		} else {
			closed.SetActive (true);
			opened.SetActive (false);
		}
	}
}