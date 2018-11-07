using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour {
	
	public GameObject target;
	float _x;
	Vector3 lastPos ;

	void Update () {
		Vector3 newPos = target.transform.localPosition;
		if (lastPos == newPos)
			return;

		if (newPos.x < lastPos.x)
			transform.localScale = new Vector3 (-1, 1, 1);
		else
			transform.localScale = new Vector3 (1, 1, 1);
		lastPos = newPos;
		transform.localPosition = newPos;
	}
}
