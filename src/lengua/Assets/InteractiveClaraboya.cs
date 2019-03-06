using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveClaraboya : InteractiveObject
{
    public GameObject state_incomplete;
    public GameObject state_estrella1;
	public GameObject state_escalera;

	public string textNoUsableItem;

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
        if (gameProgressValue == 1)
		{ 
            state_estrella1.SetActive(true);
        } else if (gameProgressValue == 0)
		{ 
			if (Data.Instance.gameProgress.GetData ("escalera_altillo").value == 1) {			
				Events.UseItem ("escalera_altillo");
				Events.OnSaveNewData ("escalera_altillo", 2);
                Events.OnTip (Data.Instance.interactiveObjectsTexts.content.GetValue("claraboyaPoneEscalera"));
               
			} else if (Data.Instance.gameProgress.GetData ("estrella").value == 1) {
                if(Data.Instance.gameProgress.GetData ("escalera_altillo").value == 2)	
                {		
                    Events.UseItem ("estrella");
                    Events.OnSaveNewData ("estrella", 2);
                    Events.OnTip (Data.Instance.interactiveObjectsTexts.content.GetValue("claraboyaPoneEstrella"));
                } else
                {
                    Events.OnTip(content.no_hay_escalera);
                }
			} else {
				Events.OnTip (Data.Instance.interactiveObjectsTexts.content.GetValue(textNoUsableItem));
			}
		}
		OnSetProgress (gameProgressValue);
	}
	
  
	public override void OnSetProgress(int value) 
	{	
        if (gameProgressValue == 0)
		{
            int somethingIn = 0;
            if (Data.Instance.gameProgress.GetData ("escalera_altillo").value == 2) {	
                state_escalera.SetActive(true);
               somethingIn++;
            }
            if (Data.Instance.gameProgress.GetData ("estrella").value == 2) {	
                state_estrella1.SetActive(true);
                somethingIn++;
            }
            if(somethingIn == 0)
              state_incomplete.SetActive(true);    
             else if(somethingIn == 2)
             {
                state_incomplete.SetActive(false);    
                state_estrella1.SetActive(true);
                Events.OnSaveNewData (gameProgressKey, 1);
             }
        } else
        {
            state_escalera.SetActive(true);
        }
	}
}
