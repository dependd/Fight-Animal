using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    enum State{
        start,
        appearancePartyNote,
        appearanceEnemyNote,
        appearanceDeadlyNote,

        end,
    }
    State now;
    [SerializeField]
    GameObject partyNote1;
    [SerializeField]
    GameObject partyNote2;
    [SerializeField]
    GameObject partyNote3;
    [SerializeField]
    GameObject enemyNote1;
    [SerializeField]
    GameObject deadlyNote;
    //hpスクリプトに参照するための変数
    GameObject notes;
    hp hp;
    //noteスクリプトに参照するための変数
    GameObject partyNote;
    note note;
    //enemynoteスクリプトに参照するための変数
    GameObject enemyNote;
    enemynote enemynote;
    //Charastatusスクリプトに参照するための変数
    Charastatus CharaStatus;
    //ScenarioTextスクリプトに参照するための変数
    GameObject text;
    ScenarioText scenarioText;
    //
    GameObject chara;
    ScinarioChara scenarioChara;
    //各キャラのCharaAnimationスクリプトに参照するための変数
    [SerializeField]
    CharaAnimations datyoAnimation;
    [SerializeField]
    GameObject datyo;
    [SerializeField]
    CharaAnimations tokageAnimation;
    [SerializeField]
    GameObject tokage;
    [SerializeField]
    CharaAnimations momongaAnimation;
    [SerializeField]
    GameObject momonga;
    [SerializeField]
    CharaAnimations kameAnimation;
    [SerializeField]
    GameObject kame;
    void Start()
    {
        //enemySliderのhpスクリプトを取得
        notes = GameObject.Find("enemySlider");
        hp = notes.GetComponent<hp>();
        //CharaStatusスクリプトを取得
        CharaStatus = GetComponent<Charastatus>();
        //partyNoteのnoteスクリプトを取得
        partyNote = GameObject.Find("PartyNote");
        note = partyNote.GetComponent<note>();
        //enemyNoteのenemynoteスクリプトを取得
        enemyNote = GameObject.Find("EnemyNote");
        enemynote = enemyNote.GetComponent<enemynote>();
        //ScenairoTextのScenarioTextスクリプトを取得
        text = GameObject.Find("ScenarioText");
        scenarioText = text.GetComponent<ScenarioText>();
        //ScenarioCharaのScenarioCharaスクリプトを取得
        chara = GameObject.Find("ScinarioChara");
        scenarioChara = chara.GetComponent<ScinarioChara>();
        //
        now = State.start;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (now)
            {
                case State.start:

                    break;
                case State.end:

                    break;
            }
        }
    }
    
    //ダメージの軽減があるかどうかの判定をする関数
    public void DamageCut(GameObject notes, bool i)
    {
        Destroy(notes);
        //HPを減らす関数
        if (i == true)
        {
            scenarioText.ChengeScenarioText("防御成功");
        }
        else
        {
            scenarioText.ChengeScenarioText("防御失敗");
        }
        hp.DownPartyHp(i, CharaStatus.tinpan.OffensivePower);
    }
    //勇者が攻撃する関数
    private void AttackAnimal(string animalName, GameObject notes, bool hantei, int power, bool deadly)
    {
        Destroy(notes);
        //攻撃成功かどうかの判定
        if (hantei == true)
        {
            //必殺ノーツかどうかの判定
            if (deadly == true)
            {
                power = power * 2;
                scenarioText.ChengeScenarioText(animalName + "必殺技\n" + power + "ダメージを与えた");
                scenarioChara.PopUpChara(animalName);
            }
            else
            {
                scenarioText.ChengeScenarioText(animalName + "攻撃\n" + power + "ダメージを与えた");
            }
            hp.DownEnemyHp(power);
        }
        else
        {
            scenarioText.ChengeScenarioText(animalName + "攻撃失敗\n");
        }
    }
    
}
