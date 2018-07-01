﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Novel
{

	//完了通知用のデリゲートメソッド
	public delegate void CompleteDelegate ();


	public abstract class AbstractComponent
	{
		//デフォルトで定義しておくパラメータ初期値。継承先で定義する
		public Dictionary<string,string> originalParam = new Dictionary<string,string> ();
		public Dictionary<string,string> param = new Dictionary<string,string> ();

		public List<string> arrayVitalParam = new List<string> ();
		protected GameManager gameManager;
		protected GameView gameView;
		public string line;
		public int line_num;
		public string tagName;
		//命令の種類を保持する
		protected Tag tag;
		protected CompleteDelegate finishAnimationDeletgate;

		public AbstractComponent ()
		{


		}

		public void init (Tag tag, int line_num)
		{

			this.tag = tag;
			this.tagName = tag.Name;
			this.gameManager = NovelSingleton.GameManager;
			this.gameView = NovelSingleton.GameView;
			this.line_num = line_num;

			this.finishAnimationDeletgate = this.finishAnimation;


		}

		public void checkVital ()
		{
			//タグから必須項目が漏れていないか、デフォルト値が入ってない場合はエラーとして警告を返す
			foreach (string vital in this.arrayVitalParam) {
				if (this.tag.getParam (vital) == null) {
					//エラーを追加
					string message = "必須パラメータ「" + vital + "」が不足しています";
					gameManager.addMessage(MessageType.Error,this.line_num, message);

				}
			}


		}

		//アニメーション完了時の処理渭城先
		public virtual void finishAnimation(){
			
		}


		//継承先で渡されたパラメータについて正常かどうかをチェックします
		public virtual void validate(){

		}

		//スタート前にかならず実行されます。skip中でも実行されるのでチェックしたい項目があれば、継承先で実装してください
		public virtual void before(){
			
		}

		public virtual void after(){

		}


		//実行前にパラメータを解析して変数を格納する
		public void calcVariable(){

			Dictionary<string,string> tmp_param = new Dictionary<string,string> ();

			//タグに入れる
			foreach (KeyValuePair<string, string> pair in this.originalParam) {


				tmp_param[pair.Key] = ExpObject.replaceVariable (this.originalParam[pair.Key]);

			}

			//タグにデフォルト値を設定中かつ、tag が指定されていない場合
			if(StatusManager.TagDefaultVal != ""){
				if (tmp_param.ContainsKey ("tag") && tmp_param["tag"] =="") {
					tmp_param ["tag"] = StatusManager.TagDefaultVal;
				}
			}

			this.param = tmp_param;


		}

		//パラメータとの差分を確認して、ファイルを作成
		public void mergeDefaultParam ()
		{

			Dictionary<string,string> param = this.tag.getParamByDictionary ();

			//タグに入れる
			foreach (KeyValuePair<string, string> pair in param) {

				this.originalParam [pair.Key] = pair.Value;

				/*
				if (this.param.ContainsKey (pair.Key)) {
					this.param [pair.Key] = pair.Value;
				} else {

					string message = "パラメータ「" + pair.Key + "」は存在しません";
					gameManager.addMessage(MessageType.Warning,this.line_num, message);

				}
				*/

			}

		}

		public void show ()
		{
			Debug.Log ("this is show:" + this.tag.Original);
		}
		//始まった時
		abstract public void start ();
	}

/*

[doc]
tag=story
title=テキスト表示
group=メッセージ関連

[desc]
テキストを表示するタグです。
通常シナリオはタグを使用せずに記述しますが
タグを使用することも可能です

[sample]

;下記２つは全く同一の動作
ストーリーを記述[p]
[story val="ストーリーを記述"]

[param]

val=表示するテキストを指定します

[_doc]

 */
	//IComponentTextはテキストを流すための機能を保持するためのインターフェース
	public class StoryComponent:AbstractComponent
	{
		public StoryComponent ()
		{

			//必須項目
			this.arrayVitalParam = new List<string> {
				"val"
			};

			this.originalParam = new Dictionary<string,string> () {
				{ "val","" }
			};

		}

		public string getText ()
		{

			return "";

		}

		public override void start ()
		{

			string message = this.param["val"];

			StatusManager.enableNextOrder = false;

			this.gameManager.scene.coroutineShowMessage (message);

			//this.gameManager.nextOrder ();

			//Debug.Log(this.tag.getParam("val"));

		}
	}
		
/*
--------------

[doc]
tag=r
group=メッセージ関連
title=改行する

[desc]
改行をします。

[sample]

テキスト表示[r]
２行目テキスト表示[r]
３行目テキスト表示[r]

[param]

[_doc]
--------------------
 */

	//改行命令 [r]
	public class RComponent:AbstractComponent
	{
		public RComponent ()
		{

			this.originalParam = new Dictionary<string,string> () {
			};

		}

		public override void start ()
		{
			//this.gameView.messageArea.guiText.text += "\n";
			this.gameManager.scene.coroutineShowMessage ("\n");

		}
	}

	/*
--------------

[doc]
tag=l
group=メッセージ関連
title=クリック待ち

[desc]
このタグの位置でクリック待ちを行います

[sample]
いち[l]に[l]さん[l][r]


[param]

[_doc]
--------------------
 */

	public class LComponent:AbstractComponent
	{
		public LComponent ()
		{



			//デフォルトのパラメータを指定
			this.originalParam = new Dictionary<string,string> () {
			};

		}

		public override void start ()
		{
			//一旦処理を止めてクリックを待つ
			StatusManager.enableNextOrder = true;

		}
	}

	/*
--------------

[doc]
tag=p
group=メッセージ関連
title=改ページクリック待ち

[desc]
改ページをともなうクリック待ちを行います

[sample]
テキスト表示[p]
１度クリックを待って[l]
２度めのクリックで改ページ[p]

[param]

[_doc]
--------------------
 */

	//改ページをいれて、クリックを待つ [r]
	public class PComponent:AbstractComponent
	{
		public PComponent ()
		{
			this.originalParam = new Dictionary<string,string> () {
				{ "name","" },
				{ "","" }
			};
		}

		public override void start ()
		{
			//一旦処理を止めてクリックを待つ
			StatusManager.enableNextOrder = true;
			this.gameManager.scene.clearCurrentMessage ();

		}
	}

	/*
--------------

[doc]
tag=cm
group=メッセージ関連
title=改ページクリック無し

[desc]
このタグに到達した時点でメッセージをクリアします

[sample]

テキスト表示[p]
ここはクリック待たないで消える[cm]
ここはクリック待ち[p]

[param]

[_doc]
--------------------
 */

	public class CmComponent:AbstractComponent
	{
		public CmComponent ()
		{
			this.originalParam = new Dictionary<string,string> () {
			};
		}

		public override void start ()
		{
			//画面に表示されている文字列も消す

			StatusManager.enableNextOrder = true;
			this.gameManager.scene.clearCurrentMessage ();
			this.gameView.messageArea.text = "";

			this.gameManager.nextOrder ();
		}
	}


	//IComponentTextはテキストを流すための機能を保持するためのインターフェース
	public class NoneComponent:AbstractComponent
	{
		public NoneComponent ()
		{
			this.originalParam = new Dictionary<string,string> () {
				{ "name","" },
				{ "","" }
			};
		
		}

		public string getText ()
		{
		
			return "";
		
		}

		public override void start ()
		{
		
			Debug.Log ("none component start");
		
			//タグのファイルを取得
			Debug.Log (this.tag.Original);
		
		}
	}

}
