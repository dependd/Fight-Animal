using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note : MonoBehaviour {
    bool one;
    int random;
    GameObject notes;
    hp hp;
    //ノーツのスピードを入れておく変数
    public float note1speed;
    public float note2speed;
    public float note3speed;
    public float note4speed;
    // Use this for initialization
    void Start () {
        one = true;
        notes = GameObject.Find("enemySlider");

        hp = notes.GetComponent<hp>();
    }
	
	// Update is called once per frame
	void Update () {
        //Update関数の中で一度だけ実行する条件
        
        //noteを動かす処理
        GameObject note1 = GameObject.Find("note1");
        note1.transform.position += new Vector3(0.1f, 0, 0);
        GameObject note2 = GameObject.Find("note2");
        note2.transform.position += new Vector3(0.1f, 0, 0);
        GameObject note3 = GameObject.Find("note3");
        note3.transform.position += new Vector3(0.1f, 0, 0);
        GameObject note4 = GameObject.Find("note4");
        note4.transform.position += new Vector3(0.1f, 0, 0);

        //画面外に出たnoteを止める条件
        //画面外に出たら敵にダメージを与える処理
        if (note1.transform.position.x >= 7.5f)
        {
            note1.transform.position = new Vector2(-10, 5);
            PartyDamage();
        }
        if (note2.transform.position.x >= 7.5f)
        {
            note2.transform.position = new Vector2(-10, 5);
            PartyDamage();
        }
        if (note3.transform.position.x >= 7.5f)
        {
            note3.transform.position = new Vector2(-10, 5);
            PartyDamage();
        }
        if (note4.transform.position.x >= 7.5f)
        {
            note4.transform.position = new Vector2(-10, 5);
            PartyDamage();
        }
        //値によってランダムなnoteを戻らせる条件
        random = RandomRange();
        if (note1.transform.position.y == 5)
        {
            if (random >= 4500 && random <= 4750)
            {
                note1.transform.position = new Vector2(-3, 3);
            }
        }
        if (note2.transform.position.y == 5)
        {
            if (random > 4750 && random <= 5000)
            {
                note2.transform.position = new Vector2(-3, 1.46f);
            }
        }
        if (note3.transform.position.y == 5)
        {
            if (random > 5000 && random <= 5250)
            {
                note3.transform.position = new Vector2(-3, 0);
            }
        }
        if (note4.transform.position.y == 5)
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
    public void PartyDamage()
    {
        hp.DownPartyHp(false);
    }
}
