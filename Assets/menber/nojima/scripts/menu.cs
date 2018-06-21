using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour {

    bool stop;
    public GameObject menuScreen;
    //Time.timescaleはUpdateは動いてFixedUpdateは動かない。
    //Updateで動いているものをFixedUpdateに変えてもらう
    public void MenuButton() {
            if (Time.timeScale == 1){
                Time.timeScale = 0;
            stop = true;
            }
            else if (Time.timeScale == 0){
                Time.timeScale = 1;
            stop = false;
            }
    }
    private void Start(){
        stop = false;
        menuScreen.SetActive(false);
    }

    public void MenuScreen() {
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
