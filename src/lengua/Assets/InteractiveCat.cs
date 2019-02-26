using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveCat : InteractiveObject
{
	public GameObject normal;
	public GameObject angry;
	public GameObject origami;
	public GameObject walk;

	void OnEnable()
	{
		SetState (normal);
	}
	public override void OnClicked() 
	{ 

	}
	public override void OnCharacterReachMe()
	{ 
		if (Data.Instance.gameProgress.GetData ("origami").value == 3)	
		{
			GotoRoom ();
		}else if (Data.Instance.gameProgress.GetData ("origami").value == 2)	
		{
			Events.OnTexts (content.catDone, "inventary/origami", GotoRoom);
			Events.OnSaveNewData ("origami", 3);
			SetState (walk);
		} else	if (Data.Instance.gameProgress.GetData ("origami").value == 1) {	
			Events.OnSaveNewData ("origami", 2);
			SetState (origami);
		} else {
			Events.OnTip (Data.Instance.interactiveObjectsTexts.content.GetValue("catSinOrigami"));
			SetState (angry);
		}
		OnSetProgress (gameProgressValue);
	}
	void SetState(GameObject go)
	{
		normal.SetActive (false);
		angry.SetActive (false);
		origami.SetActive (false);
		walk.SetActive (false);

		go.SetActive (true);
	}
	void GotoRoom()
	{
		Events.ChangeRoom (Room.types.LAB, new Vector2 (-1.142f, 2.16f));
	}
}