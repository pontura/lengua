using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class InteractiveObjectsTexts : MonoBehaviour
{

    [Serializable]
    public class Content
    {
        public string GetValue(string key)
        {
            switch (key)
            {
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
                case "gato1":
                    return gato1;
                case "gato2":
                    return gato2;
                case "cuadroOrigamis1":
                    return cuadroOrigamis1;
                case "cuadroOrigamis2":
                    return cuadroOrigamis2;
                case "pileta1":
                    return pileta1;
                case "pileta2":
                    return pileta2;
                case "armarioLab":
                    return armarioLab;
                case "letra2":
                    return letra2;
                case "pizarron":
                    return pizarron;
                case "balones1":
                    return balones1;
                case "balones2":
                    return balones2;
                case "caldero1":
                    return caldero1;
                case "caldero2":
                    return caldero2;
                case "caldero3":
                    return caldero3;
                case "libro_lab_1":
                    return libro_lab_1;
                case "libro_lab_2":
                    return libro_lab_2;
                case "cuadernoLab1":
                    return cuadernoLab1;
                case "cuadernoLab2":
                    return cuadernoLab2;
                case "cuadernoLab3":
                    return cuadernoLab3;
                case "llave02":
                    return llave02;
                case "caldero_inserted":
                    return caldero_inserted;
                case "veneno":
                    return veneno;
                case "h":
                    return h;
                case "g":
                    return g;
                case "vaso2":
                    return vaso2;
                case "balon":
                    return balon;
                case "copa":
                    return copa;
                case "ladder_1":
                    return ladder_1;
                case "usarG":
                    return usarG;
                case "cuadernoAltillo1":
                    return cuadernoAltillo1;
                case "cuadernoAltillo2":
                    return cuadernoAltillo2;
                case "cuadernoAltillo3":
                    return cuadernoAltillo3;
                case "libro_altillo_1":
                    return libro_altillo_1;
                case "libro_altillo_2":
                    return libro_altillo_2;
                case "plumasNegras":
                    return plumasNegras;
                case "ovillo":
                    return ovillo;
                case "rosa":
                    return rosa;
                case "escalera_altillo":
                    return escalera_altillo;
                case "ovillo2":
                    return ovillo2;
                case "telar_sin_ovillo":
                    return telar_sin_ovillo;
                case "claraboya":
                    return claraboya;
                case "trenza1":
                    return trenza1;
                case "trenza2":
                    return trenza2;
                case "claraboyaPoneEstrella":
                    return claraboyaPoneEstrella;
                case "claraboyaPoneEscalera":
                    return claraboyaPoneEscalera;

                case "telescopio_done":
                    return telescopio_done;
                case "telescopio_1":
                    return telescopio_1;
                case "telescopio_2":
                    return telescopio_2;
                case "bustoColocaTrenza":
                    return bustoColocaTrenza;
                case "busto":
                    return busto;
                case "manivela":
                    return manivela;
                case "no_hay_escalera":
                    return no_hay_escalera;
                case "telescopio_sin_manivela":
                    return telescopio_sin_manivela;
                case "manivela_done":
                    return manivela_done;
            }
            return "ERROR: no hay un texto default en InteractiveObjectsTexts GetValue() para " + key;
        }
        public string manivela_done;
        public string no_hay_escalera;
        public string bustoColocaTrenza;
        public string busto;
        public string manivela;
        public string telescopio_done;
        public string telescopio_1;
        public string telescopio_2;
        public string telescopio_sin_manivela;

        public string claraboyaPoneEstrella;
        public string claraboyaPoneEscalera;
        public string trenza1;
        public string trenza2;

        public string claraboya;
        public string estrella;
        public string telar_sin_ovillo;
        public string plumasNegras;
        public string ovillo;
        public string ovillo2;

        public string rosa;
        public string escalera_altillo;

        public string cuadernoAltillo1;
        public string cuadernoAltillo2;
        public string cuadernoAltillo3;

        public string libro_altillo_1;
        public string libro_altillo_2;

        public string usarG;
        public string vaso2;
        public string veneno;
        public string letra2_inserted;
        public string h_inserted;
        public string llave02_used;
        public string h;
        public string g;
        public string libro_lab_1;
        public string libro_lab_2;
        public string cuadernoLab1;
        public string cuadernoLab2;
        public string cuadernoLab3;
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
        public string caldero_inserted;
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
        public string vaso;
        public string balon;
        public string gato1;
        public string gato2;
        public string cuadroOrigamis1;
        public string cuadroOrigamis2;
        public string pileta1;
        public string pileta2;
        public string armarioLab;
        public string letra2;
        public string pizarron;
        public string balones1;
        public string balones2;
        public string caldero1;
        public string caldero2;
        public string caldero3;
        public string llave02;
        public string vaso2_inserted;
        public string balon_inserted;
        public string copa;
    }
    public Content content;

    void Start()
    {

        if (Data.Instance.reloadJson)
            StartCoroutine(LoadJson());
    }
    IEnumerator LoadJson()
    {
        print("LoadJson");
        string filePath = Application.streamingAssetsPath + "/InteractiveObjects.json";

        string json = "";
        if (filePath.Contains("://"))
        {
            using (WWW www = new WWW(filePath))
            {
                yield return www;

                json = www.text;

            }
        }
        else
        {
            if (File.Exists(filePath))
                json = System.IO.File.ReadAllText(filePath);
        }

        Debug.Log(json);

        content = JsonUtility.FromJson<Content>(json);
        Events.OnInteractiveTextsLoaded();
    }

}
