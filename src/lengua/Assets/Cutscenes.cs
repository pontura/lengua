using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenes : MonoBehaviour {

	public enum types
	{
		INTRO
	}
	void Start()
	{
		Events.OnCutscene += OnCutscene;
		Invoke ("Delayed", 0.25f);
	}
	void Delayed()
	{
		OnCutscene (types.INTRO);
	}
	void OnReady()
	{
		//;
	}
	void OnDestroy()
	{
		Events.OnCutscene -= OnCutscene;
	}
	public void OnCutscene(types anim)
	{
		switch (anim) {
		case types.INTRO:
			Events.OnDialogue (Data.Instance.dialoguesData.content.intro, OnReady);
			GetComponent<Animation> ().Play ("intro");
			break;
		}
	}
}
