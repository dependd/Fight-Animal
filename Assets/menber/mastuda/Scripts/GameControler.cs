
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour{
    //乱数を入れる変数
    int random;
    //ノーツの親オブジェクトを入れる変数
    Transform partyNoteParent;
    Transform enemyNoteParent;
    //ノーツのゲームオブジェクトを入れる変数
    GameObject note1;
    GameObject note2;
    GameObject note3;
    GameObject note4;
    GameObject enemyNote1;
    GameObject enemyNote2;
    GameObject enemyNote3;
    GameObject deadlyNote1;
    GameObject deadlyNote2;
    GameObject deadlyNote3;
    GameObject deadlyNote4;
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
    CharaAnimation datyoAnimation;
    [SerializeField]
    GameObject datyo;
    [SerializeField]
    CharaAnimation tokageAnimation;
    [SerializeField]
    GameObject tokage;
    [SerializeField]
    CharaAnimation momongaAnimation;
    [SerializeField]
    GameObject momonga;
    [SerializeField]
    CharaAnimation kameAnimation;
    [SerializeField]
    GameObject kame;
    [SerializeField]
    CharaAnimation tinpanAnimation;
    [SerializeField]
    GameObject tinpan;
    [SerializeField]
    GameObject datyoAttack;
    [SerializeField]
    CharaAnimation datyoAttackScript;
    [SerializeField]
    GameObject tokageAttack;
    [SerializeField]
    CharaAnimation tokageAttackScript;
    [SerializeField]
    GameObject momongaAttack;
    [SerializeField]
    CharaAnimation momongaAttackScript;
    [SerializeField]
    GameObject kameAttack;
    [SerializeField]
    CharaAnimation kameAttackScript;
    [SerializeField]
    GameObject tinpanAttack;
    [SerializeField]
    CharaAnimation tinpanAttackScript;
    //メニューを押したら(一応)スタートに戻る
    public void MenuButton(){
        SceneManager.LoadScene("start");
    }
    void Start(){
        //それぞれの変数にオブジェクトを格納する
        partyNoteParent = GameObject.Find("PartyNote").transform;
        enemyNoteParent = GameObject.Find("EnemyNote").transform;
        note1 = GameObject.Find("datyonote");
        note2 = GameObject.Find("tokagenote");
        note3 = GameObject.Find("momonganote");
        note4 = GameObject.Find("kamenote");
        enemyNote1 = GameObject.Find("enemyNote1");
        enemyNote2 = GameObject.Find("enemyNote2");
        enemyNote3 = GameObject.Find("enemyNote3");
        deadlyNote1 = GameObject.Find("datyodeadlyNote");
        deadlyNote2 = GameObject.Find("tokagedeadlyNote");
        deadlyNote3 = GameObject.Find("momongadeadlyNote");
        deadlyNote4 = GameObject.Find("kamedeadlyNote");
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
    }

    void Update(){
        
        if (Input.GetMouseButtonDown(0)) {
            if (enemyNoteParent.childCount > 0){
                InputNoteObject();
            }
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //敵の攻撃を防ぐ処理
            Debug.Log("クリックした座標は" + ray);
            if (ray.x >= -6.3 && ray.x <= -4.1){
                if (ray.y >= -1.5 && ray.y <= 2.7){
                    if(GameObject.Find("enemyNote1") == true){
                        if (enemyNote1.transform.position.x <= -3 && enemyNote1.transform.position.x >= -4){
                            DamageCut(enemyNote1, true);
                            tinpanAttackScript.AttackEffect("tinpan");
                            enemynote.note1st = false;
                            AllCharaPartyDamage();
                        }
                        else if (enemyNote1.transform.position.x > -4 && enemyNote1.transform.position.x < -5 || enemyNote1.transform.position.x < -3 && enemyNote1.transform.position.x > -2){
                            DamageCut(enemyNote1, false);
                            tinpanAttackScript.AttackEffect("tinpan");
                            enemynote.note1st = false;
                        }
                    }


                    if(GameObject.Find("enemyNote2") == true){
                        if (enemyNote2.transform.position.x <= -3 && enemyNote2.transform.position.x >= -4){
                            DamageCut(enemyNote2, true);
                            tinpanAttackScript.AttackEffect("tinpan");
                            enemynote.note2nd = false;
                            AllCharaPartyDamage();
                        }
                        else if (enemyNote2.transform.position.x > -4 && enemyNote2.transform.position.x < -5 || enemyNote2.transform.position.x < -3 && enemyNote2.transform.position.x > -2){
                            DamageCut(enemyNote2, false);
                            tinpanAttackScript.AttackEffect("tinpan");
                            enemynote.note2nd = false;
                        }
                    }
                    if(GameObject.Find("enemyNote3") == true){
                        if (enemyNote3.transform.position.x <= -3 && enemyNote3.transform.position.x >= -4){
                            DamageCut(enemyNote3, true);
                            tinpanAttackScript.AttackEffect("tinpan");
                            enemynote.note3rd = false;
                            AllCharaPartyDamage();
                        }
                        else if (enemyNote3.transform.position.x > -4 && enemyNote3.transform.position.x < -5 || enemyNote3.transform.position.x < -3 && enemyNote3.transform.position.x > -2){
                            DamageCut(enemyNote3, false);
                            tinpanAttackScript.AttackEffect("tinpan");
                            enemynote.note3rd = false;
                        }
                    }
                }
            }
            if(partyNoteParent.childCount > 0){
                InputNoteObject();
            }
            //1番目の勇者が攻撃する処理
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= 2.4 && ray.y <= 3.6){
                    if (GameObject.Find("datyonote") == true){
                        if (note1.transform.position.x >= 2.9 && note1.transform.position.x <= 4.1){
                            AttackAnimal("ダチョウ",note1, true, CharaStatus.datyo.OffensivePower, false);
                            datyoAnimation.AttackAnimation();
                            datyoAttackScript.AttackEffect("datyo");
                            note.note1st = false;
                        }
                        else if (note1.transform.position.x > 4 && note1.transform.position.x < 5 || note1.transform.position.x < 3 && note1.transform.position.x > 2){
                            AttackAnimal("ダチョウ",note1, false, CharaStatus.datyo.OffensivePower, false);
                            note.note1st = false;
                        }
                    }
                }
            }
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= 2.4 && ray.y <= 3.6){
                    if(GameObject.Find("datyodeadlyNote") == true){
                        if (deadlyNote1.transform.position.x >= 3.2f && deadlyNote1.transform.position.x <= 3.8f){
                            AttackAnimal("ダチョウ",deadlyNote1, true, CharaStatus.datyo.OffensivePower, true);
                            datyoAnimation.AttackAnimation();
                            tokageAttackScript.AttackEffect("datyo");
                            note.deadlyNote1st = false;
                        }
                        else if (deadlyNote1.transform.position.x > 3.8f && deadlyNote1.transform.position.x < 5 || deadlyNote1.transform.position.x < 3.2f && deadlyNote1.transform.position.x > 2){
                            AttackAnimal("ダチョウ",deadlyNote1, false, CharaStatus.datyo.OffensivePower, true);
                            note.deadlyNote1st = false;
                        }
                    }
                }
            }
            //2番目の勇者が攻撃する時の処理
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= 1 && ray.y < 2.2){
                    if (GameObject.Find("tokagenote") == true){
                        if (note2.transform.position.x >= 3 && note2.transform.position.x <= 4){
                            AttackAnimal("トカゲ",note2, true, CharaStatus.tokage.OffensivePower, false);
                            tokageAnimation.AttackAnimation();
                            tokageAttackScript.AttackEffect("tokage");
                            note.note2nd = false;
                        }
                        else if (note2.transform.position.x > 4 && note2.transform.position.x < 5 || note2.transform.position.x < 3 && note2.transform.position.x > 2){
                            AttackAnimal("トカゲ",note2, false, CharaStatus.tokage.OffensivePower, false);
                            note.note2nd = false;
                        }
                    }
                }
            }
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= 1 && ray.y < 2.2){
                    if (GameObject.Find("tokagedeadlyNote") == true){
                        if (deadlyNote2.transform.position.x >= 3.2 && deadlyNote2.transform.position.x <= 3.8){
                            AttackAnimal("トカゲ",deadlyNote2, true, CharaStatus.tokage.OffensivePower, true);
                            tokageAnimation.AttackAnimation();
                            tokageAttackScript.AttackEffect("tokage");
                            note.deadlyNote2nd = false;
                        }
                        else if (deadlyNote2.transform.position.x > 4 && deadlyNote2.transform.position.x < 5 || deadlyNote2.transform.position.x < 3 && deadlyNote2.transform.position.x > 2){
                            AttackAnimal("トカゲ",deadlyNote2, false, CharaStatus.tokage.OffensivePower, true);
                            note.deadlyNote2nd = false;
                        }
                    }
                }
            }
            //3番目の勇者が攻撃するときの処理
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= -0.4 && ray.y <= 0.6){
                    if(GameObject.Find("momonganote") == true){
                        if (note3.transform.position.x >= 3 && note3.transform.position.x <= 4){
                            AttackAnimal("モモンガ",note3, true, CharaStatus.momonga.OffensivePower, false);
                            momongaAnimation.AttackAnimation();
                            momongaAttackScript.AttackEffect("momonga");
                            note.note3rd = false;
                        }
                        else if (note3.transform.position.x > 4 && note3.transform.position.x < 5 || note3.transform.position.x < 3 && note3.transform.position.x > 2){
                            AttackAnimal("モモンガ",note3, false, CharaStatus.momonga.OffensivePower, false);
                            note.note3rd = false;
                        }
                    }
                }
            }
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= -0.4 && ray.y <= 0.6){
                    if(GameObject.Find("momongadeadlyNote") == true){
                        if (deadlyNote3.transform.position.x >= 3.2f && deadlyNote3.transform.position.x <= 3.8f){
                            AttackAnimal("モモンガ",deadlyNote3, true, CharaStatus.momonga.OffensivePower, true);
                            momongaAnimation.AttackAnimation();
                            momongaAttackScript.AttackEffect("momonga");
                            note.deadlyNote3rd = false;
                        }
                        else if (deadlyNote3.transform.position.x > 4 && deadlyNote3.transform.position.x < 5 || deadlyNote3.transform.position.x < 3 && deadlyNote3.transform.position.x > 2){
                            AttackAnimal("モモンガ",deadlyNote3, false, CharaStatus.momonga.OffensivePower, true);
                            note.deadlyNote3rd = false;
                        }
                    }
                }
            }
            //4番目の勇者が攻撃するときの処理
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= -2.3 && ray.y <= -1.0){
                    if (GameObject.Find("kamenote") == true){
                        if (note4.transform.position.x >= 3 && note4.transform.position.x <= 4){
                            AttackAnimal("カメ",note4, true, CharaStatus.kame.OffensivePower, false);
                            kameAnimation.AttackAnimation();
                            kameAttackScript.AttackEffect("kame");
                            note.note4th = false;
                        }
                        else if (note4.transform.position.x > 4 && note4.transform.position.x < 5 || note4.transform.position.x < 3 && note4.transform.position.x > 2){
                            AttackAnimal("カメ",note4, false, CharaStatus.kame.OffensivePower, false);
                            note.note4th = false;
                        }
                    }
                }
            }
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= -2.3 && ray.y <= -1.0){
                    if(GameObject.Find("kamedeadlyNote") == true){
                        if (deadlyNote4.transform.position.x >= 3.2f && deadlyNote4.transform.position.x <= 3.8){
                            AttackAnimal("カメ",deadlyNote4, true, CharaStatus.kame.OffensivePower, true);
                            kameAnimation.AttackAnimation();
                            kameAttackScript.AttackEffect("kame");
                            note.deadlyNote4th = false;
                        }
                        else if (deadlyNote4.transform.position.x > 4 && deadlyNote4.transform.position.x < 5 || deadlyNote4.transform.position.x < 3 && deadlyNote4.transform.position.x > 2){
                            AttackAnimal("カメ",deadlyNote4, false, CharaStatus.kame.OffensivePower, true);
                            note.deadlyNote4th = false;

                        }
                    }
                }
            }
        }
    }
    
    //ノーツの速度変更の関数
    public float NoteSpeeds(){
        float noteSpeed = Random.Range(0.05f, 0.1f);
        return noteSpeed;
    }
    //ダメージの軽減があるかどうかの判定をする関数
    public void DamageCut(GameObject notes,bool i){
        Destroy(notes);
        //HPを減らす関数
        if(i == true){
            scenarioText.ChengeScenarioText("防御成功");
        } else {
            scenarioText.ChengeScenarioText("防御失敗");
        }
        hp.DownPartyHp(i, CharaStatus.tinpan.OffensivePower);
    }
    //勇者が攻撃する関数
    private void AttackAnimal(string animalName,GameObject notes,bool hantei,int power,bool deadly){
        Destroy(notes);
        //攻撃成功かどうかの判定
        if(hantei == true){
            //必殺ノーツかどうかの判定
            if(deadly == true){
                power = power * 2;
                scenarioText.ChengeScenarioText(animalName + "必殺技\n" + power + "ダメージを与えた");
                scenarioChara.PopUpChara(animalName);
            } else　{
                scenarioText.ChengeScenarioText(animalName + "攻撃\n" + power + "ダメージを与えた");
            }
            hp.DownEnemyHp(power);
            tinpanAnimation.DamegeAnimation();
        } else {
            scenarioText.ChengeScenarioText(animalName + "攻撃失敗\n");
        }
    }
    public void AllCharaPartyDamage()
    {
        datyoAnimation.DefenceAnimation();
        tokageAnimation.DefenceAnimation();
        momongaAnimation.DefenceAnimation();
        kameAnimation.DefenceAnimation();
    }

    private void InputNoteObject(){
        if (GameObject.Find("datyonote") == true){
            note1 = GameObject.Find("datyonote");
        }
        if (GameObject.Find("tokagenote") == true){
            note2 = GameObject.Find("tokagenote");
        }
        if (GameObject.Find("momonganote") == true){
            note3 = GameObject.Find("momonganote");
        }
        if (GameObject.Find("kamenote") == true){
            note4 = GameObject.Find("kamenote");
        }
        if (GameObject.Find("enemyNote1") == true){
            enemyNote1 = GameObject.Find("enemyNote1");
        }
        if (GameObject.Find("enemyNote2") == true){
            enemyNote2 = GameObject.Find("enemyNote2");
        }
        if (GameObject.Find("enemyNote3") == true){
            enemyNote3 = GameObject.Find("enemyNote3");
        }
        if (GameObject.Find("datyodeadlyNote") == true){
            deadlyNote1 = GameObject.Find("datyodeadlyNote");
        }
        if (GameObject.Find("tokagedeadlyNote") == true){
            deadlyNote2 = GameObject.Find("tokagedeadlyNote");
        }
        if (GameObject.Find("momongadeadlyNote") == true){
            deadlyNote3 = GameObject.Find("momongadeadlyNote");
        }
        if (GameObject.Find("kamedeadlyNote") == true){
            deadlyNote4 = GameObject.Find("kamedeadlyNote");
        }
    }
}
