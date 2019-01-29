using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventaryUI : MonoBehaviour {
	
	public Button inventaryButton;
	public Text qty;
	public GameObject openedPanel;
	public Transform container;
	public Transform container_not_Libro;
	public InventaryButton button;
	public InventaryButton button_not_Libro;
	bool isOpen;

	void Start () {
		inventaryButton.interactable = false;
		Close ();
		Events.InventoryButtonClicked += InventoryButtonClicked;
		Events.AddToInventary += AddToInventary;
		Events.UseItem += UseItem;
	}
	void OnDestroy()
	{
		Events.InventoryButtonClicked -= InventoryButtonClicked;
		Events.AddToInventary -= AddToInventary;
		Events.UseItem -= UseItem;
	}
	void InventoryButtonClicked(string gameProgressKey)
	{
		switch (gameProgressKey) {
		case "libroIngreso":
		case "cuaderno_ingreso":
		case "libroCuadro":
			Events.OpenTrivia (gameProgressKey);
			break;
		}
		Close ();
	}
	void AddToInventary (Inventary.Item item) {
		if (item.isLibro) {
			int totalItems = Data.Instance.inventary.GetTotalLibros ();
			if (totalItems == 0)
				inventaryButton.interactable = false;
			else {
				inventaryButton.interactable = true;
				qty.text = Data.Instance.inventary.GetTotalLibros ().ToString ();
			}
		} else {
			AddNotLibro (item);
		}
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
		Events.CloseBagSfx ();
		isOpen = false;
		openedPanel.SetActive (false);
	}
	void Open()
	{
		Events.OpenBagSfx ();
		Utils.RemoveAllChildsIn (container);
		isOpen = true;
		openedPanel.SetActive (true);
		foreach (Inventary.Item item in Data.Instance.inventary.inventary) {
			if (item.isLibro) {
				InventaryButton newBbutton = Instantiate (button);
				newBbutton.transform.SetParent (container);
				newBbutton.transform.localScale = Vector3.one;
				newBbutton.Init (item);
			}
		}
	}
	void AddNotLibro(Inventary.Item item)
	{
		InventaryButton newBbutton = Instantiate (button_not_Libro);
		newBbutton.transform.SetParent (container_not_Libro);
		newBbutton.transform.localScale = Vector3.one;
		newBbutton.Init (item);
	}
	void UseItem(string gameProgressKey)
	{
		InventaryButton toDelete = null;
		foreach (InventaryButton ib in container_not_Libro.GetComponentsInChildren<InventaryButton>())
			if (ib.item.gameProgressKey == gameProgressKey)
				toDelete = ib;
		if (toDelete != null) {
			Destroy (toDelete.gameObject);
		}
	}
}
