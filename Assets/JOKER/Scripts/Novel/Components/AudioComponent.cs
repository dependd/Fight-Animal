using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Novel{


/*	
--------------

[doc]
tag=playbgm
group=オーディオ関連
title=BGM再生

[desc]
BGMを再生します。
対応ファイル形式は .aif、.wav、.mp3、 .oggファイルです
 
[sample]

;BGMの再生
[playbgm wait=false time=1 storage="music"]

[param]

storage=再生する音楽ファイルを指定します
time=音が最大ボリュームになるまでにかかる秒数をしていします。つまり値をおおきくすると長い時間をかけて徐々に音楽が再生されます
vol=再生時のボリュームを指定します（0〜1.0）１が最大です。
wait=trueを指定することでtimeで指定した時間が完了するまで次の処理に移動しなくなります。
next=falseを指定すると次の処理に移動することなく、音楽を再生します。

[_doc]
--------------------
 */


	//音楽再生用のコンポーネント
	public class PlaybgmComponent:AbstractComponent
	{
		public PlaybgmComponent ()
		{

			//必須項目
			this.arrayVitalParam = new List<string> {
				"storage" 
			};

			this.originalParam = new Dictionary<string,string> () {
				{ "storage",""},
				{ "time","0"},
				{ "vol","1"}, //ボリューム 0〜1
				{ "wait","true"},
				{ "next","true"},
			};

		}


		public override void start ()
		{
			StatusManager.enableNextOrder = false;

			string storage = this.param ["storage"];
			string file = GameSetting.PATH_AUDIO_BGM + storage;

			float time = float.Parse(this.param ["time"]);
			//			string wait = this.param ["wait"];

			CompleteDelegate completeDelegate = this.complete;

			AudioObject audioObject = this.gameManager.audioManager.getAudio (file,AudioType.Bgm);
			audioObject.time = time;
			audioObject.vol  = float.Parse(this.param["vol"]);
			audioObject.completeDelegate = completeDelegate;
			audioObject.audioSource.loop = true;

			audioObject.play();

			//this.gameManager.scene.MessageSpeed = 0.02f;
			//this.gameManager.scene.coroutineShowMessage (message);

			StatusManager.currentPlayBgm = storage;


			if (this.param ["wait"] != "true") {
				StatusManager.enableNextOrder = true;

				if(this.param["next"] =="true"){
					this.gameManager.nextOrder ();
				}
			}


		}

		public void complete(){

			if (this.param ["wait"] == "true") {
				StatusManager.enableNextOrder = true;

				if(this.param["next"] =="true"){
					this.gameManager.nextOrder ();
				}
			}
		}

	}


	/*		
--------------

[doc]
tag=stopbgm
group=オーディオ関連
title=BGM停止

[desc]
BGMを停止します。
storageを指定することで複数再生中の場合特定の音源のみを停止することができます。
ファイルはbgmフォルダ以下に格納してください

[sample]

;BGMの停止
[stopbgm]

[param]

storage=再生する音楽ファイルを指定します
time=音が停止するまでにかかる秒数を指定します。徐々に音楽が停止していきます
wait=trueを指定することでtimeで指定した時間が完了するまで次の処理に移動しなくなります。

[_doc]
--------------------
 */

	//BGMのwait は　フェードインが終わるのを待つことができる。
	public class StopbgmComponent:AbstractComponent
	{
		private bool endComplete = false; //同時に複数止めた時にコールバックを一回しか実行させないため

		public StopbgmComponent ()
		{

			//必須項目
			this.arrayVitalParam = new List<string> {
			};

			this.originalParam = new Dictionary<string,string> () {
				{ "storage",""},
				{ "time","1"},
				{ "wait","true"},
			};

		}




		public override void start ()
		{

			//storage が指定されている場合は、そのAudioのみ停止する
			StatusManager.enableNextOrder = false;

			string storage = this.param ["storage"];
			float time = float.Parse(this.param ["time"]);
			//			string wait = this.param ["wait"];

			CompleteDelegate completeDelegate = this.complete;

			if (storage != "") {
				string file = GameSetting.PATH_AUDIO_BGM + storage;
				this.gameManager.audioManager.stopAudio (file, AudioType.Bgm,time,completeDelegate);
			} else {
				this.gameManager.audioManager.stopAudio ("", AudioType.Bgm,time,completeDelegate);
			}

			//this.gameManager.scene.MessageSpeed = 0.02f;
			//this.gameManager.scene.coroutineShowMessage (message);
			StatusManager.currentPlayBgm = "";

			if (this.param ["wait"] != "true") {
				StatusManager.enableNextOrder = true;
				this.gameManager.nextOrder ();
			}



		}

		public void complete(){

			if (this.param ["wait"] == "true") {

				if (this.endComplete == false) {
					this.endComplete = true;
					StatusManager.enableNextOrder = true;
					this.gameManager.nextOrder ();
				}
			
			}
		}

	}


	/*		
--------------

[doc]
tag=playse
group=オーディオ関連
title=効果音再生

[desc]
効果音を再生します。
対応ファイル形式は .aif、.wav、.mp3、 .oggファイルです
ファイルはsoundフォルダ以下に格納してください

[sample]

;効果音の再生
[playse storage="button"]


[param]

storage=再生する音楽ファイルを指定します
vol=効果音の音量を指定します(0〜1.0)の間で指定してください
wait=trueを指定することでtimeで指定した時間が完了するまで次の処理に移動しなくなります。
loop=trueを指定すると音楽を繰り返し再生します。

[_doc]
--------------------
 */


	//効果音は再生が停止するのを待つことができる。
	public class PlayseComponent:AbstractComponent
	{

		public PlayseComponent ()
		{

			//必須項目
			this.arrayVitalParam = new List<string> {
				"storage" 
			};

			this.originalParam = new Dictionary<string,string> () {
				{ "storage",""},
				{ "vol","1"},
				{ "wait","true"},
				{ "loop","false"},

			};

		}


		public override void start ()
		{
			StatusManager.enableNextOrder = false;

			string storage = this.param ["storage"];
			string file = GameSetting.PATH_AUDIO_SE + storage;

			//			string wait = this.param ["wait"];

			CompleteDelegate completeDelegate = this.complete;
			AudioObject audioObject = this.gameManager.audioManager.getAudio (file,AudioType.Sound);
			audioObject.time = 0;
			audioObject.vol  = float.Parse(this.param["vol"]);
			audioObject.completeDelegate = completeDelegate;
			audioObject.audioSource.loop = bool.Parse(this.param["loop"]);
			audioObject.play();

			//this.gameManager.scene.MessageSpeed = 0.02f;
			//this.gameManager.scene.coroutineShowMessage (message);

			if (this.param ["wait"] != "true") {
				StatusManager.enableNextOrder = true;
				this.gameManager.nextOrder ();
			}


		}

		public void complete(){

			if (this.param ["wait"] == "true") {
				StatusManager.enableNextOrder = true;
				this.gameManager.nextOrder ();
			}
		}

	}

	/*		
--------------

[doc]
tag=stopse
group=オーディオ関連
title=効果音停止

[desc]
効果音を停止します。

[sample]

;効果音の再生
[stopse]

[param]

storage=再生する音楽ファイルを指定します
time=指定した秒数をかけて効果音が停止します
loop=wait 効果音が停止するまで待ちます

[_doc]
--------------------
 */

	public class StopseComponent:AbstractComponent
	{
		private bool endComplete = false; //同時に複数止めた時にコールバックを一回しか実行させないため

		public StopseComponent ()
		{

			//必須項目
			this.arrayVitalParam = new List<string> {
			};

			this.originalParam = new Dictionary<string,string> () {
				{ "storage",""},
				{ "time","0"},
				{ "wait","true"},
			};

		}




		public override void start ()
		{

			//storage が指定されている場合は、そのAudioのみ停止する
			StatusManager.enableNextOrder = false;

			string storage = this.param ["storage"];
			float time = float.Parse(this.param ["time"]);
			//			string wait = this.param ["wait"];

			CompleteDelegate completeDelegate = this.complete;

			if (storage != "") {
				string file = GameSetting.PATH_AUDIO_SE + storage;
				this.gameManager.audioManager.stopAudio (file, AudioType.Sound,time,completeDelegate);
			} else {
				this.gameManager.audioManager.stopAudio ("", AudioType.Sound,time,completeDelegate);
			}

			if (this.param ["wait"] != "true") {
				StatusManager.enableNextOrder = true;
				this.gameManager.nextOrder ();
			}

		}

		public void complete(){

			if (this.param ["wait"] == "true") {

				if (this.endComplete == false) {
					this.endComplete = true;
					StatusManager.enableNextOrder = true;
					this.gameManager.nextOrder ();
				}

			}
		}

	}


}

