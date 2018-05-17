using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPcolor : MonoBehaviour {
    
    //変数を入れる箱を用意
    float EnemyHp;
    float PartyHp;


    void Start(){

        //hp内のenemyhpとpartyhpを取得
         EnemyHp = GetComponent<hp>().enemyhp;
         PartyHp = GetComponent<hp>().partyhp;

    }

    
    void Update () {
        HpColor();
	}

        

    void HpColor(){

        //HPが160以下ならfillのcolorをオレンジ80以下なら赤に変える
        if (EnemyHp < 160){
            
        } else if (EnemyHp < 80) {

        }

        if (PartyHp < 160){

        }
        else if (PartyHp < 80){

        }
    }
}
