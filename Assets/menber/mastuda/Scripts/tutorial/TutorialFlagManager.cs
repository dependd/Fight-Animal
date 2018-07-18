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
    /// <summary>
    /// これ以上チュートリアルに要素を増やす場合は
    /// 
    /// case 数値:
    ///     text.ChengeScenarioText("ここにテキスト");
    ///     flags++;
    ///     break;
    /// 
    /// を追加すること
    /// 各switch文の最後のcaseにはできるだけ触れないでください
    /// </summary>
    /// <param name="i"></param>
    //画面説明
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
                //画面に黒の円を描く関数(Xの大きさ,Yの大きさ,Xの位置,Yの位置)
                serectCircle.TutorialSerectCircle(3, 5, 380, 0);
                flags++;
                break;
            case 3:
                text.ChengeScenarioText("これ敵");
                serectCircle.TutorialSerectCircle(3, 5, -380, 0);
                flags++;
                break;
            case 4:
                text.ChengeScenarioText("これHP\n左が敵、右が味方");
                serectCircle.TutorialSerectCircle(10,1.5f,0,330);
                flags++;
                break;
            case 5:
                text.ChengeScenarioText("次音符について説明");
                serectCircle.TutorialSerectCircle(800, 0, 392, 120);
                flags = 1;
                tutorialFlag = Flag.note;
                break;
        }
    }
    //攻撃音符説明
    public void Note(int i)
    {
        switch (i)
        {
            case 1:
                TouchFlag(false);
                text.ChengeScenarioText("これが攻撃音符");
                notes = note.ClonePartyNote("tokage", -2.8f, 1.46f);
                Invoke("StopNote",0.5f);
                serectCircle.TutorialSerectCircle(1.5f, 1.5f, -24, 114);
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("これが判定ライン");
                serectCircle.TutorialSerectCircle(1, 5.5f, 268.5f, 45);
                flags++;
                break;
            case 3:
                TouchFlag(false);
                text.ChengeScenarioText("重なったらここをタップ");
                StopNote();
                Invoke("StopNote", 0.75f);
                serectCircle.TutorialSerectCircle(3, 1.5f, 392, 120);
                flags++;
                break;
            case 4:
                text.ChengeScenarioText("キャラごとにタップする位置は変わる\nここは黄色い音符\nダチョウの攻撃のタッチ場所");
                serectCircle.TutorialSerectCircle(3, 1.5f, 392, 230);
                Destroy(notes);
                StopNote();
                flags++;
                break;
            case 5:
                text.ChengeScenarioText("ここは赤い音符\nトカゲの攻撃のタッチ場所");
                serectCircle.TutorialSerectCircle(3, 1.5f, 392, 120);
                flags++;
                break;
            case 6:
                text.ChengeScenarioText("ここは緑の音符\nモモンガの攻撃のタッチ場所");
                serectCircle.TutorialSerectCircle(3, 1.5f, 392, 0);
                flags++;
                break;
            case 7:
                text.ChengeScenarioText("ここは青い音符\nカメの攻撃のタッチ場所");
                serectCircle.TutorialSerectCircle(3, 1.5f, 392, -120);
                flags++;
                break;
            case 8:
                text.ChengeScenarioText("次は敵音符");
                serectCircle.TutorialSerectCircle(800, 0, 392, 120);
                flags = 1;
                tutorialFlag = Flag.enemyNote;
                break;
        }
    }
    //敵音符説明
    public void EnemyNote(int i)
    {
        switch (i)
        {
            case 1:
                TouchFlag(false);
                text.ChengeScenarioText("これは敵の音符\n敵の音符はこれの上下にもう二種類存在");
                notes = enemynote.CloneEnemyNote("1", 2.8f, 0.68f);
                moveEnemyNote = notes.GetComponent<MoveEnemyNote>();
                moveEnemyNote.lengeMAX = -0.1f;
                moveEnemyNote.lengeMIN = -0.1f;
                Invoke("StopNote", 0.5f);
                serectCircle.TutorialSerectCircle(1.5f, 1.5f, 24, 50);
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("これが判定ライン");
                serectCircle.TutorialSerectCircle(1, 5.5f, -277, 50);
                flags++;
                break;
            case 3:
                TouchFlag(false);
                text.ChengeScenarioText("重なったらここをタップ\n敵の攻撃防御のタップ場所この範囲だけ\nここだけで３つの音符分対応できる");
                StopNote();
                Invoke("StopNote", 0.75f);
                serectCircle.TutorialSerectCircle(2.5f, 5.1f, -386.3f, 40);
                flags++;
                break;
            case 4:
                text.ChengeScenarioText("次は必殺音符");
                serectCircle.TutorialSerectCircle(800, 0, 392, 120);
                Destroy(notes);
                StopNote();
                flags = 1;
                tutorialFlag = Flag.deadlyNote;
                break;
        }
    }
    //必殺音符説明
    public void DeadlyNote(int i)
    {
        switch (i)
        {
            case 1:
                TouchFlag(false);
                text.ChengeScenarioText("この短いのが必殺音符");
                notes = note.CloneDeadlyPartyNote("momonga", -2.8f, 0);
                Invoke("StopNote", 0.4f);
                serectCircle.TutorialSerectCircle(1.5f, 1.5f, 15.5f, 0.28f);
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("判定ラインはかわらず");
                serectCircle.TutorialSerectCircle(1, 5.5f, 268.5f, 45);
                flags++;
                break;
            case 3:
                TouchFlag(false);
                text.ChengeScenarioText("タイミングもタップする場所も同じだけど\n難しいよ");
                StopNote();
                Invoke("StopNote", 0.45f);
                serectCircle.TutorialSerectCircle(3, 1.5f, 392, 0);
                flags++;
                break;
            case 4:
                text.ChengeScenarioText("じゃあ実際にやってみよう！");
                serectCircle.TutorialSerectCircle(800, 0, 392, 120);
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
        text.ChengeScenarioText("");
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
