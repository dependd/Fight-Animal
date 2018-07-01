using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


namespace Novel{

	[Serializable]
	public class LogManager  {

		public List<string> arrLog = new List<string>();
		public int lognum = -1;

		public LogManager(){

		}

		public void addLog(string name,string name_color,string text){

			GameManager gameManager = NovelSingleton.GameManager;

			string str = "";
			str += "<color=#"+name_color+">"+name+"</color>\n"+text+""; 

			if (this.lognum == -1) {
				this.lognum = int.Parse(gameManager.getConfig ("backlogNum"));
			}

			this.arrLog.Add (str);

			//上限を超えていたら指定分の配列を削除する
			if (this.lognum+10 < this.arrLog.Count) {
				this.arrLog.RemoveRange (0, 10);
			}

		}

		//ログ配列データ取得
		public List<string> getLogList(){

			return this.arrLog;

		}

		public string getLogText(){

			string logtext = "";

			this.arrLog.Reverse();

			foreach (string item in this.arrLog)

			{

				logtext += item +"\n\n";

			}

			this.arrLog.Reverse();

			return logtext;
		}
	}


}