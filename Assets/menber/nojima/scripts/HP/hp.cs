using System.Collections;
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
    }
    public void DownPartyHp(bool i)
    {
        //防御成功：味方のHPを敵の攻撃力の20％分減らす
        if(i == true){
            partyhp -= 10 * 0.2f;
        }
        else {
            //防御失敗：味方のHPを敵の攻撃力分減らす
            partyhp -= 10;
        }

    }
    public void DownEnemyHp(){
        enemyhp -= 10;
    }
}
