using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventary : MonoBehaviour {
	
	public Item[] allItems;
	public List<Item> inventary;

	[Serializable]
	public class Item
	{
		public Sprite image;
		public string gameProgressKey;
	}
	void Start () {
		Events.RemoveFromInventary += RemoveFromInventary;
		Events.OnRefreshInventary += OnRefreshInventary;
		Invoke("OnRefreshInventary", 0.5f);
	}
	void OnDestroy () {
		Events.RemoveFromInventary -= RemoveFromInventary;
		Events.OnRefreshInventary -= OnRefreshInventary;
	}
	void OnRefreshInventary()
	{
		foreach (Item item in allItems) {
			if (Data.Instance.gameProgress.GetData (item.gameProgressKey).value > 0) {
				print (item.gameProgressKey + "__" + Data.Instance.gameProgress.GetData (item.gameProgressKey).value);
				AddToInventary (item.gameProgressKey);
			}
		}
	}
	void AddToInventary (string gameProgressKey) {
		foreach (Item item in allItems)
			if (item.gameProgressKey == gameProgressKey) {
				if (!HasItem (gameProgressKey)) {
					inventary.Add (item);
					Events.AddToInventary (item.gameProgressKey);
				}
			}
	}
	void RemoveFromInventary (string gameProgressKey) {
		Item itemToRemove = null;
		foreach (Item item in inventary)
			if (item.gameProgressKey == gameProgressKey)
				itemToRemove = item;
		if (itemToRemove != null)
			inventary.Remove (itemToRemove);
	}
	public bool HasItem(string gameProgressKey) {
		foreach (Item item in inventary)
			if (item.gameProgressKey == gameProgressKey)
				return true;
		return false;
	}
	public Item GetItem(string gameProgressKey) {
		foreach (Item item in allItems)
			if (item.gameProgressKey == gameProgressKey)
				return item;
		return null;
	}
}
