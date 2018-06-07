using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note : MonoBehaviour {
    int random;
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
    bool note1st = false;
    bool note2nd = false;
    bool note3rd = false;
    bool note4th = false;
    bool deadlyNote1st = false;
    bool deadlyNote2nd = false;
    bool deadlyNote3rd = false;
    bool deadlyNote4th = false;
    //CharaStatusスクリプトに参照するための変数
    GameObject GameControler;
    Charastatus CharaStatus;
    MovePartyNote MovePartyNote;
    // Use this for initialization
    void Start () {
        partyNote = GameObject.Find("partyNote");
        parent = GameObject.Find("partyNote").transform;
        //GameControlerのCharaStatusスクリプトを取得
        GameControler = GameObject.Find("GameControler");
        CharaStatus = GameControler.GetComponent<Charastatus>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //値によってランダムなnoteを戻らせる条件
        random = RandomRange();
        if (GameObject.Find("note1") == false){
            if (random > 4500 && random <= 4750 && deadlyNote1 == null){
                note1 = GameObject.Find(ClonePartyNote("1", -3, 3));
                note1Speed = (float)CharaStatus.momonga.NoteSpeed;
                note1st = true;
            }
        }
        if (GameObject.Find("note2") == false){
            if (random > 4750 && random <= 5000 && deadlyNote2 == null){
                note2 = GameObject.Find(ClonePartyNote("2",-3, 1.46f));
                note2Speed = (float)CharaStatus.tokage.NoteSpeed;
                note2nd = true;
            }
        }
        if (GameObject.Find("note3") == false){
            if (random > 5000 && random <= 5250 && deadlyNote3 == null){
                note3 = GameObject.Find(ClonePartyNote("3", -3, 0));
                note3Speed = (float)CharaStatus.datyo.NoteSpeed;
                note3rd = true;
            }
        }
        if (GameObject.Find("note4") == false){
            if (random > 5250 && random <= 5500 && deadlyNote4 == null){
                note4 = GameObject.Find(ClonePartyNote("4", -3, -1.65f));
                note4Speed = (float)CharaStatus.kame.NoteSpeed;
                note4th = true;
            }
        }
        if (GameObject.Find("deadlyNote1") == false){
            if (random >= 4400 && random <= 4450 && note1 == null){
                deadlyNote1 = GameObject.Find(CloneDeadlyPartyNote("1", -3, 3));
                deadlyNote1Speed = (float)CharaStatus.momonga.DeadlyNoteSpeed;
                deadlyNote1st = true;
            }
        }
        if (GameObject.Find("deadlyNote2") == false){
            if (random >= 4450 && random <= 4500 && note2 == null){
                deadlyNote2 = GameObject.Find(CloneDeadlyPartyNote("2", -3, 1.46f));
                deadlyNote2Speed = (float)CharaStatus.tokage.DeadlyNoteSpeed;
                deadlyNote2nd = true;
            }
        }
        if (GameObject.Find("deadlyNote3") == false){
            if (random >= 5500 && random <= 5550 && note3 == null){
                deadlyNote3 = GameObject.Find(CloneDeadlyPartyNote("3", -3, 0));
                deadlyNote3Speed = (float)CharaStatus.datyo.DeadlyNoteSpeed;
                deadlyNote3rd = true;
            }
        }
        if (GameObject.Find("deadlyNote4") == false){
            if (random >= 5550 && random <= 5600 && note4 == null){
                deadlyNote4 = GameObject.Find(CloneDeadlyPartyNote("4", -3, -1.65f));
                deadlyNote4Speed = (float)CharaStatus.kame.DeadlyNoteSpeed;
                deadlyNote4th = true;
            }
        }
        if(parent.childCount > 0) {
            OverNote();
        }
    }
    //noteが戻るためのランダムな値を出す関数
    private int RandomRange(){
        int random = Random.Range(0, 10000);
        return random;
    }
    //noteを削除する変数
    private void ReMoveNote(GameObject notes){
        Destroy(notes);
    }
    private string ClonePartyNote(string number, float i, float j){
        notes = (GameObject)Resources.Load("Prefabs/partyNote");
        notes = Instantiate(notes, new Vector3(i, j, 0), Quaternion.identity);
        //MoveNoteのスクリプトを持たせる
        notes.AddComponent<MovePartyNote>();
        notes.transform.parent = partyNote.transform;
        //名前をenemyNote"数字"に変更する
        var noteName = "note" + number;
        notes.name = noteName;
        return noteName;
    }
    private string CloneDeadlyPartyNote(string number,float i, float j){
        deadlyNote = (GameObject)Resources.Load("Prefabs/deadlyNote");
        deadlyNote = Instantiate(deadlyNote, new Vector3(i, j, 0), Quaternion.identity);
        //MoveNoteのスクリプトを持たせる
        deadlyNote.AddComponent<MovePartyNote>();
        deadlyNote.transform.parent = partyNote.transform;
        //名前をenemyNote"数字"に変更する
        var noteName = "deadlyNote" + number;
        deadlyNote.name = noteName;
        return noteName;
    }
    private void OverNote(){
        //画面外に出たnoteを止める条件
        if(note1st == true){
            if (note1.transform.position.x >= 7.5f){
                ReMoveNote(note1);
                note1st = false;
            }
        }
        if(note2nd == true){
            if (note2.transform.position.x >= 7.5f){
                ReMoveNote(note2);
                note2nd = false;
            }
        }
        if(note3rd == true){
            if (note3.transform.position.x >= 7.5f){
                ReMoveNote(note3);
                note3rd = false;
            }
        }
        if(note4th == true){
            if (note4.transform.position.x >= 7.5f){
                ReMoveNote(note4);
                note4th = false;
            }
        }
        if(deadlyNote1st == true) {
            if (deadlyNote1.transform.position.x >= 7.5f){
                ReMoveNote(deadlyNote1);
                deadlyNote1st = false;
            }
        }
        if(deadlyNote2nd == true) {
            if (deadlyNote2.transform.position.x >= 7.5f){
                ReMoveNote(deadlyNote2);
                deadlyNote2nd = false;
            }
        }
        if(deadlyNote3rd == true) {
            if (deadlyNote3.transform.position.x >= 7.5f){
                ReMoveNote(deadlyNote3);
                deadlyNote3rd = false;
            }
        }
        if(deadlyNote4th == true) {
            if (deadlyNote4.transform.position.x >= 7.5f){
                ReMoveNote(deadlyNote4);
                deadlyNote4th = false;
            }
        }
    }
}
