using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace TMPro.Examples
{
	public class NormativaParser : MonoBehaviour
	{
		public string content;
		TextMeshProUGUI textMeshPro;
		TMP_TextEventHandler TextEventHandler;

		public List<AnswerData> answers;

		TriviaData.TriviaProgress tp;

		[Serializable]
		public class AnswerData
		{
			public string sentence;
			public string selected = "";
			public string ok;
			public string[] answers;
			public int id;
		}

		void Awake()
		{
			TextEventHandler = GetComponent<TMP_TextEventHandler> ();
			textMeshPro = GetComponent<TextMeshProUGUI> ();				
			answers = new List<AnswerData> ();
		}

		public void Parse(string content, TriviaData.TriviaProgress tpro){
			tp = tpro;
			answers.Clear ();
			string[] sentences= content.Split("\n" [0]);
			foreach (string s in sentences) {
				if (s.Length > 1) {
					AnswerData data = new AnswerData ();
					//Debug.Log (s);
					string a = GetSubstringByString ("[", "]", s);
					string b = s.Replace ("[" + a + "]", "*");
					data.answers = a.Split("," [0]);
					data.ok = data.answers[0];
					//Debug.Log (b);
					string id = GetSubstringByString ("{", "}", b);
					data.id = int.Parse (id);
					data.sentence = b.Replace ("{" + id + "}", "");
					Utils.Shuffle<string> (data.answers);
					//Shuffle (data.answers );
					answers.Add (data);
				}
			}

			for (int i = 0; i < tp.triviasDone.Length; i++) {
				if (tp.triviasDone [i]) {
					AnswerData ad = answers.Find(x => x.id == i);
					if(ad!=null)
					ad.selected = ad.ok;
				}
			}

			DrawText ();
		}
		void Shuffle( string[] arr)
		{
			for(int a = 0; a<10; a++)
			{
				string s1 = arr [0];
				int rand = UnityEngine.Random.Range(1,arr.Length);
				arr [0] = arr [rand];
				arr [rand] = s1;
			}
		}

		void OnEnable()
		{
			/*if (TextEventHandler != null)
			{*/
				TextEventHandler.onLinkSelection.AddListener(OnLinkSelection);
			//}
		}
		string GetSubstringByString(string a, string b, string c)
		{
			return c.Substring((c.IndexOf(a) + a.Length), (c.IndexOf(b) - c.IndexOf(a) - a.Length));
		}

		void OnDisable()
		{
			if (TextEventHandler != null)
			{
				TextEventHandler.onLinkSelection.RemoveListener(OnLinkSelection);
			}
		}

		void OnLinkSelection(string linkID, string linkText, int linkIndex)
		{
			

			//Debug.Log("linkID" + linkID );
			//Debug.Log(linkText );
	
			//Debug.Log("OnLinkSelection Index: " + linkIndex + " with ID [" + linkID + "] and Text \"" + linkText + "\" has been selected.");
			//string[] linkArr1= linkID.Split("'" [0]);
			string[] linkArr= linkID.Split("_" [0]);
			if (linkArr.Length > 0) {
				int answerID = int.Parse (linkArr [1]);
				int selected = int.Parse (linkArr [2]);
				AnswerData ad = answers.Find(x => x.id == answerID);
				ad.selected = ad.answers[selected];
				if (ad.selected == ad.ok)
					Events.CorrectoSfx();
				else
					Events.IncorrectoSfx();
			}

			//Debug.Log("OnLinkSelection Index: " + linkIndex + " with ID [" + linkID + "] and Text \"" + linkText + "\" has been selected.");
			//TMP_LinkInfo linkInfo = textMeshPro.textInfo.linkInfo[linkIndex];

			DrawText ();

		}

		public void DrawText()
		{
			string all= "";
			int answerID = 0;
			foreach (AnswerData a in answers) {
				all	+= AddLinks(a.sentence, a.answers, answerID) + "\n";
				answerID++;
			}
			textMeshPro.text = all;
		}
		string AddLinks(string sentence, string[] items, int answerID)
		{
			string result = "";
			int thisAnswerID = 0;
			int i = 0;
			foreach (string a in items) {
				AnswerData data = answers [answerID];
				if (data.selected.Length>0) {
					if (a == data.selected) {
						if (data.ok == data.selected) {
							tp.AddNormativaDone (data.id);
							result += "<#006600>" + a + "</color> ";
							if (i < items.Length - 1)
								result += "/ ";
						} else {
							result += "<#FF0000>" + a + "</color> ";
							if (i < items.Length - 1)
								result += "/ ";
						}
					} else {
						result +=  "<s><#333>" + a + "</color></s> ";
						if (i < items.Length - 1)
							result += "/ ";
					}

				} else {
					result += "<link=ID_" + data.id + "_" + thisAnswerID + "><u><#000000>" + a + "</color></u></link> ";
					if (i < items.Length - 1)
						result += "/ ";
					thisAnswerID++;
				}
				i++;
			}
			string newSentence = sentence.Replace ("*", result);
			return newSentence;

		}

	}
}