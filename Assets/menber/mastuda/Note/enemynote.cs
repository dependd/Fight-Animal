﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemynote : MonoBehaviour
{
    int random;
    GameObject notes;
    hp hp;
    //ノーツのスピードを入れておく変数
    public float note1speed;
    public float note2speed;
    public float note3speed;
    // Use this for initialization
    void Start()
    {
        //最初のenemynoteのスピードを決める変数
        note1speed = NoteSpeeds();
        note2speed = NoteSpeeds();
        note3speed = NoteSpeeds();
        //enemySliderのスクリプトを参照       
        notes = GameObject.Find("enemySlider");
        hp = notes.GetComponent<hp>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //noteを動かす処理
        GameObject note1 = GameObject.Find("enemynote1");
        note1.transform.position += new Vector3(note1speed, 0, 0);
        GameObject note2 = GameObject.Find("enemynote2");
        note2.transform.position += new Vector3(note2speed, 0, 0);
        GameObject note3 = GameObject.Find("enemynote3");
        note3.transform.position += new Vector3(note3speed, 0, 0);

        //画面外に出たnoteを止める条件
        //画面外に出たら味方にダメージを与える処理
        if (note1.transform.position.x <= -7.5f)
        {
            note1.transform.position = new Vector2(7.5f, 2.25f);
            hp.DownpartyHp();
        }
        if (note2.transform.position.x <= -7.5f)
        {
            note2.transform.position = new Vector2(7.5f, 0.75f);
            hp.DownpartyHp();
        }
        if (note3.transform.position.x <= -7.5f)
        {
            note3.transform.position = new Vector2(7.5f, -0.75f);
            hp.DownpartyHp();
        }
        //値によってランダムなnoteを戻らせる条件
        random = RandomRange();
        if (note1.transform.position.x == 7.5f)
        {
            if (random >= 4800 && random <= 4900)
            {
                note1speed = NoteSpeeds();
                note1.transform.position = new Vector2(3, 2.25f);
            }
        }
        if (note2.transform.position.x == 7.5f)
        {
            if (random > 4900 && random <= 5000)
            {
                note2speed = NoteSpeeds();
                note2.transform.position = new Vector2(3, 0.75f);
            }
        }
        if (note3.transform.position.x == 7.5f)
        {
            if (random > 5000 && random <= 5100)
            {
                note3speed = NoteSpeeds();
                note3.transform.position = new Vector2(3, -0.75f);
            }
        }
    }
    //noteのスピードを変える変数
    private float NoteSpeeds()
    {
        float noteSpeed = Random.Range(-0.05f, -0.15f);
        return noteSpeed;
    }
    //noteが戻るためのランダムな値を出す関数
    private int RandomRange()
    {
        int random = Random.Range(0, 10000);
        return random;
    }
}
