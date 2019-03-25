using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Users : MonoBehaviour{

	public List<User> users;

	public string url = "https://docs.google.com/spreadsheets/d/1g8csS8zxK1Nj93MxPoxLMOJPwOQErYrzScykFW_LyuA/gviz/tq?tqx=out:csv";
	string csvText;

	[Serializable]
	public class User{
		public string id;
		public string name;
	}

    // Start is called before the first frame update
    void Start(){

		int val = PlayerPrefs.GetInt ("user");
		Debug.Log (val);

		if (val > 0)
			Data.Instance.esAlumno = true;

		StartCoroutine (LoadCSV(url));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	IEnumerator LoadCSV(string url){    
		WWW www = new WWW (url);
		yield return www;
		csvText = www.text;
		ParsingCSV (csvText);
	}

	public void ParsingCSV (string csvTextParsing){
		string[] line = csvTextParsing.Split ("\n" [0]);
		foreach (string s in line) {			
			string[] ss = s.Split (',');
			User u = new User ();
			u.name = ss [0].Replace("\"","");
			u.id = ss [1].Replace("\"","");
			users.Add (u);
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
