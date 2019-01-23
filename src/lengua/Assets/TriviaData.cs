using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class TriviaData : MonoBehaviour {

	public string filename="Antologia.json";

	public Antologia[] antologia;

	[Serializable]
	public class Antologia
	{
		public int id;
		public string title;
		public string author;
		public Text[] texts;
		public Trivia[] trivias;
	}

	[Serializable]
	public class Text{
		public string[] textlines;
	}

	[Serializable]
	public class Trivia{
		public string quest;
		public string[] answers;
	}

	void Start () {

		/*string filePath = "";
		#if UNITY_EDITOR
			filePath = Path.Combine (Application.streamingAssetsPath + "/", filename);
		#elif UNITY_ANDROID
			filePath = "jar:file://" + Application.dataPath + "!/assets/" + filename;
			Debug.Log ("ANDROID");
		#endif*/
		string filePath = Path.Combine (Application.streamingAssetsPath + "/", filename);
		StartCoroutine(LoadFile(filePath));

		/*Debug.Log (filePath);
		if (File.Exists (filePath)) {			
			Debug.Log ("exists");
			string dataAsJson = Utils.CSV2JSON (File.ReadAllText (filePath), '#');
			Debug.Log (dataAsJson);
			texts = JsonHelper.FromJson<ExternalText> (dataAsJson);
		} else {
			Debug.Log ("no exists");
		}*/
	}

	IEnumerator LoadFile(string filePath) {
		string text = "";
		if (filePath.Contains("://")) {
			using (WWW www = new WWW(filePath))
			{
				yield return www;
				text = www.text;
			}
		} else
			text = System.IO.File.ReadAllText(filePath);

		//string dataAsJson = Utils.CSV2JSON (text, '#');
		Debug.Log (text);
		//texts = JsonHelper.FromJson<ExternalText> (dataAsJson);
		antologia = JsonHelper.FromJson<Antologia> (text);

		Debug.Log (antologia);
	}

	// Update is called once per frame
	void Update () {

	}
}
