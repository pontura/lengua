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
			case "escritorioDoor1":
				return escritorioDoor1;
			}
			return "ERROR: no hay un texto default en InteractiveObjectsTexts GetValue() para " + key;
		}

		public string picaporte_1;
		public string picaporte_2;
		public string picaporte_3;
		public string picaporte_4;

		public string escritorio;
		public string libroIngreso;
		public string escritorioDoor1;
		public string fichero_1;
		public string fichero_con_llave;
		public string fichero_con_llave2;
		public string fichero_done;

		public string cuadro1;
		public string libroCuadro;

		public string libroBloqueado;
		public string libroCompletado;
	}
	public Content content;

	void Start () {
		if(Data.Instance.reloadJson)
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
