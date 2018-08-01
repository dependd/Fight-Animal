using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win2Communicator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Singleton.Instance.ButtonFlag[2] = 1;
        BattleManager.Instance.nowBattleScene = 2;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
