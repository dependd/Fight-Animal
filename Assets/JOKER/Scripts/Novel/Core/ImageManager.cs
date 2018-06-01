using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



namespace Novel{

	[Serializable]
	public class Image{

		//セーブ用のパラメータなど、全てココに入れておく必要がある
		public Dictionary<string,string> dicSave = new Dictionary<string,string> ();
	    
		//face 情報はココに格納
		public Dictionary<string,string> dicFace = new Dictionary<string,string> ();


		[NonSerialized]
		private AbstractObject imageObject;


		public string getParam(string key){
			return this.dicSave [key];
		}

		public void setParam(string key,string value){
			this.dicSave [key] = value;
		}

		public Image(){
		}

		public Image(Dictionary<string,string> param){

			this.dicSave ["name"] = param ["name"];
			this.dicSave ["tag"] = param["tag"];
			this.dicSave ["storage"] = param["storage"];
			this.dicSave ["isShow"] ="false";
			this.dicSave ["imagePath"] ="";
			this.dicSave ["className"] ="";
			this.dicSave ["event"] ="false";


			foreach (KeyValuePair<string, string> kvp in param) {

				//paramの内容は上書きしていく
				string key = kvp.Key;
				this.dicSave [key] = param [key];

			}

			//デフォルトの表情として登録
			this.addFace ("default", this.getParam("storage"));

		}

		public void compile(){

			GameObject g = new GameObject ("gameobject");

			AbstractObject imageObject;
			string className = this.dicSave ["className"];

			if (className == "Text") {
	
				imageObject = g.AddComponent<TextObject> ();
			
			} else if (className == "Clickable") {

				imageObject = g.AddComponent<ClickableObject> ();

			} else if (className == "Sd") {

				imageObject = g.AddComponent<SdObject> ();
						
			} else if (className == "Button") {

				imageObject = g.AddComponent<ButtonObject> ();

			} else if (className == "Live2d") {

				imageObject = g.AddComponent<Live2dObject> ();

			}else{
				imageObject = g.AddComponent<ImageObject> ();

			}

			imageObject.name = this.getParam ("name");

			//画像なりをセット
			imageObject.imagePath = this.dicSave["imagePath"];
			imageObject.set (this.dicSave);

			this.imageObject = imageObject;

			//このオブジェクトが表示対象の場合は即表示

			this.setPosition(float.Parse(this.dicSave["x"]),float.Parse(this.dicSave["y"]),float.Parse(this.dicSave["z"]));

			//scale の設定

			this.setScale (float.Parse(this.dicSave["scale_x"]),float.Parse(this.dicSave["scale_y"]),float.Parse(this.dicSave["scale_z"]));

			//イベントが登録されている場合はcolider 登録
			if (this.dicSave ["event"] == "true") {
				this.setColider ();
			}


			if (dicSave ["isShow"] == "true") {

				this.show (0, "linear");

			}

		}

		public void setColider(){
			this.dicSave ["event"] = "true";
			this.getObject ().setColider ();
		}

		public void addFace(string face,string storage){
			this.dicFace [face] = storage;
		}

		public void setFace(string face,float time,string type){

			if (!this.dicFace.ContainsKey (face)) {
				NovelSingleton.GameManager.showError ("表情「" + face + "」は存在しません。");
				//Debug.Log (e.ToString ());
			}

			string storage = this.dicFace [face];

			var tmpParam = new Dictionary<string,string> () {
				{ "storage",storage }
			};

			this.imageObject.set (tmpParam);
			this.imageObject.show (time,type);

		}

		public void setImage(Dictionary<string,string>param){

			foreach (KeyValuePair<string, string> kvp in param) {
				this.dicSave [kvp.Key] = param [kvp.Key];
			}

			this.imageObject.set (param);
			this.imageObject.show (float.Parse(param["time"]),param["type"]);



		}

		public void remove(){
			this.imageObject.remove();
			this.imageObject = null;
		}

		public void setScale(float scale_x, float scale_y, float scale_z){
			this.dicSave ["scale_x"] = ""+scale_x;
			this.dicSave ["scale_y"] = ""+scale_y;
			this.dicSave ["scale_z"] = ""+scale_z;
			this.imageObject.setScale (scale_x,scale_y,scale_z);
		}

		public void setPosition (float x,float y,float z){
		
			this.dicSave ["x"] = ""+x;
			this.dicSave ["y"] = ""+y;
			this.dicSave ["z"] = ""+z;

			this.imageObject.setPosition (x, y, z);
		
		}

		public void animPosition(Vector3 position, float scale,float time,string type ){
		
			this.dicSave ["x"] = ""+position.x;
			this.dicSave ["y"] = ""+position.y;
			this.dicSave ["z"] = "" + position.z;
			this.dicSave ["scale"] = ""+scale;

			this.getObject ().animPosition (position, scale, time, type);


		}

		public void show(float time, string type){
			this.dicSave ["isShow"] ="true";
			this.imageObject.show (time, type);

		}

		public void hide(float time, string type){

			this.dicSave ["isShow"] ="false";
			this.imageObject.hide (time, type);

		}

		public AbstractObject getObject(){
			return this.imageObject;
		}



	}

	//キャラクターマネージャー
	public class ImageManager  {

		public Dictionary<string,Image> dicImage = new Dictionary<string,Image>();
		public Dictionary<string,Dictionary<string,Image>> dicTag = new Dictionary<string,Dictionary<string,Image>>();


		public ImageManager(){

		}

		//キャラクター追加
		public void addImage(Image image){

			//イメージをコンパイルして画面に追加する
			image.compile ();

			string name = image.getParam ("name");
			string tag = image.getParam ("tag");

			this.dicImage[name] = image;

			//タグを追加します
			if (tag != "") {
				if (!this.dicTag.ContainsKey (tag)) {
					this.dicTag [tag] = new Dictionary<string,Image> ();
				}
				this.dicTag [tag][name] =  this.dicImage[name];
			}


		}

		public Image getImage(string name){

			try{
				return this.dicImage [name];
			}catch(System.Exception e){
				NovelSingleton.GameManager.showError ("画像「" + name + "」は存在しません。");
				Debug.Log (e.ToString ());
				return null;
			}
		}

		public void removeImage(string name){

			if (name == "all") {

				foreach (KeyValuePair<string, Image> kvp in this.dicImage) {
				
					string key = kvp.Key;

					Image tmp = this.getImage (key);
					this.removeTag (tmp.getParam("tag"),name);
					tmp.remove ();

					this.dicImage.Remove (key);

					//イベント消去
					NovelSingleton.GameManager.eventManager.removeEvent (key);

				}


			}else{

				Image tmp = this.getImage (name);

				this.removeTag (tmp.getParam("tag"),name);

				this.getImage(name).remove ();

				this.dicImage.Remove (name);


				//イベント消去
				NovelSingleton.GameManager.eventManager.removeEvent (name);

			}
		}

		//タグで一覧を取得
		public List<string> getImageNameByTag(string tag){

			List<string> arrName = new List<string> ();

			//指定したタグが存在しない場合
			if (!this.dicTag.ContainsKey (tag)) {
				NovelSingleton.GameManager.showError ("タグ「"+tag+"」が見つかりません");
				return arrName;
			}

			foreach (KeyValuePair<string, Image> kvp in this.dicTag[tag]) {

				string key = kvp.Key;

				arrName.Add (key);

			}

			return arrName;

		}

		public void removeTag(string tag,string name){

			if(this.dicTag.ContainsKey(tag)){

				List<string > remove_names = new List<string> (); 

				foreach (KeyValuePair<string, Image> kvp in this.dicTag[tag]) {

					string key = kvp.Key;
					if (key == name) {

						remove_names.Add (name);

					}

				}

				foreach (string key in remove_names) {
				
					this.dicTag [tag].Remove(key);
					if (this.dicTag.Count == 0) {
						this.dicTag.Remove (tag);
					}
				
				}


			}

		}

		public void removeTag(string tag){

			if (this.dicTag.ContainsKey (tag)) {

				this.dicTag.Remove (tag);

				/*
				foreach (KeyValuePair<string, Image> kvp in this.dicTag[tag]) {

					if (this.dicTag.ContainsKey (tag)) {
						this.dicTag.Remove (tag);
					}

				}
				*/

			}

		}




		//セーブデータの保存

		/*
		public Dictionary<string,SImage> createSaveData(){

			Dictionary<string,SImage> dicImageSave = new Dictionary <string,SImage> ();

			foreach (KeyValuePair<string, Image> kvp in this.dicImage) {

				SImage simage = new SImage ();
				simage.dicImageObjectParam = this.dicImage [kvp.Key].dicSave;
				simage.dicFace = this.dicImage [kvp.Key].dicFace;

			}

			return dicImageSave;

		}

		*/

	}

	//１つ分のImageデータがはいるよ

	/*
	[Serializable]
	public class SImage{
		public Dictionary<string,string> dicFace;
		public Dictionary<string,string> dicImageObjectParam = new Dictionary <string,string> ();
	}
	*/


}