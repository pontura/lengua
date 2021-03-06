﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace TMPro.Examples
{
	public class ChooseCorrectAnswer : MonoBehaviour
	{
		public string content;
		public TextMeshPro textMeshPro;
		public TMP_TextEventHandler TextEventHandler;

		public List<AnswerData> answers;

		[Serializable]
		public class AnswerData
		{
			public string sentence;
			public string selected = "";
			public string ok;
			public string[] answers;
		}

		void Start()
		{
			answers = new List<AnswerData> ();
			string[] sentences= content.Split("." [0]);
			foreach (string s in sentences) {
				if (s.Length > 1) {
					AnswerData data = new AnswerData ();
					string a = GetSubstringByString ("[", "]", s);
					data.sentence = s.Replace ("[" + a + "]", "*");
					data.answers = a.Split("," [0]);
					data.ok = data.answers[0];
					Shuffle (data.answers );
					answers.Add (data);
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
			if (TextEventHandler != null)
			{
				TextEventHandler.onLinkSelection.AddListener(OnLinkSelection);
			}
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
			Debug.Log("linkID" + linkID );
			//Debug.Log("OnLinkSelection Index: " + linkIndex + " with ID [" + linkID + "] and Text \"" + linkText + "\" has been selected.");
			//string[] linkArr1= linkID.Split("'" [0]);
			string[] linkArr= linkID.Split("_" [0]);
			if (linkArr.Length > 0) {
				int answerID = int.Parse (linkArr [1]);
				int selected = int.Parse (linkArr [2]);
				answers [answerID].selected = answers [answerID].answers[selected];
			}

			//Debug.Log("OnLinkSelection Index: " + linkIndex + " with ID [" + linkID + "] and Text \"" + linkText + "\" has been selected.");
			//TMP_LinkInfo linkInfo = textMeshPro.textInfo.linkInfo[linkIndex];

			DrawText ();

		}

		void DrawText()
		{
			string all= "";
			int answerID = 0;
			foreach (AnswerData a in answers) {
				all	+= AddLinks(a.sentence, a.answers, answerID) + ". ";
				answerID++;
			}
			textMeshPro.text = all;
		}
		string AddLinks(string sentence, string[] items, int answerID)
		{
			string result = "";
			int thisAnswerID = 0;
			foreach (string a in items) {
				AnswerData data = answers [answerID];
				if (data.selected.Length>0) {
					if (a == data.selected) {
						if (data.ok == data.selected)
							result += "<#00FF00>" + a + "</color> / ";
						else
							result += "<#FF0000>" + a + "</color> / ";
					} else {
						result +=  "<s><#FFFFFF>" + a + "</color></s> / ";
					}

				} else {
					result += "<link=ID_" + answerID + "_" + thisAnswerID + "><u><#FFFF00>" + a + "</color></u></link> / ";
					thisAnswerID++;
				}
			}
			string newSentence = sentence.Replace ("*", result);
			return newSentence;

		}

	}
}