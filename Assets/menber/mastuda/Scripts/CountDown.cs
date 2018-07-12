using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    [SerializeField]
    private Text _textCountdown;
    

    private void Awake()
    {
        CountdownCoroutine();
    }

    IEnumerator CountdownCoroutine()
    {
        _textCountdown.text = "3";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "2";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "1";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "GO!";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "";
    }
}
