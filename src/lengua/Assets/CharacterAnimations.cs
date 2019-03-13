using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour {
	
	public Animator anim;
	public states state;
	public CharacterExpressions expressions;

	void Awake()
	{
		expressions = GetComponent<CharacterExpressions> ();
	}
	public enum states
	{
		IDLE,
		WALK,
		ENTER,
		LADDER
	}
	void Update()
	{
		if(state == states.IDLE)
		{
			PlayAnim ("idle");
		}
	}
	public void Idle () {
		PlayAnim ("idle");
		state = states.IDLE;
	}
	public void IdleRosa () {
		PlayAnim ("idle_rose");
		state = states.ENTER;
	}
	
	public void Talk () {
		PlayAnim ("talk");
		state = states.IDLE;
	}
	public void Walk () {
		PlayAnim ("walk");
		state = states.WALK;
	}
	public void WalkRosa () {
		PlayAnim ("walk_rose");
		state = states.WALK;
	}
	public void Ladder () {
		PlayAnim ("ladder");
		state = states.LADDER;
	}
	public void Disappear () {
		PlayAnim ("disappear");
		state = states.ENTER;
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
