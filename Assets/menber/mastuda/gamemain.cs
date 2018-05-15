
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemain : MonoBehaviour
{
    bool one;
    int random;
    Vector2 mouseClickPosition;
    /*
    float note1speed;
    float note2speed;
    float note3speed;
    float note4speed;
    */
    //メニューを押したら(一応)スタートに戻る
    public void menuButton()
    {
        SceneManager.LoadScene("start");
    }
    void Start()
    {
        one = true;
    }

    void Update()
    {
        if (one)
        {
            /*
            note1speed = NoteSpeeds();
            note2speed = NoteSpeeds();
            note3speed = NoteSpeeds();
            note4speed = NoteSpeeds();
            */
            one = false;
        }
        /*
        GameObject note1 = GameObject.Find("note1");
        note1.transform.position += new Vector3(note1speed, 0, 0);
        GameObject note2 = GameObject.Find("note2");
        note2.transform.position += new Vector3(note2speed, 0, 0);
        GameObject note3 = GameObject.Find("note3");
        note3.transform.position += new Vector3(note3speed, 0, 0);
        GameObject note4 = GameObject.Find("note4");
        note4.transform.position += new Vector3(note4speed, 0, 0);
        */
        if (Input.GetMouseButtonDown(0))
        {
            mouseClickPosition = Input.mousePosition;
            Debug.Log("クリックした座標は" + mouseClickPosition);
            if (mouseClickPosition.x >= 0.0 && mouseClickPosition.x <= 230.0f)
            {
                if (mouseClickPosition.y >= 190.0 && mouseClickPosition.y <= 676.0)
                {
                    Debug.Log("敵の攻撃を防いだ");
                }
            }
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f)
            {
                if (mouseClickPosition.y >= 559.0 && mouseClickPosition.y <= 676.0)
                {
                    Debug.Log("勇者1攻撃");
                }
            }
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f)
            {
                if (mouseClickPosition.y >= 451.0 && mouseClickPosition.y < 559.0)
                {
                    Debug.Log("勇者2攻撃");
                }
            }
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f)
            {
                if (mouseClickPosition.y >= 322.0 && mouseClickPosition.y <= 451.0)
                {
                    Debug.Log("勇者3攻撃");
                }
            }
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f)
            {
                if (mouseClickPosition.y >= 190.0 && mouseClickPosition.y <= 322.0)
                {
                    Debug.Log("勇者4攻撃");
                }
            }
        }
        
        /*
        if (note1.transform.position.x >= 7.5f)
        {
            note1.transform.position = new Vector2(7.5f, 3);
        }
        if (note2.transform.position.x >= 7.5f)
        {
            note2.transform.position = new Vector2(7.5f, 1.46f);
        }
        if (note3.transform.position.x >= 7.5f)
        {
            note3.transform.position = new Vector2(7.5f, 0);
        }
        if (note4.transform.position.x >= 7.5f)
        {
            note4.transform.position = new Vector2(7.5f, -1.65f);
        }
        random = RandomRange();
        if (note1.transform.position.x == 7.5f)
        {
            if (random >= 4500 && random <= 4750)
            {
                note1.transform.position = new Vector2(-3, 3);
            }
        } else if (note2.transform.position.x == 7.5f)
        {
            if (random > 4750 && random <= 5000)
            {
                note2.transform.position = new Vector2(-3, 1.46f);
            }
        } else if (note3.transform.position.x == 7.5f)
        {
            if (random > 5000 && random <= 5250)
            {
                note3.transform.position = new Vector2(-3, 0);
            }
        } else if (note4.transform.position.x == 7.5f)
        {
            if (random > 5250 && random <= 5500)
            {
                note4.transform.position = new Vector2(-3, -1.65f);
            }
        }*/
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
