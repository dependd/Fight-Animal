using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_win_test : MonoBehaviour {

    //ボタンフラグのテスト用のスクリプト
    public void OnClick()
    {
        SceneManager.LoadScene("Win");

    }
}
