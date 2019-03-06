using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBusto : InteractiveObject
{
    public GameObject state_complete;
    public GameObject state_1;
    public GameObject state_2;

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
       if (gameProgressValue == 0)
        {
            if (Data.Instance.gameProgress.GetData("trenza1").value == 1)
            {
                Events.UseItem("trenza1");
                Events.OnSaveNewData("trenza1", 2);
                Events.OnTip(Data.Instance.interactiveObjectsTexts.content.GetValue("bustoColocaTrenza"));

            }
            else if (Data.Instance.gameProgress.GetData("trenza2").value == 1)
            {
                Events.UseItem("trenza2");
                Events.OnSaveNewData("trenza2", 2);
                Events.OnTip(Data.Instance.interactiveObjectsTexts.content.GetValue("bustoColocaTrenza"));
            }
            else
            {
                Events.OnTip(Data.Instance.interactiveObjectsTexts.content.GetValue(textNoUsableItem));
            }
        }
        OnSetProgress(gameProgressValue);
    }


    public override void OnSetProgress(int value)
    {
        if (gameProgressValue == 0)
        {
            state_complete.SetActive(false);
            int somethingIn = 0;
            if (Data.Instance.gameProgress.GetData("trenza1").value == 2)
            {
                state_1.SetActive(true);
                somethingIn++;
            }
            if (Data.Instance.gameProgress.GetData("trenza2").value == 2)
            {
                state_2.SetActive(true);
                somethingIn++;
            }
            if (somethingIn == 2)
            {
                state_complete.SetActive(true);
                Events.OnSaveNewData(gameProgressKey, 1);
                Events.OnTexts(content.cuadernoAltillo2, "inventary/cuadernoAltillo2", OnDone);
            }
            else
            {
                state_complete.SetActive(false);
            }
        }
        else
        {
            state_1.SetActive(true);
            state_2.SetActive(true);
            state_complete.SetActive(true);
        }
    }
      void OnDone()
	{
		Events.OpenTrivia ("cuadernoAltillo2");
	}
}
