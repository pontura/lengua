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

	void Start () {
		if (ResetProgress)
			PlayerPrefs.DeleteAll ();
		Events.OnSaveNewData += OnSaveNewData;
		SetValues ();
	}
	void SetValues()
	{
		foreach(Item item in items)
			item.value = PlayerPrefs.GetInt (item.name, 0);
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

		Events.OnRefreshInventary ();
	}
	public Item GetData(string name)
	{
		foreach(Item item in items)
			if(item.name == name)
				return item;
		return null;
	}
}
