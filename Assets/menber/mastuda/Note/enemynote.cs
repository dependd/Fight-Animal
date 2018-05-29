using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemynote : MonoBehaviour{
    int random;
    //ノーツのスピードを入れておく変数
    public float note1speed;
    public float note2speed;
    public float note3speed;
    //
    GameObject note1;
    GameObject note2;
    GameObject note3;
    //hpスクリプトに参照するための変数
    GameObject GameControler;
    GameControler GameControlers;

    // Use this for initialization
    void Start(){

        note1speed = 0;
        note2speed = 0;
        note3speed = 0;

        note1 = GameObject.Find("enemyNote1");
        note2 = GameObject.Find("enemyNote2");
        note3 = GameObject.Find("enemyNote3");

        GameControler = GameObject.Find("GameControler");
        GameControlers = GameControler.GetComponent<GameControler>();
    }

    // Update is called once per frame
    void Update(){
        //noteを動かす処理
        note1.transform.position += new Vector3(note1speed, 0, 0);
        note2.transform.position += new Vector3(note2speed, 0, 0);
        note3.transform.position += new Vector3(note3speed, 0, 0);

        //画面外に出たnoteを止める条件
        //画面外に出たら敵にダメージを与える処理
        if (note1.transform.position.x <= -7.5f){
            note1speed = 0;
            MoveNote(note1,10,5,true);
        }
        if (note2.transform.position.x <= -7.5f){
            note2speed = 0;
            MoveNote(note2,10,5,true);
        }
        if (note3.transform.position.x <= -7.5f){
            note3speed = 0;
            MoveNote(note3,10,5,true);
        }
        //値によってランダムなnoteを戻らせる条件
        random = RandomRange();
        if (note1.transform.position.y >= 5){
            if (random >= 4800 && random <= 4900){
                note1speed = NoteSpeeds();
                MoveNote(note1,3,2.11f,false);
            }
        }
        if (note2.transform.position.y >= 5){
            if (random > 4900 && random <= 5000){
                note2speed = NoteSpeeds();
                MoveNote(note2,3,0.66f,false);
            }
        }
        if (note3.transform.position.y >= 5){
            if (random > 5000 && random <= 5100){
                note3speed = NoteSpeeds();
                MoveNote(note3,3,-0.9f,false);
            }
        }
    }
    //noteのスピードを変える変数
    private float NoteSpeeds(){
        float noteSpeed = Random.Range(-0.05f, -0.15f);
        return noteSpeed;
    }
    //noteが戻るためのランダムな値を出す関数
    private int RandomRange(){
        int random = Random.Range(0, 10000);
        return random;
    }
    //noteを止めたり出現させる関数
    private void MoveNote(GameObject notes,int i ,float j,bool hantei){
        notes.transform.position = new Vector2(i, j);
        //ノーツが移動しきったかどうか
        if (hantei == true){
            GameControlers.PartyDamage(false);
        }
    }
}
