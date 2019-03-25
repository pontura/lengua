using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Splash : MonoBehaviour
{

	public GameObject login;
	public Button loginButton;
	public InputField name, id;

    // Start is called before the first frame update
    void Start()
    {
		ShowLogin ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void ShowLogin(){
		loginButton.interactable  = !Data.Instance.esAlumno;
	}

	public void PlayGame(){
		Events.ClickSfx ();
		Data.Instance.LoadScene ("Game");
	}

	public void ShowLogin(bool enable){
		login.SetActive (enable);
	}

	public void Register(){
		Data.Instance.users.IsUser (id.text);
		ShowLogin ();
		login.SetActive (false);
	}

}
