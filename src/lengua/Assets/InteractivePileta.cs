using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePileta : InteractiveObject
{
	public GameObject state_incomplete;
	public GameObject state_complete;

	public string itemToBeUsed;
	public string itemReward;

	public string textNoUsableItem;
	public bool itemRewardIsBook;

	public GameObject[] swapStateToOnClick;

	public override void OnClicked() 
	{ 
		//		if (swapStateToOnClick.Length == 0)
		//			return;
		//		if (swapStateToOnClick [0].activeSelf) {
		//			swapStateToOnClick [0].SetActive (false);
		//			swapStateToOnClick [1].SetActive (true);
		//		} else {
		//			swapStateToOnClick [1].SetActive (false);
		//			swapStateToOnClick [0].SetActive (true);
		//		}
	}
	public override void OnCharacterReachMe()
	{ 
		if (gameProgressValue == 0)
		{ 
			if (Data.Instance.gameProgress.GetData (itemToBeUsed).value == 1) {			
				Events.UseItem (itemToBeUsed);
				Events.OnSaveNewData (itemToBeUsed, 2);
				Events.OnSaveNewData (gameProgressKey, 1);

				if (itemReward != "") 
				{
					Events.OnSaveNewData (itemReward, 1);					
					if (itemRewardIsBook)
						Events.OnTexts (content.GetValue (itemReward), "inventary/" + itemReward, OnDone);
					else
						Events.OnTexts (content.GetValue (itemReward), "inventary/" + itemReward, null);
				}

			} else {
				Events.OnTip (Data.Instance.interactiveObjectsTexts.content.GetValue(textNoUsableItem));
			}
		}
		OnSetProgress (gameProgressValue);
	}
	void OnDone()
	{
		Events.OpenTrivia (itemReward);
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
