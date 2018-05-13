using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {


    public void MenuButton() {
        if (Input.GetButtonDown(buttonName: "Button")){
            if (Time.timeScale == 1.0F)
                Time.timeScale = 0F;
            
        }
        Debug.Log("click");
       
    }

}
