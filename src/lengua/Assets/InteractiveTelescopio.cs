using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveTelescopio : InteractiveObject
{
    public GameObject state_0;
    public GameObject state_1;
    public GameObject state_2;
    public GameObject state_3;
    public GameObject state_4;

    public GameObject state_estrella1;
    public GameObject state_estrella2;
    public GameObject state_estrella3;
    public GameObject state_estrella4;

    public override void OnClicked()
    {
    }
    public int totalDone;
    public override void OnCharacterReachMe()
    {
        if (Data.Instance.gameProgress.GetData("manivela").value == 0)
            Events.OnTip(content.telescopio_sin_manivela);
        else if (Data.Instance.gameProgress.GetData("manivela").value == 1)
        {
            Events.OnTexts(content.manivela_done, "inventary/manivela", OnManivela);
            Events.UseItem("manivela");
            Events.OnSaveNewData("manivela", 2);
            totalDone++;
        }
        else if (gameProgressValue == 1)
        {
            Events.OnTip(Data.Instance.interactiveObjectsTexts.content.GetValue("telescopio_done"));
        }
        else if (gameProgressValue == 0 && Data.Instance.gameProgress.GetData("claraboya").value == 1)
        {
            totalDone++;
        }
        else
        {
            Events.OnTip(content.telescopio_1);
        }
        OnSetProgress(gameProgressValue);
    }
    void OnManivela()
    {
         state_0.SetActive(false);
        state_1.SetActive(true);
    }
    public override void OnSetProgress(int value)
    {
        if (Data.Instance.gameProgress.GetData("manivela").value == 0)
          return;
        if (gameProgressValue == 1)
        {
            state_estrella1.SetActive(false);
            state_estrella2.SetActive(false);
            state_estrella3.SetActive(false);
            state_estrella4.SetActive(true);
            state_0.SetActive(false);
            state_1.SetActive(false);
            state_2.SetActive(false);
            state_3.SetActive(false);
            state_4.SetActive(true);
        }
        else if (Data.Instance.gameProgress.GetData("claraboya").value == 1)
        {
            state_estrella1.SetActive(false);
            state_estrella2.SetActive(false);
            state_estrella3.SetActive(false);
            state_estrella4.SetActive(false);
            state_0.SetActive(false);
            state_1.SetActive(false);
            state_2.SetActive(false);
            state_3.SetActive(false);
            state_4.SetActive(false);

            if (totalDone <= 1)
            {
                state_1.SetActive(true);
                state_estrella1.SetActive(true);
                Events.OnTip(content.telescopio_2);
            }
            else if (totalDone == 2)
            {
                state_2.SetActive(true);
                state_estrella2.SetActive(true);
                Events.OnTip(content.telescopio_2);
            }
            else if (totalDone == 3)
            {
                state_3.SetActive(true);
                state_estrella3.SetActive(true);
                Events.OnTip(content.telescopio_2);
            }
             else if (totalDone == 4)
            {
                state_4.SetActive(true);
                state_estrella4.SetActive(true);
                Events.OnSaveNewData(gameProgressKey, 1);
                Events.OnTexts(content.telescopio_done, "inventary/estrella", OnRepaired);
                Events.OnSaveNewData("claraboya", 2);
            }
        }
    }
    void OnRepaired()
    {
        Events.OnTexts(content.libro_altillo_2, "inventary/libro_altillo_2", OnDone);
    }
    void OnDone()
    {
        Events.OpenTrivia("libro_altillo_2");
        Events.OnSaveNewData("libro_altillo_2", 1);
    }
}