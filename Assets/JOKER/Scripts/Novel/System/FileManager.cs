using UnityEngine;
using System.Collections;
using System;

namespace Novel{

	public class FileManager
	{
		// Use this for initialization
		void Start ()
		{
			//	Debug.Log ("FileManger 初期化");
		}
		// Update is called once per frame
		void Update ()
		{
	
		}

		public string load (string file_name)
		{

			// TextAssetとして、Resourcesフォルダからテキストデータをロードする
			TextAsset stageTextAsset = Resources.Load ("novel/data/" + file_name) as TextAsset;

			if (stageTextAsset == null) {
				NovelSingleton.GameManager.showError ("ファイル「" + file_name + "」が見つかりませんでした。");
			}

			// 文字列を代入
			string stageData = stageTextAsset.text;
			// 空白を置換で削除

			return stageData;

		}
	}
}