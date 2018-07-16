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
    
	public enum Flag
    {
        description,
        note,
        enemyNote,
        deadlyNote
    }

    public int flags = 1;
    public bool flag;
    public Flag tutorialFlag;

    private void Start()
    {
        tutorialFlag = Flag.description;
        text = scenarioText.GetComponent<ScenarioText>();
        tutorialControler = GetComponent<TutorialControler>();
        Description(flags);
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
                text.ChengeScenarioText("ゲームの説明１");
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("ゲームの説明２");
                flags++;
                break;
            case 3:
                text.ChengeScenarioText("ゲームの説明３");
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
                text.ChengeScenarioText("ノーツの説明１");
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("ノーツの説明２");
                flags++;
                break;
            case 3:
                text.ChengeScenarioText("ノーツの説明３");
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
                text.ChengeScenarioText("敵ノーツの説明１");
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("敵ノーツの説明２");
                flags++;
                break;
            case 3:
                text.ChengeScenarioText("敵ノーツの説明３");
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
                text.ChengeScenarioText("必殺ノーツの説明１");
                flags++;
                break;
            case 2:
                text.ChengeScenarioText("必殺ノーツの説明２");
                flags++;
                break;
            case 3:
                text.ChengeScenarioText("必殺ノーツの説明３");
                flags = 0;
                tutorialControler.tutorialFlag = false;
                tutorialControler.SetActiveNote(false);
                break;
        }
    }
}
