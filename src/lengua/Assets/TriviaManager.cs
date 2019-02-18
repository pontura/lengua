using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaManager : MonoBehaviour {

	public bool test;
	public Text title;
	public Image background;

	public Text triviaQuest;
	public List<Text> triviaAns;
	public Transform optionsContainer;

	public GameObject correcto,incorrecto;
	public AudioClip correctoSfx,incorrectoSFx,winTrivia;

	AudioSource asource;

	TriviaData.Antologia antologia;
	TriviaData.TriviaProgress tProgress;

	string gameProgressKey;
	TMPro.Examples.TriviaPaginator paginator;

	bool close;

	void Start () {
		paginator = GetComponent<TMPro.Examples.TriviaPaginator> ();
		asource = GetComponent<AudioSource> ();
		Events.SetTrivia += SetTrivia;
		Events.NormativaDone += SetAnswer;
	}
	void OnDestroy () {
		Events.SetTrivia -= SetTrivia;
		Events.NormativaDone -= SetAnswer;
	}

	public void Close(){
		Events.TriviaClose ();
	}

	void SetTrivia (string gameProgressKey) {
		this.gameProgressKey = gameProgressKey;
		tProgress = Data.Instance.triviaData.GetTProgressByGProgress(gameProgressKey);
		if (!tProgress.completed) {
			antologia = Data.Instance.triviaData.GetAntologiaByGProgress (gameProgressKey);		
			Color color = new Color ();
			ColorUtility.TryParseHtmlString (antologia.color, out color);
			background.color = color;
			title.text = antologia.title;
			paginator.SetPages (antologia.texts [tProgress.triviasIndex].textlines, antologia.type, tProgress);
			if (antologia.type == TriviaData.TriviaType.literatura) {
				TriviaData.Trivia t = antologia.trivias [tProgress.triviasIndex];
				triviaQuest.text = t.quest;
				for (int i = 0; i < t.answers.Length; i++)
					triviaAns [i].text = t.answers [i];

				ShuffleChildOrder (optionsContainer);
			}
		}
	}

	void Update(){
		if (test) {
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				Events.OpenTrivia (Data.Instance.triviaData.antologia[0].gameprogress_name);
			}else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				Events.OpenTrivia (Data.Instance.triviaData.antologia[2].gameprogress_name);
			}else if (Input.GetKeyDown (KeyCode.Alpha3)) {
				Debug.Log ("aca");
				Events.OpenTrivia (Data.Instance.triviaData.antologia[4].gameprogress_name);
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

				if (tProgress.type == TriviaData.TriviaType.normativa) {					
					asource.PlayOneShot (winTrivia);
					Events.OnBookComplete ();
					return;
				}
				
				if (tProgress.triviasIndex >= tProgress.triviasDone.Length) {
					tProgress.completed = true;
					tProgress.state = TriviaData.TriviaState.complete;
					asource.PlayOneShot (winTrivia);
					Events.OnBookComplete ();
					return;
				} else {
					asource.PlayOneShot (correctoSfx);
				}			

				correcto.SetActive (true);
			} else {
				asource.PlayOneShot (incorrectoSFx);
				tProgress.lastBadAnswerTime = Time.realtimeSinceStartup;
				tProgress.state = TriviaData.TriviaState.blocked;
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
			SetTrivia (gameProgressKey);
		}
	}
	public void WinForced()
	{
		Events.OnBookComplete ();
	}
}
