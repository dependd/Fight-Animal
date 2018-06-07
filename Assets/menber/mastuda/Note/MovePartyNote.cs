using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePartyNote : MonoBehaviour {
    //ノーツのスピードを入れる変数
    float noteSpeed;
    //ノーツの名前を入れる変数
    string objectName;
    GameObject Gamecontroler;
    Charastatus charastatus;
    
    private void Start(){
        objectName = this.gameObject.name;
        Gamecontroler = GameObject.Find("GameControler");
        charastatus = Gamecontroler.GetComponent<Charastatus>();
        noteSpeed = NoteSpeeds();
        
    }
    // Update is called once per frame
    void FixedUpdate(){
        this.transform.position += new Vector3(noteSpeed, 0, 0);
    }

    //noteのスピードを変える変数
    private float NoteSpeeds(){
        if(objectName == "note1"){
            return (float)charastatus.momonga.NoteSpeed;
        }
        else if(objectName == "note2"){
            return (float)charastatus.tokage.NoteSpeed;
        }
        else if (objectName == "note3"){
            return (float)charastatus.datyo.NoteSpeed;
        }
        else if (objectName == "note4"){
            return (float)charastatus.kame.NoteSpeed;
        }
        else if (objectName == "deadlyNote1"){
            return (float)charastatus.momonga.DeadlyNoteSpeed;
        }
        else if (objectName == "deadlyNote2"){
            return (float)charastatus.tokage.DeadlyNoteSpeed;
        }
        else if (objectName == "deadlyNote3"){
            return (float)charastatus.datyo.DeadlyNoteSpeed;
        }
        else if (objectName == "deadlyNote4"){
            return (float)charastatus.kame.DeadlyNoteSpeed;
        } else{
            return 0;
        }
    }
}
