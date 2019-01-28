using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguesCamera : MonoBehaviour {

	public Camera camera;
	public CharacterAnimations julia;
	public CharacterAnimations marian;

	void Start () {
		camera.enabled = false;
	}
	public void SetOn (string characterName, string stateName) {

		camera.enabled = true;

		CharacterAnimations character = null;
		if(characterName == "avatar")
			character = julia;
		else
			character = marian;

		CharacterExpressions.states state = CharacterExpressions.states.CONTENTO;
		switch (stateName)
		{
		case "neutro":
				state = CharacterExpressions.states.NEUTRO;
				break;
		case "contento":
			state = CharacterExpressions.states.CONTENTO;
			break;
		case "reflexivo":
			state = CharacterExpressions.states.REFLEXIVO;
			break;
		case "preocupado":
			state = CharacterExpressions.states.PREOCUPADO;
			break;
		case "fastidio":
			state = CharacterExpressions.states.FASTIDIO;
			break;
		}		
		
		SetOnReal (character, state);
	}

	void SetOnReal (CharacterAnimations character, CharacterExpressions.states state) {
		Reset ();
		character.gameObject.SetActive (true);
		character.GetComponent<CharacterExpressions> ().SetOn (state);
	}
	void Reset()
	{
		julia.gameObject.SetActive (false);
		marian.gameObject.SetActive (false);
	}
}
