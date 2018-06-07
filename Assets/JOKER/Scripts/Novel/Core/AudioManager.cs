using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//Audio活動を管理する
namespace Novel{


	public class AudioObject:MonoBehaviour{
	
		public AudioSource audioSource ;
		public float time = 0;
		public float vol  = 1;
		public CompleteDelegate completeDelegate ;

		public void set(string file){

			AudioClip audioClip = Resources.Load(file,typeof(AudioClip)) as AudioClip;
			AudioSource audioSource = this.gameObject.AddComponent<AudioSource> ();
			audioSource.clip = audioClip;
			this.audioSource = audioSource;

		}

		public void play(){

			this.audioSource.volume = 0;
			this.audioSource.Play ();

			//通常の表示切り替えの場合
			iTween.ValueTo(this.gameObject,iTween.Hash(
				"from",0,
				"to",this.vol,
				"time",this.time,
				"oncomplete","finishFadein",
				"oncompletetarget",this.gameObject,
				"easeType","linear",
				"onupdate","fade"
			));

		}

		public void stop(){
		
			//通常の表示切り替えの場合
			iTween.ValueTo(this.gameObject,iTween.Hash(
				"from",this.vol,
				"to",0,
				"time",this.time,
				"oncomplete","finishFadeout",
				"oncompletetarget",this.gameObject,
				"easeType","linear",
				"onupdate","fade"
			));

		}

		public void fade(float val){
			this.audioSource.volume = val;
		}

		public void finishFadeout(){
			this.audioSource.Stop ();
			this.completeDelegate();

		}

		public void finishFadein(){
			this.completeDelegate();

		}







	}

	public class AudioManager
	{

		public Dictionary<string,AudioObject> dicBgm = new Dictionary<string,AudioObject>();
		public Dictionary<string,AudioObject> dicSound = new Dictionary<string,AudioObject>();


		public AudioManager ()
		{



		}

		public void addAudio(string file,AudioType audioType){

			GameObject g = new GameObject ();

			AudioObject audioObject = g.AddComponent<AudioObject> ();
			audioObject.set (file);

			this.getDic (audioType)[file] = audioObject;

		}

		private Dictionary<string,AudioObject> getDic(AudioType audioType){
		
			switch (audioType) {

			case AudioType.Bgm:
				return dicBgm;
			case AudioType.Sound:
				return dicSound;
			}

			return null;
		
		}

		public AudioObject getAudio(string file, AudioType audioType){

			Dictionary<string,AudioObject> dic = this.getDic (audioType);

			if (!dic.ContainsKey (file)) {
				this.addAudio (file, audioType);
				return this.getAudio (file, audioType);
			} else {
				return dic [file];
			}

		}


		public void stopAudio(string file,AudioType audioType,float time,CompleteDelegate completeDelegate){

			//全部停止する
			if (file == "") {
				Dictionary<string,AudioObject> dic = this.getDic (audioType);
				foreach (KeyValuePair<string, AudioObject> kvp in dic) {

					string key = kvp.Key;

					dic [key].time = time;
					dic [key].completeDelegate = completeDelegate;
					dic[key].stop();

				}

			} else {

				AudioObject audioObject = this.getAudio (file,audioType);
				audioObject.time = time;
				audioObject.completeDelegate = completeDelegate;
				audioObject.stop();

			}


		}


	}



}