using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenes : MonoBehaviour {

	public Data[] all;
	public class Data
	{
		public types type;
		public Animation anim;
	}

	public enum types
	{
		INTRO
	}
	public Animation intro;

	void Start()
	{
	}
	public void Play(Animation anim)
	{
		anim.Play ();
	}
}
