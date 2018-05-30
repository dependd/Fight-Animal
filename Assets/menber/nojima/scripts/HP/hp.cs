﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hp : MonoBehaviour
{
    Slider _enemyslider;
    Slider _partyslider;
    // Use this for initialization
    void Start()
    {
        //スライダーを取得
        _enemyslider = GameObject.Find("enemySlider").GetComponent<Slider>();

        _partyslider = GameObject.Find("partySlider").GetComponent<Slider>();
    }
    //HPの値
    public  float partyhp = 200;
    public  float enemyhp = 800;
    //HPを減らす
    // Update is called once per frame
    void Update()
    {
        
        //HPゲージに値を設定
        _enemyslider.value = enemyhp;

        _partyslider.value = partyhp;
        if (partyhp <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (enemyhp <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
    public void DownPartyHp(bool i,int j)
    {
        //防御成功：味方のHPを敵の攻撃力の20％分減らす
        if(i == true){
            float k = j * 0.2f;
            partyhp -= k;
        }
        else {
            //防御失敗：味方のHPを敵の攻撃力分減らす
            partyhp -= j;
        }

    }
    public void DownEnemyHp(int i){
        enemyhp -= i;
    }
}
