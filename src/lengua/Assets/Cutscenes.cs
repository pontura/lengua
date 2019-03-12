using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenes : MonoBehaviour
{

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
        PUERTA_MAPOTECA,
        MAPOTECA,
        MAPOTECA_END,
        MAPOTECA2,
        MAPOTECA_END2,
        FINAL,
        FINAL_END,
        PATIO,
        PATIO_END
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
		if(zina != null)
			zina.gameObject.SetActive(false);
		if(marian != null)
			marian.gameObject.SetActive(false);

        this.room = room;
        //Events.OnCutscene += OnCutscene;

        if (type == types.PATIO || type == types.INTRO || type == types.BIBLIOTECA || type == types.MAPOTECA)
            Invoke("Delayed", 0.15f);
    }
    public void Avatar_Idle()
    {
        room.roomsManager.character.view.characterAnimations.Idle();
    }
    public void Avatar_Idle_Rosa()
    {
        room.roomsManager.character.view.characterAnimations.IdleRosa();
    }
    public void Avatar_Walk()
    {
        room.roomsManager.character.view.characterAnimations.Idle();
    }
    public void Avatar_Walk_Rosa()
    {
        room.roomsManager.character.view.characterAnimations.WalkRosa();
    }
    public void Avatar_Walk_to_Ladder()
    {
        Events.OnFloorClicked(new Vector3(-5.1f, 0, 2.4f));
    }
    public void Avatar_Ladder()
    {
        room.roomsManager.character.view.characterAnimations.Ladder();
        Vector3 lastCharacterPosition = room.roomsManager.character.view.gameObject.transform.localPosition;
        iTween.MoveTo(room.roomsManager.character.view.gameObject, iTween.Hash("x", lastCharacterPosition.x + 0.32f, "y", lastCharacterPosition.y + 5, "islocal", true, "time", 25, "looptype", "none"));
        Invoke("OnReady", 2);
    }
    public void Marian_Idle()
    {
        marian.Idle();
    }
    public void Marian_Talk()
    {
        marian.Talk();
    }
    public void Marian_Walk()
    {
        marian.Walk();
    }

    public void Zina_Idle()
    {
        zina.Idle();
    }
    public void Zina_IdleRosa()
    {
        zina.IdleRosa();
    }
    public void Zina_Disappear()
    {
        zina.Disappear();
    }

    public void Avatar_Exp_NEUTRO()
    {
        room.roomsManager.character.view.characterAnimations.expressions.SetOn(CharacterExpressions.states.NEUTRO);
    }
    public void Avatar_Exp_CONTENTO()
    {
        room.roomsManager.character.view.characterAnimations.expressions.SetOn(CharacterExpressions.states.CONTENTO);
    }
    public void Avatar_Exp_REFLEXIVO()
    {
        room.roomsManager.character.view.characterAnimations.expressions.SetOn(CharacterExpressions.states.REFLEXIVO);
    }
    public void Avatar_Exp_PREOCUPADO()
    {
        room.roomsManager.character.view.characterAnimations.expressions.SetOn(CharacterExpressions.states.PREOCUPADO);
    }
    public void Avatar_Exp_FASTIDIO()
    {
        room.roomsManager.character.view.characterAnimations.expressions.SetOn(CharacterExpressions.states.FASTIDIO);
    }

    public void Marian_Exp_NEUTRO()
    {
        marian.expressions.SetOn(CharacterExpressions.states.NEUTRO);
    }
    public void Marian_Exp_CONTENTO()
    {
        marian.expressions.SetOn(CharacterExpressions.states.CONTENTO);
    }
    public void Marian_Exp_REFLEXIVO()
    {
        marian.expressions.SetOn(CharacterExpressions.states.REFLEXIVO);
    }
    public void Marian_Exp_PREOCUPADO()
    {
        marian.expressions.SetOn(CharacterExpressions.states.PREOCUPADO);
    }
    public void Marian_Exp_FASTIDIO()
    {
        marian.expressions.SetOn(CharacterExpressions.states.FASTIDIO);
    }

    public void Zina_Exp_NEUTRO()
    {
        zina.expressions.SetOn(CharacterExpressions.states.NEUTRO);
    }
    public void Zina_Exp_CONTENTO()
    {
        zina.expressions.SetOn(CharacterExpressions.states.CONTENTO);
    }
    public void Zina_Exp_REFLEXIVO()
    {
        zina.expressions.SetOn(CharacterExpressions.states.REFLEXIVO);
    }
    public void Zina_Exp_PREOCUPADO()
    {
        zina.expressions.SetOn(CharacterExpressions.states.PREOCUPADO);
    }
    public void Zina_Exp_FASTIDIO()
    {
        zina.expressions.SetOn(CharacterExpressions.states.FASTIDIO);
    }

    void Delayed()
    {

        switch (type)
        {
            case types.INTRO:
                if (Data.Instance.gameProgress.GetData("cutscenes").value < 1)
                {
                    GetComponent<Animation>().Play("intro");
                    Events.OnSaveNewData("cutscenes", 1);
                }
                else
                    return;
                break;
            case types.BIBLIOTECA:
                if (Data.Instance.gameProgress.GetData("cutscenes").value < 2)
                {
                    Events.OnSaveNewData("cutscenes", 2);
                    Events.OnFloorClicked(new Vector3(-8.5f, 0, 2));
                    GetComponent<Animation>().Play("biblioteca");
                }
                else
                    return;
                break;
            case types.PATIO:
                if (Data.Instance.gameProgress.GetData("cutscenes").value == 3)
                {
                    Events.OnSaveNewData("cutscenes", 4);
                    Events.OnFloorClicked(new Vector3(-4, 0, -5.2f));
                    GetComponent<Animation>().Play("patio");
                }
                else
                    return;
                break;
            case types.MAPOTECA:
                if (Data.Instance.gameProgress.GetData("cutscenes").value == 2)
                {
                    room.roomsManager.character.view.ResetPosition();
                    Events.OnSaveNewData("cutscenes", 3);
                    Events.OnFloorClicked(new Vector3(-1.13f, 0, 2.14f));
                    GetComponent<Animation>().Play("mapoteca");
                }
                else if (Data.Instance.gameProgress.GetData("cutscenes").value == 4 && Data.Instance.gameProgress.GetData("g").value>0)
                {
                    room.roomsManager.character.view.ResetPosition();
                    Events.OnSaveNewData("cutscenes", 5);
                    Events.OnFloorClicked(new Vector3(-1.13f, 0, 2.14f));
                    GetComponent<Animation>().Play("mapoteca2");
                    type = types.MAPOTECA2;
                }
                else if (Data.Instance.gameProgress.GetData("cutscenes").value == 5 && Data.Instance.gameProgress.GetData("rosa").value>0)
                {
                    room.roomsManager.character.view.ResetPosition();
                    Events.OnSaveNewData("cutscenes", 6);
                    Events.OnFloorClicked(new Vector3(-1.13f, 0, 2.14f));
                    GetComponent<Animation>().Play("final");
                    type = types.FINAL;
                }
                else
				{
                    return;
				}
                break;
        }
        switch (type)
        {
            case types.INTRO:
                OnCutscene(types.INTRO);
                break;
            case types.BIBLIOTECA:
                OnCutscene(types.BIBLIOTECA);
                break;
            case types.PATIO:
                OnCutscene(types.PATIO);
                break;
            case types.MAPOTECA:
                OnCutscene(types.MAPOTECA);
                break;
            case types.MAPOTECA2:
                OnCutscene(types.MAPOTECA2);
                break;
            case types.FINAL:
                OnCutscene(types.FINAL);
                break;
        }

    }
    void OnReady()
    {
        switch (type)
        {
            case types.INTRO:
                OnCutscene(types.INTRO_END);
                break;
            case types.BIBLIOTECA:
                OnCutscene(types.BIBLIOTECA_END);
                break;
            case types.PUERTA_MAPOTECA:
                Events.ChangeRoom(Room.types.MAPOTECA, new Vector2(-1.142f, 2.16f));
                //OnCutscene (types.BIBLIOTECA_END);
                break;
            case types.MAPOTECA:
                OnCutscene(types.MAPOTECA_END);
                break;
            case types.MAPOTECA2:
                OnCutscene(types.MAPOTECA_END2);
                break;
            case types.FINAL:
                OnCutscene(types.FINAL_END);
                break;
            case types.PATIO:
                OnCutscene(types.PATIO_END);
                break;
        }
    }

    void OnCutscene(types anim)
    {
        this.type = anim;
        switch (anim)
        {
            case types.INTRO:
                room.roomsManager.cutscenesUI.SetOn();
                Events.OnDialogue(Data.Instance.dialoguesData.content.intro, OnReady);
                break;
            case types.INTRO_END:
                GetComponent<Animation>().Play("introEnd");
                room.roomsManager.cutscenesUI.SetOff();
                break;
            case types.BIBLIOTECA:
                room.roomsManager.cutscenesUI.SetOn();
                Events.OnDialogue(Data.Instance.dialoguesData.content.biblioteca, OnReady);
                break;
            case types.BIBLIOTECA_END:
                GetComponent<Animation>().Play("biblioteca_end");
                room.roomsManager.cutscenesUI.SetOff();
                break;
            case types.PATIO:
               room.roomsManager.cutscenesUI.SetOn();
                Events.OnDialogue(Data.Instance.dialoguesData.content.patio, OnReady);
                break;
            case types.PATIO_END:
                GetComponent<Animation>().Play("patio_end");
                room.roomsManager.cutscenesUI.SetOff();
                break;
            case types.PUERTA_MAPOTECA:
                GetComponent<Animation>().Play("puerta_mapoteca");
                room.roomsManager.cutscenesUI.SetOn();
                Events.OnDialogue(Data.Instance.dialoguesData.content.escalera, null);
                break;
            case types.MAPOTECA:
                GetComponent<Animation>().Play("mapoteca");
                room.roomsManager.cutscenesUI.SetOn();
                Events.OnDialogue(Data.Instance.dialoguesData.content.mapoteca, OnReady);
                break;
			case types.MAPOTECA2:
                GetComponent<Animation>().Play("mapoteca2");
                room.roomsManager.cutscenesUI.SetOn();
                Events.OnDialogue(Data.Instance.dialoguesData.content.mapoteca2, OnReady);
                break;
            case types.MAPOTECA_END:
                GetComponent<Animation>().Play("mapoteca_end");
                Events.OnDialogue(Data.Instance.dialoguesData.content.mapoteca, null);
                room.roomsManager.cutscenesUI.SetOff();
                break;
            case types.MAPOTECA_END2:
                GetComponent<Animation>().Play("mapoteca_end2");
                Events.OnDialogue(Data.Instance.dialoguesData.content.mapoteca2, null);
                room.roomsManager.cutscenesUI.SetOff();
                break;
            case types.FINAL:
                GetComponent<Animation>().Play("final");
                Events.OnDialogue(Data.Instance.dialoguesData.content.final, null);
                room.roomsManager.cutscenesUI.SetOff();
                break;
            case types.FINAL_END:
                print("DONE");
                room.roomsManager.cutscenesUI.SetOff();
                break;
        }
    }
}
