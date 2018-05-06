﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Novel{

/*	
--------------

[doc]
tag=evt
group=イベント関連
title=イベントの登録

[desc]
画面上のイメージに対してイベントを登録することができます。
イベントが発生した際は指定した場所へジャンプをおこないます。
ジャンプ先は一方通行でスタックが残りません（return で戻れない）
イベントが発生した場所に戻りたい場合はジャンプ先でevt変数に呼び出し元情報が格納されているのでそれを活用します
evt.caller_index = イベントが発生した箇所のindexが格納されています　 
evt.caller_file  = イベントが発生したファイル名が格納されています
evt.caller_name  = イベントが発生したイメージのnameが格納されています。

[sample]

[button_new name="button" text="ボタンです" ]
[button_show name="button" ]

[evt name="event_button" target="*jump_start" ]

*jump_start
{evt.caller_name}がクリックされました


[param]
name=イベントを登録するnameを指定します
tag=指定タグに対してまとめてイベントを登録することができます
act=補足するイベントの種類をしていします。例えばクリックなどを指定できます。
file=イベントが発生した際にジャンプするファイル名を記述します。省略された場合は、現在のファイル名と解釈されます
target=イベントが発生した際にジャンプする先のラベル名を指定できます。省略されている場合は先頭位置からと解釈されます



[_doc]
--------------------
 */

	//イベント登録用のコンポーネント
	public class EvtComponent:AbstractComponent
	{

		protected string imagePath = "";

		public EvtComponent ()
		{

			this.imagePath = GameSetting.PATH_IMAGE;

			//必須項目
			this.arrayVitalParam = new List<string> {

			};

			this.originalParam = new Dictionary<string,string> () {
				{ "name",""},
				{ "tag",""},
				{ "act","click"},
				{ "file",""},
				{ "target",""},

			};

		}


		public override void start ()
		{

			string name = this.param ["name"];
			string tag = this.param ["tag"];

			List<string> events = new List<string> ();

			if (tag != "") {
				events = this.gameManager.imageManager.getImageNameByTag (tag);	
			} else {
				events.Add (name);
			}

			//ファイルが指定されていない場合は現在のシナリオを格納する
			if (this.param ["file"] == "") {
				this.param ["file"] = StatusManager.currentScenario;
			}

			foreach (string object_name in events) {

				this.gameManager.eventManager.addEvent (object_name, this.param);

			}

			this.gameManager.nextOrder ();

		}


	}

	/*	
--------------

[doc]
tag=evt_remove
group=イベント関連
title=イベントの削除

[desc]
登録しておいたイベントを削除し、無効化します。

[sample]


[param]
name=イベントを無効にするnameを指定します
tag=指定タグに対してまとめてイベントを無効にすることができます


[_doc]
--------------------
 */

	public class Evt_removeComponent:AbstractComponent
	{

		protected string imagePath = "";

		public Evt_removeComponent ()
		{

			this.imagePath = GameSetting.PATH_IMAGE;


			//必須項目
			this.arrayVitalParam = new List<string> {

			};

			this.originalParam = new Dictionary<string,string> () {
				{ "name",""},
				{ "tag",""},
				{ "act",""},

			};

		}


		public override void start ()
		{

			string name = this.param ["name"];
			string tag = this.param ["tag"];

			List<string> events = new List<string> ();
			if (tag != "") {
				events = this.gameManager.imageManager.getImageNameByTag (tag);	
			} else {
				events.Add (name);
			}

			foreach (string object_name in events) {
				this.gameManager.eventManager.removeEvent (object_name);
			}

		}


	}

	/*	
--------------

[doc]
tag=evt_stop
group=イベント関連
title=イベントの一時無効化

[desc]
すべてのイベントを一時無効化します。
例えばボタンが押された後、処理が完了するまで他のボタンを押してほしくない場合などに指定することができます。

[sample]


[param]


[_doc]
--------------------
 */

	//イベントをストップします。他のイベントを受け付けなくなりま
	public class Evt_stopComponent:AbstractComponent
	{

		protected string imagePath = "";

		public Evt_stopComponent ()
		{

			this.imagePath = GameSetting.PATH_IMAGE;


			//必須項目
			this.arrayVitalParam = new List<string> {

			};

			this.originalParam = new Dictionary<string,string> () {
			
			};

		}


		public override void start ()
		{

			//例外として許可する
			StatusManager.variable.remove ("_evt_name_permission");

			//StatusManager.enableEventClick = false;
			StatusManager.isEventStop = true;
			this.gameManager.nextOrder ();

		}


	}

	/*	
--------------

[doc]
tag=evt_resume
group=イベント関連
title=イベントの再開

[desc]
evt_stopで無効化していたイベントを再度有効にします。

[sample]


[param]
name=イベントを無効にするnameを指定します
tag=指定タグに対してまとめてイベントを無効にすることができます


[_doc]
--------------------
 */

	public class Evt_resumeComponent:AbstractComponent
	{

		protected string imagePath = "";

		public Evt_resumeComponent ()
		{

			this.imagePath = GameSetting.PATH_IMAGE;


			//必須項目
			this.arrayVitalParam = new List<string> {

			};

			this.originalParam = new Dictionary<string,string> () {
				{ "name",""},
				{ "tag",""},

			};

		}


		public override void start ()
		{

			//例外として許可するイベントを登録
			string name = this.param ["name"];
			string tag = this.param ["tag"];

			///タグが指定されている場合
			if (tag != "") {

				var events = this.gameManager.imageManager.getImageNameByTag (tag);	
			
				foreach (string object_name in events) {

					StatusManager.variable.set ("_evt_name_permission." + object_name, "1");

				}

			} else if (name != "") {
				StatusManager.variable.set ("_evt_name_permission." + name, "1");
			} else {
				StatusManager.variable.remove ("_evt_name_permission");

				//StatusManager.enableEventClick = true;
				StatusManager.isEventStop = false;

			}

			this.gameManager.nextOrder ();

		}


	}




}

