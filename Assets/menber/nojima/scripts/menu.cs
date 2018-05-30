using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour {
    //Time.timescaleはUpdateは動いてFixedUpdateは動かない。
    //Updateで動いているものをFixedUpdateに変えてもらう
    public void MenuButton() {
            if (Time.timeScale == 1){
                Time.timeScale = 0;
            }
        }
        
       
    

}
