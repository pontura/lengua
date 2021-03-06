﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

	public RoomsManager roomsManager;
	public float cameraSize = 1.61f;
	public types type;

	public enum types
	{
		ESCRITORIO,
		BIBLIOTECA,
		MAPOTECA,
		PATIO,
		LAB,
		ALTILLO
	}
	public Vector2 limitsX;
	public Vector2 limitsZ;

	public void Init(RoomsManager roomsManager)
	{
		GetComponent<Cutscenes> ().Init (this);
		this.roomsManager = roomsManager;
		Invoke ("Delayed", 0.1f);
	}
	void Delayed()
	{
		Events.OnEnterNewRoom (this);
	}

}
