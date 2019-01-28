using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogues : MonoBehaviour {

	public GameObject panel;
	public Text field;
	int id = 0;
	List<DialoguesData.Dialogue> dialogue;
	System.Action OnReady;
	public DialoguesCamera dialoguesCamera;

	void Start () {
		Events.OnDialogue += OnDialogue;
		Reset ();
	
	}
	void OnDestroy () {
		Events.OnDialogue -= OnDialogue;
	}

	void OnDialogue(List<DialoguesData.Dialogue> _dialogue, System.Action OnReady)
	{		
		this.OnReady = OnReady;
		this.dialogue = _dialogue;
		id = 0;
		panel.SetActive (true);
		Next ();
	}
	public void Next()
	{
		if (id >= dialogue.Count) {
			Reset ();
			if (OnReady != null) 
				OnReady ();
			Reset ();
		}
		else {
			field.text = dialogue [id].text;
			print(id + " " + dialogue [id].character + " " +  dialogue [id].state);
			dialoguesCamera.SetOn (dialogue [id].character, dialogue [id].state);
			id++;
		}
	}
	void Reset()
	{
		field.text = "";
		panel.SetActive (false);
	}
}
