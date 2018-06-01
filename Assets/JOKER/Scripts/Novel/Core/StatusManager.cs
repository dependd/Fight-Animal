using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ExpressionParser;
using System;
using NCalc;

namespace Novel{

	[Serializable]
	public class ExpObject{

		public string type;
		public string name;
		public string exp;

		public ExpObject(string exp){

			string str_left = "";
			string str_right = "";
			for (var i = 0; i < exp.Length; i++) {
				string c = exp [i].ToString ();
				if (c == "=") {
					str_right = exp.Substring (i+1);
					break;
				}
				str_left += c;

			}

			string[] tmp2 = str_left.Split ('.');

			string variable = tmp2 [0].Trim ();
			string variable_name = tmp2 [1].Trim ();
			string exp_str = str_right.Trim ();

			this.type = variable;
			this.name = variable_name;
			this.exp = exp_str;

		}

		//変数を実際の値に置き換えて返却する
		public static string replaceVariable(string str_right){

			Dictionary<string,string > dicVar = new Dictionary<string,string>();

			bool flag_var_now = false;
			string var_name = "";

			string new_str_right ="";

			Stack<string> var_stack = new Stack<string>(); //２重、３重カッコに対応

			for (var i = 0; i < str_right.Length; i++) {

				string c = str_right [i].ToString ();

				if (flag_var_now == true && c == "}") {

					//変数を格納
					//Debug.Log ("var_name ============");
					//Debug.Log (var_name);
					string var_val = StatusManager.variable.get(var_name);

					if (var_stack.Count == 0) {
						dicVar [var_name] = var_val;
						flag_var_now = false;
						var_name = "";

						new_str_right += var_val;

					} else {
						//var_nameに変数を差し込む
						string stack_var_name = var_stack.Pop ();
						var_name = stack_var_name + var_val;

					}

					//タグが確定
					continue;


				}

				if (c != "{" && flag_var_now == true) {
					var_name += c;
				}

				if (c == "{" && flag_var_now == true) {
					var_stack.Push (var_name);
					var_name = "";
				
				} else if (c == "{" && flag_var_now == false) {

					flag_var_now = true;
					var_name = "";

				} else {

					//タグに文字を追加
					if (flag_var_now == false) {
						new_str_right += c;
					}

				}



			}

			/*
			foreach (KeyValuePair<string, string> kvp in dicVar) {
				string old_var = kvp.Key;
				string new_var = kvp.Value;

				str_right = str_right.Replace ("{" + old_var + "}", new_var);

			}
			*/


			return new_str_right;

		}

		//式をを計算して結果を返す　評価はまた別
		public static string calc(string exp){

			//calc 
			//比較計算とかの場合は、別途

			//文字列比較の場合
			if (exp.IndexOf ("==") != -1) {

				string[] delimiter = { "==" };

				string[] t = exp.Split (delimiter, StringSplitOptions.None);
				string left = t [0].Trim ();
				string right = t [1].Trim ();

				if (left == right) {
					return "true";
				} else {
					return "false";
				}

			} else if (exp.IndexOf ("!=") != -1) {

				string[] delimiter = { "!=" };

				string[] t = exp.Split (delimiter, StringSplitOptions.None);
				string left = t [0].Trim ();
				string right = t [1].Trim ();

				if (left != right) {
					return "true";
				} else {
					return "false";
				}

			} else if (exp.IndexOf (">=") != -1) {

				string[] delimiter = { ">=" };
				string[] t = exp.Split (delimiter, StringSplitOptions.None);
				string left = t [0].Trim ();
				string right = t [1].Trim ();

				if (float.Parse (left) >= float.Parse (right)) {
					return "true";
				} else {
					return "false";
				}


			}else if (exp.IndexOf ("<=") != -1) {
				string[] delimiter = { "<=" };
				string[] t = exp.Split (delimiter, StringSplitOptions.None);
				string left = t [0].Trim ();
				string right = t [1].Trim ();

				if (float.Parse (left) <= float.Parse (right)) {
					return "true";
				} else {
					return "false";
				}

			} else if (exp.IndexOf (">") != -1) {

				string[] delimiter = { ">" };
				string[] t = exp.Split (delimiter, StringSplitOptions.None);
				string left = t [0].Trim ();
				string right = t [1].Trim ();

				if (float.Parse (left) > float.Parse (right)) {
					return "true";
				} else {
					return "false";
				}


			} else if (exp.IndexOf ("<") != -1) {
				string[] delimiter = { "<" };
				string[] t = exp.Split (delimiter, StringSplitOptions.None);
				string left = t [0].Trim ();
				string right = t [1].Trim ();

				if (float.Parse (left) < float.Parse (right)) {
					return "true";
				} else {
					return "false";
				}

			}else if (exp.IndexOf ("*") != -1) {

				string[] delimiter = { "*" };
				string[] t = exp.Split (delimiter, StringSplitOptions.None);
				string left = t [0].Trim ();
				string right = t [1].Trim ();

				float k = float.Parse (left) * float.Parse (right);
				return "" + k;

			} else if (exp.IndexOf ("/") != -1) {

				string[] delimiter = { "/" };
				string[] t = exp.Split (delimiter, StringSplitOptions.None);
				string left = t [0].Trim ();
				string right = t [1].Trim ();

				float k = float.Parse (left) / float.Parse (right);
				return "" + k;

			}else if (exp.IndexOf ("+") != -1) {

				//数値の先頭が-で始まって、かつもう一つ-があれば、計算。それ以外は代入
				if (exp [0] == '+') {
					if (exp.Substring (1).IndexOf ("+") == -1) {
						return exp;
					}else {
						exp = exp.Substring (1);
					}
				}

				string[] delimiter = { "+" };
				string[] t = exp.Split (delimiter, StringSplitOptions.None);
				string left = t [0].Trim ();
				string right = t [1].Trim ();

				float k = float.Parse (left) + float.Parse (right);

				return "" + k;

			} else if (exp.IndexOf ("-") != -1) {

				//数値の先頭が-で始まって、かつもう一つ-があれば、計算。それ以外は代入
				bool flag_minus = false;
				if (exp [0] == '-') {
					if (exp.Substring (1).IndexOf ("-") == -1) {
						return exp;
					} else {
						flag_minus = true;
						exp = exp.Substring (1);
					}
				}

				string[] delimiter = { "-" };
				string[] t = exp.Split (delimiter, StringSplitOptions.None);
				string left = t [0].Trim ();
				string right = t [1].Trim ();

				if (flag_minus == true) {
					left = "-" + left;
				}

				float k = float.Parse (left) - float.Parse (right);

				return "" + k;

			}   else {

				return exp;

			}

		}

	}


	//変数などバリアブルを保持する
	[Serializable]
	public class Variable{

		public Dictionary<string,Dictionary<string,string>> dicVar= new Dictionary<string,Dictionary<string,string>>();

		public void set(string key,string val){

			key = key.Replace ("{", "").Replace ("}", "");

			string[] tmp = key.Split ('.');

			string type = tmp [0].Trim ();
			string variable_name = tmp [1].Trim ();

			if (!this.dicVar.ContainsKey (type)) {
				//this.dicVar = new Dictionary<string,Dictionary<string,string>> ();
				this.dicVar [type] = new Dictionary<string,string> ();
			}

			this.dicVar [type] [variable_name] = val;

			//グローバルなら即効反映
			if (type == "global") {

				if (NovelSingleton.GameManager.globalSetting.globalVar == null) {
					NovelSingleton.GameManager.globalSetting.globalVar = new Dictionary<string,string> ();
				}

				NovelSingleton.GameManager.globalSetting.globalVar[variable_name] = val;
				NovelSingleton.GameManager.saveManager.saveGlobal (NovelSingleton.GameManager.globalSetting);

			}
		}


		public string get(string exp){

			exp = exp.Replace ("{", "").Replace ("}", "");

			string default_val = "null"; //default_val は nullという文字列を入れる
			if (exp.IndexOf ("|") != -1) {
				string[] tmp_default = exp.Split ('|');
				exp = tmp_default [0];
				default_val = tmp_default[1];

			}

			string[] tmp = exp.Split ('.');

			string type = tmp [0].Trim ();
			string variable_name = tmp [1].Trim ();

			if (this.dicVar.ContainsKey (type) && this.dicVar[type].ContainsKey (variable_name)) {
				return this.dicVar [type] [variable_name];
			} else {
				return default_val;
				//return "";
			}

		}

		public bool hasKey(string key){

			string val = this.get (key);

			if (val == "null") {
				return false;
			} else {
				return true;
			}

		}

		public Dictionary<string,string> getType(string type){
			if (!this.dicVar.ContainsKey (type)) {
				//this.dicVar = new Dictionary<string,Dictionary<string,string>> ();
				return new Dictionary<string,string> ();
			} else {
				return this.dicVar [type];
			}
		}

		//すべてのtypeパラメータを丸ごと置き換えます
		public void replaceAll(string type,Dictionary<string,string> dicVal){

			this.dicVar [type] = dicVal;

		}


		//特定の変数をすべてクリアします。
		public void remove(string type){

			this.dicVar [type] = new Dictionary<string,string>();

		}


		public void trace(string type){

			string str = "[trace]"+type+"\n";

			foreach (KeyValuePair<string, string> kvp in dicVar[type]){
				str += kvp.Key + "=" + dicVar[type] [kvp.Key] + "\n";
			}

			str +="-----------------";

			Debug.Log ("<color=green>"+str+"</color>");

		}

	}


	public class StatusManager {

		public static bool enableNextOrder  = true; //nextOrder が実行できるかどうか
		public static bool enableClickOrder  = true; //クリックでnextOrder が実行できるかどうか　[s]とかの時はこれで止めなきゃいけない

		public static bool isMessageShowing = false; //メッセージ表示中は trueになる。

		public static bool skipOrder = false; //これが真の場合は命令を無視する
		public static string currentScenario = "";

		public static string nextLoad = ""; //次に読み込むべきファイルがある場合。セーブデータスロット名が入る
		//public static bool nextLoadStepFlag = true; //次にnextLoadで次に進んだ時に、nextorderするか否か。awake

		public static string nextFileName = ""; 
		public static string nextTargetName = ""; 


		public static string TagDefaultVal = ""; //ここに値が入っているあいだtag に自動的に値がはいる
		public static bool FlagSkiiping = false ; //現在スキップ中かどうかを判定する
		public static bool FlagAuto = false ; //オート中かどうかを判定する


		public static bool nextClickShowMessage = false;

		public static bool inUiClick = false; //UIボタン系などが先に押されたので、同時に起こったscene_iniのその後のクリックは無視して欲しい
		public static bool enableEventClick = true; //イベントをクリック検知できるかどうか event_stopの場合は下のやつを使う

		public static bool isEventStop=false; //イベント停止中かどうかを保存
		public static bool isEventButtonStop = false; //uGUIのボタンイベントが先に反応している場合



		public static bool visibleMessageFrame = false; //メッセージウィンドウが表示状態か否か。

		public static string currentPlayBgm = "";  //現在再生中のBGMがある場合

		public static string currentTextColor ="";

		public static Variable variable = new Variable();

		//シーンが切り替わったタイミングでクリアする内容
		public static void initScene(){

			currentPlayBgm = "";
			inUiClick = false;

		}

		public static void setSkipOrder(){
			skipOrder = true;
			enableNextOrder = false;
		}

		public static void releaseSkipOrder(){
			skipOrder = false;
			enableNextOrder = true;
		}

		public void callJoker(string scenario_file,string target_name){
		
			StatusManager.nextFileName = scenario_file;
			StatusManager.nextTargetName = target_name;
			StatusManager.currentScenario = "";
			//jumpから来たことを通知するためのパラメータが必要
			Application.LoadLevel("Player");

		
		}


	}




}