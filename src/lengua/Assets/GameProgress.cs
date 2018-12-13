using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameProgress : MonoBehaviour {

	[Serializable]
	public class Item
	{
		public string name;
		public int value;
	}
	public Item[] items;

	void Start () {
		Events.OnSaveNewData += OnSaveNewData;
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
	}
	public Item GetData(string name)
	{
		foreach(Item item in items)
			if(item.name == name)
				return item;
		return null;
	}
}
