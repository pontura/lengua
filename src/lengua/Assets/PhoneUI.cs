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
	List<PhoneConversationsData.Data> lastConversation;
	public Image avatar;
	public Text avatarName;
	GameProgress gameProgress;

	public AudioClip ringSFX;
	public AudioClip messageSFX;
	AudioSource asource;

	void Start () {
		gameProgress = Data.Instance.gameProgress;
		asource = GetComponent<AudioSource> ();
		Events.OnCuadernoWin += OnCuadernoWin;
		Reset ();
		if (gameProgress.GetData ("celular").value == 0)
			panel.SetActive (false);
	}
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			dataContent = Data.Instance.phoneConversationsData.content.joaco_biblioteca;
			RingPhone ();
			Events.OnSaveNewData ("celular", 1);
		}

	}
	void OnCuadernoWin()
	{
		
		if (gameProgress.GetData ("celular").value == 0) {
			if (
				gameProgress.GetData ("cuaderno_ingreso").value == 2 &&
				(
					gameProgress.GetData ("cuadernoBiblioteca1").value == 2 ||
					gameProgress.GetData ("cuadernoBiblioteca2").value == 2 ||
					gameProgress.GetData ("cuadernoBiblioteca3").value == 2
				)
			) {
				dataContent = Data.Instance.phoneConversationsData.content.joaco_biblioteca;
				RingPhone ();
				Events.OnSaveNewData ("celular", 1);
			}
		} else if (gameProgress.GetData ("celular").value == 1) {
			if (
				gameProgress.GetData ("cuaderno_ingreso").value == 2 &&
				gameProgress.GetData ("cuadernoBiblioteca1").value == 2 &&
				gameProgress.GetData ("cuadernoBiblioteca2").value == 2 &&
				gameProgress.GetData ("cuadernoBiblioteca3").value == 2
			) {
				dataContent = Data.Instance.phoneConversationsData.content.marian_1;
				RingPhone ();
				Events.OnSaveNewData ("celular", 2);
			}
		} else if (gameProgress.GetData ("celular").value == 2) {
			if (
				gameProgress.GetData ("cuadernoPatio1").value == 2
			) {
				dataContent = Data.Instance.phoneConversationsData.content.patio1;
				RingPhone ();
				Events.OnSaveNewData ("celular", 3);
			}
		} else if (gameProgress.GetData ("celular").value == 3) {
			if (
				gameProgress.GetData ("cuadernoPatio2").value == 2
			) {
				dataContent = Data.Instance.phoneConversationsData.content.patio2;
				RingPhone ();
				Events.OnSaveNewData ("celular", 4);
			}
		} else if (gameProgress.GetData ("celular").value == 4) {
			if (
				gameProgress.GetData ("cuadernoPatio3").value == 2
			) {
				dataContent = Data.Instance.phoneConversationsData.content.patio3;
				RingPhone ();
				Events.OnSaveNewData ("celular", 5);
			}
		}
	}
	void RingPhone()
	{
		asource.spatialBlend = 0.4f;
		asource.loop = true;
		asource.clip = ringSFX;
		asource.Play ();
		panel.SetActive (true);
		panel.GetComponent<Animation> ().Play ("phoneRing");
	}
	public void OnClicked()
	{
		asource.Stop ();
		asource.spatialBlend = 0f;
		asource.loop = false;

		PhoneConversation ();
		panel.GetComponent<Animation> ().Stop ();
		panel.transform.localEulerAngles = Vector3.zero;
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
		panel_UI.SetActive (false);
	}
	int id;
	bool NextWillClose;
	void PhoneConversation()
	{
		panel_UI.SetActive (true);
		if (lastConversation == dataContent) {
			NextWillClose = true;
			return;
		}
		Utils.RemoveAllChildsIn (container);
		NextWillClose = false;
		lastConversation = dataContent;

		id = 0;
		Next ();
		string avatarNameText = dataContent [0].character;
		avatar.sprite = Resources.Load<Sprite> ("profile/" + avatarNameText) as Sprite;
		avatarName.text = avatarNameText;
	}
	public void Next()
	{
		if(NextWillClose || id >= dataContent.Count) {
			Reset ();
			return;
		}
		AddLine (dataContent [id]);
		id++;
		StartCoroutine (ForceScrollDown () );
	}
	void AddLine(PhoneConversationsData.Data data)
	{
		asource.clip = messageSFX;
		asource.spatialBlend = 0.6f;
		asource.Play ();
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
