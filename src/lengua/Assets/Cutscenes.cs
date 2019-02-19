using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenes : MonoBehaviour {

	public Room room;
	public CharacterAnimations marian;
	public CharacterAnimations zina;

	public types type;
	public enum types
	{
		NONE,
		INTRO,
		INTRO_END,
		BIBLIOTECA,
		BIBLIOTECA_END,
		PUERTA_MAPOTECA
	}
	void Start()
	{
		Events.OnCutscene += OnCutscene;
	}
	void OnDestroy()
	{
		Events.OnCutscene -= OnCutscene;
	}
	public void Init(Room room)
	{
		this.room = room;
		//Events.OnCutscene += OnCutscene;

		if(type == types.INTRO || type == types.BIBLIOTECA)
			Invoke ("Delayed", 0.15f);
	}
	public void Avatar_Idle()
	{
		room.roomsManager.character.view.characterAnimations.Idle ();
	}
	public void Avatar_Walk()
	{
		room.roomsManager.character.view.characterAnimations.Walk ();
	}
	public void Avatar_Walk_to_Ladder()
	{
		Events.OnFloorClicked (new Vector3(-5.1f,0,2.4f));
	}
	public void Avatar_Ladder()
	{
		room.roomsManager.character.view.characterAnimations.Ladder ();
		Vector3 pos = room.roomsManager.character.view.gameObject.transform.localPosition;
		iTween.MoveTo (room.roomsManager.character.view.gameObject, iTween.Hash ("x", pos.x+0.32f, "y", pos.y+5 , "islocal", true, "time", 25,"looptype","none"));
		Invoke ("OnReady", 2);
	}
	public void Marian_Idle()
	{
		marian.Idle ();
	}
	public void Marian_Talk()
	{
		marian.Talk ();
	}
	public void Marian_Walk()
	{
		marian.Walk ();
	}

	public void Zina_Idle()
	{
		zina.Idle ();
	}
	public void Zina_Disappear()
	{
		zina.Disappear ();
	}

	public void Avatar_Exp_NEUTRO()
	{
		room.roomsManager.character.view.characterAnimations.expressions.SetOn (CharacterExpressions.states.NEUTRO);
	}
	public void Avatar_Exp_CONTENTO()
	{
		room.roomsManager.character.view.characterAnimations.expressions.SetOn (CharacterExpressions.states.CONTENTO);
	}
	public void Avatar_Exp_REFLEXIVO()
	{
		room.roomsManager.character.view.characterAnimations.expressions.SetOn (CharacterExpressions.states.REFLEXIVO);
	}
	public void Avatar_Exp_PREOCUPADO()
	{
		room.roomsManager.character.view.characterAnimations.expressions.SetOn (CharacterExpressions.states.PREOCUPADO);
	}
	public void Avatar_Exp_FASTIDIO()
	{
		room.roomsManager.character.view.characterAnimations.expressions.SetOn (CharacterExpressions.states.FASTIDIO);
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

	public void Zina_Exp_NEUTRO()
	{
		zina.expressions.SetOn (CharacterExpressions.states.NEUTRO);
	}
	public void Zina_Exp_CONTENTO()
	{
		zina.expressions.SetOn (CharacterExpressions.states.CONTENTO);
	}
	public void Zina_Exp_REFLEXIVO()
	{
		zina.expressions.SetOn (CharacterExpressions.states.REFLEXIVO);
	}
	public void Zina_Exp_PREOCUPADO()
	{
		zina.expressions.SetOn (CharacterExpressions.states.PREOCUPADO);
	}
	public void Zina_Exp_FASTIDIO()
	{
		zina.expressions.SetOn (CharacterExpressions.states.FASTIDIO);
	}

	void Delayed()
	{	

		switch (type) {
		case types.INTRO:
			if (Data.Instance.gameProgress.GetData ("cutscenes").value < 1) {
				GetComponent<Animation> ().Play ("intro");
				Events.OnSaveNewData ("cutscenes", 1);
			}
			else
				return;
			break;
		case types.BIBLIOTECA:
			if (Data.Instance.gameProgress.GetData ("cutscenes").value < 2) {
				Events.OnSaveNewData ("cutscenes", 2);
				Events.OnFloorClicked (new Vector3 (-8.5f, 0, 2));
				GetComponent<Animation> ().Play ("biblioteca");
			}
			else
				return;
			break;
		}
		switch (type) {
		case types.INTRO:
			OnCutscene (types.INTRO);
			break;
		case types.BIBLIOTECA:
			OnCutscene (types.BIBLIOTECA);
			break;
		}

	}
	void OnReady()
	{
		print ("_______On ready " + type);
		switch (type) {
		case types.INTRO:
			OnCutscene (types.INTRO_END);
			break;
		case types.BIBLIOTECA:
			OnCutscene (types.BIBLIOTECA_END);
			break;
		case types.PUERTA_MAPOTECA:
			Events.ChangeRoom (Room.types.MAPOTECA, new Vector2 (0, 0));
			//OnCutscene (types.BIBLIOTECA_END);
			break;
		}
	}

	void OnCutscene(types anim)
	{
		this.type = anim;
		switch (anim) {
		case types.INTRO:
			room.roomsManager.cutscenesUI.SetOn ();
			Events.OnDialogue (Data.Instance.dialoguesData.content.intro, OnReady);
			break;
		case types.INTRO_END:
			GetComponent<Animation> ().Play ("introEnd");
			room.roomsManager.cutscenesUI.SetOff ();
			break;
		case types.BIBLIOTECA:
			room.roomsManager.cutscenesUI.SetOn ();
			Events.OnDialogue (Data.Instance.dialoguesData.content.biblioteca, OnReady);
			break;
		case types.BIBLIOTECA_END:
			GetComponent<Animation> ().Play ("biblioteca_end");
			room.roomsManager.cutscenesUI.SetOff ();
			break;
		case types.PUERTA_MAPOTECA:
			GetComponent<Animation> ().Play ("puerta_mapoteca");
			room.roomsManager.cutscenesUI.SetOn ();
			Events.OnDialogue (Data.Instance.dialoguesData.content.escalera, null);
			break;
		}
	}
}
