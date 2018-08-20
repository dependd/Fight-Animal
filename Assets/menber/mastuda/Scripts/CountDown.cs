using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour {

    [SerializeField]
    private Text _textCountdown;
    private void Start()
    {

        //カウントダウンの関数
        StartCoroutine(CountdownCoroutine());
    }

    public IEnumerator CountdownCoroutine()
    {
        GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
        for(int i = 0;i < notes.Length; i++)
        {
            notes[i].SetActive(false);
        }

        _textCountdown.text = "3";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "2";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "1";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "GO!";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "";
        
        for (int i = 0; i < notes.Length; i++)
        {
            notes[i].SetActive(true);
        }
        
    }
}
