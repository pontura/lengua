using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePuertaMapoteca : InteractiveObject
{
	public override void OnCharacterReachMe() 
	{
		if (Data.Instance.gameProgress.GetData ("escalera").value == 1) {
			Events.OnSaveNewData ("escalera", 2);
			Events.OnCutscene (Cutscenes.types.PUERTA_MAPOTECA);
		} else {
			Events.OnTip (content.puertaMapoteca);
		}
	}
	public void RuedaDone()
	{
		iTween.MoveTo (gameObject, iTween.Hash ("x", transform.localPosition.x-1 , "islocal", true, "time", 4 ,"looptype","none"));
	}
}
