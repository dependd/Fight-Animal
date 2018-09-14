﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePartyNote : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    [SerializeField]
    Sprite lightImages;
    [SerializeField]
    Sprite noteImage;
    //ノーツのスピードを入れる変数
    [HideInInspector]
    public float noteSpeed;
    [HideInInspector]
    public float stocNoteSpeed;
    //ノーツの名前を入れる変数
    string objectName;
    GameObject Gamecontroler;
    GameControler gameControler;
    Charastatus charastatus;
    //NoteFrequencyスクリプトに参照する
    GameObject note;
    NoteFrequency noteFrequency;

    private void Start(){
        objectName = this.gameObject.name;
        Gamecontroler = GameObject.Find("GameControler");
        charastatus = Gamecontroler.GetComponent<Charastatus>();
        noteSpeed = NoteSpeeds();
        gameControler = Gamecontroler.GetComponent<GameControler>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        note = GameObject.Find("PartyNote");
        noteFrequency = note.GetComponent<NoteFrequency>();

    }
    // Update is called once per frame
    void FixedUpdate(){
        this.transform.position += new Vector3(noteSpeed, 0, 0);
    }
    //違うcollision内に入ったら
    void OnTriggerEnter2D(Collider2D collision)
    {
        //オブジェクトのtagがEnemyならreturn
        if (collision.gameObject.tag == "Enemy")return;
        //オブジェクトのtagがEndならnoteの削除
        if (collision.gameObject.tag == "End"){
            Destroy(this.gameObject);
            noteFrequency.NoteCreateFrequency(objectName);
        }
        //違うなら判定ラインをtrueに
        else {
            CheckLine(objectName, true);
            spriteRenderer.sprite = lightImages;
        }

        
    }
    //collisionから出たら
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") return;
        //判定ラインをfalseに
        CheckLine(objectName, false);
        spriteRenderer.sprite = noteImage;
    }

    //noteのスピードを変える変数
    public float NoteSpeeds(){
        if(objectName == "datyonote"){
            return (float)charastatus.momonga.NoteSpeed;
        }
        else if(objectName == "tokagenote"){
            return (float)charastatus.tokage.NoteSpeed;
        }
        else if (objectName == "momonganote"){
            return (float)charastatus.datyo.NoteSpeed;
        }
        else if (objectName == "kamenote"){
            return (float)charastatus.kame.NoteSpeed;
        }
        else if (objectName == "datyodeadlyNote"){
            return (float)charastatus.momonga.DeadlyNoteSpeed;
        }
        else if (objectName == "tokagedeadlyNote"){
            return (float)charastatus.tokage.DeadlyNoteSpeed;
        }
        else if (objectName == "momongadeadlyNote"){
            return (float)charastatus.datyo.DeadlyNoteSpeed;
        }
        else if (objectName == "kamedeadlyNote"){
            return (float)charastatus.kame.DeadlyNoteSpeed;
        } else{
            return 0;
        }
    }
    //キャラごとに判定ラインをtrueかfalseにする関数
    private void CheckLine(string name,bool line)
    {
        switch (name)
        {
            case "datyonote":
                gameControler.datyoLine = line;
                break;
            case "tokagenote":
                gameControler.tokageLine = line;
                break;
            case "momonganote":
                gameControler.momongaLine = line;
                break;
            case "kamenote":
                gameControler.kameLine = line;
                break;
            case "datyodeadlyNote":
                gameControler.datyoLine = line;
                break;
            case "tokagedeadlyNote":
                gameControler.tokageLine = line;
                break;
            case "momongadeadlyNote":
                gameControler.momongaLine = line;
                break;
            case "kamedeadlyNote":
                gameControler.kameLine = line;
                break;
            default:
                break;
        }
    }
}
