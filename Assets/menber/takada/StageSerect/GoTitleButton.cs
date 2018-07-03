using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTitleButton : MonoBehaviour {

    public void OnClick()
    {
        SceneManager.LoadScene("start");

    }
}
