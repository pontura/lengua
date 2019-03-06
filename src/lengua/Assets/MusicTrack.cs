using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrack : MonoBehaviour
{
	public AudioClip clip;
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
		if (source.time >= clip.length * 0.5f && !skiped) {
			Events.NextMusicTrack ();
			skiped = true;
		}
    }

	public void Play(float time){
		source.clip = clip;
		source.volume = 0;
		source.time = time;
		source.PlayScheduled (time);
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
		source.volume = v;
	}
}
