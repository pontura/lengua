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
			case "libro_mapoteca_1":
				return libro_mapoteca_1;
			case "libro_mapoteca_3":
				return libro_mapoteca_3;
			case "lobo":
				return lobo;
			case "minimap_2":
				return minimap_2;
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

		public string minimap_1;
		public string minimap_2;
		public string minimap_3;

		public string minimap_1_inserted;
		public string minimap_2_inserted;
		public string minimap_3_inserted;

		public string cajoneraVacia;
		public string cuadernoMapoteca1;
		public string cuadernoMapoteca2;
		public string libro_mapoteca_1;
		public string libro_mapoteca_2;
		public string libro_mapoteca_3;
		public string lobo;
		public string lobos;
		public string map;
		public string mapReady;
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
