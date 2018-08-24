using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Novel;

public class Battle2Button : MonoBehaviour
{

    public void OnClick()
    {
        BattleManager.Instance.nowBattleScene = 2;
        NovelSingleton.StatusManager.callJoker("wide/scene3", "");

    }
}