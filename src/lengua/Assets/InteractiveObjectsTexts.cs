using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class InteractiveObjectsTexts : MonoBehaviour {

	[Serializable]
	public class Content
	{
		public string GetValue(string key)
		{
			switch (key) {
			case "escritorio":
				return escritorio;
			}
			return "ERROR: no hay un texto default en InteractiveObjectsTexts GetValue() para " + key;
		}

		public string picaporte_roto;
		public string picaporte_bien;
		public string escritorio;
		public string libroEscritorio;
	}
	public Content content;

	void Start () {
		LoadJson ();
	}
	private void LoadJson()
	{
		string filePath = Application.streamingAssetsPath + "/InteractiveObjects.json";
		print (filePath);
		if (File.Exists (filePath)) {
			string json = File.ReadAllText (filePath);
			content = JsonUtility.FromJson<Content> (json);
			Events.OnInteractiveTextsLoaded();
		}
	}

}
