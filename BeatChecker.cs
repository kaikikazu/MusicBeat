using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MusicBeat
{
	public class BeatChecker : MonoBehaviour {

		public AudioSource audioSorce;
		public Material material;
		public float Bpm = 140;
		float playtime;
		float beatUnitPerSec;
		float prevBeats;
		float prevBar;
		float animationScale;
		float count;
		
		private void Start() {
			beatUnitPerSec = 60.0f/Bpm;
		}
		void Update () {
			playtime = audioSorce.time;
			float beats = Mathf.CeilToInt(playtime/beatUnitPerSec);
			float bar = Mathf.CeilToInt(beats*0.25f);
			
			bool changeBeat = prevBeats != beats;
			bool changeBar = prevBar != bar;

			if (changeBeat){
				if(material.HasProperty("_Color")){
					if (count == 0){
						material.SetColor("_Color", Color.green);
						count++;
					} else if (count == 1){
						material.SetColor("_Color", Color.blue);
						count++;
					} else if (count == 2){
						material.SetColor("_Color", Color.yellow);
						count = 0;
					}
				}
			}
			if (changeBar){
				
			}
			prevBeats = beats;
			prevBar = bar;
		}
	}
}
