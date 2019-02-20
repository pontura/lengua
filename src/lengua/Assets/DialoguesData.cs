using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DialoguesData : MonoBehaviour {

	[Serializable]
	public class Content
	{
		public List<Dialogue> intro;
		public List<Dialogue> biblioteca;
		public List<Dialogue> escalera;
		public List<Dialogue> mapoteca;
	}
	[Serializable]
	public class Dialogue
	{
		public string character;
		public string state;
		public string text;
	}

	public Content content;

	void Start () {
		//if(Data.Instance.reloadJson)
		StartCoroutine(LoadJson ());
	}
	IEnumerator LoadJson()
	{
		string filePath = Application.streamingAssetsPath + "/Dialogue.json";
		print (filePath);

		string json = "";
		if (filePath.Contains ("://")) {
			using (WWW www = new WWW (filePath)) {
				yield return www;

				json = www.text;

			}
		} else {
			if (File.Exists (filePath))
				json = System.IO.File.ReadAllText (filePath);
		}

		content = JsonUtility.FromJson<Content> (json);
	}

}
