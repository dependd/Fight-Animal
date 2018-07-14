﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Novel
{

	/*	
--------------

[doc]
tag=text_new
group=テキスト関連
title=テキストの定義

[desc]
画面に表示するテキストを新しく定義します

■anchor に指定できる値
LowerCenter
LowerLeft
LowerRight
MiddleCenter
MiddleLeft
MiddleRight
UpperCenter
UpperLeft
UpperRight
MiddleCenter

■alignment に指定できる値
Left
Right
Center

[sample]
@text_new name="test" anchor="MiddleLeft" val="テキスト内容" x=0.227 y=0.205

;テキストの表示
@text_show name="test"

;imageタグでも表示することができます
@image_show name="test"


[param]
name=識別するための名前を指定します
val=表示するテキスト文字列を指定します
tag=タグ名を指定できます
layer=表示させるレイヤを指定します。画面の背面から順に、background,Default,character,message,front が指定できます。デフォルトはDefaultが指定されます
sort=同一レイヤ内の表示順を整数で指定してください
x=中心からのx位置を指定します
y=中心からのy位置を指定します
z=中心からのz位置を指定します
scale=文字の拡大率を指定します。つまり2と指定すると大きさが２倍になります
anchor=テキストの横位置を指定できます
color=テキストの色を16進数形式で指定します
fontsize=フォントサイズを指定します
cut=数値を指定します。指定した文字数でカットします。


[_doc]
	  --------------------
	  */

	public class Text_newComponent:AbstractComponent
	{
		protected string imagePath = "";

		public Text_newComponent ()
		{

			this.imagePath = GameSetting.PATH_IMAGE;


			//必須項目
			this.arrayVitalParam = new List<string> {
				"name",
				"val" 
			};

			this.originalParam = new Dictionary<string,string> () {

				{ "name","" },
				{ "val","" },
				{ "tag","" },
				{ "layer","Default" },
				{ "sort","0" },
				{ "x","0" },
				{ "y","0" },
				{ "z","-3.2" },
				{ "scale","1" },
				{ "anchor","MiddleCenter" },
				{ "color","FFFFFF" },
				{ "fontsize","14" },
				{ "cut","" },



			};

		}

		public override void start ()
		{

			//			string name = this.param ["name"];
			string val = this.param ["val"];
			//			string tag = this.param ["tag"];

			//todo check
			this.param ["storage"] = val;
			this.param ["className"] = "Text";

			this.param ["scale_x"] = this.param ["scale"];
			this.param ["scale_y"] = this.param ["scale"];
			this.param ["scale_z"] = this.param ["scale"];

			Image image = new Image (this.param);
			this.gameManager.imageManager.addImage (image);

			this.gameManager.nextOrder ();

			//this.gameManager.scene.MessageSpeed = 0.02f;
			//this.gameManager.scene.coroutineShowMessage (message);

		}
	}

	/*	
--------------

[doc]
tag=image_pos
group=テキスト関連
title=テキストの表示位置設定

[desc]
text_newで定義したテキストの表示位置を指定することができます。

[sample]
[text_pos name="logo" x=0 y=0.5 ]

[param]
name=識別するための名前を指定します
x=中心からのx位置を指定します
y=中心からのy位置を指定します

[_doc]
--------------------
 */

	//キャラのポジションを変更する
	public class Text_posComponent:Image_posComponent
	{
		public Text_posComponent () : base ()
		{


		}

		public override void start ()
		{
			base.start ();
		}
	}

/*	
--------------

[doc]
tag=text_show
group=テキスト関連
title=テキストを表示します。

[desc]
text_newで定義した画像を表示します

[sample]

;ロゴを表示
[text_show name=logo ]

;tagを指定して複数画像を一斉に表示することも可能
[text_show tag=logo time=3 wait=false]

[param]
name=識別するための名前を指定します
tag=識別するためのタグを指定します
x=中心からのx位置を指定します
y=中心からのy位置を指定します
z=中心からのz位置を指定します
time=表示にかかる時間を秒で指定します。デフォルトは１（秒）です
wait=表示の完了を待つかどうかを true false で指定します。デフォルトは true です。
type=表示のされ方を指定できます。デフォルトはlinear です。

[_doc]

--------------------
 */


	public class Text_showComponent:Image_showComponent
	{
		public Text_showComponent () : base ()
		{

		}

		public override void start ()
		{
			base.start ();
		}
	}

	/*	
--------------

[doc]
tag=text_hide
group=テキスト関連
title=テキストを非表示にします

[desc]
text_newで定義した画像を非表示にします。

[sample]
;name ロゴを表示
[image_show name=logo ]

;tagを指定して複数画像を一斉に表示することも可能
[image_hide name=logo time=3 wait=false]


[param]
name=識別するための名前を指定します
tag=識別するためのタグを指定します
time=非表示にかかる時間を秒で指定します。デフォルトは１（秒）です
wait=非表示の完了を待つかどうかを true false で指定します。デフォルトは true です。
type=非表示のされ方をしていできます。デフォルトはlinear です。

[_doc]
--------------------
 */

	public class Text_hideComponent:Image_hideComponent
	{
		public Text_hideComponent () : base ()
		{

		}

		public override void start ()
		{

			base.start ();

		}
	}


	/*	
--------------

[doc]
tag=text_mod
group=テキスト関連
title=テキストを変更します

[desc]
text_newで定義したテキストの情報を変更します。

[sample]
;ロゴを表示
[text_show name=logo ]

[text_mod name=logo val="変更後テキスト"]


[param]
name=識別するための名前を指定します
val=テキスト文字列を入力します
time=変更にかかる時間を秒で指定します。デフォルトは１（秒）です
wait=変更を待つかどうかを true false で指定します。デフォルトは true です。
type=変更のされ方を指定できます。デフォルトはlinear です。

[_doc]
--------------------
 */


	public class Text_modComponent:Image_modComponent
	{
		public Text_modComponent ()
		{

			//必須項目
			this.arrayVitalParam = new List<string> {
				"name"
			};

			this.originalParam = new Dictionary<string,string> () {
				{ "name","" },
				{ "face","" },
				{ "val",""},
				{ "storage","" },
				{ "time","1" },
				{ "wait","true" },
				{ "type","linear" }
			};

		}

		public override void start ()
		{

			StatusManager.enableNextOrder = false;


			string name = this.param ["name"];
			string val = this.param ["val"];
			this.param ["storage"] = val;

			Image image = this.gameManager.imageManager.getImage (name);

			//textObject.set (this.param);
			image.setImage (this.param);
			this.gameManager.nextOrder ();

			//this.gameManager.scene.MessageSpeed = 0.02f;
			//this.gameManager.scene.coroutineShowMessage (message);

		}

		public override void finishAnimation ()
		{

			//アニメーション完了後にここにくる

			if (this.param ["wait"] == "true") {
				StatusManager.enableNextOrder = true;
				this.gameManager.nextOrder ();
			}

		}
	}


	/*		
--------------

[doc]
tag=text_remove
group=テキスト関連
title=テキストの削除

[desc]
テキスト定義を削除します。

[sample]
[text_remove name="yuko"]

[param]
name=削除するテキストオブジェクト名 all と入力することですべてのキャラクターを削除することができます。



[_doc]
--------------------
 */
	//IComponentTextはテキストを流すための機能を保持するためのインターフェース
	public class Text_removeComponent:Image_removeComponent
	{
		public Text_removeComponent ()
		{

			//必須項目
			this.arrayVitalParam = new List<string> {
				"name"
			};

			this.originalParam = new Dictionary<string,string> () {
				{ "name","" },
			};

		}

		public override void start ()
		{

			string name = this.param ["name"];

			//			Image image = this.gameManager.imageManager.getImage(name);
			this.gameManager.imageManager.removeImage (name);

			this.gameManager.nextOrder ();


		}
	}
}

