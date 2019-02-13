using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterInputManager : MonoBehaviour {

	public Camera cam;
	float lastTimeClicked;
	float delay = 0.1f;
	void Update()
	{		
		if (IsPointerOverUIObject() || EventSystem.current.IsPointerOverGameObject())
		{
			
		} else{

			if (Input.GetMouseButton (0)) {
				if (lastTimeClicked != 0 && lastTimeClicked > Time.time)
					return;

				lastTimeClicked = Time.time + delay;

				Vector3 mousePos = Input.mousePosition;
				Ray mouseRay = cam.ScreenPointToRay (mousePos);

				RaycastHit[] hits = Physics.RaycastAll (mouseRay);

				for (int i = 0; i < hits.Length; i++) {
					RaycastHit hit = hits [i];
					InteractiveObject io = hit.transform.gameObject.GetComponentInParent<InteractiveObject> ();
					if (io != null) {
						Events.OnCharacterHitInteractiveObject (io);
						return;
					} else if (hit.transform.gameObject.name == "floor") {
						Ray testRay = new Ray (hit.point, Vector3.up);
						Events.OnFloorClicked (hit.point);
					}
				}
			}
		}
	}
	private bool IsPointerOverUIObject() {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}
}
