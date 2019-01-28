using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class TriviaData : MonoBehaviour {

	public string filename="Antologia.json";

	public List<TriviaProgress> triviaProgress;
	public Antologia[] antologia;

	[Serializable]
	public class Antologia
	{
		public string id;
		public string gameprogress_name;
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

	[Serializable]
	public class TriviaProgress
	{
		public string id;
		public string gameprogress_name;
		public int triviasIndex;
		public bool[] triviasDone;
		public bool completed;
		public float lastBadAnswerTime;
	}

	void Start () {
		if (!Data.Instance.reloadJson)
			return;
		/*string filePath = "";
		#if UNITY_EDITOR
			filePath = Path.Combine (Application.streamingAssetsPath + "/", filename);
		#elif UNITY_ANDROID
			filePath = "jar:file://" + Application.dataPath + "!/assets/" + filename;
			Debug.Log ("ANDROID");
		#endif*/
		string filePath = Path.Combine (Application.streamingAssetsPath + "/", filename);
		StartCoroutine(LoadFile(filePath));
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

		Debug.Log (text);
		antologia = JsonHelper.FromJson<Antologia> (text);

		for (int i = 0; i < antologia.Length; i++) {
			TriviaProgress tp = new TriviaProgress ();
			tp.id = antologia [i].id;
			tp.gameprogress_name = antologia [i].gameprogress_name;
			tp.triviasDone = new bool[antologia [i].trivias.Length];
			triviaProgress.Add (tp);
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public Antologia GetAntologiaByGProgress(string gameprogress_name){
		Antologia a = Array.Find (antologia, x => x.gameprogress_name == gameprogress_name);
		return a;
	}

	public TriviaProgress GetTProgressByGProgress(string gameprogress_name){
		TriviaProgress a = triviaProgress.Find(x => x.gameprogress_name == gameprogress_name);
		return a;
	}
}