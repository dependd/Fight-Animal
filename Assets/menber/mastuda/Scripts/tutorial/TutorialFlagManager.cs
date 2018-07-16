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

	public enum Flag
    {
        description,
        note,
        enemyNote,
        deadlyNote,
        tutorialBattle
    }

    public int flags = 1;
    public bool flag = false;
    public Flag tutorialFlag;

    private void Start()
    {
        tutorialFlag = Flag.description;
        text = scenarioText.GetComponent<ScenarioText>();
        tutorialControler = GetComponent<TutorialControler>();
        Description(flags);
        note.randomMAX = 0 ;
        enemynote.randomMAX = 0;
        
    }
    private void Update()
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
    public void Description(int i)
    {
        switch (i)
        {
            case 1:
                text.ChengeScenarioText("これ味方");
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("これ敵");
                flags++;
                break;
            case 3:
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
                text.ChengeScenarioText("これが攻撃ノーツ");
                note.ClonePartyNote("tokage", -2.8f, 1.46f);
                Invoke("StopNote",0.5f);
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("これが判定ライン");
                flags++;
                break;
            case 3:
                text.ChengeScenarioText("重なったらここをタップ");
                StopNote();
                Invoke("StopNote", 0.75f);
                flags++;
                break;
            case 4:
                text.ChengeScenarioText("次は敵ノーツ");
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
                text.ChengeScenarioText("これ敵ノーツ");
                enemynote.CloneEnemyNote("1", 2.8f, 0.68f);
                Invoke("StopNote", 0.5f);
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("これが判定ライン");
                flags++;
                break;
            case 3:
                text.ChengeScenarioText("重なったらここをタップ");
                StopNote();
                Invoke("StopNote", 0.6f);
                flags++;
                break;
            case 4:
                text.ChengeScenarioText("次は必殺ノーツ");
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
                text.ChengeScenarioText("これ必殺ノーツ");
                note.CloneDeadlyPartyNote("momonga", -2.8f, 0);
                Invoke("StopNote", 0.45f);
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("判定ラインはかわらず");
                flags++;
                break;
            case 3:
                text.ChengeScenarioText("タイミングも同じだけど難しいよ");
                StopNote();
                Invoke("StopNote", 0.5f);
                flags++;
                break;
            case 4:
                text.ChengeScenarioText("じゃあ実際にやってみよう！");
                tutorialControler.tutorialFlag = false;
                StopNote();
                //tutorialControler.SetActiveNote(false);
                Invoke("ReStart",1.0f);
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
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    private void ReStart()
    {
        note.randomMAX = 100000;
        enemynote.randomMAX = 10000;
    }
}
