using System.Collections;
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
            if (random > 46000 && random <= 48000 && deadlyNote1 == null){
                note1 = GameObject.Find(ClonePartyNote("datyo", -3, 3));
                note1Speed = (float)CharaStatus.momonga.NoteSpeed;
                note1st = true;
            }
        }
        if (GameObject.Find("tokagenote") == false){
            if (random > 48000 && random <= 50000 && deadlyNote2 == null){
                note2 = GameObject.Find(ClonePartyNote("tokage",-3, 1.46f));
                note2Speed = (float)CharaStatus.tokage.NoteSpeed;
                note2nd = true;
            }
        }
        if (GameObject.Find("momonganote") == false){
            if (random > 50000 && random <= 52000 && deadlyNote3 == null){
                note3 = GameObject.Find(ClonePartyNote("momonga", -3, 0));
                note3Speed = (float)CharaStatus.datyo.NoteSpeed;
                note3rd = true;
            }
        }
        if (GameObject.Find("kamenote") == false){
            if (random > 52000 && random <= 54000 && deadlyNote4 == null){
                note4 = GameObject.Find(ClonePartyNote("kame", -3, -1.65f));
                note4Speed = (float)CharaStatus.kame.NoteSpeed;
                note4th = true;
            }
        }
        if (GameObject.Find("datyodeadlyNote") == false){
            if (random >= 44000 && random <= 44500 && note1 == null){
                deadlyNote1 = GameObject.Find(CloneDeadlyPartyNote("datyo", -3, 3));
                deadlyNote1Speed = (float)CharaStatus.momonga.DeadlyNoteSpeed;
                deadlyNote1st = true;
            }
        }
        if (GameObject.Find("tokagedeadlyNote") == false){
            if (random >= 44500 && random <= 45000 && note2 == null){
                deadlyNote2 = GameObject.Find(CloneDeadlyPartyNote("tokage", -3, 1.46f));
                deadlyNote2Speed = (float)CharaStatus.tokage.DeadlyNoteSpeed;
                deadlyNote2nd = true;
            }
        }
        if (GameObject.Find("momongadeadlyNote") == false){
            if (random >= 55000 && random <= 55500 && note3 == null){
                deadlyNote3 = GameObject.Find(CloneDeadlyPartyNote("momonga", -3, 0));
                deadlyNote3Speed = (float)CharaStatus.datyo.DeadlyNoteSpeed;
                deadlyNote3rd = true;
            }
        }
        if (GameObject.Find("kamedeadlyNote") == false){
            if (random >= 55500 && random <= 56000 && note4 == null){
                deadlyNote4 = GameObject.Find(CloneDeadlyPartyNote("kame", -3, -1.65f));
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
