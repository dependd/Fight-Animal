using UnityEngine;
using System.Collections;
using Novel;
using UnityEngine.UI;

public class MessageFrame : MonoBehaviour {


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

		this.hideUiObject ();
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

		this.showUiObject ();
	}

	public void showMessageWithoutNextOrder(float time){

		//通常の表示切り替えの場合
		iTween.ValueTo(this.gameObject,iTween.Hash(
			"from",0,
			"to",1,
			"time",time,
			"oncomplete","finishAnimationWithoutNextOrder",
			"oncompletetarget",this.gameObject,
			"easeType","linear",
			"onupdate","crossFade"
		));

		this.showUiObject ();

	}


	public void hideMessageWithoutNextOrder(float time){

		//通常の表示切り替えの場合
		iTween.ValueTo(this.gameObject,iTween.Hash(
			"from",1,
			"to",0,
			"time",time,
			"oncomplete","finishAnimationWithoutNextOrder",
			"oncompletetarget",this.gameObject,
			"easeType","linear",
			"onupdate","crossFade"
		));

		this.hideUiObject ();

	}

	private void showUiObject(){


		GameObject canvas = GameObject.Find ("Canvas");
		canvas.GetComponent<Canvas>().enabled = true;

		/*
		//uiタグが付いているものを消去する
		GameObject[] obj = GameObject.FindGameObjectsWithTag ("ui");

		for (var i = 0; i < obj.Length; i++) {

			GameObject g_obj = (GameObject)obj[i];

			if (g_obj.GetComponent<GUIText> () != null) {
				g_obj.GetComponent<GUIText> ().enabled = true;
			} else {
				GameObject g_fore = g_obj.transform.FindChild ("fore").gameObject;
			
				g_fore.GetComponent<SpriteRenderer> ().enabled = true;
			}
		}
		*/

	}

	private void hideUiObject(){


		GameObject canvas = GameObject.Find ("Canvas");
		canvas.GetComponent<Canvas>().enabled = false;


		//uiタグが付いているものを消去する
		/*
		GameObject[] obj = GameObject.FindGameObjectsWithTag ("ui");

		for (var i = 0; i < obj.Length; i++) {

			GameObject g_obj = (GameObject)obj[i];

			if (g_obj.GetComponent<GUIText> () != null) {
				g_obj.GetComponent<GUIText> ().enabled = false;
			} else {
				GameObject g_fore = g_obj.transform.FindChild ("fore").gameObject;

				g_fore.GetComponent<SpriteRenderer> ().enabled = false;
			}
		}
		*/

	
	}

	public void crossFade(float val){
		//var test = this.gameObject.GetComponent<Image> ();

		var spriteRender = this.gameObject.GetComponent<UnityEngine.UI.Image> ();
		var color_fore = spriteRender.color;
		color_fore.a = val;
		spriteRender.color = color_fore;

	}

	public void finishAnimation(){

		StatusManager.enableClickOrder = true;
		NovelSingleton.GameManager.nextOrder ();
	}

	public void finishAnimationWithoutNextOrder(){

		StatusManager.enableClickOrder = true;

	}


}
