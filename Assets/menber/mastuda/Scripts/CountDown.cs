using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour {

    [SerializeField]
    private Image _spriteCountdown;
    [SerializeField] Sprite one;
    [SerializeField] Sprite twe;
    [SerializeField] Sprite three;
    [SerializeField] Sprite go;

    private void Start()
    {

        //カウントダウンの関数
       // StartCoroutine(CountdownCoroutine());
    }

    public IEnumerator CountdownCoroutine()
    {
        GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
        for(int i = 0;i < notes.Length; i++)
        {
            notes[i].SetActive(false);
        }
        _spriteCountdown.color = new Color(255,255,255,255);
        //_textCountdown.text = "3";
        _spriteCountdown.sprite = three;
        yield return new WaitForSeconds(1.0f);

        //_textCountdown.text = "2";
        _spriteCountdown.sprite = twe;
        yield return new WaitForSeconds(1.0f);

        //_textCountdown.text = "1";
        _spriteCountdown.sprite = one;
        yield return new WaitForSeconds(1.0f);

        //_textCountdown.text = "GO!";
        _spriteCountdown.sprite = go;
        yield return new WaitForSeconds(1.0f);

        //_textCountdown.text = "";
        _spriteCountdown.color = new Color(255,255,255,0);
        
        for (int i = 0; i < notes.Length; i++)
        {
            notes[i].SetActive(true);
        }
        
    }
}
