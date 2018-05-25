
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
    Charastatus Charastatus;
    //メニューを押したら(一応)スタートに戻る
    public void MenuButton(){
        SceneManager.LoadScene("start");
    }
    void Start(){
        note1 = GameObject.Find("note1");
        note2 = GameObject.Find("note2");
        note3 = GameObject.Find("note3");
        note4 = GameObject.Find("note4");
        enemynote1 = GameObject.Find("enemynote1");
        enemynote2 = GameObject.Find("enemynote2");
        enemynote3 = GameObject.Find("enemynote3");
        deadlyNote1 = GameObject.Find("deadlyNote1");
        deadlyNote2 = GameObject.Find("deadlyNote2");
        deadlyNote3 = GameObject.Find("deadlyNote3");
        deadlyNote4 = GameObject.Find("deadlyNote4");

        notes = GameObject.Find("enemySlider");
        hp = notes.GetComponent<hp>();

        Charastatus = GetComponent<Charastatus>();
        Charastatus.Charactor();
    }

    void Update(){
        //Update内で一度だけ行う処理
        
        if (Input.GetMouseButtonDown(0)){
            mouseClickPosition = Input.mousePosition;
            //敵の攻撃を防ぐ処理
            Debug.Log("クリックした座標は" + mouseClickPosition);
            if (mouseClickPosition.x >= 35.0 && mouseClickPosition.x <= 190.0f){
                if (mouseClickPosition.y >= 250.0 && mouseClickPosition.y <= 640.0){
                    if (enemynote1.transform.position.x <= -3 && enemynote1.transform.position.x >= -4){
                        enemynote1.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("敵の攻撃を防いだ");
                        PartyDamage(true);
                    }
                    else if (enemynote1.transform.position.x > -4 && enemynote1.transform.position.x < -5 || enemynote1.transform.position.x < -3 && enemynote1.transform.position.x > -2){
                        enemynote1.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("防御失敗");
                        PartyDamage(false);
                    }
                    if (enemynote2.transform.position.x <= -3 && enemynote2.transform.position.x >= -4){
                        enemynote2.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("敵の攻撃を防いだ");
                        PartyDamage(true);
                    }
                    else if (enemynote2.transform.position.x > -4 && enemynote1.transform.position.x < -5 || enemynote2.transform.position.x < -3 && enemynote1.transform.position.x > -2){
                        enemynote2.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("防御失敗");
                        PartyDamage(false);
                    }
                    if (enemynote3.transform.position.x <= -3 && enemynote3.transform.position.x >= -4){
                        enemynote3.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("敵の攻撃を防いだ");
                        PartyDamage(true);
                    } else if (enemynote3.transform.position.x > -4 && enemynote1.transform.position.x < -5 || enemynote3.transform.position.x < -3 && enemynote1.transform.position.x > -2){
                        enemynote3.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("防御失敗");
                        PartyDamage(false);
                    }
                }
            }
            //1番目の勇者が攻撃する処理
            if (mouseClickPosition.x >= 839.0 && mouseClickPosition.x <= 1024.0f){
                if (mouseClickPosition.y >= 580.0 && mouseClickPosition.y <= 660.0){
                    if (note1.transform.position.x >= 3 && note1.transform.position.x <= 4){
                        note1.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者１攻撃");
                        Charastatus.Animal tokage = new Charastatus.Animal();
                        int tokageAttack = tokage.OffensivePower;
                        Debug.Log(tokageAttack);
                        hp.DownEnemyHp();
                    } else if (note1.transform.position.x > 4 && enemynote1.transform.position.x < 5 || note1.transform.position.x < 3 && enemynote1.transform.position.x > 2){
                        note1.transform.position = new Vector2(10, 5);
                        Debug.Log("攻撃失敗");
                    }
                    if (deadlyNote1.transform.position.x >= 3.2f && deadlyNote1.transform.position.x <= 3.8f){
                        deadlyNote1.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者１必殺技");
                        hp.DownEnemyHp();
                    }　else if (deadlyNote1.transform.position.x > 3.8f && enemynote1.transform.position.x < 5 || deadlyNote1.transform.position.x < 3.2f && enemynote1.transform.position.x > 2){
                        deadlyNote1.transform.position = new Vector2(-10, 5);
                        Debug.Log("攻撃失敗");
                    }
                }
            }
            //2番目の勇者が攻撃する時の処理
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f){
                if (mouseClickPosition.y >= 460.0 && mouseClickPosition.y < 540.0){
                    if (note2.transform.position.x >= 3 && note2.transform.position.x <= 4){
                        note2.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者2攻撃");
                        hp.DownEnemyHp();
                    } else if (note2.transform.position.x > 4 && enemynote1.transform.position.x < 5 || note2.transform.position.x < 3 && enemynote1.transform.position.x > 2){
                        note2.transform.position = new Vector2(10, 5);
                        Debug.Log("攻撃失敗");
                    }
                    if (deadlyNote2.transform.position.x >= 3.2 && deadlyNote2.transform.position.x <= 3.8){
                        deadlyNote2.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者2必殺技");
                        hp.DownEnemyHp();
                    }else if (deadlyNote2.transform.position.x > 4 && enemynote1.transform.position.x < 5 || deadlyNote2.transform.position.x < 3 && enemynote1.transform.position.x > 2){
                        deadlyNote2.transform.position = new Vector2(-10, 5);
                        Debug.Log("攻撃失敗");
                    }
                }
            }
            //3番目の勇者が攻撃するときの処理
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f){
                if (mouseClickPosition.y >= 340.0 && mouseClickPosition.y <= 420.0){
                    if (note3.transform.position.x >= 3 && note3.transform.position.x <= 4){
                        note3.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者3攻撃");
                        hp.DownEnemyHp();
                    }else if (note3.transform.position.x > 4 && enemynote1.transform.position.x < 5 || note3.transform.position.x < 3 && enemynote1.transform.position.x > 2){
                        note3.transform.position = new Vector2(10, 5);
                        Debug.Log("攻撃失敗");
                    }
                    if (deadlyNote3.transform.position.x >= 3.2f && deadlyNote3.transform.position.x <= 3.8f){
                        deadlyNote3.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者3必殺技");
                        hp.DownEnemyHp();
                    }else if (deadlyNote3.transform.position.x > 4 && enemynote1.transform.position.x < 5 || deadlyNote3.transform.position.x < 3 && enemynote1.transform.position.x > 2){
                        deadlyNote3.transform.position = new Vector2(-10, 5);
                        Debug.Log("攻撃失敗");
                    }
                }
            }
            //4番目の勇者が攻撃するときの処理
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f){
                if (mouseClickPosition.y >= 220.0 && mouseClickPosition.y <= 300.0){
                    if (note4.transform.position.x >= 3 && note4.transform.position.x <= 4){
                        note4.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者4攻撃");
                        hp.DownEnemyHp();
                    }else if (note4.transform.position.x > 4 && enemynote1.transform.position.x < 5 || note4.transform.position.x < 3 && enemynote1.transform.position.x > 2){
                        note4.transform.position = new Vector2(10, 5);
                        Debug.Log("攻撃失敗");
                    }
                    if (deadlyNote4.transform.position.x >= 3.2f && deadlyNote4.transform.position.x <= 3.8){
                        deadlyNote4.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者4必殺技");
                        hp.DownEnemyHp();
                    }else if (deadlyNote4.transform.position.x > 4 && enemynote1.transform.position.x < 5 || deadlyNote4.transform.position.x < 3 && enemynote1.transform.position.x > 2){
                        deadlyNote4.transform.position = new Vector2(10, 5);
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
    //hpスクリプトのDownPartyHpに参照して味方のHpを減らす関数
    public void PartyDamage(bool i)
    {
        hp.DownPartyHp(i);
    }

}
