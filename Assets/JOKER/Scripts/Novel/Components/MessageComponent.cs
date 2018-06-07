using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


namespace Novel {

	/*	
--------------

[doc]
tag=delay
group=メッセージ関連
title=メッセージ速度

[desc]
メッセージの表示速度を調整できます。
うまく活用することで効果的な演出を行うことが可能です。

一度だけ有効でクリックで元の速度に戻ります。

[sample]

ここは通常通りの速度で表示されます[p]
[delay speed="0.1" ]
ここは文字速度が遅くなって表示されます[p]
]

[param]
speed=１文字が表示される秒数を指定します。

[_doc]
--------------------
 */

	public class DelayComponent:AbstractComponent
	{

		public DelayComponent ()
		{
			//必須項目
			this.arrayVitalParam = new List<string> {
				"speed",
			};

			this.originalParam = new Dictionary<string,string> () {
				{"speed","0.02"}
			};
		}

		public override void start ()
		{

			//this.gameManager.setConfig ("messageSpeed",this.param["speed"]);
			this.gameManager.scene.MessageSpeed = float.Parse (this.param["speed"]);
			this.gameManager.nextOrder ();

		}


	}

	/*	
--------------

[doc]
tag=font
group=メッセージ関連
title=メッセージフォント設定

[desc]
メッセージの色とサイズを変更することができます。
設定は[resetfont]タグに到達するまで有効です。

色についてはHTMLなどで使用する形式を使用でき
あらゆる色を設定することが可能です
色コードについては<a href="http://www.colordic.org/">色見本</>が参考になるかと思います

[sample]

;色を変更します。シャープはあっても無くても良いです。
[font color=#EE1919 ]
ここは色が変更されたメッセージに鳴ります

[resetfont]
ここはもとの色に戻って表示されます。

[param]
color=色コードを指定します。16進数形式で指定してください（例）#FFFFFF
size=フォントサイズを指定します

[_doc]
--------------------
 */

	public class FontComponent:AbstractComponent
	{

		public FontComponent ()
		{
			//必須項目
			this.arrayVitalParam = new List<string> {
			};

			this.originalParam = new Dictionary<string,string> () {
				{"size",""},
				{"color",""},
			};
		}

		public override void start ()
		{

			//this.gameView.messageArea.GetComponent<GUIText> ().guiText.fontSize = int.Parse(this.gameManager.getConfig ("messageFontSize"));

			if (this.param ["size"] != "") {
				int size = int.Parse (this.param["size"]);
				this.gameView.messageArea.GetComponent<Text>().fontSize = size;

			}

			if (this.param ["color"] != "") {
				string color = this.param ["color"];
				this.gameView.messageArea.GetComponent<Text>().color = ColorX.HexToRGB (color);
				StatusManager.currentTextColor = color;

			}

			this.gameManager.nextOrder ();

		}


	}

	/*	
--------------

[doc]
tag=fontreset
group=メッセージ関連
title=メッセージ設定のリセット

[desc]

[font]タグで設定した内容を取り消して、標準の状態に戻します。

[sample]

;色を変更します。シャープはあっても無くても良いです。
[font color=#EE1919 ]

[resetfont]
ここはもと色に戻って表示されます

[param]

[_doc]
--------------------
 */
	public class FontresetComponent:AbstractComponent
	{

		public FontresetComponent ()
		{
			//必須項目
			this.arrayVitalParam = new List<string> {
			};

			this.originalParam = new Dictionary<string,string> () {
			};
		}

		public override void start ()
		{

			//this.gameView.messageArea.GetComponent<GUIText> ().guiText.color = ColorX.HexToRGB (this.gameManager.getConfig ("messageFontColor"));
			this.gameView.messageArea.GetComponent<Text>().color = ColorX.HexToRGB (this.gameManager.getConfig ("messageFontColor"));;

			//this.gameView.messageArea.GetComponent<GUIText> ().guiText.fontSize = int.Parse(this.gameManager.getConfig ("messageFontSize"));
			this.gameView.messageArea.GetComponent<Text> ().fontSize = int.Parse(this.gameManager.getConfig ("messageFontSize"));

			this.gameManager.nextOrder ();

		}


	}

		

}