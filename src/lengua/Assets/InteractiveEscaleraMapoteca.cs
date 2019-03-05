using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveEscaleraMapoteca : InteractiveObject
{
	public GameObject state_incomplete;
	public GameObject state_complete;

	public string itemToBeUsed;
	public string itemReward;

	public string textNoUsableItem;
	public string textWhenDone;

	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe()
	{ 
		if (gameProgressValue == 1) { 
			Events.ChangeRoom (Room.types.ALTILLO, new Vector2 (3.2f,-0.5f));
		}
		if (gameProgressValue == 0) { 
			if (Data.Instance.gameProgress.GetData (itemToBeUsed).value == 1) {			
				Events.UseItem (itemToBeUsed);
				Events.OnSaveNewData (itemToBeUsed, 2);
				Events.OnSaveNewData (gameProgressKey, 1);
				//Events.OnSaveNewData (itemReward, 1);
				Events.OnTexts (textWhenDone, "inventary/" + itemToBeUsed, OnUsed);
				return;
			} else {
				Events.OnTip (textNoUsableItem);
			}
		} else {
			
		}
		OnSetProgress (gameProgressValue);
	}
	void OnUsed()
	{
		OnSetProgress (gameProgressValue);
	}
	public override void OnSetProgress(int value) 
	{	
		state_incomplete.SetActive (false);
		state_complete.SetActive (false);

		if (value == 0) 
			state_incomplete.SetActive (true);
		else
			state_complete.SetActive (true);
	}
}
