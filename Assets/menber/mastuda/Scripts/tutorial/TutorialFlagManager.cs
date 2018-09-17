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
    [SerializeField]
    NoteFrequency noteFrequency;
    TouchHantei touchHantei;

    [SerializeField]
    GameObject countDownImage;
    CountDown countDown;


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
        touchHantei = GetComponent<TouchHantei>();
        countDown = countDownImage.GetComponent<CountDown>();
        if (BattleManager.Instance.nowBattleScene == 0)
        {
            Description(flags);
        }else if (BattleManager.Instance.nowBattleScene == 1)
        {
            DeadlyNote(flags);
        }
        note.datyoNote = false;
        note.tokageNote = false;
        note.momongaNote = false;
        note.kameNote = false;
        enemynote.enemyNote1 = false;
        enemynote.enemyNote2 = false;
        enemynote.enemyNote3 = false;
    }
    private void Update()
    {
        if (touchFlag)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (BattleManager.Instance.nowBattleScene == 0)
                {
                    touchHantei.toucjFlag = false;
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
                        default:
                            break;
                    }
                }
                else if (BattleManager.Instance.nowBattleScene == 1)
                {
                    DeadlyNote(flags);
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
                text.ChengeScenarioText("チュートリアルです。");
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("右側が味方です。");
                //画面に黒の円を描く関数(Xの大きさ,Yの大きさ,Xの位置,Yの位置)
                serectCircle.TutorialSerectCircle(3, 5, 380, 0);
                flags++;
                break;
            case 3:
                text.ChengeScenarioText("左側が敵です。");
                serectCircle.TutorialSerectCircle(3, 5, -380, 0);
                flags++;
                break;
            case 4:
                text.ChengeScenarioText("上にあるのがHPです。\n左側が敵のHP、右側が味方のHPです。");
                serectCircle.TutorialSerectCircle(10, 1.5f, 0, 330);
                flags++;
                break;
            case 5:
                text.ChengeScenarioText("ボードについての説明です。");
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
                text.ChengeScenarioText("これが攻撃のボードです。");
                notes = note.ClonePartyNote("tokage", -2.8f, 1.51f);
                Invoke("StopNote", 0.6f);
                serectCircle.TutorialSerectCircle(1.5f, 1.5f, -24, 114);
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("これが判定ラインです。");
                serectCircle.TutorialSerectCircle(1, 5.5f, 268.5f, 45);
                flags++;
                break;
            case 3:
                TouchFlag(false);
                text.ChengeScenarioText("重なったらここをタップ");
                StopNote();
                Invoke("StopNote", 1f);
                serectCircle.TutorialSerectCircle(3, 1.5f, 392, 120);
                flags++;
                break;
            case 4:
                text.ChengeScenarioText("キャラごとにタップする位置は変わります。\nここは黄色いボード\nダチョウの攻撃のタッチ場所です。");
                serectCircle.TutorialSerectCircle(3, 1.5f, 392, 230);
                Destroy(notes);
                StopNote();
                flags++;
                break;
            case 5:
                text.ChengeScenarioText("ここは赤いボード\nトカゲの攻撃のタッチ場所です。");
                serectCircle.TutorialSerectCircle(3, 1.5f, 392, 120);
                flags++;
                break;
            case 6:
                text.ChengeScenarioText("ここは緑のボード\nモモンガの攻撃のタッチ場所です。");
                serectCircle.TutorialSerectCircle(3, 1.5f, 392, 0);
                flags++;
                break;
            case 7:
                text.ChengeScenarioText("ここは青いボード\nカメの攻撃のタッチ場所です。");
                serectCircle.TutorialSerectCircle(3, 1.5f, 392, -120);
                flags++;
                break;
            case 8:
                text.ChengeScenarioText("次は敵のボードです。");
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
                text.ChengeScenarioText("これは敵の攻撃を防御するためのボードです。\nこのボードは上、真ん中、下の３種類があります。");
                notes = enemynote.CloneEnemyNote("1", 2.8f, 0.68f);
                moveEnemyNote = notes.GetComponent<MoveEnemyNote>();
                moveEnemyNote.lengeMAX = -0.1f;
                moveEnemyNote.lengeMIN = -0.1f;
                Invoke("StopNote", 0.5f);
                serectCircle.TutorialSerectCircle(1.5f, 1.5f, 24, 50);
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("これが判定ラインです。");
                serectCircle.TutorialSerectCircle(1, 5.5f, -277, 50);
                flags++;
                break;
            case 3:
                TouchFlag(false);
                text.ChengeScenarioText("重なったらここをタップ\n敵の攻撃の防御をするためのタップ場所はこの範囲だけです。\nここだけで３つのボード分対応できます。");
                StopNote();
                Invoke("StopNote", 0.75f);
                serectCircle.TutorialSerectCircle(2.5f, 5.1f, -386.3f, 40);
                flags++;
                break;
            case 4:
                text.ChengeScenarioText("それでは実際にやってみましょう！");
                serectCircle.TutorialSerectCircle(800, 0, 392, 120);
                //tutorialControler.tutorialFlag = false;
                touchFlag = false;
                StopNote();
                Destroy(notes);
                //tutorialControler.SetActiveNote(false);
                Invoke("ReStart", 1.0f);
                tutorialFlag = Flag.tutorialBattle;
                touchHantei.toucjFlag = true;
                flag = true;
                break;
        }
    }
    //必殺音符説明
    public void DeadlyNote(int i)
    {
        switch (i)
        {
            case 1:
                text.ChengeScenarioText("必殺ボードについての説明です。");
                serectCircle.TutorialSerectCircle(800, 0, 392, 120);
                flags++;
                break;
            case 2:
                TouchFlag(false);
                text.ChengeScenarioText("この短いのが必殺ボードです。");
                notes = note.CloneDeadlyPartyNote("momonga", -2.8f, 0);
                Invoke("StopNote", 0.4f);
                serectCircle.TutorialSerectCircle(1.5f, 1.5f, 15.5f, 0.28f);
                flags++;
                break;
            case 3:
                text.ChengeScenarioText("判定ラインは変わりません。");
                serectCircle.TutorialSerectCircle(1, 5.5f, 268.5f, 45);
                flags++;
                break;
            case 4:
                TouchFlag(false);
                text.ChengeScenarioText("タイミングもタップする場所も同じですが難しいです。");
                StopNote();
                Invoke("StopNote", 0.45f);
                serectCircle.TutorialSerectCircle(3, 1.5f, 392, 0);
                flags++;
                break;
            case 5:
                text.ChengeScenarioText("それでは実際にやってみましょう！");
                serectCircle.TutorialSerectCircle(800, 0, 392, 120);
                //tutorialControler.tutorialFlag = false;
                touchFlag = false;
                Destroy(notes);
                StopNote();
                //tutorialControler.SetActiveNote(false);
                Invoke("ReStart", 1.0f);
                touchHantei.toucjFlag = true;
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
        if (BattleManager.Instance.nowBattleScene == 1)
        {
            var tinpan = GameObject.Find("tinpan");
            var charaAnimation = tinpan.GetComponent<CharaAnimation>();
            StartCoroutine(charaAnimation.TransfromAnim());
            text.ChengeScenarioText("チンパンが本性をあらわした!!");
        }
        else
        {
            noteFrequency.GetComponent<NoteFrequency>().enabled = true;
            StartCoroutine(countDown.CountdownCoroutine());
            text.ChengeScenarioText("");
        }
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
