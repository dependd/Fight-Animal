using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFlagManager : SingletonMonoBehaviour<TutorialFlagManager> {
    [SerializeField]
    GameObject scenarioText;
    [SerializeField]
    ScenarioText text;
    [SerializeField]
    TutorialControler tutorialControler;
    [SerializeField]
    note note;
    [SerializeField]
    GameObject partyNote;
    [SerializeField]
    enemynote enemynote;
    [SerializeField]
    GameObject enemyNote;
    MoveEnemyNote moveEnemyNote;
    GameObject notes = null;
    [SerializeField]
    GameObject SerectCircle;
    [SerializeField]
    SerectCircle serectCircle;

    public enum Flag
    {
        description,
        note,
        enemyNote,
        deadlyNote,
        tutorialBattle,

    }

    private bool touchFlag = true;
    [HideInInspector]
    public int flags = 1;
    [HideInInspector]
    public bool flag = false;
    [HideInInspector]
    public Flag tutorialFlag;

    private void Start()
    {
        tutorialFlag = Flag.description;
        text = scenarioText.GetComponent<ScenarioText>();
        tutorialControler = GetComponent<TutorialControler>();
        serectCircle = SerectCircle.GetComponent<SerectCircle>();
        Description(flags);
        note.randomMAX = 0 ;
        enemynote.randomMAX = 0;
        
    }
    private void Update()
    {
        if (touchFlag)
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (tutorialFlag)
                {
                    case Flag.description:
                        Description(flags);
                        break;
                    case Flag.note:
                        Note(flags);
                        break;
                    case Flag.enemyNote:
                        EnemyNote(flags);
                        break;
                    case Flag.deadlyNote:
                        DeadlyNote(flags);
                        break;
                    default:
                        break;
                }
            }
        }
    
    }
    public void Description(int i)
    {
        switch (i)
        {
            case 1:
                text.ChengeScenarioText("チュートリアルです");
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("これ味方");
                serectCircle.TutorialSerectCircle(3.5f, 6, 380, 0);
                flags++;
                break;
            case 3:
                text.ChengeScenarioText("これ敵");
                serectCircle.TutorialSerectCircle(3.5f, 6, -380, 0);
                flags++;
                break;
            case 4:
                text.ChengeScenarioText("これHP");
                flags = 1;
                tutorialFlag = Flag.note;
                break;

        }
    }
    public void Note(int i)
    {
        switch (i)
        {
            case 1:
                TouchFlag(false);
                text.ChengeScenarioText("これが攻撃ノーツ");
                notes = note.ClonePartyNote("tokage", -2.8f, 1.46f);
                Invoke("StopNote",0.5f);
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("これが判定ライン");
                flags++;
                break;
            case 3:
                TouchFlag(false);
                text.ChengeScenarioText("重なったらここをタップ");
                StopNote();
                Invoke("StopNote", 0.75f);
                flags++;
                break;
            case 4:
                text.ChengeScenarioText("次は敵ノーツ");
                Destroy(notes);
                StopNote();
                flags = 1;
                tutorialFlag = Flag.enemyNote;
                break;
        }
    }
    public void EnemyNote(int i)
    {
        switch (i)
        {
            case 1:
                TouchFlag(false);
                text.ChengeScenarioText("これ敵ノーツ");
                notes = enemynote.CloneEnemyNote("1", 2.8f, 0.68f);
                moveEnemyNote = notes.GetComponent<MoveEnemyNote>();
                moveEnemyNote.lengeMAX = -0.1f;
                moveEnemyNote.lengeMIN = -0.1f;
                Invoke("StopNote", 0.5f);
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("これが判定ライン");
                flags++;
                break;
            case 3:
                TouchFlag(false);
                text.ChengeScenarioText("重なったらここをタップ");
                StopNote();
                Invoke("StopNote", 0.75f);
                flags++;
                break;
            case 4:
                text.ChengeScenarioText("次は必殺ノーツ");
                Destroy(notes);
                StopNote();
                flags = 1;
                tutorialFlag = Flag.deadlyNote;
                break;
        }
    }
    public void DeadlyNote(int i)
    {
        switch (i)
        {
            case 1:
                TouchFlag(false);
                text.ChengeScenarioText("これ必殺ノーツ");
                notes = note.CloneDeadlyPartyNote("momonga", -2.8f, 0);
                Invoke("StopNote", 0.4f);
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("判定ラインはかわらず");
                flags++;
                break;
            case 3:
                TouchFlag(false);
                text.ChengeScenarioText("タイミングも同じだけど難しいよ");
                StopNote();
                Invoke("StopNote", 0.45f);
                flags++;
                break;
            case 4:
                text.ChengeScenarioText("じゃあ実際にやってみよう！");
                tutorialControler.tutorialFlag = false;
                Destroy(notes);
                StopNote();
                //tutorialControler.SetActiveNote(false);
                Invoke("ReStart",1.5f);
                tutorialFlag = Flag.tutorialBattle;
                flag = true;
                break;
        }
    }
    public void StopNote()
    {
        //timescaleが1のときにクリックしたら0にしてstopをtrueにする
        //timescaleが0のときにクリックしたら1にしてstopをfalseにする
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            TouchFlag(true);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    private void ReStart()
    {
        note.randomMAX = 250000;
        enemynote.randomMAX = 25000;
    }
    private void TouchFlag(bool i)
    {
        if (i)
        {
            touchFlag = true;
        }
        else
        {
            touchFlag = false;
        }
    }
}
