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
            StopNote(note1);
        }
        if (note2.transform.position.x <= -7.5f){
            note2speed = 0;
            StopNote(note2);
        }
        if (note3.transform.position.x <= -7.5f){
            note3speed = 0;
            StopNote(note3);
        }
        //値によってランダムなnoteを戻らせる条件
        random = RandomRange();
        if (note1.transform.position.y >= 5){
            if (random >= 4800 && random <= 4900){
                note1speed = NoteSpeeds();
                RetrunNote(note1);
            }
        }
        if (note2.transform.position.y >= 5){
            if (random > 4900 && random <= 5000){
                note2speed = NoteSpeeds();
                RetrunNote(note2);
            }
        }
        if (note3.transform.position.y >= 5){
            if (random > 5000 && random <= 5100){
                note3speed = NoteSpeeds();
                RetrunNote(note3);
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
    //noteを止める関数
    private void StopNote(GameObject notes){
        note1speed = 0;
        notes.transform.position = new Vector2(10, 5);
        GameControlers.PartyDamage(false);
    }
    //noteを出現させる関数
    private void RetrunNote(GameObject notes){
        notes.transform.position = new Vector2(3, 2.25f);
    }
}
