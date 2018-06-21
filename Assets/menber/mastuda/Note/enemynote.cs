using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemynote : MonoBehaviour{
    int random;
    //各noteを格納する変数
    GameObject note1;
    GameObject note2;
    GameObject note3;
    GameObject note;
    GameObject enemyNote;
    Transform parent;
    //どのnoteかを判定するための変数
    public bool note1st = false;
    public bool note2nd = false;
    public bool note3rd = false;
    //GameControlerスクリプトに参照するための変数
    GameObject GameControler;
    GameControler GameControlers;
    // Use this for initialization
    void Start(){
        enemyNote = GameObject.Find("enemyNote");
        parent = GameObject.Find("enemyNote").transform;
        note1 = null;//GameObject.Find("enemyNote1");
        note2 = null;//GameObject.Find("enemyNote2");
        note3 = null;//GameObject.Find("enemyNote3");

        GameControler = GameObject.Find("GameControler");
        GameControlers = GameControler.GetComponent<GameControler>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        //noteを動かす処理
        //note1.transform.position += new Vector3(note1speed, 0, 0);
        //note2.transform.position += new Vector3(note2speed, 0, 0);
        //note3.transform.position += new Vector3(note3speed, 0, 0);


        //値によってランダムなnoteを戻らせる条件
        random = RandomRange();
        if (GameObject.Find("enemyNote1") == false){
            if (random >= 4800 && random <= 4900){
                note1 = GameObject.Find(CloneEnemyNote("1", 3, 2.2f));
                note1st = true;
            }
        }
        if (GameObject.Find("enemyNote2") == false){
            if (random > 4900 && random <= 5000){
                note2 = GameObject.Find(CloneEnemyNote("2",3,0.68f));
                note2nd = true;
            }
        }
        if (GameObject.Find("enemyNote3") == false){
            if (random > 5000 && random <= 5100){
                note3 = GameObject.Find(CloneEnemyNote("3",3,-0.85f));
                note3rd = true;
            }
        }
        if (parent.childCount > 0){
            OverNote();
        }
    }
    //noteのスピードを変える変数
    private float NoteSpeeds(){
        float noteSpeed = Random.Range(-0.05f, -0.15f);
        return noteSpeed;
    }
    //noteが戻るためのランダムな値を出す関数
    private int RandomRange(){
        int random = Random.Range(0, 10000);
        return random;
    }
    //noteを止めたり出現させる関数
    private void MoveNotes(GameObject notes, bool hantei){
        //ノーツが移動しきったかどうか
        if (hantei == true){
            GameControlers.DamageCut(notes, false);
        }
        Destroy(notes);
    }
    //PrefabのenemyNoteをゲーム画面に表示させる関数
    private string CloneEnemyNote(string name,float i,float j){
        note = (GameObject)Resources.Load("Prefabs/enemyNote");
        note = Instantiate(note, new Vector3(i,j,0), Quaternion.identity);
        //MoveNoteのスクリプトを持たせる
        note.AddComponent<MoveEnemyNote>();
        /*
        note.AddComponent<BoxCollider2D>();
        var collider = note.GetComponent<BoxCollider2D>();
        collider.size = new Vector2(1, 1);*/
        note.transform.parent = enemyNote.transform;
        //名前をenemyNote"数字"に変更する
        var noteName = "enemyNote" + name;
        note.name = noteName;
        return noteName;
    }
    private void OverNote(){
        //画面外に出たnoteを止める条件
        //画面外に出たら敵にダメージを与える処理
        if (note1st){
            if (note1.transform.position.x <= -7.5f){
                MoveNotes(note1, true);
                note1st = false;
            }
        }
        if (note2nd){
            if (note2.transform.position.x <= -7.5f){
                MoveNotes(note2, true);
                note2nd = false;
            }
        }

        if (note3rd){
            if (note3.transform.position.x <= -7.5f){
                MoveNotes(note3, true);
                note3rd = false;
            }
        }
    }
}
