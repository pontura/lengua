using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventaryButton : MonoBehaviour {

	public Image image;
	public Inventary.Item item;

	public void Init(Inventary.Item item) {

		this.item = item;
		image.sprite = item.image;
	}
	public void Clicked()
	{
		Events.InventoryButtonClicked (item.gameProgressKey);
	}
}
