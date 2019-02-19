using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneSfxs : MonoBehaviour{

	public List<AudioClip> clips;

	AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
		source = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void PlayClip(int index){
		source.PlayOneShot (clips [index]);
	}
}
