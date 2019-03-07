using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenesUI : MonoBehaviour {

	public GameObject panel;
	Animation anim;

	void Start () {
		Reset ();
		anim = panel.GetComponent<Animation> ();
	}

	public void SetOn() {
		Events.CutsceneMusic (true);
		panel.SetActive (true);
	}
	public void SetOff() {
		Events.CutsceneMusic (false);
		anim.Play ("cutscenesOff");
		Invoke ("Reset", 2);
	}
	void Reset()
	{
		panel.SetActive (false);
	}
}
