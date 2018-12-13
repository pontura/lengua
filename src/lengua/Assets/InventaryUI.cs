using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventaryUI : MonoBehaviour {
	
	public GameObject panel;
	public Text qty;
	public GameObject openedPanel;
	public Transform container;
	public InventaryButton button;
	bool isOpen;

	void Start () {
		Close ();
		Loop();
		Events.InventoryButtonClicked += InventoryButtonClicked;
	}
	void OnDestroy()
	{
		Events.InventoryButtonClicked -= InventoryButtonClicked;
	}
	void InventoryButtonClicked(string gameProgressKey)
	{
		switch (gameProgressKey) {
		case "libroIngreso":
		case "cuaderno_ingreso":
			Events.OpenTrivia (gameProgressKey);
			break;
		}
		Close ();
	}
	void Loop () {
		int totalItems = Data.Instance.inventary.inventary.Count;
		if (totalItems == 0)
			panel.SetActive (false);
		else {
			panel.SetActive (true);
			qty.text = totalItems.ToString ();
		}
		Invoke ("Loop", 1);
	}
	public void Toogle()
	{		
		if (!isOpen)
			Open ();
		else
			Close ();
	}
	void Close()
	{
		isOpen = false;
		openedPanel.SetActive (false);
	}
	void Open()
	{
		Utils.RemoveAllChildsIn (container);
		isOpen = true;
		openedPanel.SetActive (true);
		foreach (Inventary.Item item in Data.Instance.inventary.inventary) {
			InventaryButton newBbutton = Instantiate(button);
			newBbutton.transform.SetParent (container);
			newBbutton.transform.localScale = Vector3.one;
			newBbutton.Init (item);
		}
	}
}
