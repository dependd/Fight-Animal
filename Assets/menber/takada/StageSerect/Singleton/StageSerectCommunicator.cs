using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSerectCommunicator : MonoBehaviour {

    [SerializeField] private GameObject BattleButton1;
    [SerializeField] private GameObject BattleButton2;

    // Use this for initialization
    void Start () {

         BattleButton1.SetActive(false);
         BattleButton2.SetActive(false);

        if (Singleton.Instance.ButtonFlag[1] == 1)
        {
            BattleButton1.SetActive(true);
        }
        if (Singleton.Instance.ButtonFlag[2] == 1)
        {
            BattleButton2.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
