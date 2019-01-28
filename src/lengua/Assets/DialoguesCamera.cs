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

	public void SetOn (CharacterAnimations character, CharacterExpressions.states state) {
		Reset ();
		character.gameObject.SetActive (true);
		character.GetComponent<CharacterExpressions> ().SetOn (state);
	}
	void Reset()
	{
		julia.gameObject.SetActive (false);
		marian.gameObject.SetActive (false);
		camera.enabled = false;
	}
}
