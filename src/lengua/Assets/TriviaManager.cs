using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaManager : MonoBehaviour {

	public bool test;
	public Text title;

	TriviaData.Antologia antologia;
	TriviaData.TriviaProgress tProgress;

	string gameProgressKey;
	TriviaPaginator paginator;

	void Start () {
		paginator = GetComponent<TriviaPaginator> ();
		Events.OpenTrivia += OpenTrivia;
	}
	void OnDestroy () {
		Events.OpenTrivia -= OpenTrivia;
	}
	void OpenTrivia (string gameProgressKey) {
		this.gameProgressKey = gameProgressKey;
		antologia = Data.Instance.triviaData.GetAntologiaByGProgress (gameProgressKey);
		tProgress = Data.Instance.triviaData.GetTProgressByGProgress(gameProgressKey);
		title.text = antologia.title;
		paginator.SetPages (antologia.texts [tProgress.triviasIndex].textlines);
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
