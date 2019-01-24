using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaPaginator : MonoBehaviour {

	public Text pagImpar;
	public Text pagPar;

	public int charsPerLine;
	public int linesPerPage;

	public List<string> pages;

	public int charCount,lineCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetPages(string[] textlines){
		charCount = 0;
		lineCount = 0;

		string page = "";
		Debug.Log (textlines.Length);
		for (int i = 0; i < textlines.Length; i++) {
			for (int j = 0; j < textlines [i].Length; j++) {
				page += textlines [i] [j];
				charCount++;
				if (charCount >= charsPerLine) {
					charCount = 0;
					lineCount++;
					if (lineCount >= linesPerPage) {
						pages.Add (page);
						page = "";
						lineCount = 0;
						charCount = 0;
					}
				}
			}
			page += '\n';
		}
		pages.Add (page);

		pagImpar.text = pages [0];
		if(pages.Count>1)
			pagPar.text = pages [1];
		else
			pagPar.text = "";
	}
}
