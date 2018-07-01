using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


namespace Novel{

	[Serializable]
	public class Scenario
	{
		public string name;
		public List<AbstractComponent> arrayComponent;
		public Dictionary<string,int> dicLabel = new Dictionary<string,int>();

		public Scenario(){
		}

		public Scenario (string scenario_name, List<AbstractComponent> list)
		{
			this.name = scenario_name;
			this.arrayComponent = list;
		}

		public void addLabel(string label_name,int index){
			//Debug.Log (label_name);
			this.dicLabel [label_name] = index;
		}

		public int getIndex(string label_name){

			if (label_name == "")
				return -1;

			if (!this.dicLabel.ContainsKey (label_name)) {
				NovelSingleton.GameManager.showError (this.name+"にラベル「"+label_name+"」が見つかりません。");
			}

			return this.dicLabel[label_name];

		}

	}

	[Serializable]
	public class Macro
	{
		public string name;
		public string file_name;
		public int index;

		public Macro(){
		}

		public Macro (string name, string file_name,int index)
		{
			this.name = name;
			this.file_name = file_name;
			this.index = index;
		}

	}

	//マクロ呼出しを保持するクラス
	[Serializable]
	public class CallStack {

		public Dictionary<string,string> dicVar = new Dictionary<string,string>();
		public string scenarioNname;
		public int index;

		public CallStack(){
		}

		public CallStack(string scenario_name,int index,Dictionary<string,string> dicVar){
			this.scenarioNname = scenario_name;
			this.index = index;
			this.dicVar = dicVar;
		}


	}

	//if文の入れ子などを管理するスタック
	[Serializable]
	public class IfStack{

		public bool isIfProcess = false;

		public IfStack(){
		}

		public IfStack(bool val){
			this.isIfProcess = val;
		}


	}

	[Serializable]
	public class ScenarioManager  {

		[NonSerialized]
		private Dictionary<string, Scenario> dicScenario = new Dictionary<string,Scenario>();

		public Dictionary<string, Macro> dicMacro = new Dictionary<string,Macro> ();

		//stackを配列に置き換える
		//public Stack<CallStack> qStack = new Stack<CallStack>();
		//public Stack<IfStack> ifStack = new Stack<IfStack>();

		public List<CallStack> qStack = new List<CallStack>();
		public List<IfStack> ifStack = new List<IfStack>();


		public int ifNum = 0;
		public int macroNum = 0;

		public ScenarioManager(){

		}

		public Scenario getScenario(string file_name){

			//Debug.Log ("=  getScenario  =======================");
			//Debug.Log (file_name);
			//Debug.Log (this.dicScenario.ContainsKey (file_name));

			//シナリオからロードしてきた時はnull になってるからね
			if (this.dicScenario == null) {
				this.dicScenario = new Dictionary<string,Scenario>();
			}

			if (this.dicScenario.ContainsKey (file_name)) {

				return this.dicScenario [file_name];
			} else {
				return null;
			}

		}

		//シナリオの追加 ラベルの位置計算もここでやる
		public void addScenario(string scenario_name,List<AbstractComponent> list){

			this.dicScenario [scenario_name] = new Scenario (scenario_name,list);

			int index = 0;
			foreach(AbstractComponent cmp in list){
				if (cmp.tagName == "label") {
					this.dicScenario [scenario_name].addLabel(cmp.originalParam["name"],index);
				}

				index++;
			}
		
		}


		public int getIndex(string scenario_name,string label_name){

			//シナリオがまだ読み込まれていない場合は読み込みを行う
			if (!this.dicScenario.ContainsKey (scenario_name)) {
				return -1;
			}

			return this.dicScenario [scenario_name].getIndex (label_name);

		}

		public void addStack(string scenario_name,int index,Dictionary<string,string> dicVar){

			//stack追加時にdicVarに呼び出し元情報を入れる
			//呼び出し元の情報はcaller_indexに入る。
			dicVar ["caller_index"] = ""+index;
			dicVar ["caller_file"] = scenario_name;

			var mp = StatusManager.variable.getType ("mp");

			////
			/*
			Debug.Log ("== add stack ===============");
			foreach (KeyValuePair<string, string> kvp in mp){
				Debug.Log (kvp.Key);
				Debug.Log(kvp.Value);
			}
			*/

			this.qStack.Add (new CallStack(scenario_name,index,mp));

			//スタックを追加した時点で使用できる引数変数を格納する
			StatusManager.variable.replaceAll("mp",dicVar);;

		}

		public CallStack popStack(){

			try{

				CallStack c = this.qStack[this.qStack.Count-1];

				//var mp = StatusManager.variable.getType ("mp");

				/*
				Debug.Log ("== pop stack ===============");
				foreach (KeyValuePair<string, string> kvp in c.dicVar){
					Debug.Log (kvp.Key);
					Debug.Log(kvp.Value);
				}
				*/



				StatusManager.variable.replaceAll("mp",c.dicVar);;

				this.qStack.RemoveAt(this.qStack.Count-1);

				return c;

			}catch(System.Exception e){
				NovelSingleton.GameManager.showError ("スタックが不足しています。callとreturnの関係を確認して下さい");
				Debug.Log (e.ToString ());
				return null;
			}
		}

		public int countStack(){
			return this.qStack.Count;
		}


		/// <summary>
		/// //////if 周りのスタック管理
		/// </summary>

		public void addIfStack(bool proccess){

			this.ifStack.Add (new IfStack(proccess));

		}

		public IfStack popIfStack(){

			try{

				IfStack c = this.ifStack[this.ifStack.Count-1];
				this.ifStack.RemoveAt(this.ifStack.Count-1);

				return c;

			}catch(System.Exception e){
				Debug.Log (e.ToString ());
				NovelSingleton.GameManager.showError ("スタックが不足しています。ifとendifの関係を確認して下さい");
				return null;
			}
		}

		//現在のifスタックの状態を確認する
		public bool currentIfStack(){

			return this.ifStack[this.ifStack.Count-1].isIfProcess;
		
		}

		//スタックの状態を変更する
		public void changeIfStack(bool proccess){

			IfStack s = this.popIfStack();
			s.isIfProcess = proccess;
			this.ifStack.Add (s);

		}

		public int countIfStack(){
			return this.ifStack.Count;
		}

		//スタックをすべて削除します

		public void removeAllStacks(){
			//未実装
			this.qStack.Clear ();
			this.ifStack.Clear ();
			this.ifNum = 0;

		}



//// macro ///////

		public void addMacro(string macro_name,string file_name, int index){

			this.dicMacro[macro_name] = new Macro(macro_name,file_name,index);

		}

		/*
		public void addMacroStack(string macro_name,Dictionary<string,string> dicVar){
			this.macroNum++;
			Macro macro = dicMacro [macro_name];
			this.addStack (macro.file_name, macro.index, dicVar);

		}
		*/

		public Macro getMacro(string macro_name){

			if(!this.dicMacro.ContainsKey (macro_name)){
				NovelSingleton.GameManager.showError ("マクロ「" + macro_name + "」は見つかりませんでした");
			}

			return this.dicMacro [macro_name]; 

		}






	}


}