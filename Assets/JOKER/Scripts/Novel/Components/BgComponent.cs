﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Novel{


	/*	
--------------

[doc]
tag=bg_new
group=イメージ関連
title=背景を作製

[desc]
新しく背景を定義します。
通常は１度だけ定義しておくことで場面の切り替えなどが実現できます。
複数の背景を定義して組み合わせることで高度な演出を実現することも可能です。
画像ファイルはbackgroundフォルダ以下に配置してください。
[sample]

;背景を定義 
[bg_new storage="room"]

;背景を表示します
[bg_show ]

;名前を指定して表示することも可能
[bg_new name="test" storage="room"]

;背景を表示します
[bg_show name="test" ]

[param]
name=識別するための名前を指定します
storage=画像ファイルを指定します。ファイルはbackgroundフォルダに格納してください
tag=タグ名を指定できます
layer=表示レイヤです。通常は変更しないでください
sort=同一レイヤ内の表示順を整数で指定してください
x=中心からのx位置を指定します
y=中心からのy位置を指定します
scale_x=X方向へのイメージの拡大率を指定します。
scale_y=Y方向へのイメージの拡大率を指定します。
scale=イメージの拡大率を指定します。つまり2と指定すると大きさが２倍になります

[_doc]
--------------------
 */

	public class Bg_newComponent:Image_newComponent
	{
		public Bg_newComponent ():base()
		{

			//必須項目
			this.arrayVitalParam = new List<string> {
				"storage" 
			};


			//画像のルートパスが異なってくる
			base.imagePath = GameSetting.PATH_BG_IMAGE;

		}

		public override void start ()
		{
			if (this.param ["name"] == "") {
				this.param["name"] = "background";
			}

			this.param ["layer"] ="background";
			this.param ["imagePath"] = GameSetting.PATH_BG_IMAGE;

			base.start ();

		}

	}

	//背景のポジションを変更する
	public class Bg_posComponent:Image_posComponent
	{
		public Bg_posComponent ():base()
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
tag=bg_show
group=イメージ関連
title=背景を表示します。

[desc]
bg_newで定義した背景を表示します

[sample]

;背景を定義 
[bg_new storage="room"]

;背景を表示します
[bg_show ]

[param]
name=識別するための名前を指定します
tag=識別するためのタグを指定します
x=中心からのx位置を指定します
y=中心からのy位置を指定します
time=表示にかかる時間を秒で指定します。デフォルトは１（秒）です
wait=表示の完了を待つかどうかを true false で指定します。デフォルトは true です。
type=表示のされ方を指定できます。

[_doc]
--------------------
 */

	//IComponentTextはテキストを流すための機能を保持するためのインターフェース
	public class Bg_showComponent:Image_showComponent
	{
		public Bg_showComponent ():base()
		{

		}


		public override void start ()
		{
			if (this.param ["name"] == "") {
				this.param["name"] = "background";
			}
			base.start ();


		}


	}


	/*	
--------------

[doc]
tag=bg_hide
group=イメージ関連
title=背景を非表示にします

[desc]
bg_newで定義した背景を非表示にします。

[sample]

[bg_show  ]
[bg_hide wait=false]


[param]
name=識別するための名前を指定します
tag=識別するためのタグを指定します
time=非表示にかかる時間を秒で指定します。デフォルトは１（秒）です
wait=非表示の完了を待つかどうかを true false で指定します。デフォルトは true です。
type=非表示のされ方を指定できます。デフォルトはlinear です。

[_doc]
--------------------
 */

	public class Bg_hideComponent:Image_hideComponent
	{
		public Bg_hideComponent ():base()
		{

		}


		public override void start ()
		{
			if (this.param ["name"] == "") {
				this.param["name"] = "background";
			}

			base.start ();

		}

	}

	//キャラの表情登録用
	public class Bg_faceComponent:Image_faceComponent
	{
		public Bg_faceComponent ():base()
		{
			base.imagePath = GameSetting.PATH_BG_IMAGE;

		}


		public override void start ()
		{

			base.start ();

		}


	}

	/*	
--------------

[doc]
tag=bg_mod
group=イメージ関連
title=背景を変更します

[desc]
bg_newで定義した画像の情報を変更します。

[sample]
;name ロゴを表示
[bg_show ]

;背景を切り替え
[bg_mod storage="other_bg"]

[param]
name=識別するための名前を指定します
storage=画像ファイル名を直接していできます。フォルダはbackgroundフォルダ 以下を参照します。
time=変更にかかる時間を秒で指定します。デフォルトは１（秒）です
wait=変更を待つかどうかを true false で指定します。デフォルトは true です。
type=変更のされ方を指定できます。デフォルトはlinear です。

[_doc]
--------------------
 */

	//IComponentTextはテキストを流すための機能を保持するためのインターフェース
	public class Bg_modComponent:Image_modComponent
	{
		public Bg_modComponent ():base()
		{
			//必須項目
			this.arrayVitalParam = new List<string> {
			};
		}


		public override void start ()
		{

			this.param ["imagePath"] = GameSetting.PATH_BG_IMAGE;

			if (this.param ["name"] == "") {
				this.param["name"] = "background";
			}

			base.start ();

		}

	}

/*	
--------------

[doc]
tag=bg_remove
group=イメージ関連
title=背景の削除

[desc]
背景定義を削除します。
使用しなくなった背景を削除することにより
メモリを節約することでゲームが快適に動作することができます。
このタグで背景を削除した場合、再度表示するときは
新たに[bg_new]する必要があります。

[sample]
[bg_remove name="room"]

[param]
name=削除する背景を指定します。


[_doc]
--------------------
 */


	public class Bg_removeComponent:Image_removeComponent
	{
		public Bg_removeComponent ():base()
		{


		}


		public override void start ()
		{

			if (this.param ["name"] == "") {
				this.param["name"] = "background";
			}

			base.start ();
		}

	}


}

