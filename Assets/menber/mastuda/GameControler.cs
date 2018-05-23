
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
    }

    void Update(){
        //Update内で一度だけ行う処理
        
        if (Input.GetMouseButtonDown(0)){
            mouseClickPosition = Input.mousePosition;
            //敵の攻撃を防ぐ処理
            Debug.Log("クリックした座標は" + mouseClickPosition);
            if (mouseClickPosition.x >= 0.0 && mouseClickPosition.x <= 230.0f){
                if (mouseClickPosition.y >= 190.0 && mouseClickPosition.y <= 676.0){
                    if (enemynote1.transform.position.x <= -3 && enemynote1.transform.position.x >= -5){
                        enemynote1.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("敵の攻撃を防いだ");
                        PartyDamage(true);
                    }
                    if (enemynote2.transform.position.x <= -3 && enemynote2.transform.position.x >= -5){
                        enemynote2.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("敵の攻撃を防いだ");
                        PartyDamage(true);
                    }
                    if (enemynote3.transform.position.x <= -3 && enemynote3.transform.position.x >= -5){
                        enemynote3.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("敵の攻撃を防いだ");
                        PartyDamage(true);
                    }
                }
            }
            //1番目の勇者が攻撃する処理
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f){
                if (mouseClickPosition.y >= 559.0 && mouseClickPosition.y <= 676.0){
                    if (note1.transform.position.x >= 3 && note1.transform.position.x <= 5){
                        note1.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者１攻撃");
                        hp.DownEnemyHp();
                    }
                    if (deadlyNote1.transform.position.x >= 3 && note1.transform.position.x <= 5){
                        deadlyNote1.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者１必殺技");
                        hp.DownEnemyHp();
                    }
                }
            }
            //2番目の勇者が攻撃する時の処理
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f){
                if (mouseClickPosition.y >= 451.0 && mouseClickPosition.y < 559.0){
                    if (note2.transform.position.x >= 3 && note2.transform.position.x <= 5){
                        note2.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者2攻撃");
                        hp.DownEnemyHp();
                    }
                    if (deadlyNote2.transform.position.x >= 3 && note2.transform.position.x <= 5){
                        deadlyNote2.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者2必殺技");
                        hp.DownEnemyHp();
                    }
                }
            }
            //3番目の勇者が攻撃するときの処理
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f){
                if (mouseClickPosition.y >= 322.0 && mouseClickPosition.y <= 451.0){
                    if (note3.transform.position.x >= 3 && note3.transform.position.x <= 5){
                        note3.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者3攻撃");
                        hp.DownEnemyHp();
                    }
                    if (deadlyNote3.transform.position.x >= 3 && note3.transform.position.x <= 5){
                        deadlyNote3.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者3必殺技");
                        hp.DownEnemyHp();
                    }
                }
            }
            //4番目の勇者が攻撃するときの処理
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f){
                if (mouseClickPosition.y >= 190.0 && mouseClickPosition.y <= 322.0){
                    if (note4.transform.position.x >= 3 && note4.transform.position.x <= 5){
                        note4.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者4攻撃");
                        hp.DownEnemyHp();
                    }
                    if (deadlyNote4.transform.position.x >= 3 && note4.transform.position.x <= 5){
                        deadlyNote4.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者4必殺技");
                        hp.DownEnemyHp();
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
    //ランダムな数値を出す関数
    public int RandomRange(){
        int random = Random.Range(0, 10000);
        return random;
    }
    public void PartyDamage(bool i)
    {
        hp.DownPartyHp(i);
    }

}
