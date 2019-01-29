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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
