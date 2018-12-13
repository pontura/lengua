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
		Events.OnCharacterHitInteractiveObject += OnCharacterHitInteractiveObject;
	}
	void OnDestroy () {
		Events.OnFloorClicked -= OnFloorClicked;
		Events.OnCharacterStopWalking -= OnCharacterStopWalking;
		Events.OnCharacterHitInteractiveObject -= OnCharacterHitInteractiveObject;
	}
	void OnCharacterHitInteractiveObject(InteractiveObject io)
	{
		if (state != states.PLAYING)
			return;
//		
//		Door door = io.GetComponent<Door> ();
//
//		if (door == null || door.state == Door.states.UNAVAILABLE)
//			return;
//		
//		if (door.state == Door.states.CLOSED) {			
//			selectedInteractiveObject = io;
//			Vector3 newPos = io.transform.localPosition;
//			newPos.z -= 1.5f;
//			OnFloorClicked (newPos);
//			state = states.OPENING_FRUIT_NINJA;
//		} else {			
//			selectedInteractiveObject = io;
//			Door d = selectedInteractiveObject as Door;
//			nextScene = d.minigame.ToString ();
//			Vector3 newPos = io.transform.localPosition;
//			newPos.z -= 0.35f;
//			OnFloorClicked (newPos);
//			state = states.ENTERING_DOOR;
//		}
	}
	void OnFloorClicked (Vector3 pos) {
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
	}
	void OnCharacterStopWalking()
	{
		print ("OnCharacterStopWalking");
		view.characterAnimations.Idle ();
	}
}
