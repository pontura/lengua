using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventaryUI : MonoBehaviour {
	
	public Button inventaryButton;
	public GameObject opened;
	public GameObject closed;
	public GameObject nums;

	public Text qty;
	public GameObject openedPanel;
	public Transform container;
	public Transform container_not_Libro;
	public InventaryButton button;
	public InventaryButton button_not_Libro;
	bool isOpen;

	void Start () {
		nums.SetActive (false);
		inventaryButton.gameObject.SetActive (false);
		Close ();
		Events.InventoryButtonClicked += InventoryButtonClicked;
		Events.AddToInventary += AddToInventary;
		Events.UseItem += UseItem;
		Events.OnFloorClicked += OnFloorClicked;
	}
	void OnDestroy()
	{
		Events.InventoryButtonClicked -= InventoryButtonClicked;
		Events.AddToInventary -= AddToInventary;
		Events.UseItem -= UseItem;
		Events.OnFloorClicked -= OnFloorClicked;
	}
	void OnFloorClicked(Vector3 p)
	{
		Close ();
	}
	void InventoryButtonClicked(string gameProgressKey)
	{
		print ("Abre: " + gameProgressKey);
		switch (gameProgressKey) {
		case "libroIngreso":
		case "cuaderno_ingreso":
		case "libroCuadro":
		case "cuadernoBiblioteca1":
		case "cuadernoBiblioteca2":
		case "cuadernoBiblioteca3":
		case "libro_biblioteca_1":
		case "libro_biblioteca_2":

		case "libro_mapoteca_1":
		case "libro_mapoteca_2":
		case "libro_mapoteca_3":

		case "cuadernoMapoteca1":
		case "cuadernoMapoteca2":

		case "cuadernoPatio1":
		case "cuadernoPatio2":
		case "cuadernoPatio3":

		case "libro_patio_1":
		case "libro_patio_2":
		case "libro_patio_3":


		case "cuadernoLab1":
		case "cuadernoLab2":
		case "cuadernoLab3":
		case "libro_lab_1":
		case "libro_lab_2":

		case "cuadernoAltillo1":
		case "cuadernoAltillo2":
		case "cuadernoAltillo3":
		case "libro_altillo_1":
		case "libro_altillo_2":
			Events.OpenTrivia (gameProgressKey);
			break;
		}
		Close ();
	}
	void AddToInventary (Inventary.Item item) {
		if (item.isLibro) {
			int totalItems = Data.Instance.inventary.GetTotalLibros ();
			if (totalItems == 0) {
				inventaryButton.gameObject.SetActive (false);
				nums.SetActive (false);
			}
			else {
				nums.SetActive (true);
				inventaryButton.gameObject.SetActive (true);
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
		else {
			Events.CloseBagSfx ();
			Close ();
		}
	}
	void Close()
	{		
		isOpen = false;
		openedPanel.SetActive (false);
		opened.SetActive (false);
		closed.SetActive (true);
	}
	void Open()
	{
		opened.SetActive (true);
		closed.SetActive (false);
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
