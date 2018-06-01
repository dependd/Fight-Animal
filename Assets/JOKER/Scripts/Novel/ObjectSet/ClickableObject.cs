using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;



namespace Novel{

	public class ClickableObject : AbstractObject {

		//foreとbackを持つ
		//private string name;

		private GameObject image;

		private SpriteRenderer spriteRenderImage;

		//private Sprite targetSprite ;
		private bool isShow = true;

		public string filename = "";


		//イメージオブジェクト新規作成
		public ClickableObject(){
			this.gameManager = NovelSingleton.GameManager;
		}

		public override void init(Dictionary<string,string> param){


			this.param = param;

			GameObject g = Resources.Load(GameSetting.PATH_PREFAB + "Clickable") as GameObject;
			this.rootObject = (GameObject)Instantiate(g,new Vector3(0,0f,-3.2f),Quaternion.identity); 
			this.rootObject.name = this.name;

			this.image = g;

			this.spriteRenderImage = this.image.GetComponent<SpriteRenderer> ();

			//this.targetSprite = this.spriteRenderImage.sprite;

			Color tmp = this.spriteRenderImage.color;
			tmp.a = float.Parse (this.param ["a"]);

			//ソート位置を調整
			this.rootObject.GetComponent<SpriteRenderer> ().sortingOrder = int.Parse (this.param["sort"]);
			this.rootObject.GetComponent<SpriteRenderer> ().color = tmp;
			//this.spriteRenderImage.color = tmp;
			//透明度を設定できる


		}

		public override void set(Dictionary<string,string> param){

			if (this.rootObject == null) {
				this.init (param);
			}


		}

		public override void setColider(){

			this.rootObject.AddComponent<BoxCollider2D> ();
			BoxCollider2D b = this.rootObject.GetComponent<BoxCollider2D> ();
			b.isTrigger = true;
			if (this.isShow == true) {
				b.enabled = true;
			} else {
				b.enabled = false;
			}

			/*
			var sr = this.rootObject.GetComponent<SpriteRenderer> ();

			Vector2 size = new Vector2 (sr.bounds.size.x, sr.bounds.size.y);
			b.size = size;
			*/
		}


		public override void show(float time,string easeType){

			this.isShow = true;

			//通常の表示切り替えの場合
			iTween.ValueTo(this.gameObject,iTween.Hash(
				"from",0,
				"to",float.Parse(this.param["a"]),
				"time",time,
				"oncomplete","finishAnimation",
				"oncompletetarget",this.gameObject,
				"easeType",easeType,
				"onupdate","crossFade"
			));

		}

		public override void setScale(float scale_x, float scale_y, float scale_z){

			this.rootObject.transform.localScale = new Vector3 (scale_x, scale_y, 1);

		}


		public override void hide(float time,string easeType){

			this.isShow = false;

			BoxCollider2D b = this.rootObject.GetComponent<BoxCollider2D> ();
			if (b != null) {
				b.enabled = false;
			}
			//通常の表示切り替えの場合
			iTween.ValueTo(this.gameObject,iTween.Hash(
				"from",float.Parse(this.param["a"]),
				"to",0,
				"time",time,
				"oncomplete","finishAnimation",
				"oncompletetarget",this.gameObject,
				"easeType",easeType,
				"onupdate","crossFade"
			));



		}


		private void crossFade(float val){

			var color = this.spriteRenderImage.color;
			color.a = val;
			this.image.GetComponent<SpriteRenderer> ().color = color;

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

		}

	}


}