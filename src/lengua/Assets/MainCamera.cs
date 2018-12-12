﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	public Vector2 limitsX;
	public Vector2 limitsZ;

	public GameObject target;

	public states state;
	public enum states
	{
		ON
	}

	void Start () {
		state = states.ON;
	}
	void Update () {
		FollowingUpdate ();
	}
	void FollowingUpdate()
	{
		Vector3 pos = target.transform.localPosition;

		if (pos.x < limitsX.x)
			pos.x = limitsX.x;
		else if (pos.x > limitsX.y)
			pos.x = limitsX.y;

		if (pos.z > limitsZ.x)
			pos.z = limitsZ.x;
		else if (pos.z < limitsZ.y)
			pos.z = limitsZ.y;
		
		transform.localPosition = Vector3.Lerp(transform.localPosition, pos, 0.1f);
	}
}
