using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
	public bool reloadJson;
    const string PREFAB_PATH = "Data";    
    static Data mInstance = null;
	[HideInInspector]
	public InteractiveObjectsTexts interactiveObjectsTexts;
	[HideInInspector]
	public GameProgress gameProgress;
	[HideInInspector]
	public Inventary inventary;
	[HideInInspector]
	public TriviaData triviaData;
	[HideInInspector]
	public DialoguesData dialoguesData;
	[HideInInspector]
	public PhoneConversationsData phoneConversationsData;

	public static Data Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<Data>();

                if (mInstance == null)
                {
                    GameObject go = Instantiate(Resources.Load<GameObject>(PREFAB_PATH)) as GameObject;
                    mInstance = go.GetComponent<Data>();
                }
            }
            return mInstance;
        }
    }
    public string currentLevel;
	public int currentLevelIndex;
    public void LoadScene(string aLevelName)
    {
        this.currentLevel = aLevelName;
        Time.timeScale = 1;
		currentLevelIndex = SceneManager.GetSceneByName (aLevelName).buildIndex;
        SceneManager.LoadScene(aLevelName);
    }

    void Awake()
    {
		QualitySettings.vSyncCount = 1;

        if (!mInstance)
            mInstance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
	
		Scene actual = SceneManager.GetActiveScene ();
		currentLevelIndex = actual.buildIndex;
		currentLevel = actual.name;

		phoneConversationsData = GetComponent<PhoneConversationsData> ();
		interactiveObjectsTexts = GetComponent<InteractiveObjectsTexts> ();
		gameProgress = GetComponent<GameProgress> ();
		inventary = GetComponent<Inventary> ();
		triviaData = GetComponent<TriviaData> ();
		dialoguesData = GetComponent<DialoguesData> ();

    }
}
