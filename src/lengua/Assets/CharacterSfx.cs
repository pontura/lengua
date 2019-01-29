using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSfx : MonoBehaviour {

	public AudioClip getBook;
	public AudioClip getItem;

	AudioSource asource;

	// Use this for initialization
	void Start () {
		asource = GetComponent<AudioSource> ();
		Events.AddToInventary += AddToInventary;
	}

	void OnDestroy(){
		Events.AddToInventary -= AddToInventary;
	}

	void AddToInventary (Inventary.Item item) {
		if (item.isLibro) {
			asource.PlayOneShot (getBook);
		} else {
			asource.PlayOneShot (getItem);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
