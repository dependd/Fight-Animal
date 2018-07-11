using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hp : MonoBehaviour
{

    public GameObject PartyDamage;
    public GameObject EnemyDamage;

    public Text PD;
    public Text ED;

    Slider _enemyslider;
    Slider _partyslider;

    bool EDcount;
    bool PDcount;

    float TimeCountX = 1;
    float TimeCountZ = 1;
    // Use this for initialization
    void Start(){
        EDcount = false;
        PDcount = false;


        PartyDamage.SetActive(false);
        EnemyDamage.SetActive(false);
        //スライダーを取得
        _enemyslider = GameObject.Find("enemySlider").GetComponent<Slider>();

        _partyslider = GameObject.Find("partySlider").GetComponent<Slider>();
    }
    //HPの値
    public float partyhp = 200;
    public float enemyhp = 800;
    //HPを減らす
    // Update is called once per frame
    void Update(){

        if (EDcount == true) {
            TimeCountX -= Time.deltaTime;
        }
        if (PDcount == true){
            TimeCountZ -= Time.deltaTime;
        }
        //HPゲージに値を設定
        _enemyslider.value = enemyhp;

        _partyslider.value = partyhp;
        if (partyhp <= 0){
            SceneManager.LoadScene("GameOver");
        }
        if (enemyhp <= 0){
            SceneManager.LoadScene("Win");
        }
    }
    public void DownPartyHp(bool i, int j){
        //防御成功：味方のHPを敵の攻撃力の20％分減らす
        if (i == true){
            float k = j * 0.2f;
            partyhp -= k;
            EnemyDamage.SetActive(true);
            string X = k.ToString();
            ED.text = X;
            EDcount = true;
            if (TimeCountX == 0) {
                EnemyDamage.SetActive(false);
            }
        }
        else{
            //防御失敗：味方のHPを敵の攻撃力分減らす
            partyhp -= j;
            EnemyDamage.SetActive(true);
            string Y = j.ToString();
            ED.text = Y;
            EDcount = true;
            if (TimeCountX == 0) {
                EnemyDamage.SetActive(false);
            }
        }

    }
    public void DownEnemyHp(int i){
        enemyhp -= i;
        PartyDamage.SetActive(true);
        string Z = i.ToString();
        PD.text = Z;
        PDcount = true;
        if (TimeCountZ == 0){
            PartyDamage.SetActive(false);
        }
    }
}
