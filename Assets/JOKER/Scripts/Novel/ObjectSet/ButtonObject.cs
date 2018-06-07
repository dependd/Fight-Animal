using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using System.IO;


namespace Novel{

	public class ButtonObject : AbstractObject {

		//private string name;

		private Button targetButton ;
		private Text   targetText;

		private bool isShow=false;

		public string filename = "";

		//イメージオブジェクト新規作成
		public ButtonObject(){
			this.gameManager = NovelSingleton.GameManager;
		}

		public override void init(Dictionary<string,string> param){

			this.param = param;

			GameObject g = Resources.Load(GameSetting.PATH_PREFAB + "Button") as GameObject;
			GameObject canvas = GameObject.Find ("Canvas") as GameObject;

			this.rootObject = (GameObject)Instantiate(g,new Vector3(0,0.5f,-3.2f),Quaternion.identity); 
			this.rootObject.name = param ["name"];
			this.rootObject.transform.parent = canvas.transform;


			this.targetText = this.rootObject.GetComponentInChildren<Text> ();
			this.targetButton = this.rootObject.GetComponentInChildren<Button> ();

			this.targetText.alignment = TextEnum.textAnchor (this.param ["anchor"]);
			//TextEnum.textAlignment(this.param["alignment"]);
			//this.targetText.anchor    = TextEnum.textAnchor(this.param["anchor"]);

			string color = this.param ["color"];

			Color objColor =  ColorX.HexToRGB(color);
			objColor.a = 0;
			this.targetText.color = objColor;

			this.targetText.fontSize = int.Parse(this.param ["fontsize"]);


			/*
			this.guiScaler = new GuiScaler (guiText);
			this.rootObject.name = this.name;
			*/
			/*
			if (this.param ["layer"] == "ui") {
				//タグをつける
				this.rootObject.tag = "ui";
			}
			*/

		}

		public override void set(Dictionary<string,string> param){

			if (this.rootObject == null) {
				this.init (param);
			}

			string text = this.param["val"];

			if (this.param ["cut"] != "") {
				int cut = int.Parse (this.param ["cut"]);
				if (cut < text.Length) {
					text = text.Substring (0,cut);

					this.param ["val"] = text;

				}
			}

			this.rootObject.GetComponentInChildren<Text> ().text = text;

			//イメージ ここのpathは廃止の方向で
			if (this.param.ContainsKey ("path") && this.param ["path"] == "true") {

				if (this.param ["storage"] != "") {

					#if(!UNITY_WEBPLAYER)

					/*
					byte[] bytes = File.ReadAllBytes(this.param["storage"]);

					Texture2D texture = new Texture2D (0, 0);
					texture.LoadImage (bytes);
					this.targetButton.image = texture;
					*/

					#else



					#endif

				} else {
					//画像がない場合はデフォルトの未設定のファイルを見せるか。。
				}

			} else {

				if (param ["storage"] != "") {

					string filename = this.imagePath + param ["storage"];
					this.filename = filename;
					Sprite imageSprite = Resources.Load<Sprite> (filename);

					//scale の調整
					this.targetButton.image.overrideSprite = imageSprite;
					this.targetButton.image.SetNativeSize ();

				}

				//width の設定
				if (param["width"] !="" && param["height"] !="" ) {
					this.targetButton.GetComponent<RectTransform> ().sizeDelta = new Vector2(float.Parse (param ["width"]),float.Parse (param ["height"]));
				}

			}


			//クリックされた時
			this.targetButton.onClick.AddListener (() => {

				Debug.Log("clicked---:"+this.rootObject.name);
				this.gameManager.eventManager.checkEvent(this.rootObject.name,"click");

				//この次のイベントは止める check
				//StatusManager.isEventButtonStop = true;
				StatusManager.inUiClick = true;
				//イベントチェック

				//Debug.Log ("Clicked.-------------------");
					
			});

		}


		public override void setColider(){

			/*
			if (this.targetButton != null) {

				Debug.Log ("geeeeeeeeeeeeeeeeeee");

				this.rootObject.AddComponent<BoxCollider2D> ();
				BoxCollider2D b = this.rootObject.GetComponent<BoxCollider2D> ();
				b.isTrigger = true;
				if (this.isShow == true) {
					b.enabled = true;
				} else {
					b.enabled = false;
				}

				Vector2 size = new Vector2 (this.targetButton.GetComponent<RectTransform>().sizeDelta.x, this.targetButton.GetComponent<RectTransform>().sizeDelta.y);
				b.size = size;

			}
			*/


		}

		public override void setPosition(float x,float y,float z){
			this.targetButton.GetComponent<RectTransform>().localPosition = new Vector3(x,y,z);
		
		}


		public override void show(float time,string easeType){

			this.isShow = true;

			//通常の表示切り替えの場合
			iTween.ValueTo(this.gameObject,iTween.Hash(
				"from",0,
				"to",1,
				"time",time,
				"oncomplete","finishAnimation",
				"oncompletetarget",this.gameObject,
				"easeType",easeType,
				"onupdate","crossFade"
			));



		}

		public override void hide(float time,string easeType){

			this.isShow = false;

			//BoxCollider2D b = this.rootObject.GetComponent<BoxCollider2D> ();
			//b.enabled = false;

			//通常の表示切り替えの場合
			iTween.ValueTo(this.gameObject,iTween.Hash(
				"from",1,
				"to",0,
				"time",time,
				"oncomplete","finishAnimation",
				"oncompletetarget",this.gameObject,
				"easeType",easeType,
				"onupdate","crossFade"
			));

		}



		private void crossFade(float val){

			var color = this.rootObject.GetComponentInChildren<Text> ().color;
			color.a = val;
			this.rootObject.GetComponentInChildren<Text> ().color = color;
			this.rootObject.GetComponent<UnityEngine.UI.Image>().color = color;


		}



		//アニメーションの終了をいじょうするための
		private void finishAnimation ()
		{

			if (this.completeDeletgate != null) {
				this.completeDeletgate ();
			}

		}


		// Use this for initialization
		void Start () {


		}

		// Update is called once per frame
		void Update () {


			if (Input.GetMouseButtonDown (0)) {
			
			}

		}

	}


}