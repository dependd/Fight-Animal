
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;
using System.Text;
//using MiniJSON;


namespace Novel
{

	//ゲーム全体に関する情報を保持する
	[Serializable]
	public class SaveGlobalObject{

		//global変数を保持する。ゲームごとに変わらない変数 global.x みたいなやつ
		public Dictionary<string,string> globalVar = new Dictionary<string,string>() ;


	}


	[Serializable]
	public class SaveObject{

		public string currentFile ="";
		public int  currentIndex =-1;

		public string name ="";
		public string title ="";
		public string description ="";
		public string date = "";
		public string currentMessage ="";

		public bool visibleMessageFrame = true;
		public bool enableNextOrder =true;
		public bool enableEventClick = true;
		public bool enableClickOrder = true;
		public string currentPlayBgm = "";

		public bool isEventStop = false;

		//画面のキャプチャ情報
		public string cap_img_file ="";

		//ImageManager 編
		//dicImage
		public Dictionary <string,Image> dicImage ;
		//dicTab 
		public Dictionary<string,Dictionary<string,Image>> dicTag ;

		//イベント管理用
		public Dictionary<string,EventObject> dicEvent ; 

		//スタック管理
		public ScenarioManager scenarioManager;

		public LogManager logManager;

		//変数管理　
		public Variable variable;


	}

	public class SaveManager
	{

		private string storagePath ;


		public SaveManager ()
		{

			this.storagePath = Application.persistentDataPath + "/novel";

		}

		//グローバルセッティングを保存します
		public void saveGlobal(SaveGlobalObject sobj){

			NovelSingleton.GameManager.globalSetting = sobj;
			string json = LitJson.JsonMapper.ToJson (sobj);


			//WebPlayer の場合保存方法に変化を入れる
			if (Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.OSXWebPlayer) {

				PlayerPrefs.SetString("setting.dat", json);

			} else {

				string path = storagePath + "/setting.dat";

				//ディレクトリ存在チェック
				if (!Directory.Exists (storagePath)) {
					Directory.CreateDirectory (storagePath);
				}


				FileStream fs = new FileStream (path,
					               FileMode.Create,
					               FileAccess.Write);

				StreamWriter sw = new StreamWriter (fs);
				sw.Write (json);
				sw.Flush ();
				sw.Close ();
				fs.Close ();
			}
		}

		public void loadGlobal(){

			//WebPlayer の場合保存方法に変化を入れる
			if (Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.OSXWebPlayer) {

				if (!PlayerPrefs.HasKey ("setting.dat")) {
					this.saveGlobal (new SaveGlobalObject ());
				}

				string json = PlayerPrefs.GetString ("setting.dat");

				SaveGlobalObject obj = LitJson.JsonMapper.ToObject<SaveGlobalObject> (json);
				NovelSingleton.GameManager.globalSetting = obj;


			} else {


				string path = storagePath + "/setting.dat";

				if (!File.Exists (path)) {
					//ファイル作製
					this.saveGlobal (new SaveGlobalObject ());
				}

				FileStream fs = new FileStream (path,
					               FileMode.Open,
					               FileAccess.Read);

				StreamReader sr = new StreamReader (path, System.Text.Encoding.Default);
				string json = sr.ReadToEnd ();

				SaveGlobalObject obj = LitJson.JsonMapper.ToObject<SaveGlobalObject> (json);

				sr.Close ();
				fs.Close ();

				NovelSingleton.GameManager.globalSetting = obj;

			}

			//グローバル変数を格納する
			StatusManager.variable.replaceAll("global",NovelSingleton.GameManager.globalSetting.globalVar);

			StatusManager.variable.trace ("global");

		}

		//一時退避しておいたスナップから保存を実行する
		public void saveFromSnap(string name){
		
			//一時領域からデータ取得
			string path = storagePath + "/savesnap.sav";
			object obj = LoadFromBinaryFile (path);
			if (obj == null) {
			
			} else {
				SaveObject sobj = (SaveObject)LoadFromBinaryFile (path);
				string w_path = storagePath + "/"+name+".sav";
				SaveToBinaryFile(sobj, w_path);
			}

		}

		//plus が true の場合は、一つ進めたところをロードさせる。sleepgameの後とか戻ってきた時用
		public void save(string save_name,bool plus =false){

			SaveObject sobj = new SaveObject ();
			sobj.name = save_name;
			//タイトルとか、基本情報を格納
			sobj.title = NovelSingleton.GameManager.scene.messageForSaveTitle;
			sobj.date = DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss");
			sobj.currentMessage = NovelSingleton.GameManager.scene.messageForSaveTitle;

			sobj.dicImage = NovelSingleton.GameManager.imageManager.dicImage;
			sobj.dicTag   = NovelSingleton.GameManager.imageManager.dicTag;
			sobj.dicEvent = NovelSingleton.GameManager.eventManager.dicEvent;
			sobj.scenarioManager = NovelSingleton.GameManager.scenarioManager;
			sobj.variable = StatusManager.variable;
			sobj.currentFile = StatusManager.currentScenario;
			sobj.currentIndex = NovelSingleton.GameManager.CurrentComponentIndex;
			sobj.logManager = NovelSingleton.GameManager.logManager;

			//ステータス
			sobj.visibleMessageFrame = StatusManager.visibleMessageFrame;
			sobj.enableNextOrder = StatusManager.enableNextOrder;
			sobj.enableEventClick = StatusManager.enableEventClick;
			sobj.enableClickOrder = StatusManager.enableClickOrder;
			sobj.currentPlayBgm = StatusManager.currentPlayBgm;
			sobj.isEventStop = StatusManager.isEventStop;

			//画面のキャプチャを作成して保存する
			//保存先のパス

			if (plus == true) {
				sobj.currentIndex++;
			}

			//sobjをシリアライズ化して保存 

			string path = storagePath + "/"+save_name+".sav";

			SaveToBinaryFile(sobj, path);

		}

		public void SaveToBinaryFile(SaveObject obj, string path)
		{

			string json = LitJson.JsonMapper.ToJson (obj);

			//WebPlayer の場合保存方法に変化を入れる
			if (Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.OSXWebPlayer) {

				PlayerPrefs.SetString(path, json);

			} else {


				if (!Directory.Exists(storagePath))
				{
					Directory.CreateDirectory(storagePath);
				}

				FileStream fs = new FileStream(path,
					FileMode.Create,
					FileAccess.Write);

				StreamWriter sw = new StreamWriter(fs);
				sw.Write(json);
				sw.Flush ();
				sw.Close ();
				fs.Close();

			}
		}

		public object LoadFromBinaryFile(string path)
		{

			//WebPlayer の場合保存方法に変化を入れる
			if (Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.OSXWebPlayer) {

				string json = PlayerPrefs.GetString (path);
				SaveObject obj = LitJson.JsonMapper.ToObject<SaveObject> (json);

				return obj;

			} else {

				if (!File.Exists (path)) {
					return null;
				}

				FileStream fs = new FileStream (path,
					               FileMode.Open,
					               FileAccess.Read);

				StreamReader sr = new StreamReader (path, System.Text.Encoding.Default);
				string json = sr.ReadToEnd ();

				if (json == "") {
					return null;
				}

				SaveObject obj = LitJson.JsonMapper.ToObject<SaveObject> (json);

				sr.Close ();
				fs.Close ();

				return obj;

			}


		}

		public SaveObject getSaveData(string data_name){
		
			string path = storagePath + "/"+data_name+".sav";

			SaveObject obj = (SaveObject)LoadFromBinaryFile (path);

			return obj;
		
		}

		public void applySaveVariable(string save_name, string var_name="save"){

			//最初のセーブデータを取得するか。
			SaveObject sobj =  NovelSingleton.SaveManager.getSaveData(save_name);
			//this.gameManager.saveManager.getSaveData ("save_"+current_index);
			StatusManager.variable.set (var_name+".name", save_name);

			if (sobj != null) {

				StatusManager.variable.set (var_name+".title", sobj.title);
				StatusManager.variable.set (var_name+".date", sobj.date);
				StatusManager.variable.set (var_name+".description", sobj.description);
				StatusManager.variable.set (var_name+".name", save_name);
				//StatusManager.variable.set ("save.img", sobj.cap_img_file);

			} else {

				StatusManager.variable.set (var_name+".title", "データがありません");
				StatusManager.variable.set (var_name+".date", "" );
				StatusManager.variable.set (var_name+".description", "");
				StatusManager.variable.set (var_name+".name", save_name);
				//StatusManager.variable.set ("save.img", "");

			}


		}

		/*		

		public string Base64FromStringComp(string st)
		{
			// 文字列をバイト配列に変換します
			byte[] source = Encoding.UTF8.GetBytes(st);
			return this._Base64FromStringComp(source);

		}

		public string _Base64FromStringComp(byte[] source)
		{



			// 入出力用のストリームを生成します
			MemoryStream ms = new MemoryStream();
			DeflateStream CompressedStream = new DeflateStream(ms, CompressionMode.Compress);

			// ストリームに圧縮するデータを書き込みます
			CompressedStream.Write(source, 0, source.Length);
			CompressedStream.Close();

			// 圧縮されたデータを バイト配列で取得します
			byte[] destination = ms.ToArray();

			//Base64で文字列に変換
			string base64String;
			base64String = System.Convert.ToBase64String(destination, Base64FormattingOptions.InsertLineBreaks);

			return base64String;
		}

//------------------------------------------
//BASE64文字列を戻し解凍の上で文字列に変換して返す
//
//------------------------------------------
		public string StringFromBase64Comp(string st)
		{
			Debug.Log (st);
			#region BASE64文字列を圧縮バイナリへ戻す
			byte [] bs = System.Convert.FromBase64String(st);
			#endregion

			#region 圧縮バイナリを文字列へ解凍する

			// 入出力用のストリームを生成します
			MemoryStream ms = new MemoryStream(bs);
			MemoryStream ms2 = new MemoryStream();

			DeflateStream CompressedStream = new DeflateStream(ms, CompressionMode.Decompress);

			//　MemoryStream に展開します
			while (true)
			{
				int rb = CompressedStream.ReadByte();
				// 読み終わったとき while 処理を抜けます
				if (rb == -1)
				{
					break;
				}
				// メモリに展開したデータを読み込みます
				ms2.WriteByte((byte)rb);
			}

			string result = Encoding.UTF8.GetString(ms2.ToArray());
			#endregion

			return result;
		}
		*/

	}

}