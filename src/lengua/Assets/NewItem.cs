using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewItem : MonoBehaviour {

	public GameObject panel;
	public Text title;
	public Image image;

	void Start () {
		Reset ();
		Events.AddToInventary += AddToInventary;
	}
	void OnDestroy () {
		Events.AddToInventary -= AddToInventary;
	}
	void AddToInventary (Inventary.Item _item) {
		Invoke ("Delayed", 1);
		Inventary.Item item = Data.Instance.inventary.GetItem (_item.gameProgressKey);
		image.sprite = item.image;
		Invoke ("Close", 2);
	}
	void Delayed()
	{
		panel.SetActive (true);
	}
	public void Close()
	{
		panel.GetComponent<Animation> ().Play ("newItemOff");
		Invoke("Reset", 0.5f);
	}
	void Reset()
	{
		panel.SetActive (false);
	}
}
