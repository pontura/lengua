using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
	
	public types type;

	public enum types
	{
		ESCRITORIO,
		BIBLIOTECA
	}
	public Vector2 limitsX;
	public Vector2 limitsZ;

	void OnEnable()
	{
		Invoke ("Delayed", 0.1f);
	}
	void Delayed()
	{
		Events.OnEnterNewRoom (this);
	}

}
