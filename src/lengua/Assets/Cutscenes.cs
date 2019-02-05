using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenes : MonoBehaviour {

	public Character character;
	public CutscenesUI cutscenesUI;

	[HideInInspector]
	public CharacterAnimations avatar;
	public CharacterAnimations marian;

	public types type;
	public enum types
	{
		NONE,
		INTRO,
		INTRO_END
	}
	void Start()
	{
		avatar = character.view.characterAnimations;
		Events.OnCutscene += OnCutscene;

		if(type == types.INTRO)
			Invoke ("Delayed", 0.15f);
	}

	public void Avatar_Walk()
	{
		avatar.Walk ();
	}
	public void Marian_Idle()
	{
		marian.Idle ();
	}
	public void Marian_Walk()
	{
		marian.Walk ();
	}

	public void Avatar_Exp_NEUTRO()
	{
		avatar.expressions.SetOn (CharacterExpressions.states.NEUTRO);
	}
	public void Avatar_Exp_CONTENTO()
	{
		avatar.expressions.SetOn (CharacterExpressions.states.CONTENTO);
	}
	public void Avatar_Exp_REFLEXIVO()
	{
		avatar.expressions.SetOn (CharacterExpressions.states.REFLEXIVO);
	}
	public void Avatar_Exp_PREOCUPADO()
	{
		avatar.expressions.SetOn (CharacterExpressions.states.PREOCUPADO);
	}
	public void Avatar_Exp_FASTIDIO()
	{
		avatar.expressions.SetOn (CharacterExpressions.states.FASTIDIO);
	}

	public void Marian_Exp_NEUTRO()
	{
		marian.expressions.SetOn (CharacterExpressions.states.NEUTRO);
	}
	public void Marian_Exp_CONTENTO()
	{
		marian.expressions.SetOn (CharacterExpressions.states.CONTENTO);
	}
	public void Marian_Exp_REFLEXIVO()
	{
		marian.expressions.SetOn (CharacterExpressions.states.REFLEXIVO);
	}
	public void Marian_Exp_PREOCUPADO()
	{
		marian.expressions.SetOn (CharacterExpressions.states.PREOCUPADO);
	}
	public void Marian_Exp_FASTIDIO()
	{
		marian.expressions.SetOn (CharacterExpressions.states.FASTIDIO);
	}

	void Delayed()
	{
		cutscenesUI.SetOn ();
		GetComponent<Animation> ().Play ("intro");
		Invoke ("Delayed2", 2);
	}
	void Delayed2()
	{
		OnCutscene (types.INTRO);
	}
	void OnReady()
	{
		OnCutscene (types.INTRO_END);
	}
	void OnDestroy()
	{
		Events.OnCutscene -= OnCutscene;
	}
	void OnCutscene(types anim)
	{
		switch (anim) {
		case types.INTRO:
			Events.OnDialogue (Data.Instance.dialoguesData.content.intro, OnReady);
			break;
		case types.INTRO_END:
			GetComponent<Animation> ().Play ("introEnd");
			cutscenesUI.SetOff ();
			break;
		}
	}
}
