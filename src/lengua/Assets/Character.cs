using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public states state;
	public enum states{
		PLAYING
	}
	public GameObject target;

	MoveTo moveTo;
	public CharacterView view;

	InteractiveObject selectedInteractiveObject;

	string nextScene;

	void Start () {
		state = states.PLAYING;
		moveTo = GetComponent<MoveTo> ();

		Events.OnFloorClicked += OnFloorClicked;
		Events.OnCharacterStopWalking += OnCharacterStopWalking;
		Events.OnCharacterWalkToInteractiveObject += OnCharacterWalkToInteractiveObject;
		Events.ForceCharacterPosition += ForceCharacterPosition;
	}
	void OnDestroy () {
		Events.OnFloorClicked -= OnFloorClicked;
		Events.OnCharacterStopWalking -= OnCharacterStopWalking;
		Events.OnCharacterWalkToInteractiveObject -= OnCharacterWalkToInteractiveObject;
		Events.ForceCharacterPosition -= ForceCharacterPosition;
	}
	void ForceCharacterPosition (Vector3 pos)
	{
		target.transform.position = pos;
		transform.position = pos;
	}
	void OnCharacterWalkToInteractiveObject(InteractiveObject io, Vector3 offset)
	{
		if (state != states.PLAYING)
			return;		

		CancelInvoke ();
		Invoke ("TimeoutWalking", 2);
		
		selectedInteractiveObject = io;
		WalkTo (io.transform.localPosition + offset);
	}
	void OnFloorClicked (Vector3 pos) {
		selectedInteractiveObject = null;
		WalkTo (pos);
	}
	void WalkTo(Vector3 pos)
	{
		target.transform.position = pos;
		LookAtTarget (target);
		Vector3 rot = transform.localEulerAngles;
		rot.x = rot.z = 0;
		transform.localEulerAngles = rot;
		moveTo.Init (pos);
		view.characterAnimations.Walk ();
	}
	void LookAtTarget(GameObject lookAtTarget)
	{
		Vector3 pos = lookAtTarget.transform.localPosition;
		pos.y = transform.localPosition.y;
		transform.LookAt (pos);
		view.LookTo (pos);
	}
	void TimeoutWalking()
	{
		CancelInvoke ();
		if(selectedInteractiveObject)
			OnCharacterStopWalking ();
	}
	void OnCharacterStopWalking()
	{
		CancelInvoke ();
		if (selectedInteractiveObject) {			
			moveTo.Reset ();
			LookAtTarget (selectedInteractiveObject.gameObject);
			Events.OnCharacterReachInteractiveObject (selectedInteractiveObject);
		}
		view.characterAnimations.Idle ();
	}
}
