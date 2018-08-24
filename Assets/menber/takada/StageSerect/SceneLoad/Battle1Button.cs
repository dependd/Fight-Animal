using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Novel;

public class Battle1Button : MonoBehaviour {

    public void OnClick()
    {
        BattleManager.Instance.nowBattleScene = 1;
        NovelSingleton.StatusManager.callJoker("wide/scene2", "");

    }
}
