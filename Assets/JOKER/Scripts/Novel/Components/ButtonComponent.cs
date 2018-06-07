﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Novel
{

	/*		
--------------

[doc]
tag=button_new
group=ボタン関連
title=ボタンの定義

[desc]
画面にボタンを配置します
ボタンに対してイベントを関連付けて使用してください。

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


[sample]
@button_new name="test" anchor="MiddleLeft" val="ボタンのテキスト内容" x=100 y=100

;テキストの表示
@button_show name="test"

;imageタグでも表示することができます
@button_show name="test"


[param]
name=識別するための名前を指定します
storage=ボタンに使用する画像を指定します
val=ボタンにテキストを載せたい場合、文字列を指定します
tag=タグ名を指定できます
layer=表示させるレイヤを指定します。画面の背面から順に、background,Default,character,message,front が指定できます。デフォルトはDefaultが指定されます
sort=同一レイヤ内の表示順を整数で指定してください
x=中心からのx位置を指定します
y=中心からのy位置を指定します
z=中心からのz位置を指定します
scale_x=X方向へのボタンの拡大率を指定します。
scale_y=Y方向へのボタンの拡大率を指定します。
width=ボタンの横幅を指定します（必ずheightとセットで指定します）
height=ボタンの高さを指定します（必ずwidthとセットで指定します）
scale=ボタンの拡大率を指定します。つまり2と指定すると大きさが２倍になります
anchor=テキストの位置を指定できます
color=テキストの色を16進数形式で指定します
fontsize=フォントサイズを指定します
cut=数値を指定します。指定した文字数でカットします。


[_doc]
	  --------------------
	  */

	public class Button_newComponent:AbstractComponent
	{
		protected string imagePath = "";

		public Button_newComponent ()
		{

			this.imagePath = GameSetting.PATH_IMAGE;


			//必須項目
			this.arrayVitalParam = new List<string> {
				"name",
				"storage"
			};

			this.originalParam = new Dictionary<string,string> () {

				{ "name","" },
				{ "val","" },
				{ "tag","" },
				{ "storage","" },
				{ "layer","Default" },
				{ "sort","0" },
				{ "x","0" },
				{ "y","0" },
				{ "z","-3.2" },
				{ "scale","" },
				{ "scale_x","1" },
				{ "scale_y","1" },
				{ "scale_z","1" },

				{ "width",""},
				{ "height",""},

				{ "anchor","MiddleCenter" },
				//{ "alignment","Center" },
				{ "color","FFFFFF" },
				{ "fontsize","24" },
				{ "cut","" },
				{ "imagePath",GameSetting.PATH_IMAGE},
				{ "path","false"}


			};

		}

		public override void start ()
		{

			this.param ["className"] = "Button";

			if (this.param ["scale"] != "") {

				this.param ["scale_x"] = this.param ["scale"];
				this.param ["scale_y"] = this.param ["scale"];
				this.param ["scale_z"] = this.param ["scale"];

			} else {
				this.param ["scale"] = "1";
			}

			/*
			if (this.param ["width"] == "") {
				this.param ["width"] = "0";
			}

			if (this.param ["height"] == "") {
				this.param ["height"] = "0";
			}
			*/

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
tag=button_pos
group=ボタン関連
title=ボタンの表示位置設定

[desc]
button_newで定義したボタンの表示位置を指定することができます。

[sample]
[button_pos name="logo" x=0 y=0.5 ]

[param]
name=識別するための名前を指定します
x=中心からのx位置を指定します
y=中心からのy位置を指定します

[_doc]
--------------------
 */

	//キャラのポジションを変更する
	public class Button_posComponent:Image_posComponent
	{
		public Button_posComponent () : base ()
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
tag=button_show
group=ボタン関連
title=ボタンを表示します。

[desc]
button_newで定義したボタンを表示します

[sample]

;ロゴを表示
[button_show name=logo ]

;tagを指定して複数画像を一斉に表示することも可能
[button_show tag=logo time=3 wait=false]

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


	public class Button_showComponent:Image_showComponent
	{
		public Button_showComponent () : base ()
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
tag=button_hide
group=ボタン関連
title=ボタンを非表示にします

[desc]
button_newで定義した画像を非表示にします。

[sample]
;name ボタンを表示
[button_show name=logo ]

;tagを指定して複数画像を一斉に表示することも可能
[button_hide name=logo time=3 wait=false]


[param]
name=識別するための名前を指定します
tag=識別するためのタグを指定します
time=非表示にかかる時間を秒で指定します。デフォルトは１（秒）です
wait=非表示の完了を待つかどうかを true false で指定します。デフォルトは true です。
type=非表示のされ方をしていできます。デフォルトはlinear です。

[_doc]
--------------------
 */

	public class Button_hideComponent:Image_hideComponent
	{
		public Button_hideComponent () : base ()
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
tag=button_mod
group=ボタン関連
title=ボタンを変更します

[desc]
button_newで定義したボタンの情報を変更します。

[sample]
;ロゴを表示
[button_show name=logo ]

[button_mod name=logo val="変更後テキスト"]


[param]
name=識別するための名前を指定します
val=テキスト文字列を入力します
time=変更にかかる時間を秒で指定します。デフォルトは１（秒）です
wait=変更を待つかどうかを true false で指定します。デフォルトは true です。
type=変更のされ方を指定できます。デフォルトはlinear です。

[_doc]
--------------------
 */


	public class Button_modComponent:Image_modComponent
	{
		public Button_modComponent ()
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
tag=button_remove
group=ボタン関連
title=ボタンの削除

[desc]
ボタン定義を削除します。

[sample]
[button_remove name="yuko"]

[param]
name=削除するテキストオブジェクト名 



[_doc]
--------------------
 */
	//IComponentTextはテキストを流すための機能を保持するためのインターフェース
	public class Button_removeComponent:Image_removeComponent
	{
		public Button_removeComponent ()
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

