/**********************************************


WARNING !!!!

このファイルはダミークラスです。
Live2DをJOKERで使用する場合はLive2Dプラグインパッケージをインポートして
このファイルを上書きしてください


**************************************************/


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;


namespace Novel{

	public class Live2dObject : AbstractObject {

		//foreとbackを持つ
		//private string name;

		private GameObject live2dModel;
		private bool isShow = false;



		//イメージオブジェクト新規作成
		public Live2dObject(){
			this.gameManager = NovelSingleton.GameManager;
		}


	}


}