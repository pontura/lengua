using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public states state;
	public enum states{
		PLAYING,
		OPENING_FRUIT_NINJA,
		ENTERING_DOOR
	}
	public GameObject target;

	MoveTo moveTo;
	public CharacterAnimations anim;

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
	IEnumerator EnterMinigame()
	{
		anim.Enter ();
		yield return new WaitForSeconds (1.25f);
		Data.Instance.LoadScene (nextScene);
	}
	void OnFloorClicked (Vector3 pos) {
		
		if (state == states.ENTERING_DOOR)
			return;
		else if (state == states.OPENING_FRUIT_NINJA)
			state = states.PLAYING;
		
		target.transform.position = pos;
		LookAtTarget (target);
		Vector3 rot = transform.localEulerAngles;
		rot.x = rot.z = 0;
		transform.localEulerAngles = rot;
		moveTo.Init (pos);
		anim.Walk ();
	}
	void LookAtTarget(GameObject lookAtTarget)
	{
		Vector3 pos = lookAtTarget.transform.localPosition;
		pos.y = transform.localPosition.y;
		transform.LookAt (pos);
	}
	void OnCharacterStopWalking()
	{
		if (selectedInteractiveObject != null) {
			if (state == states.OPENING_FRUIT_NINJA) {
				LookAtTarget (selectedInteractiveObject.transform.gameObject);
			}
		}

		selectedInteractiveObject = null;
		if (state == states.ENTERING_DOOR) {
			StartCoroutine (EnterMinigame ());
			return;
		}		

		anim.Idle ();
	}
}
