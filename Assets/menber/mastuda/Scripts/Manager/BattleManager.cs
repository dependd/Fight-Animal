using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager{

    //インスタンス
    private static BattleManager _instance = null;

    public static BattleManager Instance
    {

        get
        {
            if (_instance == null)
            {
                _instance = new BattleManager();
            }
            return _instance;
        }
    }
    public BattleManager()
    {

    }

    //ばとるフラグの配列を用意
    public int nowBattleScene = 0;

}
