using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPcolor : MonoBehaviour {
    
    //変数を入れる箱を用意
    float EnemyHp;
    float PartyHp;
    private GameObject partySlider;
    private GameObject enemySlider;
    private GameObject FillColor1;
    private GameObject FillColor2;
    

    //色の指定はfloat型のRGBA値に255.0fで除算したもの

    //private Color Green = Color.green;
    private Color Red = new Color(255.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f);
    private Color Orange = new Color(255.0f / 255.0f ,110.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f);

    void Start(){
        //GameObjectを取得
        partySlider = GameObject.Find("partySlider");
        enemySlider = GameObject.Find("enemySlider");
        FillColor1 = GameObject.Find("Fill");
        FillColor2 = GameObject.Find("Fill2");
        //hp内のenemyhpとpartyhpを取得
         EnemyHp = enemySlider.GetComponent<hp>().enemyhp;
         PartyHp = enemySlider.GetComponent<hp>().partyhp;
    }

    
    public void Update () {
        ColorChange();
	}

        

    void ColorChange(){

        //HPが160以下ならfillのcolorをオレンジ80以下なら赤に変える
        if (EnemyHp < 640){
            FillColor1.GetComponent<Image>().color = Orange;
        } else if (EnemyHp < 320) {
            enemySlider.GetComponent<Image>().color = Red;
        }

        if (PartyHp < 160) {
            FillColor2.GetComponent<Image>().color = Orange;
        }else if (PartyHp < 80) {
            FillColor2.GetComponent<Image>().color = Red;
        }
    }
}
