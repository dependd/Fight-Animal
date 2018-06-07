using UnityEngine;
using System.Collections;
using Novel;

public class CanvasLog : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	//ログを閉じる
	public void closeLog(){

		//イベントを停止する
		StatusManager.enableEventClick = true;
		NovelSingleton.GameManager.nextOrder ();

		GameObject back = GameObject.Find ("CanvasLog") as GameObject;
		back.GetComponent<Canvas> ().enabled = false;



		//テキストにバックログを表示する
		//nextOrderする？

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
