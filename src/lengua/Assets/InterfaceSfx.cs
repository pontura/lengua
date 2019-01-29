using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceSfx : MonoBehaviour {

	public AudioClip click;
	public AudioClip openBag;
	public AudioClip closeBag;
	public AudioClip openBook;
	public AudioClip closeBook;

	AudioSource asource;

	// Use this for initialization
	void Start () {
		asource = GetComponent<AudioSource> ();
		Events.ClickSfx += ClickSfx;
		Events.OpenBagSfx += OpenBagSfx;
		Events.CloseBagSfx += CloseBagSfx;
		Events.OpenBookSfx += OpenBookSfx;
		Events.CloseBookSfx += CloseBookSfx;
	}

	void OnDestroy(){
		Events.ClickSfx -= ClickSfx;
		Events.OpenBagSfx -= OpenBagSfx;
		Events.CloseBagSfx -= CloseBagSfx;
		Events.OpenBookSfx -= OpenBookSfx;
		Events.CloseBookSfx -= CloseBookSfx;
	}

	void ClickSfx(){
		asource.PlayOneShot (click);
	}

	void OpenBagSfx(){
		asource.PlayOneShot (openBag);
	}

	void CloseBagSfx(){
		asource.PlayOneShot (closeBag);
	}

	void OpenBookSfx(){
		asource.PlayOneShot (openBook);
	}

	void CloseBookSfx(){
		asource.PlayOneShot (closeBook);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
