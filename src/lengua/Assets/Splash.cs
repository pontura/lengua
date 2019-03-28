using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{

	public GameObject login;
	public Button loginButton;
	public InputField name, id;
	public GameObject credits;
	public LoadingBar loadingBar;
	public GameObject noLogin;

	public bool loadDone;

    // Start is called before the first frame update
    void Start()
    {
		loadingBar.transform.parent.gameObject.SetActive (true);
		StartCoroutine (AsynchronousLoad ("Game"));
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
		bool val = Data.Instance.users.IsUser (id.text);
		ShowLogin ();
		login.SetActive (false);
		if (!val)
			noLogin.SetActive (true);		
		Invoke ("HideMessage", 3);
	}

	void HideMessage(){
		noLogin.SetActive (false);
	}


	public void ShowCredits(bool enable){
		credits.SetActive (enable);
	}

	IEnumerator AsynchronousLoad (string scene)
	{
		yield return null;

		AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
		ao.allowSceneActivation = false;

		while (! ao.isDone)
		{			
			// [0, 0.9] > [0, 1]\
			float progress = Mathf.Clamp01(ao.progress / 0.9f);
			loadingBar.SetFill(progress);

			yield return new WaitForSeconds(1);
			// Loading completed
			/*if (ao.progress == 0.9f){
				loading.SetActive (false);
				playButton.SetActive (true);
			}*/

			if(loadDone)
				ao.allowSceneActivation = true;

			yield return null;
		}
	}

}
