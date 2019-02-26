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
			case "libro_mapoteca_2":
				return libro_mapoteca_2;
			case "libro_mapoteca_3":
				return libro_mapoteca_3;
			case "lobo":
				return lobo;
			case "minimap_2":
				return minimap_2;
			case "tarjeta":
				return tarjeta;
			case "mapasDesconocidos":
				return mapasDesconocidos;
			case "mapaConstelacion":
				return mapaConstelacion;
			case "mapasMedicion":
				return mapasMedicion;
			case "globo_1":
				return globo_1;
			case "cuadernoPatio1":
				return cuadernoPatio1;
			case "cuadernoPatio2":
				return cuadernoPatio2;
			case "cuadernoPatio3":
				return cuadernoPatio3;
			case "cuadernoArbol":
				return cuadernoArbol;
			case "libro_patio_1":
				return libro_patio_1;
			case "libro_patio_2":
				return libro_patio_2;
			case "libro_patio_3":
				return libro_patio_3;
			case "pozo":
				return pozo;
			case "ligustrina":
				return ligustrina;
			case "estatuaIncompleta":
				return estatuaIncompleta;
			case "cola_inserted":
				return cola_inserted;
			case "montura_inserted":
				return montura_inserted;
			case "catSinOrigami":
				return catSinOrigami;
			case "origami":
				return origami;
			case "banco":
				return banco;
			case "catDone":
				return catDone;
			}
			return "ERROR: no hay un texto default en InteractiveObjectsTexts GetValue() para " + key;
		}

		public string catDone;
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

		public string cola_inserted;
		public string montura_inserted;

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
		public string palanca;
		public string ladder_1;
		public string ladder_2;

		public string globo_1;
		public string globo_2;

		public string tarjeta;
		public string mapasDesconocidos;
		public string mapaConstelacion;
		public string mapasMedicion;

		public string cuadernoPatio1;
		public string cuadernoPatio2;
		public string cuadernoPatio3;

		public string libro_patio_1;
		public string libro_patio_2;
		public string libro_patio_3;
		public string cola;
		public string montura;
		public string pala;
		public string piedra;
		public string tijeras;
		public string cuadernoArbol;
		public string pozo;
		public string ligustrina;
		public string estatuaIncompleta;
		public string origami;
		public string catSinOrigami;
		public string banco;
	}
	public Content content;

	void Start () {
		
		if(Data.Instance.reloadJson)
			StartCoroutine(LoadJson ());
	}
	IEnumerator LoadJson()
	{
		print ("LoadJson");
		string filePath = Application.streamingAssetsPath + "/InteractiveObjects.json";

		string json = "";
		if (filePath.Contains ("://")) {
			using (WWW www = new WWW (filePath)) {
				yield return www;

				json = www.text;

			}
		} else { 
			if (File.Exists (filePath))
				json = System.IO.File.ReadAllText (filePath);
		}

		Debug.Log (json);

		content = JsonUtility.FromJson<Content> (json);
		Events.OnInteractiveTextsLoaded ();
	}

}
