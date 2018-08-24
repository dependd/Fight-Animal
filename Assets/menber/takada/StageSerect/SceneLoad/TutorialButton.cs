using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Novel;

public class TutorialButton : MonoBehaviour
{

    public void OnClick()
    {
        BattleManager.Instance.nowBattleScene = 0;
        NovelSingleton.StatusManager.callJoker("wide/scene1", "");

    }
}