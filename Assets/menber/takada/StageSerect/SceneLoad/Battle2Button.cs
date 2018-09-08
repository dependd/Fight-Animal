using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Novel;

public class Battle2Button : MonoBehaviour
{

	[SerializeField] GameObject noButton;
	OpenMenu Menu;
	private void Start(){

		Menu = noButton.GetComponent<OpenMenu>();
	}

    public void OnClick()
	{
		if (!Menu.touchFlag)
			return;
        BattleManager.Instance.nowBattleScene = 2;
        NovelSingleton.StatusManager.callJoker("wide/scene3", "");

    }
}