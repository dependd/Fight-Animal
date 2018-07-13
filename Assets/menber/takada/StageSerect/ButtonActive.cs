using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonActive : MonoBehaviour {

    public GameObject BattleButton1;
    public GameObject BattleButton2;

    // Use this for initialization
    void Start () {
        BattleButton1.SetActive(false);
        BattleButton2.SetActive(false);
    }




}
