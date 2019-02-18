using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneLine : MonoBehaviour
{
	public Text avatarField;
	public Text contentField;
	public Image image;

	public void AddLine(PhoneConversationsData.Data data)
	{
		avatarField.text = data.character;
		if (data.emoji != "") {
			string url = "emoticones/" + data.emoji;
			image.sprite = Resources.Load<Sprite> (url) as Sprite;
			contentField.text = "";
		} else {
			image.enabled = false;
			contentField.text = data.text;
		}
	}
}
