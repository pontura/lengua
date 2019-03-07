using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrack : MonoBehaviour
{
	public AudioClip clip;
	public float maxVol = 1f;
	public bool multitrack;
	AudioSource source;
	bool skiped;

    // Start is called before the first frame update
    void Start()
    {
		Debug.Log (clip.length);
		source = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
		if (!multitrack)
			return;
		if (source.time >= clip.length * 0.5f && !skiped) {
			Debug.Log (source.clip.name);
			Events.NextMusicTrack ();
			skiped = true;
		} else if (skiped) {
			if (source.time < clip.length * 0.5f)
				skiped = false;
		}
    }

	public void Play(float time){
		source.clip = clip;
		source.volume = 0;
		if (time >= clip.length * 0.5f)
			skiped = true;
		source.time = time;

		source.Play();
	}

	public void Stop(){
		source.Stop ();
		skiped = false;
	}

	public float GetTime(){
		return source.time;
	}

	public float GetLength(){
		return clip.length;
	}

	public void SetVol(float v){
		source.volume = v*maxVol;
	}
}
