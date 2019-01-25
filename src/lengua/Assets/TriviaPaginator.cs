using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaPaginator : MonoBehaviour {

	public Text pageLeft;
	public Text pageRight;
	public GameObject triviaUI;

	public int charsPerLine;
	public int linesPerPage;

	public List<string> pages;

	public int charCount,lineCount;

	public GameObject backBtn,nextBtn;

	int bookIndex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetPages(string[] textlines){
		charCount = 0;
		lineCount = 0;

		pages.Clear ();

		string page = "";
		Debug.Log (textlines.Length);

		bool nextpage = false;
		for (int i = 0; i < textlines.Length; i++) {
			for (int j = 0; j < textlines [i].Length; j++) {				
				if (nextpage && (textlines [i] [j] == '\n' || textlines [i] [j] == '.')) {
					//page += '#';
					nextpage = false;
					pages.Add (page);
					page = "";
					lineCount = 0;
					charCount = 0;
				} else {
					page += textlines [i] [j];
					charCount++;
					if (charCount >= charsPerLine || textlines [i] [j]== '\n') {
						//page += '$';
						charCount = 0;
						lineCount++;
						if (lineCount >= linesPerPage) {						
							nextpage = true;
						}
					}
				}
			}
			page += '\n';
		}
		pages.Add (page);

		bookIndex = 0;
		backBtn.SetActive (false);
		DrawPages ();

		/*pageLeft.text = pages [0];
		if(pages.Count>1)
			pageRight.text = pages [1];
		else
			pageRight.text = "";*/
	}

	void DrawPages(){
		triviaUI.SetActive (false);
		if (bookIndex > 0)
			backBtn.SetActive (true);
		else
			backBtn.SetActive (false);
		
		int pageIndex = bookIndex * 2;
		if (pageIndex < pages.Count) {
			pageLeft.text = pages [pageIndex];
			nextBtn.SetActive (true);
		} else {
			pageLeft.text = "";
			pageRight.text = "";
			SetTrivia (true);
			nextBtn.SetActive (false);
			return;
		}

		if (pageIndex + 1 < pages.Count) {
			pageRight.text = pages [pageIndex+1];
			nextBtn.SetActive (true);
		}else {
			pageRight.text = "";
			SetTrivia (false);
			nextBtn.SetActive (false);
			return;
		}


		
	}

	void SetTrivia(bool left){
		
		if (left)
			triviaUI.transform.SetParent (pageLeft.transform);
		else
			triviaUI.transform.SetParent (pageRight.transform);
		
		triviaUI.SetActive (true);
		triviaUI.transform.localPosition = Vector3.zero;

	}

	public void ChangePage(int val){
		if (val < 0) {			
			if (bookIndex == 0)
				return;
			bookIndex--;
			DrawPages ();
		} else if (val > 0) {			
			bookIndex++;
			DrawPages ();
		}
	}
}
