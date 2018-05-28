﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note : MonoBehaviour {
    int random;
    //ノーツのスピードを入れておく変数
    float note1speed;
    float note2speed;
    float note3speed;
    float note4speed;
    //ノーツのオブジェクトを入れておく変数
    GameObject note1;
    GameObject note2;
    GameObject note3;
    GameObject note4;
    GameObject deadlyNote1;
    GameObject deadlyNote2;
    GameObject deadlyNote3;
    GameObject deadlyNote4;
    //CharaStatusスクリプトに参照するための変数
    GameObject GameControlers;
    Charastatus CharaStatus;
    // Use this for initialization
    void Start () {

        note1 = GameObject.Find("note1");
        note2 = GameObject.Find("note2");
        note3 = GameObject.Find("note3");
        note4 = GameObject.Find("note4");
        deadlyNote1 = GameObject.Find("deadlyNote1");
        deadlyNote2 = GameObject.Find("deadlyNote2");
        deadlyNote3 = GameObject.Find("deadlyNote3");
        deadlyNote4 = GameObject.Find("deadlyNote4");
        //GameControlerのCharaStatusスクリプトを取得
        GameControlers = GameObject.Find("GameControler");
        CharaStatus = GameControlers.GetComponent<Charastatus>();
        //noteSpeedに初期値を入れる
    }
	
	// Update is called once per frame
	void Update () {
        
        //noteを動かす処理
        note1.transform.position += new Vector3(note1speed, 0, 0);
        note2.transform.position += new Vector3(note2speed, 0, 0);
        note3.transform.position += new Vector3(note3speed, 0, 0);
        note4.transform.position += new Vector3(note4speed, 0, 0);
        deadlyNote1.transform.position += new Vector3(note1speed + 0.05f, 0, 0);
        deadlyNote2.transform.position += new Vector3(note2speed + 0.05f, 0, 0);
        deadlyNote3.transform.position += new Vector3(note3speed + 0.05f, 0, 0);
        deadlyNote4.transform.position += new Vector3(note4speed + 0.05f, 0, 0);

        //画面外に出たnoteを止める条件
        //画面外に出たら味方にダメージを与える処理
        if (note1.transform.position.x >= 7.5f){
            note1speed = 0;
            ReMoveNote(note1,-10,7);
        }
        if (note2.transform.position.x >= 7.5f){
            note2speed = 0;
            ReMoveNote(note2,-10,7);
        }
        if (note3.transform.position.x >= 7.5f){
            note3speed = 0;
            ReMoveNote(note3,-10,7);
        }
        if (note4.transform.position.x >= 7.5f){
            note4speed = 0;
            ReMoveNote(note4,-10,7);
        }
        if (deadlyNote1.transform.position.x >= 7.5f){
            note1speed = 0;
            ReMoveNote(deadlyNote1,-10,7);
        }
        if (deadlyNote2.transform.position.x >= 7.5f){
            note2speed = 0;
            ReMoveNote(deadlyNote2,-10,7);
        }
        if (deadlyNote3.transform.position.x >= 7.5f){
            note3speed = 0;
            ReMoveNote(deadlyNote3,-10,7);
        }
        if (deadlyNote4.transform.position.x >= 7.5f){
            note4speed = 0;
            ReMoveNote(deadlyNote4,-10,7);
        }
        //値によってランダムなnoteを戻らせる条件
        random = RandomRange();
        if (note1.transform.position.y == 7){
            if (random > 4500 && random <= 4750){
                note1speed = 0.1f;
                ReMoveNote(note1, -3, 3);
            }
        }
        if (note2.transform.position.y == 7){
            if (random > 4750 && random <= 5000){
                note2speed = 0.1f;
                ReMoveNote(note2, -3, 1.46f);
            }
        }
        if (note3.transform.position.y == 7){
            if (random > 5000 && random <= 5250){
                note3speed = 0.1f;
                ReMoveNote(note3, -3, 0);
            }
        }
        if (note4.transform.position.y == 7){
            if (random > 5250 && random <= 5500){
                note4speed = 0.1f;
                ReMoveNote(note4, -3, -1.65f);
            }
        }
        if (deadlyNote1.transform.position.y == 7){
            if (random >= 4400 && random <= 4450){
                note1speed = 0.1f;
                ReMoveNote(deadlyNote1, -3, 3);
            }
        }
        if (deadlyNote2.transform.position.y == 7){
            if (random >= 4450 && random <= 4500){
                note2speed = 0.1f;
                ReMoveNote(deadlyNote2, -3, 1.46f);
            }
        }
        if (deadlyNote3.transform.position.y == 7){
            if (random >= 5500 && random <= 5550){
                note3speed = 0.1f;
                ReMoveNote(deadlyNote3, -3, 0);
            }
        }
        if (deadlyNote4.transform.position.y == 7){
            if (random >= 5550 && random <= 5600){
                note4speed = 0.1f;
                ReMoveNote(deadlyNote4, -3, -1.65f);
            }
        }
    }
    //noteのスピードを変える変数
    private float NoteSpeeds(){
        float noteSpeed = Random.Range(0.05f, 0.15f);
        return noteSpeed;
    }
    //noteが戻るためのランダムな値を出す関数
    private int RandomRange(){
        int random = Random.Range(0, 10000);
        return random;
    }
    private void ReMoveNote(GameObject notes,int i,float j) { 
        notes.transform.position = new Vector2(i, j);
    }
}
