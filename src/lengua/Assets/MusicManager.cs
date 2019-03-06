using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public GameObject fade;
	public List<MusicTrack> tracks;

	int trackIndex;
	public float bpm = 90f;
	public int numBeatsPerSegment = 16;

	float nextEventTime;

    // Start is called before the first frame update
    void Start()
    {
		Events.NextMusicTrack += NextMusicTrack;

		nextEventTime = tracks [0].GetLength ()*0.5f;

		Inicio (trackIndex,true, 10f,0f);
    }

	void OnDestroy(){
		Events.NextMusicTrack -= NextMusicTrack;
	}

    // Update is called once per frame
    void Update()
    {
		/*double time = AudioSettings.dspTime;

		if (time + 1.0f > nextEventTime) {
			

		}*/
    }

	void NextMusicTrack(){
		Debug.Log ("ACA");
		Inicio (trackIndex,false, nextEventTime,tracks[trackIndex].GetTime());
		trackIndex++;
		if (trackIndex > tracks.Count - 1)
			trackIndex = 0;
		Inicio (trackIndex,true, nextEventTime,0f);
	}

	void Inicio(int index,bool enable,float dur,float time){
		Fade trackFade = Instantiate (fade).GetComponent<Fade>();
		trackFade.OnBeginMethod = () => {
			if(enable)
				tracks[index].Play(time);
		};
		trackFade.OnLoopMethod = () => {			
			float v = Mathf.Lerp(0,1f,trackFade.time);
			tracks[index].SetVol(v);
			/*if(!enable){
				Color c2 = mancha1.color;
				//mancha1.color = new Color(c2.r,c2.g,c2.b,v);
			}*/
		};
		trackFade.OnEndMethod = () => {
			if(!enable){
				tracks[index].Stop();
			}
			trackFade.Destroy();
		};
		if(enable)
			trackFade.StartFadeIn (dur);		
		else
			trackFade.StartFadeOut (dur);		
	}
}
