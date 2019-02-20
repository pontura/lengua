using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PhoneConversationsData : MonoBehaviour {

	[Serializable]
	public class Content
	{
		public List<Data> joaco_biblioteca;
		public List<Data> marian_1;
	}
	[Serializable]
	public class Data
	{
		public string character;
		public string emoji;
		public string text;
	}

	public Content content;

	void Start () {
		//if(Data.Instance.reloadJson)
		StartCoroutine(LoadJson());
	}
	IEnumerator LoadJson()
	{
		string filePath = Application.streamingAssetsPath + "/PhoneConversationsData.json";
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
