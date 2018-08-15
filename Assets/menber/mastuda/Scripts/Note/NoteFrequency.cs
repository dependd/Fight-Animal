using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteFrequency : MonoBehaviour {
    //経過時間、ノーツが消えた時間を格納する
    float elapsedTime;
    note note;
    enemynote enemynote;
    GameObject enemyNote;
    //どのノーツかを判断する
    bool momonga;
    float momongaTime = 9999;
    bool tokage;
    float tokageTime = 9999;
    bool datyo;
    float datyoTime = 9999;
    bool kame;
    float kameTime = 9999;
    bool enemy1;
    float enemy1Time = 9999;
    bool enemy2;
    float enemy2Time = 9999;
    bool enemy3;
    float enemy3Time = 9999;
    //最大何秒でノーツを出すか
    int maxRenge;


    // Use this for initialization
    void Start () {
        note = GetComponent<note>();
        enemyNote = GameObject.Find("EnemyNote");
        enemynote = enemyNote.GetComponent<enemynote>();
        if (BattleManager.Instance.nowBattleScene == 0){
            maxRenge = 5;
        } else if (BattleManager.Instance.nowBattleScene == 1){
            maxRenge = 3;
        }else if(BattleManager.Instance.nowBattleScene == 2)
        {
            maxRenge = 2;
        }
	}
	
	// Update is called once per frame
	void Update () {

        elapsedTime += Time.deltaTime;
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
                momonga = false;
                momongaTime = 9999;
            }
            else{
                int rnd = RandomRange();
                if (rnd == 1){
                    note.momongaNote = true;
                    momonga = false;
                    momongaTime = 9999;
                }
            }
        }
        if (kame){
            if (kameTime < elapsedTime){
                note.kameNote = true;
                kame = false;
                kameTime = 9999;
            }
            else{
                int rnd = RandomRange();
                if (rnd == 1){
                    note.kameNote = true;
                    kame = false;
                    kameTime = 9999;
                }
            }
        }
        if (enemy1){
            if (enemy1Time < elapsedTime){
                enemynote.enemyNote1 = true;
                enemy1 = false;
                enemy1Time = 9999;
            }
            else{
                int rnd = RandomRange();
                if (rnd == 1){
                    enemynote.enemyNote1 = true;
                    enemy1 = false;
                    enemy1Time = 9999;
                }
            }
        }
        if (enemy2){
            if (enemy2Time < elapsedTime){
                enemynote.enemyNote2 = true;
                enemy2 = false;
                enemy2Time = 9999;
            }
            else{
                int rnd = RandomRange();
                if (rnd == 1){
                    enemynote.enemyNote2 = true;
                    enemy2 = false;
                    enemy2Time = 9999;
                }
            }
        }
        if (enemy3){
            if (enemy3Time < elapsedTime){
                enemynote.enemyNote3 = true;
                enemy3 = false;
                enemy3Time = 9999;
            }
            else{
                int rnd = RandomRange();
                if (rnd == 1){
                    enemynote.enemyNote3 = true;
                    enemy3 = false;
                    enemy3Time = 9999;
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
                tokageTime += maxRenge;
                break;
            case "datyonote":
                datyo = true;
                datyoTime = elapsedTime;
                datyoTime += maxRenge;
                break;
            case "momonganote":
                momonga = true;
                momongaTime = elapsedTime;
                momongaTime += maxRenge;
                break;
            case "kamenote":
                kame = true;
                kameTime = elapsedTime;
                kameTime += maxRenge;
                break;
            case "enemyNote1":
                enemy1 = true;
                enemy1Time = elapsedTime;
                enemy1Time += maxRenge;
                break;
            case "enemyNote2":
                enemy2 = true;
                enemy2Time = elapsedTime;
                enemy2Time += maxRenge;
                break;
            case "enemyNote3":
                enemy3 = true;
                enemy3Time = elapsedTime;
                enemy3Time += maxRenge;
                break;
        }
    }
    private int RandomRange()
    {

        int random = Random.Range(0, 180);
        return random;
    }
}
