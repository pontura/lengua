using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterExpressions : MonoBehaviour {
	
	[Serializable]
	public class Type
	{
		public states state;
		public SpriteRenderer spriteRenderer;
	}
	[Serializable]
	public enum states
	{
		NEUTRO,
		CONTENTO,
		REFLEXIVO,
		PREOCUPADO,
		FASTIDIO
	}
	public Type[] all;
	public void SetOn(states state)
	{
		Reset ();
		foreach (Type t in all) {
			if (t.state == state) {
				t.spriteRenderer.enabled = true;
			}
		}
	}
	void Reset()
	{
		foreach (Type t in all)
			t.spriteRenderer.enabled = false;
	}
}
