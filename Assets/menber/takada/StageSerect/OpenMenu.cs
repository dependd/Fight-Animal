using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour {

    public GameObject MenuScreen;

    private void Start()
    {
        MenuScreen.SetActive(false);

    }

    //ボタンがクリックされたらパネルを表示
    public void OnClick()
    {
        MenuScreen.SetActive(true);
    }

}
