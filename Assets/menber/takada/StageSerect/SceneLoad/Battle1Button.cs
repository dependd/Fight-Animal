using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Novel;

public class Battle1Button : MonoBehaviour {
    ButtonAnim buttunActive;
    private void Start()
    {
        buttunActive = GetComponent<ButtonAnim>();
        if (Singleton.Instance.ButtonFlag[2] == 1)
        {
            buttunActive.enabled = false;
        }
    }
    public void OnClick()
    {
        BattleManager.Instance.nowBattleScene = 1;
        NovelSingleton.StatusManager.callJoker("wide/scene2", "");

    }
}
