﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePlaceObjectGeneric : InteractiveObject
{
	public GameObject state_incomplete;
	public GameObject state_complete;

	public string itemToBeUsed;
	public string itemReward;

	public string textNoUsableItem;

	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe()
	{ 
		if (gameProgressValue == 0)
		{ 
			if (Data.Instance.gameProgress.GetData (itemToBeUsed).value == 1) {			
				Events.UseItem (itemToBeUsed);
				Events.OnSaveNewData (itemToBeUsed, 2);
				Events.OnSaveNewData (gameProgressKey, 1);
				Events.OnSaveNewData (itemReward, 1);
				Events.OnTexts (content.GetValue (itemReward), "inventary/" + itemReward, null);
			} else {
				Events.OnTip (textNoUsableItem);
			}
		}
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
	void OnRepaired()
	{
	}
}
