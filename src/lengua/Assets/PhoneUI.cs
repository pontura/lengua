using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneUI : MonoBehaviour {

	public GameObject panel;
	public GameObject panel_UI;
	public Transform container;
	public ScrollRect scrollRect;
	public PhoneLine phoneLine_to_instantiate;
	List<PhoneConversationsData.Data> dataContent;
	System.Action OnReady;

	void Start () {
		Events.PhoneConversation += PhoneConversation;
		Reset ();
	}
	public void Close()
	{
		Reset ();
	}
	public void Win()
	{
		Reset ();
	}
	void Reset()
	{
		panel.SetActive (false);
		panel_UI.SetActive (false);
	}
	int id;
	void PhoneConversation(List<PhoneConversationsData.Data> _content, System.Action OnReady)
	{
		this.OnReady = OnReady;
		panel_UI.SetActive (true);
		this.dataContent = _content;
		id = 0;
		Next ();

	}
	public void Next()
	{
		if (id >= dataContent.Count) {
			OnReady ();
			Reset ();
			return;
		}
		AddLine (dataContent [id]);
		id++;
		StartCoroutine (ForceScrollDown () );
	}
	void AddLine(PhoneConversationsData.Data data)
	{
		PhoneLine line = Instantiate (phoneLine_to_instantiate);
		line.transform.SetParent (container);
		line.transform.localScale = Vector3.one;
		line.AddLine (data);
	}
	IEnumerator ForceScrollDown () {
		// Wait for end of frame AND force update all canvases before setting to bottom.
		yield return new WaitForEndOfFrame ();
		Canvas.ForceUpdateCanvases ();
		scrollRect.verticalNormalizedPosition = 0f;
		Canvas.ForceUpdateCanvases ();
	}
}
