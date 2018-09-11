using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hp : MonoBehaviour
{
    GameObject gameObject;
    GameControler gameControler;


    public GameObject PartyDamage;
    public GameObject EnemyDamage;

    public Text PD;
    public Text ED;

    Slider _enemyslider;
    Slider _partyslider;
    // Use this for initialization
    void Start()
    {
        gameObject = GameObject.Find("GameControler");
        gameControler = gameObject.GetComponent<GameControler>();
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
    void Update()
    {

        //HPゲージに値を設定
        _enemyslider.value = enemyhp;

        _partyslider.value = partyhp;
        if (partyhp <= 0)
        {
            //StartCoroutine(gameControler.BattleLose());
        }
        if (enemyhp <= 0)
        {
            //StartCoroutine(gameControler.BattleWin());
        }
    }
    public void DownPartyHp(bool i, int j)
    {
        //防御成功：味方のHPを敵の攻撃力の20％分減らす
        if (i == true)
        {
            float k = j * 0.2f;
            partyhp -= k;
            EnemyDamage.SetActive(true);
            string X = k.ToString();
            ED.text = X;
            Invoke("DelayEnemyDamage", 0.5f);
        }
        else
        {
            //防御失敗：味方のHPを敵の攻撃力分減らす
            partyhp -= j;
            EnemyDamage.SetActive(true);
            string Y = j.ToString();
            ED.text = Y;
            Invoke("DelayEnemyDamage", 0.5f);
        }

    }
    public void DownEnemyHp(int i)
    {
       
        enemyhp -= i;
        PartyDamage.SetActive(true);
        string Z = i.ToString();
        PD.text = Z;

        Invoke("DelayPartyDamage", 0.3f);
     
    }

    void DelayPartyDamage() {
        PartyDamage.SetActive(false);
    }

    void DelayEnemyDamage() {
        EnemyDamage.SetActive(false);
    }
}
