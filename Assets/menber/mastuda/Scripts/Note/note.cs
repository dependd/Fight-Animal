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
    //CharaStatusスクリプトに参照するための変数
    GameObject GameControler;
    Charastatus CharaStatus;
    MovePartyNote MovePartyNote;
    //NoteFrequencyスクリプトに参照するための変数
    NoteFrequency noteFrequency;
    //ノーツ作成のフラグ
    //[HideInInspector]
    public bool datyoNote;
    //[HideInInspector]
    public bool tokageNote;
    //[HideInInspector]
    public bool momongaNote;
    //[HideInInspector]
    public bool kameNote;
    // Use this for initialization
    void Start () {
        partyNote = GameObject.Find("PartyNote");
        parent = GameObject.Find("PartyNote").transform;
        //GameControlerのCharaStatusスクリプトを取得
        GameControler = GameObject.Find("GameControler");
        CharaStatus = GameControler.GetComponent<Charastatus>();
        noteFrequency = GetComponent<NoteFrequency>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //値によってランダムなnoteを戻らせる条件
        //random = RandomRange();
        //if (GameObject.Find("datyonote") == false){
            if (/*random > 28000 && random <= 29000 && deadlyNote1 == null*/datyoNote){
                int rnd = RandomRange();
                if (rnd != 4){
                    note1 = ClonePartyNote("datyo", -2.5f, 3);
                    note1Speed = (float)CharaStatus.momonga.NoteSpeed;
                    datyoNote = false;
                }
                else{
                    deadlyNote1 = CloneDeadlyPartyNote("datyo", -2.5f, 3);
                    deadlyNote1Speed = (float)CharaStatus.momonga.DeadlyNoteSpeed;
                    datyoNote = false;
                }
            }
        
        //if (GameObject.Find("tokagenote") == false){
            if (/*random > 49000 && random <= 50000 && deadlyNote2 == null*/tokageNote){
                int rnd = RandomRange();
                if (rnd != 4){
                    note2 = ClonePartyNote("tokage", -2.5f, 1.51f);
                    note2Speed = (float)CharaStatus.tokage.NoteSpeed;
                    tokageNote = false;
                }
                else{
                    deadlyNote2 = CloneDeadlyPartyNote("tokage", -2.5f, 1.46f);
                    deadlyNote2Speed = (float)CharaStatus.tokage.DeadlyNoteSpeed;
                    tokageNote = false;
                }
            }
        
        //if (GameObject.Find("momonganote") == false){
            if (/*random > 70000 && random <= 71000 && deadlyNote3 == null*/momongaNote){
                int rnd = RandomRange();
                if (rnd != 4){
                    note3 = ClonePartyNote("momonga", -2.5f, 0);
                    note3Speed = (float)CharaStatus.datyo.NoteSpeed;
                    momongaNote = false;
                }
                else{
                    deadlyNote3 = CloneDeadlyPartyNote("momonga", -2.5f, 0);
                    deadlyNote3Speed = (float)CharaStatus.datyo.DeadlyNoteSpeed;
                    momongaNote = false;
                }
            }
        
        //if (GameObject.Find("kamenote") == false){
            if (/*random > 91000 && random <= 93000 && deadlyNote4 == null*/kameNote){
                int rnd = RandomRange();
                if (rnd != 4){
                    note4 = ClonePartyNote("kame", -2.5f, -1.65f);
                    note4Speed = (float)CharaStatus.kame.NoteSpeed;
                    kameNote = false;
                }
                else{
                    deadlyNote4 = CloneDeadlyPartyNote("kame", -2.5f, -1.65f);
                    deadlyNote4Speed = (float)CharaStatus.kame.DeadlyNoteSpeed;
                    kameNote = false;
                }
            }
        /*
        if (GameObject.Find("datyodeadlyNote") == false){
            if (random >= 44000 && random <= 44500 && note1 == null){
                deadlyNote1 = CloneDeadlyPartyNote("datyo", -2.8f, 3);
                deadlyNote1Speed = (float)CharaStatus.momonga.DeadlyNoteSpeed;
            }
        }
        if (GameObject.Find("tokagedeadlyNote") == false){
            if (random >= 44500 && random <= 45000 && note2 == null){
                deadlyNote2 = CloneDeadlyPartyNote("tokage", -2.8f, 1.46f);
                deadlyNote2Speed = (float)CharaStatus.tokage.DeadlyNoteSpeed;
            }
        }
        if (GameObject.Find("momongadeadlyNote") == false){
            if (random >= 55000 && random <= 55500 && note3 == null){
                deadlyNote3 = CloneDeadlyPartyNote("momonga", -2.8f, 0);
                deadlyNote3Speed = (float)CharaStatus.datyo.DeadlyNoteSpeed;
            }
        }
        if (GameObject.Find("kamedeadlyNote") == false){
            if (random >= 55500 && random <= 56000 && note4 == null){
                deadlyNote4 = CloneDeadlyPartyNote("kame", -2.8f, -1.65f);
                deadlyNote4Speed = (float)CharaStatus.kame.DeadlyNoteSpeed;
            }
        }*/
    }
    //noteが戻るためのランダムな値を出す関数
    private int RandomRange(){
        
        int random = Random.Range(0, 5);
        return random;
    }
    //noteを削除する変数
    private void ReMoveNote(GameObject notes){
        Destroy(notes);
    }
    public GameObject ClonePartyNote(string name, float i, float j){
        notes = (GameObject)Resources.Load("Prefabs/Note/" + name + "Note");
        notes = Instantiate(notes, new Vector3(i, j, 0), Quaternion.identity);
        notes.transform.parent = partyNote.transform;
        //名前をenemyNote"数字"に変更する
        var noteName = name + "note";
        notes.name = noteName;
        return notes;
    }
    //noteをインスタンス化する
    public GameObject CloneDeadlyPartyNote(string name,float i, float j){
        if (BattleManager.Instance.nowBattleScene == 0)
        {
            ClonePartyNote(name,i,j);
            return null;
        }
        deadlyNote = (GameObject)Resources.Load("Prefabs/Note/" + name + "DeadlyNote");
        deadlyNote = Instantiate(deadlyNote, new Vector3(i, j, 0), Quaternion.identity);
        deadlyNote.transform.parent = partyNote.transform;
        //名前をenemyNote"数字"に変更する
        var noteName = name + "deadlyNote";
        deadlyNote.name = noteName;
        return deadlyNote;
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
