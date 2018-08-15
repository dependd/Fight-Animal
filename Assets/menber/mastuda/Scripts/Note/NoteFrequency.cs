using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteFrequency : MonoBehaviour {
    //経過時間、ノーツが消えた時間を格納する
    float elapsedTime;
    note note;
    //どのノーツかを判断する
    bool momonga;
    float momongaTime = 9999;
    bool tokage;
    float tokageTime = 9999;
    bool datyo;
    float datyoTime = 9999;
    bool kame;
    float kameTime = 9999;




    // Use this for initialization
    void Start () {
        note = GetComponent<note>();
	}
	
	// Update is called once per frame
	void Update () {

        elapsedTime += Time.deltaTime;
        Debug.Log(elapsedTime);
        Frequency();
    }
    //ノーツを出現させるか判定する関数
    private void Frequency()
    {
        //経過時間が3秒後の時間より多くなったら
        if (tokage){
            if (tokageTime < elapsedTime){
                note.tokageNote = true;
                tokage = false;
                tokageTime = 9999;
            }
            else{
                int rnd = RandomRange();
                if (rnd == 1){
                    note.tokageNote = true;
                    tokage = false;
                    tokageTime = 9999;
                }
            }
        }
        if (datyo){
            if (datyoTime < elapsedTime){
                note.datyoNote = true;
                datyo = false;
                datyoTime = 9999;
            }
            else{
                int rnd = RandomRange();
                if (rnd == 1){
                    note.datyoNote = true;
                    datyo = false;
                    datyoTime = 9999;
                }
            }
        }
        if (momonga){
            if (momongaTime < elapsedTime){
                note.momongaNote = true;
                momongaTime = 9999;
            }
            else{
                int rnd = RandomRange();
                if (rnd == 1){
                    note.momongaNote = true;
                    momongaTime = 9999;
                }
            }
        }
        if (kame){
            if (kameTime < elapsedTime){
                note.kameNote = true;
                kameTime = 9999;
            }
            else{
                int rnd = RandomRange();
                if (rnd == 1){
                    note.kameNote = true;
                    kameTime = 9999;
                }
            }
        }
    }
    //ノーツが消えたタイミングを判定する
    public void NoteCreateFrequency(string name)
    {
        switch (name)
        {
            case "tokagenote":
                tokage = true;
                //今のelapsedTimeより三秒後を確定でノーツが出現するように
                tokageTime = elapsedTime;
                tokageTime += 3;
                break;
            case "datyonote":
                datyo = true;
                datyoTime = elapsedTime;
                datyoTime += 3;
                break;
            case "momonganote":
                momonga = true;
                momongaTime = elapsedTime;
                momongaTime += 3;
                break;
            case "kamenote":
                kame = true;
                kameTime = elapsedTime;
                kameTime += 3;
                break;
        }
    }
    private int RandomRange()
    {

        int random = Random.Range(0, 180);
        return random;
    }
}
