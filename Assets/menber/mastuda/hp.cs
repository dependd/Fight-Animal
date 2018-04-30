using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    float Hp = 100;
    //HPを減らす
    // Update is called once per frame
    void Update()
    {
        Hp -= 1;
        //HPゲージに値を設定
        _enemyslider.value = Hp;

        _partyslider.value = Hp;

    }
}
