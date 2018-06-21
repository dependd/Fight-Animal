
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
    //メニューを押したら(一応)スタートに戻る
    public void MenuButton(){
        SceneManager.LoadScene("start");
    }
    void Start(){
        //それぞれの変数にオブジェクトを格納する
        partyNoteParent = GameObject.Find("PartyNote").transform;
        enemyNoteParent = GameObject.Find("EnemyNote").transform;
        note1 = GameObject.Find("note1");
        note2 = GameObject.Find("note2");
        note3 = GameObject.Find("note3");
        note4 = GameObject.Find("note4");
        enemyNote1 = GameObject.Find("enemyNote1");
        enemyNote2 = GameObject.Find("enemyNote2");
        enemyNote3 = GameObject.Find("enemyNote3");
        deadlyNote1 = GameObject.Find("deadlyNote1");
        deadlyNote2 = GameObject.Find("deadlyNote2");
        deadlyNote3 = GameObject.Find("deadlyNote3");
        deadlyNote4 = GameObject.Find("deadlyNote4");
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
        //textのScenarioTextスクリプトを取得
        text = GameObject.Find("ScenarioText");
        scenarioText = text.GetComponent<ScenarioText>();
        //
        chara = GameObject.Find("ScinarioChara");
        scenarioChara = chara.GetComponent<ScinarioChara>();
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
                        }
                        else if (enemyNote1.transform.position.x > -4 && enemyNote1.transform.position.x < -5 || enemyNote1.transform.position.x < -3 && enemyNote1.transform.position.x > -2){
                            DamageCut(enemyNote1, false);
                        }
                        enemynote.note1st = false;
                    }

                    if(GameObject.Find("enemyNote2") == true){
                        if (enemyNote2.transform.position.x <= -3 && enemyNote2.transform.position.x >= -4){
                            DamageCut(enemyNote2, true);
                        }
                        else if (enemyNote2.transform.position.x > -4 && enemyNote2.transform.position.x < -5 || enemyNote2.transform.position.x < -3 && enemyNote2.transform.position.x > -2){
                            DamageCut(enemyNote2, false);
                        }
                        enemynote.note2nd = false;
                    }
                    if(GameObject.Find("enemyNote3") == true){
                        if (enemyNote3.transform.position.x <= -3 && enemyNote3.transform.position.x >= -4){
                            DamageCut(enemyNote3, true);
                        }
                        else if (enemyNote3.transform.position.x > -4 && enemyNote3.transform.position.x < -5 || enemyNote3.transform.position.x < -3 && enemyNote3.transform.position.x > -2){
                            DamageCut(enemyNote3, false);
                        }
                        enemynote.note3rd = false;
                    }
                }
            }
            if(partyNoteParent.childCount > 0){
                InputNoteObject();
            }
            //1番目の勇者が攻撃する処理
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= 2.4 && ray.y <= 3.6){
                    if (GameObject.Find("note1") == true){
                        if (note1.transform.position.x >= 3 && note1.transform.position.x <= 4){
                            AttackAnimal("ダチョウ",note1, true, CharaStatus.datyo.OffensivePower, false);
                            Debug.Log("ダチョウ攻撃");
                        }
                        else if (note1.transform.position.x > 4 && note1.transform.position.x < 5 || note1.transform.position.x < 3 && note1.transform.position.x > 2){
                            AttackAnimal("ダチョウ",note1, false, CharaStatus.datyo.OffensivePower, false);
                            Debug.Log("攻撃失敗");
                        }
                        note.note1st = false;
                    }
                }
            }
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= 2.4 && ray.y <= 3.6){
                    if(GameObject.Find("deadlyNote1") == true){
                        if (deadlyNote1.transform.position.x >= 3.2f && deadlyNote1.transform.position.x <= 3.8f){
                            AttackAnimal("ダチョウ",deadlyNote1, true, CharaStatus.datyo.OffensivePower, true);
                            Debug.Log("ダチョウ必殺技");
                        }
                        else if (deadlyNote1.transform.position.x > 3.8f && deadlyNote1.transform.position.x < 5 || deadlyNote1.transform.position.x < 3.2f && deadlyNote1.transform.position.x > 2){
                            AttackAnimal("ダチョウ",deadlyNote1, false, CharaStatus.datyo.OffensivePower, true);
                            Debug.Log("攻撃失敗");
                        }
                        note.deadlyNote1st = false;
                    }
                }
            }
            //2番目の勇者が攻撃する時の処理
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= 1 && ray.y < 2.2){
                    if (GameObject.Find("note2") == true){
                        if (note2.transform.position.x >= 3 && note2.transform.position.x <= 4){
                            AttackAnimal("トカゲ",note2, true, CharaStatus.tokage.OffensivePower, false);
                            Debug.Log("トカゲ攻撃");
                        }
                        else if (note2.transform.position.x > 4 && note2.transform.position.x < 5 || note2.transform.position.x < 3 && note2.transform.position.x > 2){
                            AttackAnimal("トカゲ",note2, false, CharaStatus.tokage.OffensivePower, false);
                            Debug.Log("攻撃失敗");
                        }
                        note.note2nd = false;
                    }
                }
            }
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= 1 && ray.y < 2.2){
                    if (GameObject.Find("deadlyNote2") == true){
                        if (deadlyNote2.transform.position.x >= 3.2 && deadlyNote2.transform.position.x <= 3.8){
                            AttackAnimal("トカゲ",deadlyNote2, true, CharaStatus.tokage.OffensivePower, true);
                            Debug.Log("トカゲ必殺技");
                        }
                        else if (deadlyNote2.transform.position.x > 4 && deadlyNote2.transform.position.x < 5 || deadlyNote2.transform.position.x < 3 && deadlyNote2.transform.position.x > 2){
                            AttackAnimal("トカゲ",deadlyNote2, false, CharaStatus.tokage.OffensivePower, true);
                            Debug.Log("攻撃失敗");
                        }
                        note.deadlyNote2nd = false;
                    }
                }
            }
            //3番目の勇者が攻撃するときの処理
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= -0.4 && ray.y <= 0.6){
                    if(GameObject.Find("note3") == true){
                        if (note3.transform.position.x >= 3 && note3.transform.position.x <= 4){
                            AttackAnimal("モモンガ",note3, true, CharaStatus.momonga.OffensivePower, false);
                            Debug.Log("モモンガ攻撃");
                        }
                        else if (note3.transform.position.x > 4 && note3.transform.position.x < 5 || note3.transform.position.x < 3 && note3.transform.position.x > 2){
                            AttackAnimal("モモンガ",note3, false, CharaStatus.momonga.OffensivePower, false);
                            Debug.Log("攻撃失敗");
                        }
                        note.note3rd = false;
                    }
                }
            }
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= -0.4 && ray.y <= 0.6){
                    if(GameObject.Find("deadlyNote3") == true){
                        if (deadlyNote3.transform.position.x >= 3.2f && deadlyNote3.transform.position.x <= 3.8f){
                            AttackAnimal("モモンガ",deadlyNote3, true, CharaStatus.momonga.OffensivePower, true);
                            Debug.Log("モモンガ必殺技");
                        }
                        else if (deadlyNote3.transform.position.x > 4 && deadlyNote3.transform.position.x < 5 || deadlyNote3.transform.position.x < 3 && deadlyNote3.transform.position.x > 2){
                            AttackAnimal("モモンガ",deadlyNote3, false, CharaStatus.momonga.OffensivePower, true);
                            Debug.Log("攻撃失敗");
                        }
                        note.deadlyNote3rd = false;
                    }
                }
            }
            //4番目の勇者が攻撃するときの処理
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= -2.3 && ray.y <= -1.0){
                    if (GameObject.Find("note4") == true){
                        if (note4.transform.position.x >= 3 && note4.transform.position.x <= 4){
                            AttackAnimal("カメ",note4, true, CharaStatus.kame.OffensivePower, false);
                            Debug.Log("カメ攻撃");
                        }
                        else if (note4.transform.position.x > 4 && note4.transform.position.x < 5 || note4.transform.position.x < 3 && note4.transform.position.x > 2){
                            AttackAnimal("カメ",note4, false, CharaStatus.kame.OffensivePower, false);
                            Debug.Log("攻撃失敗");
                        }
                        note.note4th = false;
                    }
                }
            }
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= -2.3 && ray.y <= -1.0){
                    if(GameObject.Find("deadlyNote4") == true){
                        if (deadlyNote4.transform.position.x >= 3.2f && deadlyNote4.transform.position.x <= 3.8){
                            AttackAnimal("カメ",deadlyNote4, true, CharaStatus.kame.OffensivePower, true);
                            Debug.Log("カメ必殺技");
                        }
                        else if (deadlyNote4.transform.position.x > 4 && deadlyNote4.transform.position.x < 5 || deadlyNote4.transform.position.x < 3 && deadlyNote4.transform.position.x > 2){
                            AttackAnimal("カメ",deadlyNote4, false, CharaStatus.kame.OffensivePower, true);
                            Debug.Log("攻撃失敗");
                        }
                        note.deadlyNote4th = false;
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
        } else {
            scenarioText.ChengeScenarioText(animalName + "攻撃失敗\n");
        }
    }


    private void InputNoteObject(){
        if (GameObject.Find("note1") == true){
            note1 = GameObject.Find("note1");
        }
        if (GameObject.Find("note2") == true){
            note2 = GameObject.Find("note2");
        }
        if (GameObject.Find("note3") == true){
            note3 = GameObject.Find("note3");
        }
        if (GameObject.Find("note4") == true){
            note4 = GameObject.Find("note4");
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
        if (GameObject.Find("deadlyNote1") == true){
            deadlyNote1 = GameObject.Find("deadlyNote1");
        }
        if (GameObject.Find("deadlyNote2") == true){
            deadlyNote2 = GameObject.Find("deadlyNote2");
        }
        if (GameObject.Find("deadlyNote3") == true){
            deadlyNote3 = GameObject.Find("deadlyNote3");
        }
        if (GameObject.Find("deadlyNote4") == true){
            deadlyNote4 = GameObject.Find("deadlyNote4");
        }
    }
}
