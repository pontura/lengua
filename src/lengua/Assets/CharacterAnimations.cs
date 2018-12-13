using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour {
	
	public Animator anim;
	public states state;

	public enum states
	{
		IDLE,
		WALK,
		ENTER
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
