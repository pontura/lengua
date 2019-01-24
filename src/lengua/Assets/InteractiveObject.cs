using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour {

	public bool walkToMe = true;
	public Vector3 waltoToMeOffset;
	[HideInInspector]
	public InteractiveObjectsTexts.Content content;
	[HideInInspector]
	public GameProgress gameProgress;
	public string gameProgressKey;
	public int gameProgressValue;

	void Start()
	{
		Events.OnCharacterHitInteractiveObject += OnCharacterHitInteractiveObject;
		Events.OnCharacterReachInteractiveObject += OnCharacterReachInteractiveObject;
		Events.OnRefreshInventary += OnRefreshInventary;
		Events.OnInteractiveTextsLoaded += OnInteractiveTextsLoaded;
		OnInteractiveTextsLoaded ();
	}
	void OnDestroy()
	{
		Events.OnCharacterHitInteractiveObject -= OnCharacterHitInteractiveObject;
		Events.OnCharacterReachInteractiveObject -= OnCharacterReachInteractiveObject;
		Events.OnRefreshInventary -= OnRefreshInventary;
		Events.OnInteractiveTextsLoaded -= OnInteractiveTextsLoaded;
	}
	void OnInteractiveTextsLoaded()
	{
		content = Data.Instance.interactiveObjectsTexts.content;
		if (content == null)
			return;		
		gameProgress = Data.Instance.gameProgress;
		GetProgress (gameProgressKey);
	}
	void OnRefreshInventary()
	{
		GetProgress (gameProgressKey);
	}
	void GetProgress(string itemName)
	{		
		GameProgress.Item item = gameProgress.GetData (itemName);
		if (item == null)
			return;
		if (item.name == gameProgressKey) {
			gameProgressValue = item.value;
			OnSetProgress (item.value);
		}
	}
	void OnCharacterHitInteractiveObject(InteractiveObject io)
	{
		if (io == this) {
			
			if(walkToMe)
				Events.OnCharacterWalkToInteractiveObject (io, waltoToMeOffset);
			
			OnClicked ();
		}
	}
	void OnCharacterReachInteractiveObject(InteractiveObject io)
	{
		print ("OnCharacterReachInteractiveObject " + io);
		if (io == this) {
			GetProgress (gameProgressKey);
			OnCharacterReachMe ();
		}
	}
	public virtual void OnClicked() 
	{ 
		print ("clicked " + gameObject.name);
	}
	public virtual void OnCharacterReachMe() 
	{ 
		print ("OnCharacterReachMe " + gameProgressKey);
		if (gameProgressKey != "") {
			Events.OnTip(content.GetValue(gameProgressKey));
		}
	}
	public virtual void OnSetProgress(int value) {	}
	public void SetCollider(bool isOn)
	{
		GetComponentInChildren<Collider> ().enabled = isOn;
	}
}
