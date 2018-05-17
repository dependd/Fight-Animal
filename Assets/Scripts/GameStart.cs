using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TransitionToResult();
        }
    }
    public void TransitionToResult()
    {
        SceneManager.LoadScene("Battle");
    }

    

}
