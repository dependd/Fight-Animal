using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialControler : MonoBehaviour {
    [SerializeField]
    TutorialFlagManager flagManager;


    GameObject[] objs;

    public bool tutorialFlag = false;
    void Start()
    {
        
        objs = GameObject.FindGameObjectsWithTag("Note");
        //SetActiveNote(true);
    }
    
    public void SetActiveNote(bool hantei)
    {
        if (hantei)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].SetActive(false);
                
            }
        }
        else
        {
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].SetActive(true);
            }
        }
    }
}