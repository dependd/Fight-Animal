using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActive_call : MonoBehaviour {

    public GameObject BattleButton1;
    public GameObject BattleButton2;

    public void TutorialWinLoad(){

        BattleButton1.SetActive(true);

    }

    public void Battle1winLoad(){

        BattleButton2.SetActive(true);

    }

}
