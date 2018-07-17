﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyNote : MonoBehaviour {
    GameObject GameControler;
    GameControler gameControler;
    GameObject tinpan;
    CharaAnimation animation;

    float noteSpeed;
    public float lengeMAX = -0.15f;
    public float lengeMIN = -0.05f;


    string objName;
    private void Start(){
        objName = this.gameObject.name;
        noteSpeed = NoteSpeeds();
        Debug.Log(noteSpeed);
        GameControler = GameObject.Find("GameControler");
        gameControler = GameControler.GetComponent<GameControler>();
        tinpan = GameObject.Find("tinpan");
        animation = tinpan.GetComponent<CharaAnimation>();
    }
    // Update is called once per frame
    void FixedUpdate () {
        this.transform.position += new Vector3(noteSpeed,0,0);
	}

    //noteのスピードを変える変数
    private float NoteSpeeds(){
        float noteSpeed = Random.Range(lengeMIN, lengeMAX);
        return noteSpeed;
    }
    //違うcollision内に入ったら
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //オブジェクトのtagがEnemyならreturn
        if (collision.gameObject.tag == "Party") return;
        //オブジェクトのtagがEndならnoteの削除
        if (collision.gameObject.tag == "End")
        {
            Destroy(this.gameObject);
            gameControler.DamageCut(null, false);
            animation.AttackEffect("tinpan");
        }
        //違うなら判定ラインをtrueに
        else
        {
            CheckEnemyLine(objName, true);
        }
    }
    //collisionから出たら
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Party") return;
        //判定ラインをfalseに
        CheckEnemyLine(objName, false);
    }
    //noteごとに判定ラインをtrueかfalseにする関数
    private void CheckEnemyLine(string line,bool check)
    {
        switch (line)
        {
            case "enemyNote1":
                gameControler.enemyLine1 = check;
                break;
            case "enemyNote2":
                gameControler.enemyLine2 = check;
                break;
            case "enemyNote3":
                gameControler.enemyLine3 = check;
                break;
            default:
                break;
        }
    }
}
