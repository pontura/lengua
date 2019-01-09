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
	}
	void OnDestroy () {
		Events.OpenTrivia -= OpenTrivia;
	}
	void OpenTrivia (string gameProgressKey) {
		this.gameProgressKey = gameProgressKey;
		panel.SetActive (true);
		title.text = gameProgressKey;
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
