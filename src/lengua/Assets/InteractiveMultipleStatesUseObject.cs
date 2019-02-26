using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMultipleStatesUseObject : InteractiveObject
{
	public GameObject[] states;
	public string itemToBeUsed;
	public string itemReward;
	int uses;
	public string textNoUsableItem;
	public bool itemRewardIsBook;

	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe()
	{ 
		if (uses == states.Length-1) 
			return;
		if (Data.Instance.gameProgress.GetData (itemToBeUsed).value == 1) {	

			if (uses < states.Length - 1) {
				uses++;

				if (uses == states.Length-1) 
					Done ();
			}
		} else {
			Events.OnTip (Data.Instance.interactiveObjectsTexts.content.GetValue(textNoUsableItem));
		}

		OnSetProgress (gameProgressValue);
	}
	void Done()
	{
		SetCollider (false);
		Events.OnSaveNewData (gameProgressKey, 1);
		Events.UseItem (itemToBeUsed);
		Events.OnSaveNewData (itemToBeUsed, 2);
		Events.OnSaveNewData (itemReward, 1);

		if(itemRewardIsBook)
			Events.OnTexts (content.GetValue (itemReward), "inventary/" + itemReward, OnDone);
		else
			Events.OnTexts (content.GetValue (itemReward), "inventary/" + itemReward, null);
	}
	void OnDone()
	{
		Events.OpenTrivia (itemReward);
	}
	public override void OnSetProgress(int value) 
	{	
		foreach(GameObject go in states)
			go.SetActive (false);

		states[uses].SetActive (true);
	}
	void OnRepaired()
	{
		
	}
}