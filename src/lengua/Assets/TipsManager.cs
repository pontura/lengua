using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsManager : MonoBehaviour {

	public GameObject panel;
	public Text field;

	void Start () {
		Events.OnTip += OnTip;
		Events.OnTexts += OnTexts;
		Reset ();
	}
	void OnDestroy () {
		Events.OnTip -= OnTip;
		Events.OnTexts -= OnTexts;
	}
	void OnTexts(string value, System.Action readComplete)
	{
		Reset ();
	}
	void OnTip(string value)
	{
		panel.SetActive (true);
		field.text = value;
		float timeOut = 2 + (value.Length / 50);
		Invoke ("Reset", timeOut);
	}
	void Reset()
	{
		field.text = "";
		panel.SetActive (false);
	}
}
