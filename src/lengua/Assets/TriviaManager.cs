using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaManager : MonoBehaviour {

	public bool test;
	int showIndex = 28;
	public Text title;
	public Image backgroundLibro;
	public GameObject libro;
	public Image backgroundCuaderno;
	public GameObject cuaderno;

	public Text triviaQuest;
	public List<Text> triviaAns;
	public Transform optionsContainer;

	public GameObject correcto,incorrecto;
	public AudioClip correctoSfx,incorrectoSfx,winTrivia,openSfx,closeSfx;
    
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
		Events.CorrectoSfx += CorrectoSfx;
		Events.IncorrectoSfx += IncorrectoSfx;
		Events.LogEvent += LogEvent;
	}
	void OnDestroy () {
		Events.SetTrivia -= SetTrivia;
		Events.NormativaDone -= SetAnswer;
		Events.CorrectoSfx -= CorrectoSfx;
		Events.IncorrectoSfx -= IncorrectoSfx;
		Events.LogEvent -= LogEvent;
	}

	public void Close(){
		asource.pitch = 1f;
		asource.PlayOneShot (closeSfx);
		Events.TriviaClose ();
	}

	public void CorrectoSfx(){
		asource.pitch = 1f;
		asource.PlayOneShot (correctoSfx);
	}

	public void IncorrectoSfx(){
		asource.pitch = 1f;
		asource.PlayOneShot (incorrectoSfx);
	}

	void SetTrivia (string gameProgressKey) {
		asource.pitch = 1f;
		asource.PlayOneShot (openSfx);
		this.gameProgressKey = gameProgressKey;
		tProgress = Data.Instance.triviaData.GetTProgressByGProgress(gameProgressKey);
		if (!tProgress.completed) {
			antologia = Data.Instance.triviaData.GetAntologiaByGProgress (gameProgressKey);		
			Color color = new Color ();
			ColorUtility.TryParseHtmlString (antologia.color, out color);
			backgroundLibro.color = color;
			backgroundCuaderno.color = color;
			title.text = antologia.title;
			paginator.SetPages (antologia.texts [tProgress.triviasIndex].textlines, antologia.type, tProgress);
			if (antologia.type == TriviaData.TriviaType.literatura) {
				libro.SetActive (true);
				cuaderno.SetActive (false);
				TriviaData.Trivia t = antologia.trivias [tProgress.triviasIndex];
				triviaQuest.text = t.quest;
				for (int i = 0; i < t.answers.Length; i++)
					triviaAns [i].text = t.answers [i];

				ShuffleChildOrder (optionsContainer);
			} else {
				libro.SetActive (false);
				cuaderno.SetActive (true);
			}
		}
	}

	void Update(){
		if (test) {
			if (Input.GetKeyDown (KeyCode.W)) {
				showIndex++;
				if (showIndex >= Data.Instance.triviaData.antologia.Length)
					showIndex = 0;
			}if (Input.GetKeyDown (KeyCode.Q)) {
				showIndex--;
				if (showIndex < 0)
					showIndex = Data.Instance.triviaData.antologia.Length-1;
			}else if (Input.GetKeyDown (KeyCode.Alpha1)) {
				Events.OpenTrivia (Data.Instance.triviaData.antologia[showIndex].gameprogress_name);
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

	public void SetAnswer(int option){
		string val = option == 0 ? "CORRECTO" : "INCORRECTO";
        long score = option == 0 ? 1 : 0;
        if (tProgress.type == TriviaData.TriviaType.literatura) 
			LogEvent ("TIPO:"+tProgress.type.ToString ()+"&ID_Trivia:"+tProgress.id+"&EjercicioNro:"+tProgress.triviasIndex+"&Opción:"+option+"&"+val, score);
		
			if (option==0) {				
				tProgress.triviasDone [tProgress.triviasIndex] = true;
				tProgress.triviasIndex++;				

				if (tProgress.type == TriviaData.TriviaType.normativa) {
					asource.pitch = 1f;
					asource.PlayOneShot (winTrivia);
					Events.OnBookComplete ();
					return;
				}
				
				if (tProgress.triviasIndex >= tProgress.triviasDone.Length) {
					tProgress.completed = true;
					tProgress.state = TriviaData.TriviaState.complete;
					asource.pitch = 1f;
					asource.PlayOneShot (winTrivia);
					Events.OnBookComplete ();
					return;
				} else {
					asource.pitch = 1f;
					asource.PlayOneShot (correctoSfx);
				}			

				Data.Instance.triviaData.SaveProgress ();
				correcto.SetActive (true);
			} else {
				asource.pitch = 1f;
				asource.PlayOneShot (incorrectoSfx);
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

	public void LogEvent(string respuesta,long value){
        Data.Instance.triviaData.triviaCount++;
        PlayerPrefs.SetInt("triviaCount", Data.Instance.triviaData.triviaCount);
		if (Data.Instance.esAlumno) {
            Firebase.Analytics.Parameter[] scoreParameters = {
                 new Firebase.Analytics.Parameter("Respuesta",respuesta),
                 new Firebase.Analytics.Parameter(Firebase.Analytics.FirebaseAnalytics.ParameterScore,value)
             };

            Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventPostScore, scoreParameters);

        }
	}
}
