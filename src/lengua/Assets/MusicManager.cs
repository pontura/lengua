using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public GameObject fade;
	public List<MusicTrack> tracks;
	public MusicTrack cutscene;
	public MusicTrack phono;

	int trackIndex;
	public float bpm = 90f;
	public int numBeatsPerSegment = 16;

	float nextEventTime;

    // Start is called before the first frame update
    void Start()
    {
		Events.NextMusicTrack += NextMusicTrack;
		Events.CutsceneMusic += Cutscene;
		Events.PhoneMusic += Phono;
		Events.StopMusic += StopAll;

		nextEventTime = tracks [0].GetLength ()*0.5f;

		//MusicCue (tracks[trackIndex],true, 10f,0f);
    }

	void OnDestroy(){
		Events.NextMusicTrack -= NextMusicTrack;
		Events.CutsceneMusic -= Cutscene;
		Events.PhoneMusic -= Phono;
		Events.StopMusic -= StopAll;
	}

    // Update is called once per frame
    void Update()
    {
		/*double time = AudioSettings.dspTime;

		if (time + 1.0f > nextEventTime) {
			

		}*/
    }

	void StopAll(){
		foreach (MusicTrack mt  in tracks)
			mt.Stop ();
		cutscene.Stop ();
		phono.Stop ();
	}

	void Cutscene(bool enable){
		Debug.Log ("Cutscene "+enable);
		if (enable) {
			MusicCue (tracks [trackIndex], false, 10, tracks [trackIndex].GetTime ());
			int lastIndex = trackIndex;
			trackIndex++;
			if (trackIndex > tracks.Count - 1)
				trackIndex = 0;
			MusicCue (cutscene, true, 10, tracks [lastIndex].GetTime());
		} else {
			MusicCue (cutscene, false, 10, 0);
			MusicCue (tracks [trackIndex], true, 20, cutscene.GetTime ());
		}
	}

	void Phono(bool enable){
		Debug.Log ("Cutscene "+enable);
		if (enable) {
			MusicCue (tracks [trackIndex], false, 10, 0f);
			int lastIndex = trackIndex;
			trackIndex++;
			if (trackIndex > tracks.Count - 1)
				trackIndex = 0;
			MusicCue (phono, true, 10, tracks [lastIndex].GetTime());
		} else {
			MusicCue (phono, false, 20, 0f);
			MusicCue (tracks [trackIndex], true, 10, phono.GetTime ());
		}
	}

	void NextMusicTrack(){
		//Debug.Log ("ACA");
		MusicCue (tracks[trackIndex],false, nextEventTime,0f);
		int lastIndex = trackIndex;
		trackIndex++;
		if (trackIndex > tracks.Count - 1)
			trackIndex = 0;
		MusicCue (tracks[trackIndex],true, nextEventTime,tracks[lastIndex].GetTime());
	}

	void MusicCue(MusicTrack track,bool enable,float dur,float time){
		Fade trackFade = Instantiate (fade).GetComponent<Fade>();
		trackFade.OnBeginMethod = () => {
			if(enable)
				track.Play(time);
		};
		trackFade.OnLoopMethod = () => {			
			float v = Mathf.Lerp(0,1f,trackFade.time);
			track.SetVol(v);
			/*if(!enable){
				Color c2 = mancha1.color;
				//mancha1.color = new Color(c2.r,c2.g,c2.b,v);
			}*/
		};
		trackFade.OnEndMethod = () => {
			if(!enable){
				track.Stop();
			}
			trackFade.Destroy();
		};
		if(enable)
			trackFade.StartFadeIn (dur);		
		else
			trackFade.StartFadeOut (dur);		
	}
}
