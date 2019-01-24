using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaManager : MonoBehaviour {

	public bool test;
	public Text title;


	TriviaData.Antologia antologia;

	string gameProgressKey;

	void Start () {
		Events.OpenTrivia += OpenTrivia;
	}
	void OnDestroy () {
		Events.OpenTrivia -= OpenTrivia;
	}
	void OpenTrivia (string gameProgressKey) {
		this.gameProgressKey = gameProgressKey;
		antologia = Data.Instance.triviaData.GetAntologiaByGProgress (gameProgressKey);
		title.text = antologia.title;
	}

	void Update(){
		if (test) {
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				Debug.Log ("aca");
				Events.OpenTrivia (Data.Instance.triviaData.antologia[0].gameprogress_name);
			}
		}
	}
}
