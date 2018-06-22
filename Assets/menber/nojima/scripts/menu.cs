using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class menu : MonoBehaviour {

    bool stop;
    public GameObject menuScreen;
    //Time.timescaleはUpdateは動いてFixedUpdateは動かない。
    //Updateで動いているものをFixedUpdateに変えてもらう
    public void MenuButton() {
        //timescaleが1のときにクリックしたら0にしてstopをtrueにする
        //timescaleが0のときにクリックしたら1にしてstopをfalseにする
        if (Time.timeScale == 1){
                Time.timeScale = 0;
            stop = true;
            }else if (Time.timeScale == 0){
                Time.timeScale = 1;
            stop = false;
            }
    }
    private void Start(){
        Time.timeScale = 1;
        stop = false;
        menuScreen.SetActive(false);
    }

    public void MenuScreen() {
        //stopがtrueならmenuScreenが表示される
        //stopがfalseならmenuScreenが非表示になる
        if (stop == true){
            menuScreen.SetActive(true);
        }else if (stop == false) {
            menuScreen.SetActive(false);
        }
    }
    public void Retrun() {
        SceneManager.LoadScene("start");
    }




}
