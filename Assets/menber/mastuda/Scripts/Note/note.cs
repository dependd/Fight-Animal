﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note : MonoBehaviour {
    int random;
    //Sprite
    [SerializeField]
    Sprite datyoSprite;
    [SerializeField]
    Sprite tokageSprite;
    [SerializeField]
    Sprite momongaSprite;
    [SerializeField]
    Sprite kameSprite;

    //Prefabからインスタンスするときに使用する変数
    GameObject notes;
    GameObject deadlyNote;
    GameObject partyNote;
    Transform parent;
    //ノーツのスピードを入れておく変数
    public float note1Speed;
    public float note2Speed;
    public float note3Speed;
    public float note4Speed;
    public float deadlyNote1Speed;
    public float deadlyNote2Speed;
    public float deadlyNote3Speed;
    public float deadlyNote4Speed;
    //ノーツのオブジェクトを入れておく変数
    GameObject note1;
    GameObject note2;
    GameObject note3;
    GameObject note4;
    GameObject deadlyNote1;
    GameObject deadlyNote2;
    GameObject deadlyNote3;
    GameObject deadlyNote4;
    //ノーツの判定をする変数
    public bool note1st = false;
    public bool note2nd = false;
    public bool note3rd = false;
    public bool note4th = false;
    public bool deadlyNote1st = false;
    public bool deadlyNote2nd = false;
    public bool deadlyNote3rd = false;
    public bool deadlyNote4th = false;
    //CharaStatusスクリプトに参照するための変数
    GameObject GameControler;
    Charastatus CharaStatus;
    MovePartyNote MovePartyNote;
    // Use this for initialization
    void Start () {
        partyNote = GameObject.Find("PartyNote");
        parent = GameObject.Find("PartyNote").transform;
        //GameControlerのCharaStatusスクリプトを取得
        GameControler = GameObject.Find("GameControler");
        CharaStatus = GameControler.GetComponent<Charastatus>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //値によってランダムなnoteを戻らせる条件
        random = RandomRange();
        if (GameObject.Find("datyonote") == false){
            if (random > 28000 && random <= 29000 && deadlyNote1 == null){
                note1 = GameObject.Find(ClonePartyNote("datyo", -2.8f, 3));
                note1Speed = (float)CharaStatus.momonga.NoteSpeed;
                note1st = true;
            }
        }
        if (GameObject.Find("tokagenote") == false){
            if (random > 49000 && random <= 50000 && deadlyNote2 == null){
                note2 = GameObject.Find(ClonePartyNote("tokage",-2.8f, 1.46f));
                note2Speed = (float)CharaStatus.tokage.NoteSpeed;
                note2nd = true;
            }
        }
        if (GameObject.Find("momonganote") == false){
            if (random > 70000 && random <= 71000 && deadlyNote3 == null){
                note3 = GameObject.Find(ClonePartyNote("momonga", -2.8f, 0));
                note3Speed = (float)CharaStatus.datyo.NoteSpeed;
                note3rd = true;
            }
        }
        if (GameObject.Find("kamenote") == false){
            if (random > 91000 && random <= 93000 && deadlyNote4 == null){
                note4 = GameObject.Find(ClonePartyNote("kame", -2.8f, -1.65f));
                note4Speed = (float)CharaStatus.kame.NoteSpeed;
                note4th = true;
            }
        }
        if (GameObject.Find("datyodeadlyNote") == false){
            if (random >= 44000 && random <= 44500 && note1 == null){
                deadlyNote1 = GameObject.Find(CloneDeadlyPartyNote("datyo", -2.8f, 3));
                deadlyNote1Speed = (float)CharaStatus.momonga.DeadlyNoteSpeed;
                deadlyNote1st = true;
            }
        }
        if (GameObject.Find("tokagedeadlyNote") == false){
            if (random >= 44500 && random <= 45000 && note2 == null){
                deadlyNote2 = GameObject.Find(CloneDeadlyPartyNote("tokage", -2.8f, 1.46f));
                deadlyNote2Speed = (float)CharaStatus.tokage.DeadlyNoteSpeed;
                deadlyNote2nd = true;
            }
        }
        if (GameObject.Find("momongadeadlyNote") == false){
            if (random >= 55000 && random <= 55500 && note3 == null){
                deadlyNote3 = GameObject.Find(CloneDeadlyPartyNote("momonga", -2.8f, 0));
                deadlyNote3Speed = (float)CharaStatus.datyo.DeadlyNoteSpeed;
                deadlyNote3rd = true;
            }
        }
        if (GameObject.Find("kamedeadlyNote") == false){
            if (random >= 55500 && random <= 56000 && note4 == null){
                deadlyNote4 = GameObject.Find(CloneDeadlyPartyNote("kame", -2.8f, -1.65f));
                deadlyNote4Speed = (float)CharaStatus.kame.DeadlyNoteSpeed;
                deadlyNote4th = true;
            }
        }
    }
    //noteが戻るためのランダムな値を出す関数
    private int RandomRange(){
        
        int random = Random.Range(0, 100000);
        return random;
    }
    //noteを削除する変数
    private void ReMoveNote(GameObject notes){
        Destroy(notes);
    }
    private string ClonePartyNote(string name, float i, float j){
        notes = (GameObject)Resources.Load("Prefabs/Note/" + name + "Note");
        notes = Instantiate(notes, new Vector3(i, j, 0), Quaternion.identity);
        //MoveNoteのスクリプトを持たせる
        notes.AddComponent<MovePartyNote>();
        notes.transform.parent = partyNote.transform;
        //名前をenemyNote"数字"に変更する
        var noteName = name + "note";
        notes.name = noteName;
        return noteName;
    }
    //noteをインスタンス化する
    private string CloneDeadlyPartyNote(string name,float i, float j){
        deadlyNote = (GameObject)Resources.Load("Prefabs/Note/" + name + "DeadlyNote");
        deadlyNote = Instantiate(deadlyNote, new Vector3(i, j, 0), Quaternion.identity);
        //MoveNoteのスクリプトを持たせる
        deadlyNote.AddComponent<MovePartyNote>();
        deadlyNote.transform.parent = partyNote.transform;
        //名前をenemyNote"数字"に変更する
        var noteName = name + "deadlyNote";
        deadlyNote.name = noteName;
        return noteName;
    }
    //
    private Sprite ChangeSprite(string name)
    {
        Sprite spr = null;
        switch (name)
        {
            case "datyo":
                spr = datyoSprite;
                break;
            case "tokage":
                spr = tokageSprite;
                break;
            case "momonga":
                spr = momongaSprite;
                break;
            case "kame":
                spr = kameSprite;
                break;
        }
        return spr;
    }
    
    
}
