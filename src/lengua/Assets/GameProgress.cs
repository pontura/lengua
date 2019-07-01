using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameProgress : MonoBehaviour {

	public bool ResetProgress;

	[Serializable]
	public class Item
	{
		public string name;
		public int value;
	}
	public Item[] items;

	void Awake () {
		if (ResetProgress)
			PlayerPrefs.DeleteAll ();
		Events.OnSaveNewData += OnSaveNewData;
		SetValues ();
	}
	void SetValues()
	{
        foreach (Item item in items)
            item.value = PlayerPrefs.GetInt(item.name, 0);
        Events.OnGameProgressLoaded();
	}
	void OnSaveNewData(string itemName, int value)
	{
		Item item = GetData (itemName);

		if (item == null) {
			Debug.LogError ("No existe el objeto " + itemName);
			return;
		}

		item.value = value;
		PlayerPrefs.SetInt (item.name, value);

        if(itemName == "cutscenes" && Data.Instance.esAlumno && Data.Instance.firebaseInitialized)
        {
            Firebase.Analytics.Parameter[] LevelUpParameters = {
            new Firebase.Analytics.Parameter(
                Firebase.Analytics.FirebaseAnalytics.ParameterLevel, value),
            new Firebase.Analytics.Parameter(
                Firebase.Analytics.FirebaseAnalytics.ParameterCharacter,"nivel:"+value+"&preguntas:"+Data.Instance.triviaData.triviaCount)
            };
            Firebase.Analytics.FirebaseAnalytics.LogEvent(
              Firebase.Analytics.FirebaseAnalytics.EventLevelUp,
              LevelUpParameters);
        }

		Events.OnRefreshInventary ();
	}
	public Item GetData(string name)
	{
		foreach(Item item in items)
			if(item.name == name)
				return item;
		return null;
	}
	public void SetData(string name, int _value)
	{
		foreach (Item item in items)
			if (item.name == name)
				item.value = _value;
	}
}
