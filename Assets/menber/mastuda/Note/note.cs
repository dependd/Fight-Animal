using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note : MonoBehaviour {
    int random;
    //ノーツのスピードを入れておく変数
    float note1Speed;
    float note2Speed;
    float note3Speed;
    float note4Speed;
    float deadlyNote1Speed;
    float deadlyNote2Speed;
    float deadlyNote3Speed;
    float deadlyNote4Speed;
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
        note1.transform.position += new Vector3(note1Speed, 0, 0);
        note2.transform.position += new Vector3(note2Speed, 0, 0);
        note3.transform.position += new Vector3(note3Speed, 0, 0);
        note4.transform.position += new Vector3(note4Speed, 0, 0);
        deadlyNote1.transform.position += new Vector3(deadlyNote1Speed, 0, 0);
        deadlyNote2.transform.position += new Vector3(deadlyNote2Speed, 0, 0);
        deadlyNote3.transform.position += new Vector3(deadlyNote3Speed, 0, 0);
        deadlyNote4.transform.position += new Vector3(deadlyNote4Speed, 0, 0);

        //画面外に出たnoteを止める条件
        if (note1.transform.position.x >= 7.5f){
            ReMoveNote(note1,-10,7);
            note1Speed = 0;
        }
        if (note2.transform.position.x >= 7.5f){
            ReMoveNote(note2,-10,7);
            note2Speed = 0;
        }
        if (note3.transform.position.x >= 7.5f){
            ReMoveNote(note3,-10,7);
            note3Speed = 0;
        }
        if (note4.transform.position.x >= 7.5f){
            ReMoveNote(note4,-10,7);
            note4Speed = 0;
        }
        if (deadlyNote1.transform.position.x >= 7.5f){
            ReMoveNote(deadlyNote1,-10,7);
            deadlyNote1Speed = 0;
        }
        if (deadlyNote2.transform.position.x >= 7.5f){
            ReMoveNote(deadlyNote2,-10,7);
            deadlyNote2Speed = 0;
        }
        if (deadlyNote3.transform.position.x >= 7.5f){
            ReMoveNote(deadlyNote3,-10,7);
            deadlyNote3Speed = 0;
        }
        if (deadlyNote4.transform.position.x >= 7.5f){
            ReMoveNote(deadlyNote4,-10,7);
            deadlyNote4Speed = 0;
        }
        //値によってランダムなnoteを戻らせる条件
        random = RandomRange();
        if (note1.transform.position.y == 7){
            if (random > 4500 && random <= 4750 && deadlyNote1.transform.position.y != 3){
                ReMoveNote(note1, -3, 3);
                note1Speed = (float)CharaStatus.momonga.NoteSpeed;
            }
        }
        if (note2.transform.position.y == 7){
            if (random > 4750 && random <= 5000 && deadlyNote2.transform.position.y != 1.46f){
                ReMoveNote(note2, -3, 1.46f);
                note2Speed = (float)CharaStatus.tokage.NoteSpeed;
            }
        }
        if (note3.transform.position.y == 7){
            if (random > 5000 && random <= 5250 && deadlyNote3.transform.position.y != 0){
                ReMoveNote(note3, -3, 0);
                note3Speed = (float)CharaStatus.datyo.NoteSpeed;
            }
        }
        if (note4.transform.position.y == 7){
            if (random > 5250 && random <= 5500 && deadlyNote4.transform.position.y != -1.65f){
                ReMoveNote(note4, -3, -1.65f);
                note4Speed = (float)CharaStatus.kame.NoteSpeed;
            }
        }
        if (deadlyNote1.transform.position.y == 7){
            if (random >= 4400 && random <= 4450 && note1.transform.position.y != 3){
                ReMoveNote(deadlyNote1, -3, 3);
                deadlyNote1Speed = (float)CharaStatus.momonga.DeadlyNoteSpeed;
            }
        }
        if (deadlyNote2.transform.position.y == 7){
            if (random >= 4450 && random <= 4500 && note2.transform.position.y != 1.46f){
                ReMoveNote(deadlyNote2, -3, 1.46f);
                deadlyNote2Speed = (float)CharaStatus.tokage.DeadlyNoteSpeed;
            }
        }
        if (deadlyNote3.transform.position.y == 7){
            if (random >= 5500 && random <= 5550 && note3.transform.position.y != 0){
                ReMoveNote(deadlyNote3, -3, 0);
                deadlyNote3Speed = (float)CharaStatus.datyo.DeadlyNoteSpeed;
            }
        }
        if (deadlyNote4.transform.position.y == 7){
            if (random >= 5550 && random <= 5600 && note4.transform.position.y != -1.65f){
                ReMoveNote(deadlyNote4, -3, -1.65f);
                deadlyNote4Speed = (float)CharaStatus.kame.DeadlyNoteSpeed;
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
