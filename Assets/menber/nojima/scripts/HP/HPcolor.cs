using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPcolor : MonoBehaviour {

    //変数を入れる箱を用意
    float EnemyHp;
    float PartyHp;
    private GameObject enemySlider;
    private GameObject FillColor1;
    private GameObject FillColor2;
    

    //色の指定はfloat型のRGBA値に255.0fで除算したもの

    
    private Color Red = new Color(255.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f);
    private Color Orange = new Color(255.0f / 255.0f ,110.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f);

    void Start(){
        //GameObjectを取得
        enemySlider = GameObject.Find("enemySlider");
        FillColor1 = GameObject.Find("Fill");
        FillColor2 = GameObject.Find("Fill2");
        

    }

    
    public void Update () {
        //hp内のenemyhpとpartyhpを取得
        EnemyHp = enemySlider.GetComponent<hp>().enemyhp;
        PartyHp = enemySlider.GetComponent<hp>().partyhp;

        ColorChange();

	}

        

    public void ColorChange(){
        
        //エネミーHP
        //試遊会は160,80以下に
        //HPが640以下ならオレンジに。320以下なら赤に
        if (EnemyHp <= 160){
            FillColor1.GetComponent<Image>().color = Orange;
        }if (EnemyHp <= 80) {
            FillColor1.GetComponent<Image>().color = Red;
        }

        //パーティHP
        //HPが160以下ならfillのcolorをオレンジ80以下なら赤に変える
        if (PartyHp <= 160) {
            FillColor2.GetComponent<Image>().color = Orange;
        }if (PartyHp <= 80) {
            FillColor2.GetComponent<Image>().color = Red;
        }
    }
}
