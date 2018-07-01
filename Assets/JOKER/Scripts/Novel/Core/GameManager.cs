
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Novel
{

	public class GameManager
	{
		private FileManager fm;
		public  Parser parser;
		
		public  ImageManager imageManager;
		public  ScenarioManager scenarioManager;
		public	StatusManager statusManager;
		public  AudioManager  audioManager;
		public  EventManager  eventManager;
		public  SaveManager   saveManager;
		public  LogManager logManager;

		public SaveGlobalObject globalSetting;

		private List<AbstractComponent> arrayComponents;

		public List<string> errorMessage = new List<string>();
		public List<string> warningMessage = new List<string>();

		public bool enableGameStart = true;

		public SceneInit scene;

		public JokerSetting jokerSetting = GameObject.Find("JOKER_SETTING").GetComponent<JokerSetting>();


		//ステータスを確認する
		public bool isMessageShowing = false; //メッセージを表示してよいかどうか


		private int currentComponentIndex = -1;


		public GameManager ()
		{

			this.fm = new FileManager ();
			this.parser = new Parser ("Novel");

			this.imageManager = NovelSingleton.ImageManager;
			this.scenarioManager = NovelSingleton.ScenarioManager;
			this.statusManager = NovelSingleton.StatusManager;
			this.audioManager = NovelSingleton.AudioManager;
			this.eventManager = NovelSingleton.EventManager;
			this.saveManager = NovelSingleton.SaveManager;
			this.logManager = new LogManager ();

		}

		public int CurrentComponentIndex{

			get{ return this.currentComponentIndex; }
			set{this.currentComponentIndex = value; }

		}


		public void addMessage(MessageType type, int num, string message){

			if (message == "")
				return;

			if (type == MessageType.Error) {

				string str = "<color=green>Novel</color>["+StatusManager.currentScenario+"]:<color=red>Error:"+num+"行目 "+message+"</color>";
				this.errorMessage.Add (str);
			
			} else if(type == MessageType.Warning) {
			
				string str = "<color=green>Novel</color>["+StatusManager.currentScenario+"]:<color=yellow>Warning:"+num+"行目 "+message+"</color>";
				this.warningMessage.Add (str);
			
			}


		}

		public void showError(string message){

			try{

				int line_num = this.arrayComponents [this.currentComponentIndex].line_num;
				string str = "<color=green>Novel</color>["+StatusManager.currentScenario+"]:<color=red>Error:"+line_num+"行目 "+message+"</color>";
				Debug.Log (str);
			}catch(Exception e){
				Debug.LogError (e);
			}
		}

		public void showLog(string message){

			if (this.getConfig ("showLog") == "true") {
				Debug.Log (message);
			}


		}


		public void setScene(SceneInit b){
			this.scene = b;
		}


		//実行すべき命令がないか、チェックする
		public void check(){
			
		}

		//文字列から即時タグを実行することができます。
		public void startTag(string tag){
			AbstractComponent cmp = this.parser.makeTag (tag);
			cmp.start ();
		}

		public void loadConfig(){
		
			Debug.Log ("init GameManager");
			string config_text = this.fm.load ("config/config");

			//パーサーを動作させる
			var dicConfig = this.parser.parseConfig (config_text);

			//dicConfigの中身をconfig に格納する
			StatusManager.variable.replaceAll ("config", dicConfig);


			Debug.Log ("config end");

		}

		public AbstractComponent getComponent(int index){

			return this.arrayComponents[index];

		}

		public string getConfig(string key){
			return StatusManager.variable.get ("config." + key);
		}

		public void setConfig(string key,string val){
			StatusManager.variable.set ("config." + key,val);
		}

		public void loadScenario(string scenario_name){

			Debug.Log ("init GameManager");

			Scenario sce = this.scenarioManager.getScenario (scenario_name);

			if (sce != null) {
				this.arrayComponents = sce.arrayComponent;
		
			} else {

				string script_text = this.fm.load ("scenario/"+scenario_name);
				StatusManager.currentScenario = scenario_name;

				//パーサーを動作させる
				this.arrayComponents = this.parser.parseScript (script_text);

				this.scenarioManager.addScenario(scenario_name,this.arrayComponents);


				if (this.errorMessage.Count > 0) {
					this.enableGameStart = false;
					foreach (string message in this.errorMessage) {
						Debug.Log (message);
					}

				}


				if (this.warningMessage.Count >0) {
					foreach (string message in this.warningMessage) {
						Debug.Log (message);
					}

				}

				if (!this.enableGameStart) {

					Debug.Log("<color=red>致命的なエラーがあります。ゲームを開始できません</color>");
					throw new System.Exception ();

				}

				this.errorMessage.Clear ();
				this.warningMessage.Clear ();

			}


		}

		//クリックされて次の命令に行くかをチェックする
		public void clickNextOrder(){
		
			//window非表示状態からの復帰の場合
			if (StatusManager.nextClickShowMessage == true) {
				StatusManager.nextClickShowMessage = false;
				NovelSingleton.GameView.showMessageWithoutNextOrder (0.5f); //nextorder はしない。
				return;
			}

			if (StatusManager.enableClickOrder == true && StatusManager.enableNextOrder == true) {
				this.nextOrder ();
			}

		}

		//次の命令へ
		public void nextOrder(){

			if (StatusManager.isMessageShowing == true) {
				return;
			}

			//nextOrder を指定されたなら、クリックは有効になる
			StatusManager.enableClickOrder = true;

			this.currentComponentIndex++;

			//シナリオファイルの最後まで来た時。スタックが存在するならreturn する
			if (this.currentComponentIndex >= this.arrayComponents.Count) {

				if (this.scenarioManager.countStack () > 0) {
					//スタックがあるならreturn する
					this.startTag ("[return]");
				} else {
					//this.showError ("シナリオファイルの終端まで到達しました");
				}

				return;
			}

			AbstractComponent cmp = this.arrayComponents [this.currentComponentIndex];


			cmp.before ();

			if (StatusManager.skipOrder == false) {

				cmp.calcVariable ();
				cmp.validate ();

				string p = "";
				foreach (KeyValuePair<string, string> kvp in cmp.param) {
					p += kvp.Key + "=" + kvp.Value+" " ;
				}

				this.showLog ("[" + cmp.tagName + " " + p +" ]");

				cmp.start ();
				cmp.after ();



			} else {
				this.nextOrder ();
			}



		}


		//ゲームをロードします
		public void loadData(string data_name){
		
			Debug.Log ("load files ");
			SaveObject sobj =  this.saveManager.getSaveData(data_name);

			Dictionary<string,Image> dic = sobj.dicImage;

			//イメージオブジェクトを画面に復元する
			foreach (KeyValuePair<string, Image> kvp in sobj.dicImage) {

				//画面を復元していきまする
				Image image = new Image (dic [kvp.Key].dicSave);
				image.dicFace = dic [kvp.Key].dicFace;
				this.imageManager.addImage(image);

			}

			//タグも復元
			this.imageManager.dicTag = sobj.dicTag;

			this.eventManager.dicEvent = sobj.dicEvent;
			this.scenarioManager = sobj.scenarioManager;
			StatusManager.variable = sobj.variable;

			//グローバルで置き換える
			NovelSingleton.GameManager.saveManager.loadGlobal ();
			StatusManager.variable.replaceAll ("global", NovelSingleton.GameManager.globalSetting.globalVar);


			//開始位置の確認
			StatusManager.currentScenario = sobj.currentFile;
			this.CurrentComponentIndex = sobj.currentIndex -1  ;

			this.loadScenario (StatusManager.currentScenario);

			StatusManager.enableClickOrder = true;

			//テキストを復元する
			NovelSingleton.GameView.messageArea.GetComponent<Text>().text = sobj.currentMessage;

			//現在の色が設定されている場合は色も復元
			if (StatusManager.currentTextColor != "") {
				NovelSingleton.GameView.messageArea.GetComponent<Text>().color = ColorX.HexToRGB (StatusManager.currentTextColor);
			}

			NovelSingleton.GameManager.scene.messageForSaveTitle = sobj.currentMessage;

			//ステータス復元
			StatusManager.visibleMessageFrame = sobj.visibleMessageFrame;
			StatusManager.enableNextOrder = sobj.enableNextOrder;
			StatusManager.enableEventClick = sobj.enableEventClick ;
			StatusManager.enableClickOrder = sobj.enableClickOrder;
			StatusManager.currentPlayBgm = sobj.currentPlayBgm;

			StatusManager.isEventStop = sobj.isEventStop;
			//Debug.Log ("wwww:" + sobj.isEventStop);

			NovelSingleton.GameManager.logManager = sobj.logManager;

			//メッセージウィドウが表示状態なら、ここで表示する
			if (StatusManager.visibleMessageFrame == true) {
				NovelSingleton.GameView.showMessageWithoutNextOrder (0f);
			} else {
				NovelSingleton.GameView.hideMessageWithoutNextOrder (0f);
			}

			if (StatusManager.currentPlayBgm != "") {

				Novel.AbstractComponent cmp = NovelSingleton.GameManager.parser.makeTag ("[playbgm wait=false next=false storage='"+StatusManager.currentPlayBgm+"']");
				cmp.start ();

			}

			//何故か、、ここにいれないと。メッセージがすごく遅くなる
			NovelSingleton.GameManager.scene.messageSpeed = 0.02f;


			this.nextOrder ();

			//画面を再現します ImageObject のみ



		}

	}


}

