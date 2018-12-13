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
		
	void Start () {
		Events.OnTexts += OnTexts;
		Reset ();
	}
	void OnDestroy () {
		Events.OnTexts -= OnTexts;
	}
	void OnTexts(string fullString)
	{		
		this.all = fullString.Split ("/" [0]);
		total = all.Length;
		id = 0;
		panel.SetActive (true);
		Next ();
	}
	public void Next()
	{
		if (id >= total)
			Reset ();
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
