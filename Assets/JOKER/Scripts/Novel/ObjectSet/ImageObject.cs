﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;


namespace Novel{

	public class ImageObject : AbstractObject {

		//foreとbackを持つ
		//private string name;

		private GameObject spriteFore;
		private GameObject spriteBack;

		private SpriteRenderer spriteRenderFore;
		private SpriteRenderer spriteRenderBack;

		private Sprite targetSprite ;

		private bool isShow = false;

		public string filename = "";

		//イメージオブジェクト新規作成
		public ImageObject(){
			this.gameManager = NovelSingleton.GameManager;
		}

		public override void init(Dictionary<string,string> param){

			this.param = param;
		 
			GameObject g = Resources.Load(GameSetting.PATH_PREFAB + "Image") as GameObject;
			this.rootObject = (GameObject)Instantiate(g,new Vector3(0,0f,-3.2f),Quaternion.identity); 

			this.rootObject.name = this.name;

			//サイズを指定できる

			this.spriteFore = this.rootObject.transform.Find("fore").gameObject;
			this.spriteBack = this.rootObject.transform.Find("back").gameObject;

			this.spriteRenderFore = this.spriteFore.GetComponent<SpriteRenderer> ();
			this.spriteRenderBack = this.spriteBack.GetComponent<SpriteRenderer> ();

			//Layerの設定
			this.spriteRenderFore.sortingLayerName = this.param ["layer"];
			this.spriteRenderFore.sortingOrder = int.Parse(this.param ["sort"]);

			this.spriteRenderBack.sortingLayerName = this.param ["layer"];
			this.spriteRenderBack.sortingOrder = int.Parse(this.param ["sort"]);


		}

		public override void set(Dictionary<string,string> param){

			if (this.rootObject == null) {
				this.init (param);
			}

			if (this.param.ContainsKey ("path") && this.param ["path"] == "true") {

				if (this.param ["storage"] != "") {

					#if(!UNITY_WEBPLAYER)

					byte[] bytes = File.ReadAllBytes(this.param["storage"]);

					Texture2D texture = new Texture2D (0, 0);
					texture.LoadImage (bytes);
					this.targetSprite = Sprite.Create (texture, new Rect (0, 0, Screen.width, Screen.height), new Vector2 (1f, 1f));

					#else



					#endif

				} else {
					//画像がない場合はデフォルトの未設定のファイルを見せるか。。
				}

			} else {
				string filename = this.imagePath + param ["storage"];
				this.filename = filename;
				this.targetSprite = Resources.Load<Sprite> (filename);
			}
			SpriteRenderer sr_back = this.spriteBack.GetComponent<SpriteRenderer> ();
			sr_back.sprite = this.targetSprite;


			if (this.param ["layer"] == "background") {

				//背景の場合、サイズを画面いっぱいにする
				SpriteRenderer sr = this.spriteRenderBack;

				float x = sr.sprite.bounds.size.x;
				float y = sr.sprite.bounds.size.y; 

				float worldScreenHeight = Camera.main.orthographicSize * 2;
				float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

				this.spriteRenderBack.transform.localScale = new Vector3 (
					worldScreenWidth / x,
					worldScreenHeight / y, 1);

							
				this.spriteRenderFore.transform.localScale = new Vector3 (
					worldScreenWidth / x,
					worldScreenHeight / y, 1);

			} else {


			}
		}

		public override void setColider(){

			if (this.targetSprite != null) {
			
				this.rootObject.AddComponent<BoxCollider2D> ();
				BoxCollider2D b = this.rootObject.GetComponent<BoxCollider2D> ();
				b.isTrigger = true;
				if (this.isShow == true) {
					b.enabled = true;
				} else {
					b.enabled = false;
				}

				Vector2 size = new Vector2 (this.targetSprite.bounds.size.x, this.targetSprite.bounds.size.y);
				b.size = size;
			
			}

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
				"onupdate","crossFadeShow"
			));


			//アニメーション開始
			/*
			Animation ani_fore = this.spriteFore.GetComponent<Animation> ();
			Animation ani_back = this.spriteBack.GetComponent<Animation> ();

			ani_fore.Play ();
			ani_back.Play ("TransShow");

			//メソッドの登録
			CompleteDelegate completeDeletgate = this.finishAnimation;
			this.gameManager.scene.coroutineAnimation (ani_back, completeDeletgate);	
			*/

		}

		public override void hide(float time,string easeType){

			this.isShow = false;

			BoxCollider2D b = this.rootObject.GetComponent<BoxCollider2D> ();
			if (b != null) {
				b.enabled = false;
			}
			//通常の表示切り替えの場合
			iTween.ValueTo(this.gameObject,iTween.Hash(
				"from",1,
				"to",0,
				"time",time,
				"oncomplete","finishAnimation",
				"oncompletetarget",this.gameObject,
				"easeType",easeType,
				"onupdate","crossFadeHide"
			));

		}


		private void crossFadeShow(float val){

			var color_back = this.spriteRenderBack.color;
			color_back.a = val;
			this.spriteRenderBack.color = color_back;

			var color_fore = this.spriteRenderFore.color;
			color_fore.a = 1-val;
			this.spriteRenderFore.color = color_fore;


		}


		private void crossFadeHide(float val){

			var color_fore = this.spriteRenderFore.color;
			color_fore.a = val;
			this.spriteRenderFore.color = color_fore;


		}



		//アニメーションの終了をいじょうするための
		private void finishAnimation ()
		{

			SpriteRenderer sr_fore = this.spriteFore.GetComponent<SpriteRenderer> ();
			SpriteRenderer sr_back = this.spriteBack.GetComponent<SpriteRenderer> ();

			//全面に今回適応した背景の画像を配置する
			BoxCollider2D b = this.rootObject.GetComponent<BoxCollider2D> ();

			if (this.isShow == true) {
				//表示の時
				sr_fore.sprite = this.targetSprite;
				sr_fore.color = new Color (1, 1, 1, 1);

				if (b != null) {
					b.enabled = true;
				}


			} else {

				//sr_fore.sprite = this.targetSprite;
				sr_fore.sprite = null;
				sr_fore.color = new Color (1, 1, 1, 0);
				if (b != null) {
					b.enabled = false;
				}

			}

			sr_back.color = new Color (1, 1, 1, 0);

			//sr_back.sprite = null;

			if (this.completeDeletgate != null) {
				this.completeDeletgate ();
			}

		}


		// Use this for initialization
		void Start () {


		}
		
		// Update is called once per frame
		void Update () {

		}

	}


}