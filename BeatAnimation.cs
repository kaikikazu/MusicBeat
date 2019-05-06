using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  MusicBeat
{
	public class BeatAnimation : MonoBehaviour {

		public AudioSource audioSorce;
		public float Bpm = 140;

		public float minSize;
		public float maxSize;

		float playtime;
		float beatUnitPerSec;
		float beats;
		float bar;
		float animationScale;
		
		private void Start() {
			beatUnitPerSec = 60.0f/Bpm;
		}
		void Update () {
			playtime = audioSorce.time;
			beats = playtime/beatUnitPerSec;
			bar = beats*0.25f;
			float animationScale = GetAnimationTime(beats,minSize,maxSize);
			transform.localScale = Vector3.one*animationScale;
		}

		float　GetAnimationTime(float beats,float curvMin,float curvMax){
			float musicSyncedValue = Mathf.Cos(2*Mathf.PI*beats);
			musicSyncedValue += 1;
			musicSyncedValue *= 0.5f;
			return Mathf.Lerp(curvMin,curvMax,musicSyncedValue);
		}
	}
}