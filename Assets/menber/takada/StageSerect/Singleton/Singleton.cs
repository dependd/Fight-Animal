using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton {

    //インスタンス
    private static Singleton _instance = null;

    public static Singleton Instance{

        get{
            if(_instance == null){
                _instance = new Singleton();
            }
            return _instance;
        }
    }
    public Singleton()   {

    }

    //ボタンフラグの配列を用意
    public int[] ButtonFlag = new int[3] { 1, 0, 0 };

}
