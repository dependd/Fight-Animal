
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour{
    //乱数を入れる変数
    int random;
    //マウスのクリック位置を入れる変数
    Vector2 mouseClickPosition;
    //ノーツのゲームオブジェクトを入れる変数
    GameObject note1;
    GameObject note2;
    GameObject note3;
    GameObject note4;
    GameObject enemynote1;
    GameObject enemynote2;
    GameObject enemynote3;
    GameObject deadlyNote1;
    GameObject deadlyNote2;
    GameObject deadlyNote3;
    GameObject deadlyNote4;
    //hpスクリプトに参照するための変数
    GameObject notes;
    hp hp;
    //Charastatusスクリプトに参照するための変数
    Charastatus CharaStatus;
    //メニューを押したら(一応)スタートに戻る
    public void MenuButton(){
        SceneManager.LoadScene("start");
    }
    void Start(){
        note1 = GameObject.Find("note1");
        note2 = GameObject.Find("note2");
        note3 = GameObject.Find("note3");
        note4 = GameObject.Find("note4");
        enemynote1 = GameObject.Find("enemyNote1");
        enemynote2 = GameObject.Find("enemyNote2");
        enemynote3 = GameObject.Find("enemyNote3");
        deadlyNote1 = GameObject.Find("deadlyNote1");
        deadlyNote2 = GameObject.Find("deadlyNote2");
        deadlyNote3 = GameObject.Find("deadlyNote3");
        deadlyNote4 = GameObject.Find("deadlyNote4");
        //enemySliderのhpスクリプトを取得
        notes = GameObject.Find("enemySlider");
        hp = notes.GetComponent<hp>();
        //CharaStatusスクリプトを取得
        CharaStatus = GetComponent<Charastatus>();
    }

    void Update(){
        
        if (Input.GetMouseButtonDown(0)){
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //敵の攻撃を防ぐ処理
            Debug.Log("クリックした座標は" + ray);
            if (mouseClickPosition.x >= 35.0 && mouseClickPosition.x <= 190.0f){
                if (mouseClickPosition.y >= 250.0 && mouseClickPosition.y <= 640.0){
                    if (enemynote1.transform.position.x <= -3 && enemynote1.transform.position.x >= -4){
                        DamageCut(enemynote1,true);
                    }
                    else if (enemynote1.transform.position.x > -4 && enemynote1.transform.position.x < -5 || enemynote1.transform.position.x < -3 && enemynote1.transform.position.x > -2){
                        DamageCut(enemynote1,false);
                    }
                    if (enemynote2.transform.position.x <= -3 && enemynote2.transform.position.x >= -4){
                        DamageCut(enemynote2,true);
                    }
                    else if (enemynote2.transform.position.x > -4 && enemynote2.transform.position.x < -5 || enemynote2.transform.position.x < -3 && enemynote2.transform.position.x > -2){
                        DamageCut(enemynote2,false);
                    }
                    if (enemynote3.transform.position.x <= -3 && enemynote3.transform.position.x >= -4){
                        DamageCut(enemynote3, true);
                    }
                    else if (enemynote3.transform.position.x > -4 && enemynote3.transform.position.x < -5 || enemynote3.transform.position.x < -3 && enemynote3.transform.position.x > -2){
                        DamageCut(enemynote3, false);
                    }
                }
            }
            //1番目の勇者が攻撃する処理
            if (mouseClickPosition.x >= 839.0 && mouseClickPosition.x <= 1024.0f){
                if (mouseClickPosition.y >= 580.0 && mouseClickPosition.y <= 660.0){
                    if (note1.transform.position.x >= 3 && note1.transform.position.x <= 4){
                        AttackAnimal(note1, true, CharaStatus.datyo.OffensivePower, false);
                        Debug.Log("ダチョウ攻撃");
                    } else if (note1.transform.position.x > 4 && note1.transform.position.x < 5 || note1.transform.position.x < 3 && note1.transform.position.x > 2){
                        AttackAnimal(note1, false, CharaStatus.datyo.OffensivePower, false);
                        Debug.Log("攻撃失敗");
                    }

                    if (deadlyNote1.transform.position.x >= 3.2f && deadlyNote1.transform.position.x <= 3.8f){
                        AttackAnimal(deadlyNote1, true, CharaStatus.datyo.OffensivePower, true);
                        Debug.Log("ダチョウ必殺技");
                    }　else if (deadlyNote1.transform.position.x > 3.8f && deadlyNote1.transform.position.x < 5 || deadlyNote1.transform.position.x < 3.2f && deadlyNote1.transform.position.x > 2){
                        AttackAnimal(deadlyNote1, false, CharaStatus.datyo.OffensivePower, true);
                        Debug.Log("攻撃失敗");
                    }
                }
            }
            //2番目の勇者が攻撃する時の処理
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f){
                if (mouseClickPosition.y >= 460.0 && mouseClickPosition.y < 540.0){
                    if (note2.transform.position.x >= 3 && note2.transform.position.x <= 4){
                        AttackAnimal(note2, true, CharaStatus.tokage.OffensivePower, false);
                        Debug.Log("トカゲ攻撃");
                    } else if (note2.transform.position.x > 4 && note2.transform.position.x < 5 || note2.transform.position.x < 3 && note2.transform.position.x > 2){
                        AttackAnimal(note2, false, CharaStatus.tokage.OffensivePower, false);
                        Debug.Log("攻撃失敗");
                    }
                    if (deadlyNote2.transform.position.x >= 3.2 && deadlyNote2.transform.position.x <= 3.8){
                        AttackAnimal(deadlyNote2, true, CharaStatus.tokage.OffensivePower, true);
                        Debug.Log("トカゲ必殺技");
                    }else if (deadlyNote2.transform.position.x > 4 && deadlyNote2.transform.position.x < 5 || deadlyNote2.transform.position.x < 3 && deadlyNote2.transform.position.x > 2){
                        AttackAnimal(deadlyNote2, false, CharaStatus.tokage.OffensivePower, true);
                        Debug.Log("攻撃失敗");
                    }
                }
            }
            //3番目の勇者が攻撃するときの処理
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f){
                if (mouseClickPosition.y >= 340.0 && mouseClickPosition.y <= 420.0){
                    if (note3.transform.position.x >= 3 && note3.transform.position.x <= 4){
                        AttackAnimal(note3, true, CharaStatus.momonga.OffensivePower, false);
                        Debug.Log("モモンガ攻撃");
                    }else if (note3.transform.position.x > 4 && note3.transform.position.x < 5 || note3.transform.position.x < 3 && note3.transform.position.x > 2){
                        AttackAnimal(note3, false, CharaStatus.momonga.OffensivePower, false);
                        Debug.Log("攻撃失敗");
                    }
                    if (deadlyNote3.transform.position.x >= 3.2f && deadlyNote3.transform.position.x <= 3.8f){
                        AttackAnimal(deadlyNote3, true, CharaStatus.momonga.OffensivePower, true);
                        Debug.Log("モモンガ必殺技");
                    }else if (deadlyNote3.transform.position.x > 4 && deadlyNote3.transform.position.x < 5 || deadlyNote3.transform.position.x < 3 && deadlyNote3.transform.position.x > 2){
                        AttackAnimal(deadlyNote3, false, CharaStatus.momonga.OffensivePower, true);
                        Debug.Log("攻撃失敗");
                    }
                }
            }
            //4番目の勇者が攻撃するときの処理
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f){
                if (mouseClickPosition.y >= 220.0 && mouseClickPosition.y <= 300.0){
                    if (note4.transform.position.x >= 3 && note4.transform.position.x <= 4){
                        AttackAnimal(note4, true, CharaStatus.kame.OffensivePower, false);
                        Debug.Log("カメ攻撃");
                    }else if (note4.transform.position.x > 4 && note4.transform.position.x < 5 || note4.transform.position.x < 3 && note4.transform.position.x > 2){
                        AttackAnimal(note4, false, CharaStatus.kame.OffensivePower, false);
                        Debug.Log("攻撃失敗");
                    }
                    if (deadlyNote4.transform.position.x >= 3.2f && deadlyNote4.transform.position.x <= 3.8){
                        AttackAnimal(deadlyNote4, true, CharaStatus.kame.OffensivePower, true);
                        Debug.Log("カメ必殺技");
                    }else if (deadlyNote4.transform.position.x > 4 && deadlyNote4.transform.position.x < 5 || deadlyNote4.transform.position.x < 3 && deadlyNote4.transform.position.x > 2){
                        AttackAnimal(deadlyNote4, false, CharaStatus.kame.OffensivePower, true);
                        Debug.Log("攻撃失敗");
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
        notes.transform.position = new Vector2(10, 5);
        //HPを減らす関数
        hp.DownPartyHp(i, CharaStatus.tinpan.OffensivePower);
    }
    //勇者が攻撃する関数
    private void AttackAnimal(GameObject notes,bool hantei,int power,bool deadly){
        notes.transform.position = new Vector2(-10, 7);
        //攻撃成功かどうかの判定
        if(hantei == true){
            //必殺ノーツかどうかの判定
            if(deadly == true){
                power = power * 2;
            }
            hp.DownEnemyHp(power);
        }
    }
}
