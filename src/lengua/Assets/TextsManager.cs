using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextsManager : MonoBehaviour {

	public GameObject panel;
	public Text field;
	int id = 0;
	int total;
	string[] all;
	System.Action OnReady;
		
	void Start () {
		Events.OnTexts += OnTexts;
		Reset ();
	}
	void OnDestroy () {
		Events.OnTexts -= OnTexts;
	}
	void OnTexts(string fullString, System.Action OnReady)
	{		
		this.OnReady = OnReady;
		this.all = fullString.Split ("/" [0]);
		total = all.Length;
		id = 0;
		panel.SetActive (true);
		Next ();
	}
	public void Next()
	{
		if (id >= total) {
			Reset ();
			if (OnReady != null)
				OnReady ();
		}
		else {
			field.text = all [id];
			id++;
		}
	}
	void Reset()
	{
		field.text = "";
		panel.SetActive (false);
	}
}
