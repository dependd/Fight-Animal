using UnityEngine;
using System.Collections;
using Novel;
using UnityEngine.UI;

public class MessageArea : MonoBehaviour {

	private Text guiTextMessage;
	private GuiScaler guiScaler;


	void Start(){
	
		GameObject obj = GameObject.Find ("message_area");
		this.guiTextMessage = obj.GetComponent<Text> ();
		//this.guiScaler = new GuiScaler (this.guiTextMessage);
	
	}


	void Update(){

		/*
		if (this.guiScaler != null) {
			this.guiScaler.fontResize ();
		}
		*/
	}

	public void hideMessage(float time){

		//通常の表示切り替えの場合
		iTween.ValueTo(this.gameObject,iTween.Hash(
			"from",1,
			"to",0,
			"time",time,
			"oncomplete","finishAnimation",
			"oncompletetarget",this.gameObject,
			"easeType","linear",
			"onupdate","crossFade"
		));


	}

	public void showMessage(float time){

		//通常の表示切り替えの場合
		iTween.ValueTo(this.gameObject,iTween.Hash(
			"from",0,
			"to",1,
			"time",time,
			"oncomplete","finishAnimation",
			"oncompletetarget",this.gameObject,
			"easeType","linear",
			"onupdate","crossFade"
		));


	}

	public void crossFade(float val){

		var color_fore = this.guiTextMessage.color;
		color_fore.a = val;
		this.guiTextMessage.color = color_fore;

	}

	public void finishAnimation(){

		Debug.Log ("finish!");
	}




}
