using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour {
	
	public GameObject target;
	float _x;
	Vector3 lastPos ;

	void Start()
	{
		Events.OnFloorClicked += OnFloorClicked;
	}

	void OnFloorClicked(Vector3 pos)
	{
		if (pos.x < transform.localPosition.x)
			transform.localScale = new Vector3 (-1, 1, 1);
		else
			transform.localScale = new Vector3 (1, 1, 1);
	}

	void Update () {
		Vector3 newPos = target.transform.localPosition;
		if (lastPos == newPos)
			return;
		lastPos = newPos;
		transform.localPosition = newPos;
	}
}
