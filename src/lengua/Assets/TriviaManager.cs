﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaManager : MonoBehaviour {

	public bool test;
	public Text title;

	public Text triviaQuest;
	public List<Text> triviaAns;
	public Transform optionsContainer;

	public GameObject correcto,incorrecto;

	TriviaData.Antologia antologia;
	TriviaData.TriviaProgress tProgress;

	string gameProgressKey;
	TriviaPaginator paginator;

	bool close;

	void Start () {
		paginator = GetComponent<TriviaPaginator> ();
		Events.OpenTrivia += OpenTrivia;
	}
	void OnDestroy () {
		Events.OpenTrivia -= OpenTrivia;
	}
	void OpenTrivia (string gameProgressKey) {
		this.gameProgressKey = gameProgressKey;
		tProgress = Data.Instance.triviaData.GetTProgressByGProgress(gameProgressKey);
		if (!tProgress.completed) {
			antologia = Data.Instance.triviaData.GetAntologiaByGProgress (gameProgressKey);		
			title.text = antologia.title;
			paginator.SetPages (antologia.texts [tProgress.triviasIndex].textlines);
			TriviaData.Trivia t = antologia.trivias [tProgress.triviasIndex];
			triviaQuest.text = t.quest;
			for (int i = 0; i < t.answers.Length; i++)
				triviaAns [i].text = t.answers [i];

			ShuffleChildOrder (optionsContainer);
		}
	}

	void Update(){
		if (test) {
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				Debug.Log ("aca");
				Events.OpenTrivia (Data.Instance.triviaData.antologia[0].gameprogress_name);
			}
		}
	}

	void ShuffleChildOrder(Transform container){
		for (int i = 0; i < container.childCount; i++) {
			Transform t = container.GetChild (i);
			if (Random.value < 0.3f)
				t.transform.SetAsFirstSibling ();
			else if (Random.value < 0.6)
				t.transform.SetAsLastSibling ();
		}
	}

	public void SetAnswer(bool correct){
		if (correct) {			
			tProgress.triviasDone [tProgress.triviasIndex] = true;
			tProgress.triviasIndex++;
			if (tProgress.triviasIndex >= tProgress.triviasDone.Length) {
				tProgress.completed = true;
				Events.OnBookComplete ();
				return;
			}
			correcto.SetActive (true);
		} else {
			incorrecto.SetActive (true);
			close = true;
		}
		Invoke ("HideSigns", 3);
	}

	void HideSigns(){		
		correcto.SetActive (false);
		incorrecto.SetActive (false);
		if (close) {
			close = false;
			Events.OnTriviaWrong ();
		} else {
			OpenTrivia (gameProgressKey);
		}
	}
}
