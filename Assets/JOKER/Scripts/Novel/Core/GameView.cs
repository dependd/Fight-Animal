

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Novel
{

	//ゲームのViewを管理する
	public class GameView{

		public Text messageArea;
		public GameObject messageFrame;


		public GameView(){

			this.messageArea 		  = (GameObject.Find ("message_area") as GameObject).GetComponent<Text>();
			this.messageFrame 		  = GameObject.Find ("MessageFrame") as GameObject;

		}

		public void hideMessage(float time){

			StatusManager.visibleMessageFrame = false;
			this.messageFrame.SendMessage ("hideMessage", time);
			this.messageArea.SendMessage ("hideMessage", time);

		}

		public void showMessage(float time){

			StatusManager.visibleMessageFrame = true;
			this.messageFrame.SendMessage ("showMessage", time);
			this.messageArea.SendMessage ("showMessage", time);

		}

		public void showMessageWithoutNextOrder(float time){

			StatusManager.visibleMessageFrame = true;
			this.messageFrame.SendMessage ("showMessageWithoutNextOrder", time);
			this.messageArea.SendMessage ("showMessage", time);

		}

		public void hideMessageWithoutNextOrder(float time){

			StatusManager.visibleMessageFrame = false;
			this.messageFrame.SendMessage ("hideMessageWithoutNextOrder", time);
			this.messageArea.SendMessage ("hideMessage", time);

		}




	}

}
