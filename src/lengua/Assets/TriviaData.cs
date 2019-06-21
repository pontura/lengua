using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class TriviaData : MonoBehaviour {

	public string filename="Antologia.json";

	public List<TriviaProgress> triviaProgress;
	public Antologia[] antologia;
	public float blockedTime;
	public float resetTime;
	public float normativaMinimum = 0.7f;
    public int triviaCount;

    char propSep = '&';
	char elementSep = '#';
	char doneSep = '@';

	public enum TriviaType{
		literatura,
		normativa
	}

	[Serializable]
	public class Antologia
	{
		public string id;
		public string gameprogress_name;
		public string title;
		public string author;
		public string color;
		public TriviaType type;
		public int area;
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
		public TriviaType type;
		public int area;
		public int triviasIndex;
		public bool[] triviasDone;
		public bool completed;
		public float lastBadAnswerTime;
		public TriviaState state;

		public void Reset(){
			for (int i = 0; i < triviasDone.Length; i++)
				triviasDone [i] = false;
			triviasIndex = 0;
			state = TriviaState.idle;
		}

		public void AddNormativaDone(int index){
			if (type == TriviaType.normativa) {
				triviasDone [index] = true;
			}

			int dones = 0;
			for(int i=0;i<triviasDone.Length;i++){
				if (triviasDone [i])
					dones++;
			}
			if (dones == triviasDone.Length) {
				completed = true;
				state = TriviaState.complete;
				Events.NormativaDone (0);
			} else if (1f * dones / triviasDone.Length >= Data.Instance.triviaData.normativaMinimum) {
				state = TriviaState.done;
			}
		}
	}

	public enum TriviaState{
		idle,
		blocked,
		done,
		complete
	}

	void Start () {
        /*if (!Data.Instance.reloadJson)
			return;*/

        triviaCount = PlayerPrefs.GetInt("triviaCount");

		string filePath = Path.Combine (Application.streamingAssetsPath + "/", filename);
		StartCoroutine(LoadFile(filePath));
	}

	public void SaveProgress(){
		string data = "";
		for(int j=0;j<triviaProgress.Count;j++){
			TriviaProgress tp = triviaProgress [j];
			data += tp.id + propSep +
			tp.gameprogress_name + propSep +
			tp.type + propSep +
			tp.area + propSep +
			tp.triviasIndex + propSep;
			for (int i = 0; i < tp.triviasDone.Length; i++) {
				data += tp.triviasDone[i];
				if (i < tp.triviasDone.Length - 1)
					data += doneSep;
			}
			data += propSep + "";
			data += "" + tp.completed + propSep +
				tp.state;

			if (j < triviaProgress.Count - 1)
				data += "" + elementSep;
			
		}		
		PlayerPrefs.SetString ("TriviaProgress", data);
	}

	bool LoadProgress(){
		string d = PlayerPrefs.GetString ("TriviaProgress");

		//Debug.Log (d);

		if (d == "")
			return false;
		else {
			string[] data = d.Split (elementSep);
			foreach (string s in data) {
				//Debug.Log (s);
				TriviaProgress tp = new TriviaProgress ();
				string[] ss = s.Split (propSep);
				//Debug.Log (ss[0]);
				tp.id = ss[0];
				tp.gameprogress_name = ss[1];
				tp.type = (TriviaType)System.Enum.Parse (typeof(TriviaType), ss [2]);
				tp.area = int.Parse(ss[3]);

				string[] done = ss [5].Split (doneSep);
				tp.triviasDone = new bool[done.Length];
				if (tp.type == TriviaType.normativa) {
					tp.triviasIndex = int.Parse(ss[4]);
					for (int i = 0; i < done.Length; i++) {
						tp.triviasDone [i] = bool.Parse (done [i]);
						int j = int.Parse (tp.id);
						antologia [j].texts [0].textlines [i] = "{" + i + "}" + antologia [j].texts [0].textlines [i];
					}

				}
				tp.completed = bool.Parse(ss [6]);
				tp.state = (TriviaState)System.Enum.Parse (typeof(TriviaState), ss [7]);

				triviaProgress.Add (tp);

			}
			return true;
		}

	}

	IEnumerator LoadFile(string filePath) {
		string text = "";
		if (filePath.Contains("://")) {
			using (WWW www = new WWW(filePath))
			{
				yield return www;

				if (string.IsNullOrEmpty (www.error)) {
					text = System.Text.Encoding.UTF8.GetString (www.bytes, 3, www.bytes.Length - 3);  // Skip thr first 3 bytes (i.e. the UTF8 BOM)
				} else {
					text = www.text;
				}
			}
		} else
			text = System.IO.File.ReadAllText(filePath);

		Debug.Log (text);
		antologia = JsonHelper.FromJson<Antologia> (text);

		triviaProgress.Clear ();

		if (!LoadProgress ()) {

			for (int i = 0; i < antologia.Length; i++) {
				TriviaProgress tp = new TriviaProgress ();
				tp.id = antologia [i].id;
				tp.gameprogress_name = antologia [i].gameprogress_name;
				tp.type = antologia [i].type;
				if (antologia [i].type == TriviaType.literatura)
					tp.triviasDone = new bool[antologia [i].trivias.Length];
				else {
					tp.triviasDone = new bool[antologia [i].texts [0].textlines.Length];
					for (int j = 0; j < antologia [i].texts [0].textlines.Length; j++)
						antologia [i].texts [0].textlines [j] = "{" + j + "}" + antologia [i].texts [0].textlines [j];
				}
				tp.area = antologia [i].area;
				tp.state = TriviaState.idle;
				triviaProgress.Add (tp);
			}
		}
	}

	public Antologia GetAntologiaByGProgress(string gameprogress_name){
		Antologia a = Array.Find (antologia, x => x.gameprogress_name == gameprogress_name);
		return a;
	}

	public TriviaProgress GetTProgressByGProgress(string gameprogress_name){
		TriviaProgress a = triviaProgress.Find(x => x.gameprogress_name == gameprogress_name);
		return a;
	}

	public TriviaState GetStateByGProgress(string gameprogress_name){
		TriviaProgress a = triviaProgress.Find(x => x.gameprogress_name == gameprogress_name);

	//	Debug.Log (Time.realtimeSinceStartup - a.lastBadAnswerTime + " state: " + a.state);
		Debug.Log("gameprogress_name " + gameprogress_name);

		if (a.state == TriviaState.complete)
			return a.state;
		else if (a.state == TriviaState.idle)
			return a.state;
		else if (a.state == TriviaState.blocked) {
			if (Time.realtimeSinceStartup - a.lastBadAnswerTime < blockedTime)
				return a.state;
			else if (Time.realtimeSinceStartup - a.lastBadAnswerTime <= resetTime) {
				a.state = TriviaState.idle;
				return a.state;
			} else {
				a.Reset ();
				return a.state;
			}				
		} else {
			Debug.Log ("en caso de agregar nuevo estado CHEQUEAR AQUI");
			return a.state;
		}
	}

	public bool AreaDone(int area){
		List<TriviaProgress> tps = triviaProgress.FindAll(x => x.area == area);
		foreach (TriviaProgress tp in tps) {
			if (tp.state != TriviaState.done && tp.state != TriviaState.complete)
				return false;
		}
		return true;	
	}
}