using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneLine : MonoBehaviour
{
	public Text avatarField;
	public Text contentField;

	public void AddLine(PhoneConversationsData.Data data)
	{
		avatarField.text = data.character;
		if (data.emoji != "") {
			contentField.text = "<" + data.emoji + ">";
		} else {
			contentField.text = data.text;
		}
	}
}
