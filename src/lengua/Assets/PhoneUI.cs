using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneUI : MonoBehaviour {

	public GameObject panel;

	void Start () {
		Reset ();
		Events.OpenTrivia += OpenTrivia;
	}
	void OnDestroy () {
		Events.OpenTrivia -= OpenTrivia;
	}
	void OpenTrivia (string gameProgressKey) {
		
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
	}
}
