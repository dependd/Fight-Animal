using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour {
    

    public void MenuButton() {
        if (Input.GetButtonDown("Button")){
            if (Time.timeScale == 1.0F)
                Time.timeScale = 0F;
            
        }
        Debug.Log("click");
       
    }

}
