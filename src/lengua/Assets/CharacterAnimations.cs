using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour {
	
	public GameObject characterAnim_to_instantiate;
	Animator anim;
	public states state;
	public Transform container;

	public enum states
	{
		IDLE,
		WALK,
		ENTER
	}
	void Start()
	{
		GameObject go = Instantiate (characterAnim_to_instantiate);
		go.transform.SetParent (container);
		go.transform.localEulerAngles = Vector3.zero;
		go.transform.localPosition = Vector3.zero;
		anim = go.GetComponent<Animator> ();
		Idle ();
	}
	public void Idle () {
		PlayAnim ("idle");
		state = states.IDLE;
	}
	public void Walk () {
		PlayAnim ("walk");
		state = states.WALK;
	}
	public void Use () {
		PlayAnim ("use");
	}
	public void Enter () {
		state = states.ENTER;
	}
	public void PlayAnim (string name) {
		anim.Play (name);
	}


}
