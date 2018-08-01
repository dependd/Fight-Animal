using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCommunicator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Singleton.Instance.ButtonFlag[1] = 1;
        BattleManager.Instance.nowBattleScene = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
