using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	public Vector3 fruitNinja_Offset;
	public GameObject target;
	public states state;
	public enum states
	{
		FOLLOWING_CHARACTER,
		FRUIT_NINJA
	}

	void Start () {
		state = states.FOLLOWING_CHARACTER;
	}
	void OnDestroy()
	{
	}
	void Update () {
		FollowingUpdate ();
	}
	void CloseFruitNinja(bool win)
	{
		state = states.FOLLOWING_CHARACTER;
	}
	void FollowingUpdate()
	{
		Vector3 pos = target.transform.localPosition;
		transform.localPosition = Vector3.Lerp(transform.localPosition, pos, 0.1f);
	}
}
