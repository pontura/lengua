using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveCompuerta : InteractiveObject
{
    public override void OnCharacterReachMe()
    {
       if (gameProgressValue == 0)
        {
            if (Data.Instance.gameProgress.GetData("rosa").value == 1)
            {
                Events.ChangeRoom(Room.types.MAPOTECA,new Vector2(2,2));
            } else
            {
                Events.OnTip(content.compuerta_no);
            }
        }
        OnSetProgress(gameProgressValue);
    }

}