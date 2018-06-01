using UnityEngine;
using System.Collections;
using Novel;

public class CloseButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){

		if (StatusManager.inUiClick == true) {
			StatusManager.inUiClick = false;
			return;
		}

		//skip中にクリックされた場合、Skipを止める
		if (StatusManager.FlagSkiiping == true) {
			StatusManager.FlagSkiiping = false;
		}

		//次のクリックで表示されるために
		StatusManager.nextClickShowMessage = true;

		//ここで、ウィンドウをただ、閉じるだけ
		NovelSingleton.GameView.hideMessageWithoutNextOrder (0f);

	}

}
