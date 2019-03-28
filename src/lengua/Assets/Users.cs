using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Users : MonoBehaviour{

	public List<User> users;
	//string urls = "https://docs.google.com/spreadsheets/d/1g8csS8zxK1Nj93MxPoxLMOJPwOQErYrzScykFW_LyuA/gviz/tq?tqx=out:csv";
	public List<string> urls;
	public bool isWeb;
	string csvText;

	[Serializable]
	public class User{
		public string id;
		public string apellido;
		public string nombre;
	}

    // Start is called before the first frame update
    void Start(){

		int val = PlayerPrefs.GetInt ("user");
		Debug.Log (val);

		if (val > 0)
			Data.Instance.esAlumno = true;

		foreach(string url in urls)
			StartCoroutine (LoadCSV(url));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	IEnumerator LoadCSV(string url){
		if (isWeb) {
			WWW www = new WWW (url);
			yield return www;
			csvText = www.text;
			ParsingCSV (csvText);
		} else {
			string filePath = Application.streamingAssetsPath + "/" + url;
			print (filePath);

			if (filePath.Contains ("://")) {
				using (WWW www = new WWW (filePath)) {
					yield return www;

					csvText = www.text;
				}
			} else {
				if (File.Exists (filePath))
					csvText = System.IO.File.ReadAllText (filePath);
				
			}

			ParsingCSV (csvText);
		}
	}

	public void ParsingCSV (string csvTextParsing){
		string[] line = csvTextParsing.Split ("\n" [0]);
		for(int i=1;i<line.Length;i++){
			if (line [i] != "") {
				string[] ss = line [i].Split (',');
				User u = new User ();
				u.apellido = ss [0].Replace ("\"", "");
				Debug.Log (i);
				u.nombre = ss [1].Replace ("\"", "");
				ss [2] = ss [2].Replace ("\"", "");
				u.id = ss [2].Replace ("\r", "");
				users.Add (u);
			}
		}
	}

	public bool IsUser(string id){
		int val = users.FindIndex (x => x.id == id);
		Data.Instance.esAlumno = val > -1;
		if(Data.Instance.esAlumno)
			PlayerPrefs.SetInt ("user", 1);
		return Data.Instance.esAlumno;
	}
}