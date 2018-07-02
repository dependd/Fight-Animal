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
        if(objectName == "datyonote"){
            return (float)charastatus.momonga.NoteSpeed;
        }
        else if(objectName == "tokagenote"){
            return (float)charastatus.tokage.NoteSpeed;
        }
        else if (objectName == "momonganote"){
            return (float)charastatus.datyo.NoteSpeed;
        }
        else if (objectName == "kamenote"){
            return (float)charastatus.kame.NoteSpeed;
        }
        else if (objectName == "datyodeadlyNote"){
            return (float)charastatus.momonga.DeadlyNoteSpeed;
        }
        else if (objectName == "tokagedeadlyNote"){
            return (float)charastatus.tokage.DeadlyNoteSpeed;
        }
        else if (objectName == "momongadeadlyNote"){
            return (float)charastatus.datyo.DeadlyNoteSpeed;
        }
        else if (objectName == "kamedeadlyNote"){
            return (float)charastatus.kame.DeadlyNoteSpeed;
        } else{
            return 0;
        }
    }
}
