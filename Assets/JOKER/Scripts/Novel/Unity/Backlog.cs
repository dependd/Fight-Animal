using UnityEngine;
using System.Collections;
using Novel;
public class Backlog : MonoBehaviour {

	//GUISkin skin ;

	Vector2 scrollViewVector = Vector2.zero;

	Rect scrollViewRect  = new Rect(0, 0, Screen.width, Screen.height);
	Rect scrollViewAllRect = new Rect (10, 10, 100, 1000);

	public bool visible = false;

	public string text ="";

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
	
		// Skin代入

		if (this.visible == true) {

			if (GUI.Button (new Rect (Screen.width - 120, 10, 100, 60), "BACK"))
			{
				this.hideBacklog ();
			}

			// スクロールビューの開始位置を作成する
			scrollViewVector = GUI.BeginScrollView (scrollViewRect, scrollViewVector, scrollViewAllRect);

			// Button
			GUI.Label (new Rect (10, 10, Screen.width, 2000), this.text);
			// スクロールビューの終了位置を作成する 

			GUI.EndScrollView ();

		}
	
	}

	public void showBacklog(){

		Vector3 v = GameObject.Find ("MaskBlack").transform.position;
		v.x = 0;
		GameObject.Find ("MaskBlack").transform.position = v;

		this.text = NovelSingleton.GameManager.logManager.getLogText ();

		this.visible = true;

	}

	public void hideBacklog(){

		this.visible = false;
		StatusManager.enableEventClick = true;
		NovelSingleton.GameManager.nextOrder ();

		Vector3 v = GameObject.Find ("MaskBlack").transform.position;
		v.x = -1000;
		GameObject.Find ("MaskBlack").transform.position = v;

	}



}
