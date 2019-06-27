using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trivia : MonoBehaviour
{

    public GameObject panel;
    public Text title;
    string gameProgressKey;
    void Start()
    {

        Reset();
        Events.OpenTrivia += OpenTrivia;
        Events.OnBookComplete += Win;
        Events.OnTriviaWrong += Close;
        Events.TriviaClose += Close;
    }
    void OnDestroy()
    {
        Events.OpenTrivia -= OpenTrivia;
        Events.OnBookComplete -= Win;
        Events.OnTriviaWrong -= Close;
        Events.TriviaClose -= Close;
    }
    void OpenTrivia(string gameProgressKey)
    {
        this.gameProgressKey = gameProgressKey;
        TriviaData.TriviaState ts = Data.Instance.triviaData.GetStateByGProgress(gameProgressKey);
        //Debug.Log("gameProgressKey: " + gameProgressKey + " state: " + ts);
        if (ts == TriviaData.TriviaState.idle || ts == TriviaData.TriviaState.done)
        {
            Events.SetTrivia(gameProgressKey);
            panel.SetActive(true);
            //title.text = gameProgressKey;
        }
        else if (ts == TriviaData.TriviaState.blocked)
        {
            Events.OnTip(Data.Instance.interactiveObjectsTexts.content.libroBloqueado);
            Debug.Log("La trivia está bloqueada, tiene que esperar un minuto");
        }
        else if (ts == TriviaData.TriviaState.complete)
        {
            Events.OnTip(Data.Instance.interactiveObjectsTexts.content.libroCompletado);
            Debug.Log("La trivia ya está completa");
        }
    }
    public void Close()
    {
        Reset();
    }
    public void Win()
    {
        Reset();
        switch (gameProgressKey)
        {
            case "libroIngreso":
                if (Data.Instance.gameProgress.GetData("fichero_llave").value == 0)
                    Events.OnSaveNewData("fichero_llave", 1);
                break;
            case "cuaderno_ingreso":
                if (Data.Instance.gameProgress.GetData("destornillador").value == 0)
                {
                    if (Data.Instance.gameProgress.GetData("destornillador").value == 0)
                        Events.OnSaveNewData("destornillador", 1);
                }
                OnCuadernoWin("cuaderno_ingreso");
                break;
            case "libro_biblioteca_1":
                if (Data.Instance.gameProgress.GetData("cuerno2").value == 0)
                {
                    if (Data.Instance.gameProgress.GetData("cuerno2").value == 0)
                    {
                        Events.OnSaveNewData("cuerno2", 1);
                        Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.cuerno2, "inventary/cuerno", null);
                    }
                }
                break;
            case "libro_biblioteca_2":
                if (Data.Instance.gameProgress.GetData("rueda").value == 0)
                {
                    if (Data.Instance.gameProgress.GetData("rueda").value == 0)
                    {
                        Events.OnSaveNewData("rueda", 1);
                        Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.rueda, "inventary/rueda", null);
                    }
                }
                break;
            case "libro_mapoteca_1":
                if (Data.Instance.gameProgress.GetData("minimap_3").value == 0)
                {
                    if (Data.Instance.gameProgress.GetData("minimap_3").value == 0)
                    {
                        Events.OnSaveNewData("minimap_3", 1);
                        Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.minimap_3, "inventary/minimap_3", null);
                    }
                }
                break;
            case "libro_mapoteca_3":
                if (Data.Instance.gameProgress.GetData("palanca").value == 0)
                {
                    if (Data.Instance.gameProgress.GetData("palanca").value == 0)
                    {
                        Events.OnSaveNewData("palanca", 1);
                        Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.palanca, "inventary/palanca", null);
                    }
                }
                break;
            case "libro_patio_1":
                if (Data.Instance.gameProgress.GetData("pala").value == 0)
                {
                    if (Data.Instance.gameProgress.GetData("pala").value == 0)
                    {
                        Events.OnSaveNewData("pala", 1);
                        Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.pala, "inventary/pala", null);
                    }
                }
                break;
            case "libro_patio_2":
                if (Data.Instance.gameProgress.GetData("cola").value == 0)
                {
                    if (Data.Instance.gameProgress.GetData("cola").value == 0)
                    {
                        Events.OnSaveNewData("cola", 1);
                        Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.cola, "inventary/cola", null);
                    }
                }
                break;
            case "libro_patio_3":
                if (Data.Instance.gameProgress.GetData("origami").value == 0)
                {
                    if (Data.Instance.gameProgress.GetData("origami").value == 0)
                    {
                        Events.OnSaveNewData("origami", 1);
                        Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.origami, "inventary/origami", null);
                    }
                }
                break;
            case "cuadernoBiblioteca1":
                OnCuadernoWin("cuadernoBiblioteca1");
                break;
            case "cuadernoBiblioteca2":
                OnCuadernoWin("cuadernoBiblioteca2");
                break;
            case "cuadernoBiblioteca3":
                //			if (Data.Instance.gameProgress.GetData ("tijeras").value == 0) {
                //				if (Data.Instance.gameProgress.GetData ("tijeras").value == 0)
                //					Events.OnSaveNewData ("tijeras", 1);
                //			}
                OnCuadernoWin("cuadernoBiblioteca3");
                break;


            case "cuadernoPatio1":
                OnCuadernoWin(gameProgressKey);
                Events.OnSaveNewData("piedra", 1);
                Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.piedra, "inventary/piedra", null);
                break;
            case "cuadernoPatio2":
                OnCuadernoWin(gameProgressKey);
                Events.OnSaveNewData("montura", 1);
                Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.montura, "inventary/montura", null);
                break;
            case "cuadernoPatio3":
                OnCuadernoWin(gameProgressKey);
                Events.OnSaveNewData("tijeras", 1);
                Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.tijeras, "inventary/tijeras", null);
                break;
            case "libro_lab_1":
                if (Data.Instance.gameProgress.GetData("vaso").value == 0)
                {
                    if (Data.Instance.gameProgress.GetData("vaso").value == 0)
                    {
                        Events.OnSaveNewData("vaso", 1);
                        Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.vaso, "inventary/vaso", null);
                    }
                }
                break;
            case "libro_lab_2":
                if (Data.Instance.gameProgress.GetData("h").value == 0)
                {
                    if (Data.Instance.gameProgress.GetData("h").value == 0)
                    {
                        Events.OnSaveNewData("h", 1);
                        Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.h, "inventary/h", null);
                    }
                }
                break;
            case "cuadernoLab1":
                OnCuadernoWin("cuadernoLab1");
                break;
            case "cuadernoLab2":
                OnCuadernoWin("cuadernoLab2");
                Events.OnSaveNewData("llave02", 1);
                Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.llave02, "inventary/llave02", null);
                break;
            case "cuadernoLab3":
                Events.OnSaveNewData("balon", 1);
                Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.balon, "inventary/balon", null);
                OnCuadernoWin("cuadernoLab3");
                break;


            case "libro_altillo_1":
                if (Data.Instance.gameProgress.GetData("estrella").value == 0)
                {
                    if (Data.Instance.gameProgress.GetData("estrella").value == 0)
                    {
                        Events.OnSaveNewData("estrella", 1);
                        Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.estrella, "inventary/estrella", null);
                    }
                }
                break;

            case "libro_altillo_2":
                if (Data.Instance.gameProgress.GetData("rosa").value == 0)
                {
                    if (Data.Instance.gameProgress.GetData("rosa").value == 0)
                    {
                        Events.OnSaveNewData("rosa", 1);
                        Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.rosa, "inventary/rosa", null);
                    }
                }
                break;

            case "cuadernoAltillo2":
                Events.OnSaveNewData("plumasNegras", 1);
                Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.plumasNegras, "inventary/plumasNegras", null);
                OnCuadernoWin("cuadernoAltillo2");
                break;
			case "cuadernoAltillo3":
                Events.OnSaveNewData("manivela", 1);
                Events.OnTexts(Data.Instance.interactiveObjectsTexts.content.manivela, "inventary/manivela", null);
                OnCuadernoWin("cuadernoAltillo3");
                break;


        }
    }

    void OnCuadernoWin(string cuadernoName)
    {
        Events.OnSaveNewData(cuadernoName, 2);
        Events.OnCuadernoWin();
    }
    void Reset()
    {
        panel.SetActive(false);
    }
}
