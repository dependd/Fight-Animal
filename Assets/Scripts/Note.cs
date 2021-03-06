﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {
    bool one;
    int random;
    //ノーツのスピードを入れておく変数
    public float note1speed;
    public float note2speed;
    public float note3speed;
    public float note4speed;
    // Use this for initialization
    void Start () {
        one = true;
        
    }
	
	// Update is called once per frame
	void Update () {
        //Update関数の中で一度だけ実行する条件
        if (one)
        {
            note1speed = NoteSpeeds();
            Debug.Log(note1speed);
            note2speed = NoteSpeeds();
            Debug.Log(note2speed);
            note3speed = NoteSpeeds();
            Debug.Log(note3speed);
            note4speed = NoteSpeeds();
            Debug.Log(note4speed);
            one = false;
        }
        //noteを動かす処理
        GameObject note1 = GameObject.Find("note1");
        note1.transform.position += new Vector3(note1speed, 0, 0);
        GameObject note2 = GameObject.Find("note2");
        note2.transform.position += new Vector3(note2speed, 0, 0);
        GameObject note3 = GameObject.Find("note3");
        note3.transform.position += new Vector3(note3speed, 0, 0);
        GameObject note4 = GameObject.Find("note4");
        note4.transform.position += new Vector3(note4speed, 0, 0);

        //画面外に出たnoteを止める条件
        //画面外に出たら敵にダメージを与える処理
        if (note1.transform.position.x >= 7.5f)
        {
            note1.transform.position = new Vector2(7.5f, 3);

        }
        if (note2.transform.position.x >= 7.5f)
        {
            note2.transform.position = new Vector2(7.5f, 1.46f);
        }
        if (note3.transform.position.x >= 7.5f)
        {
            note3.transform.position = new Vector2(7.5f, 0);
        }
        if (note4.transform.position.x >= 7.5f)
        {
            note4.transform.position = new Vector2(7.5f, -1.65f);
        }
        //値によってランダムなnoteを戻らせる条件
        random = RandomRange();
        if (note1.transform.position.x == 7.5f)
        {
            if (random >= 4500 && random <= 4750)
            {
                note1.transform.position = new Vector2(-3, 3);
            }
        }
        if (note2.transform.position.x == 7.5f)
        {
            if (random > 4750 && random <= 5000)
            {
                note2.transform.position = new Vector2(-3, 1.46f);
            }
        }
        if (note3.transform.position.x == 7.5f)
        {
            if (random > 5000 && random <= 5250)
            {
                note3.transform.position = new Vector2(-3, 0);
            }
        }
        if (note4.transform.position.x == 7.5f)
        {
            if (random > 5250 && random <= 5500)
            {
                note4.transform.position = new Vector2(-3, -1.65f);
            }
        }
    }
    //noteのスピードを変える変数
    private float NoteSpeeds()
    {
        float noteSpeed = Random.Range(0.05f, 0.15f);
        return noteSpeed;
    }
    //noteが戻るためのランダムな値を出す関数
    private int RandomRange()
    {
        int random = Random.Range(0, 10000);
        return random;
    }
}
