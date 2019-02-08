using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trivia : MonoBehaviour {

	public GameObject panel;
	public Text title;
	string gameProgressKey;

	void Start () {
		Reset ();
		Events.OpenTrivia += OpenTrivia;
		Events.OnBookComplete += Win;
		Events.OnTriviaWrong += Close;
	}
	void OnDestroy () {
		Events.OpenTrivia -= OpenTrivia;
		Events.OnBookComplete -= Win;
		Events.OnTriviaWrong -= Close;
	}
	void OpenTrivia (string gameProgressKey) {
		this.gameProgressKey = gameProgressKey;
		TriviaData.TriviaState ts = Data.Instance.triviaData.GetStateByGProgress(gameProgressKey);
		Debug.Log ("gameProgressKey: " + gameProgressKey + " state: " + ts);
		if (ts == TriviaData.TriviaState.idle || ts == TriviaData.TriviaState.done) {
			Events.SetTrivia (gameProgressKey);
			panel.SetActive (true);
			//title.text = gameProgressKey;
		} else if (ts == TriviaData.TriviaState.blocked) {
			Events.OnTip (Data.Instance.interactiveObjectsTexts.content.libroBloqueado);
			Debug.Log ("La trivia está bloqueada, tiene que esperar un minuto");
		} else if (ts == TriviaData.TriviaState.complete) {
			Events.OnTip (Data.Instance.interactiveObjectsTexts.content.libroCompletado);
			Debug.Log ("La trivia ya está completa");
		}
	}
	public void Close()
	{
		Reset ();
	}
	public void Win()
	{
		Reset ();
		switch(gameProgressKey)
		{
		case "libroIngreso":
			if (Data.Instance.gameProgress.GetData ("fichero_llave").value == 0) 
				Events.OnSaveNewData ("fichero_llave", 1);
			break;
		case "cuaderno_ingreso":
			if (Data.Instance.gameProgress.GetData ("destornillador").value == 0) {
				if(Data.Instance.gameProgress.GetData("destornillador").value==0)
					Events.OnSaveNewData ("destornillador", 1);
			}
			break;
		case "libroCuadro":
			if (Data.Instance.gameProgress.GetData ("destornillador").value == 0) {
				if(Data.Instance.gameProgress.GetData("destornillador").value==0)
					Events.OnSaveNewData ("destornillador", 1);
			}
			break;
		}
	}
	void Reset()
	{
		panel.SetActive (false);
	}
}
