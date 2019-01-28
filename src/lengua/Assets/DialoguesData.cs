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
			LoadJson ();
	}
	private void LoadJson()
	{
		string filePath = Application.streamingAssetsPath + "/Dialogue.json";
		print (filePath);
		if (File.Exists (filePath)) {
			string json = File.ReadAllText (filePath);
			content = JsonUtility.FromJson<Content> (json);
		}
	}

}
