
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemain : MonoBehaviour
{
    bool one;
    int random;
    Vector2 mouseClickPosition;
    GameObject note1;
    GameObject note2;
    GameObject note3;
    GameObject note4;
    GameObject enemynote1;
    GameObject enemynote2;
    GameObject enemynote3;
    GameObject enemynote4;
    //メニューを押したら(一応)スタートに戻る
    public void menuButton()
    {
        SceneManager.LoadScene("start");
    }
    void Start()
    {
        one = true;
        note1 = GameObject.Find("note1");
        note2 = GameObject.Find("note2");
        note3 = GameObject.Find("note3");
        note4 = GameObject.Find("note4");
        enemynote1 = GameObject.Find("enemynote1");
        enemynote2 = GameObject.Find("enemynote2");
        enemynote3 = GameObject.Find("enemynote3");
        enemynote4 = GameObject.Find("enemynote4");
    }

    void Update()
    {
        //Update内で一度だけ行う処理
        if (one)
        {
            
            one = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            mouseClickPosition = Input.mousePosition;
            Debug.Log("クリックした座標は" + mouseClickPosition);
            if (mouseClickPosition.x >= 0.0 && mouseClickPosition.x <= 230.0f)
            {
                if (mouseClickPosition.y >= 190.0 && mouseClickPosition.y <= 676.0)
                {
                    if (enemynote1.transform.position.x <= -3 && enemynote1.transform.position.x >= -5)
                    {
                        enemynote1.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("敵の攻撃を防いだ");
                    }
                    if (enemynote2.transform.position.x <= -3 && enemynote2.transform.position.x >= -5)
                    {
                        enemynote2.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("敵の攻撃を防いだ");
                    }
                    if (enemynote3.transform.position.x <= -3 && enemynote3.transform.position.x >= -5)
                    {
                        enemynote3.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("敵の攻撃を防いだ");
                    }
                    if (enemynote4.transform.position.x <= -3 && enemynote4.transform.position.x >= -5)
                    {
                        enemynote4.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("敵の攻撃を防いだ");
                    }
                }
            }
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f)
            {
                if (mouseClickPosition.y >= 559.0 && mouseClickPosition.y <= 676.0)
                {
                    if (note1.transform.position.x >= 3 && note1.transform.position.x <= 5)
                    {
                        note1.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者１攻撃");
                    }
                }
            }
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f)
            {
                if (mouseClickPosition.y >= 451.0 && mouseClickPosition.y < 559.0)
                {
                    if (note2.transform.position.x >= 3 && note2.transform.position.x <= 5)
                    {
                        note2.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者2攻撃");
                    }
                }
            }
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f)
            {
                if (mouseClickPosition.y >= 322.0 && mouseClickPosition.y <= 451.0)
                {
                    if (note3.transform.position.x >= 3 && note3.transform.position.x <= 5)
                    {
                        note3.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者3攻撃");
                    }
                }
            }
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f)
            {
                if (mouseClickPosition.y >= 190.0 && mouseClickPosition.y <= 322.0)
                {
                    if (note4.transform.position.x >= 3 && note4.transform.position.x <= 5)
                    {
                        note4.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者4攻撃");
                    }
                }
            }
        }
        
    }
    
    //ノーツの速度変更の関数
    public float NoteSpeeds()
    {
        float noteSpeed = Random.Range(0.05f, 0.1f);
        return noteSpeed;
    }

    public int RandomRange()
    {
        int random = Random.Range(0, 10000);
        return random;
    }
}
