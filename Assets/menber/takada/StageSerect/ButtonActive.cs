using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonActive : MonoBehaviour {

    //イベントの定義（2つとも引数無し）
    public UnityEvent TutorialWinLoad;
    public UnityEvent Battle1winLoad;
    //オブジェクトの定義
    public GameObject BattleButton1;
    public GameObject BattleButton2;


    void Start () {
        BattleButton1.SetActive(false);
        BattleButton2.SetActive(false);
    }
    
    void Update(){

        if (false) {
            //引数無しのコールバック
            if (TutorialWinLoad != null)
                TutorialWinLoad.Invoke();
        }

        if (false) {
            //引数無しのコールバック
            if (Battle1winLoad != null)
                Battle1winLoad.Invoke();
        }
    }

        
}



