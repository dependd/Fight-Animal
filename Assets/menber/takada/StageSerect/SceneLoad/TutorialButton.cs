using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Novel;

public class TutorialButton : MonoBehaviour
{

    public void OnClick()
    {
        NovelSingleton.StatusManager.callJoker("wide/scene1", "");

    }
}