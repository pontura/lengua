using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour {
	
	[HideInInspector]
	public CharacterAnimations characterAnimations;

	public CharacterAnimations characterAnim_to_instantiate;
	public Transform container;
	public GameObject target;
	float _x;
	Vector3 lastPos ;

	void Start()
	{
		characterAnimations = Instantiate (characterAnim_to_instantiate);
		characterAnimations.transform.SetParent (container);
		characterAnimations.transform.localEulerAngles = Vector3.zero;
		characterAnimations.transform.localPosition = Vector3.zero;
		characterAnimations.Idle ();
	}

	public void LookTo(Vector3 pos)
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
