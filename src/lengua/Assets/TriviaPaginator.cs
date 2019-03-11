using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace TMPro.Examples
{
	public class TriviaPaginator : MonoBehaviour
	{


		public TextMeshProUGUI pageLeft;
		NormativaParser leftParser;
		public TextMeshProUGUI pageRight;
		NormativaParser rightParser;
		public TMP_FontAsset normativaFont;
		public float normativaFont_size;
		public TMP_FontAsset literaturaFont;
		public float literaturaFont_size;
		public GameObject triviaUI;
		public AudioClip nextSfx;
		AudioSource source;

		public int charsPerLine;
		public int linesPerPage;

		public int charsPerLine_norma;
		public int linesPerPage_norma;

		public List<string> pages;

		public int charCount, lineCount;

		public GameObject backBtn, nextBtn;

		int bookIndex;

		TriviaData.TriviaType type;

		TriviaData.TriviaProgress tp;

		// Use this for initialization
		void Start ()
		{
			source = GetComponent<AudioSource> ();
			leftParser = pageLeft.GetComponent<NormativaParser> ();
			rightParser = pageRight.GetComponent<NormativaParser> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}

		public void SetPages (string[] textlines, TriviaData.TriviaType t, TriviaData.TriviaProgress tpro)
		{

			type = t;
			int charsPL=charsPerLine;
			int lPP=linesPerPage;

			if (type == TriviaData.TriviaType.literatura) {
				pageLeft.font = literaturaFont;
				pageLeft.fontStyle = FontStyles.Normal;
				pageLeft.fontSize = literaturaFont_size;
				pageRight.font = literaturaFont;
				pageRight.fontStyle = FontStyles.Normal;
				pageRight.fontSize = literaturaFont_size;
				charsPL = charsPerLine;
				lPP = linesPerPage;
			} else if (type == TriviaData.TriviaType.normativa) {
				pageLeft.font = normativaFont;
				pageLeft.fontStyle = FontStyles.Italic;
				pageLeft.fontSize = normativaFont_size;
				pageRight.font = normativaFont;
				pageRight.fontStyle = FontStyles.Italic;
				pageRight.fontSize = normativaFont_size;
				charsPL = charsPerLine_norma;
				lPP = linesPerPage_norma;
			}
			

			tp = tpro;

			charCount = 0;
			lineCount = 0;

			pages.Clear ();

			string page = "";
			Debug.Log (textlines.Length);

			bool nextpage = false;
			bool changePage = false;
			for (int i = 0; i < textlines.Length; i++) {
				for (int j = 0; j < textlines [i].Length; j++) {				
					if (nextpage && (textlines [i] [j] == '\n' || textlines [i] [j] == '.') || textlines [i] [j] == '#') {
						//page += '#';
						nextpage = false;
						changePage = true;
						if(textlines [i] [j] == '.')
							page += '.';
						pages.Add (page);
						page = "";
						lineCount = 0;
						charCount = 0;
					} else {
						page += textlines [i] [j];
						charCount++;
						if (charCount >= charsPL || textlines [i] [j] == '\n') {
							//page += '$';
							charCount = 0;
							lineCount++;
							if (lineCount >= lPP) {						
								nextpage = true;
							}
						}
					}
				}
				if (changePage)
					changePage = false;
				else
					page += '\n';
			}
			if(page!="")
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

		void DrawPages ()
		{
			triviaUI.SetActive (false);
			if (bookIndex > 0)
				backBtn.SetActive (true);
			else
				backBtn.SetActive (false);
		
			int pageIndex = bookIndex * 2;
			if (pageIndex < pages.Count) {
				if (type == TriviaData.TriviaType.literatura) {
					pageLeft.text = pages [pageIndex];
					nextBtn.SetActive (true);
				}else {					
					leftParser.Parse (pages [pageIndex],tp);
					nextBtn.SetActive (false);
				}
			} else {
				pageLeft.text = "";
				pageRight.text = "";
				if (type == TriviaData.TriviaType.literatura)
				SetTrivia (true);
				nextBtn.SetActive (false);
				return;
			}

			if (pageIndex + 1 < pages.Count) {
				if (type == TriviaData.TriviaType.literatura) {
					pageRight.text = pages [pageIndex + 1];
					nextBtn.SetActive (true);
				}else {
					rightParser.Parse (pages [pageIndex + 1],tp);
					if(pages.Count>pageIndex + 2)  
						nextBtn.SetActive (true);
					else
						nextBtn.SetActive (false);
				}
			} else {
				pageRight.text = "";
				if (type == TriviaData.TriviaType.literatura)
				SetTrivia (false);
				nextBtn.SetActive (false);
				return;
			}


		
		}

		void SetTrivia (bool left)
		{
		
			if (left)
				triviaUI.transform.SetParent (pageLeft.transform);
			else
				triviaUI.transform.SetParent (pageRight.transform);
		
			triviaUI.SetActive (true);
			triviaUI.transform.localPosition = Vector3.zero;

		}

		public void ChangePage (int val)
		{
			if (val < 0) {			
				if (bookIndex == 0)
					return;
				bookIndex--;
				source.clip = nextSfx;
				source.pitch = UnityEngine.Random.Range (1.1f, 1.5f);
				source.Play ();
				DrawPages ();
			} else if (val > 0) {			
				bookIndex++;
				source.clip = nextSfx;
				source.pitch = UnityEngine.Random.Range (1.1f, 1.5f);
				source.Play ();
				DrawPages ();
			}
		}
	}
}