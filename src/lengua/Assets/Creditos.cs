using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour {

	public GameObject container;
	public float pausaInicial;
	public float speed;
	RectTransform rt;

	public Vector3 originalPos;
	public bool run;
	public float yLimit = 3600;

	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform> ();
		originalPos = rt.position;
	}

	void OnEnable(){
		if (rt == null) {
			rt = GetComponent<RectTransform> ();
			originalPos = rt.position;
		}
		run = false;

		rt.position = originalPos;
		Invoke ("Run", pausaInicial);
	}

	void Run(){
		run = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(run){
			Vector3 p =	rt.localPosition;

			rt.localPosition = new Vector3 (p.x, p.y + speed, p.z);
			if (p.y >= yLimit) {
				//rt.position = new Vector3 (p.x, 0, p.z);
				run = false;
				//Events.ShowLevelMenu (true);
				if (SceneManager.GetActiveScene ().name == "0_Splash") {
					container.SetActive (false);
				} else {
					Events.StopMusic ();
					SceneManager.LoadScene ("0_Splash");
				}
			}
		}
	}
}
