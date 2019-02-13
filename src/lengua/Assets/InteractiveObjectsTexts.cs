﻿using System.Collections;
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
			case "alfonsina":
				return alfonsina;
			case "cuadernoBiblioteca2":
				return cuadernoBiblioteca2;
			case "cuadernoBiblioteca1":
				return cuadernoBiblioteca1;
			case "cuadernoBiblioteca3":
				return cuadernoBiblioteca3;
			case "libros_dibujos":
				return libros_dibujos;
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
		public string libroCuadro2;

		public string libroBloqueado;
		public string libroCompletado;
		public string cuerno1;
		public string cuerno2;
		public string minotauro_0;
		public string minotauro_1;
		public string minotauro_2;
		public string alfonsina;
		public string puerta_biblioteca_patio;
		public string escalera_1;
		public string escalera_2;
		public string cuadernoBiblioteca1;
		public string cuadernoBiblioteca2;
		public string cuadernoBiblioteca3;

		public string libro_biblioteca_1;
		public string libro_biblioteca_2;

		public string libros_dibujos;
		public string rueda;

		public string puertaMapoteca;
	}
	public Content content;

	void Start () {
		
		if(Data.Instance.reloadJson)
			LoadJson ();
	}
	private void LoadJson()
	{
		print ("LoadJson");
		string filePath = Application.streamingAssetsPath + "/InteractiveObjects.json";
		if (File.Exists (filePath)) {
			string json = File.ReadAllText (filePath);
			content = JsonUtility.FromJson<Content> (json);
			Events.OnInteractiveTextsLoaded();
		}
	}

}
