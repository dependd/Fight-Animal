using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Novel;

public class TutorialButton : MonoBehaviour
{
    ButtonAnim buttunActive;
	[SerializeField] GameObject noButton;
	OpenMenu Menu;

    private void Start()
    {
		Menu = noButton.GetComponent<OpenMenu>();
        buttunActive = GetComponent<ButtonAnim>();
        if (Singleton.Instance.ButtonFlag[1] == 0 && Singleton.Instance.ButtonFlag[2] == 0)
        {
            buttunActive.enabled = true;
        }
    }
    public void OnClick()
    {
		if (!Menu.touchFlag)
			return;
        BattleManager.Instance.nowBattleScene = 0;
        NovelSingleton.StatusManager.callJoker("wide/scene1", "");

    }
}