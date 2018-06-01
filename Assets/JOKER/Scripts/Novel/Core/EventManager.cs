using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//Audio活動を管理する
namespace Novel{

	[Serializable]
	public class EventObject{

		public Dictionary<string,string> param;
		public string name;
		public string file;
		public string target;
		public string act;

		public EventObject(){
		}

		public EventObject(Dictionary<string,string>param){

			this.name = param ["name"];
			this.file = param ["file"];
			this.target = param ["target"];
			this.act = param ["act"];

			this.param = param;

		}


	}

	public class EventManager
	{

		public Dictionary<string,EventObject> dicEvent = new Dictionary<string,EventObject>();
		public GameManager gameManager;

		public EventManager ()
		{


		}

		public void addEvent(string name,Dictionary<string,string> param){

			//イベントが追加されたもののみ、colider を設定するというのはどうだろう。
			NovelSingleton.GameManager.imageManager.getImage(name).setColider();

			//param から
			this.dicEvent [name] = new EventObject (param);


		}

		public void checkEvent(string name,string act){

			if (StatusManager.enableEventClick == true && name == "_sp_button_close") {
				//StatusManager.inUiClick = false;
				StatusManager.enableClickOrder = false;
				StatusManager.nextClickShowMessage = true;

				NovelSingleton.GameView.hideMessageWithoutNextOrder (0.2f);
				return;
			}

		
			//指定したイベントが存在する場合、その場所にジャンプする
			if (this.dicEvent.ContainsKey (name)) {

				EventObject obj = this.dicEvent [name];


				//Debug.Log ("check:"+name);
				//Debug.Log ("StatusManager.isEventStop:" + StatusManager.isEventStop);

				//イベントが停止中の場合、特定の許可されたイベントしか実行できない
				if (StatusManager.isEventStop == true) {

					if (!StatusManager.variable.hasKey ("_evt_name_permission." + name)) {
						return;
					}
				
				//クリックも停止中の時は、、、
				}else if (StatusManager.enableEventClick != true) {

					//Debug.Log (name);
					//停止中とか関係ない
					/*
					if (!StatusManager.variable.hasKey ("_evt_name_permission." + name)) {
						return;
					}
					*/

					return;

				}


				if (obj.act == act) {

					//イベントを実施中の場合は、次に検知する画面クリックは無効にしてもらう
					//StatusManager.inUiClick = true;

					GameManager gm = NovelSingleton.GameManager;

					//ジャンプを実行する時に呼び出した位置情報を保持する
					StatusManager.variable.set ("evt.caller_file", StatusManager.currentScenario);

					int current_index = NovelSingleton.GameManager.CurrentComponentIndex;

					if (NovelSingleton.GameManager.getComponent (current_index).tagName == "s") {
						current_index = current_index - 1;
					}

					StatusManager.variable.set ("evt.caller_index", ""+(current_index));

					//paramの内容をevt変数に入れていく
					foreach (KeyValuePair<string, string> kvp in obj.param) {
						StatusManager.variable.set ("evt."+kvp.Key,obj.param[kvp.Key]);
					}

					//イベントの名前はクリックされたオブジェクトの名前
					StatusManager.variable.set ("evt.caller_name", name);


					string tag_str ="[jump file='"+ obj.file +"' target='"+obj.target+"' ]";
					AbstractComponent cmp = gm.parser.makeTag (tag_str);
					cmp.start();

				}

			}

		}

		public void removeEvent(string name){
		
			if (this.dicEvent.ContainsKey (name)) {

				this.dicEvent.Remove (name);

			}
		
		}




	}



}