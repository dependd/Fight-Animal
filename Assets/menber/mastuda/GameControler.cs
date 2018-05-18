
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    int random;
    Vector2 mouseClickPosition;
    //GameObjectを格納する変数
    GameObject techniuqueNote1;
    GameObject note2;
    GameObject note3;
    GameObject note4;
    GameObject enemyNote1;
    GameObject enemyNote2;
    GameObject enemyNote3;
    GameObject deadlyNote1;
    GameObject deadlyNote2;
    GameObject deadlyNote3;
    GameObject deadlyNote4;
    //hpスクリプトを取得するための変数
    GameObject notes;
    hp hp;
    //メニューを押したら(一応)スタートに戻る
    public void menuButton()
    {
        SceneManager.LoadScene("start");
    }
    void Start()
    {
        //対応するObjectの取得
        techniuqueNote1 = GameObject.Find("note1");
        note2 = GameObject.Find("note2");
        note3 = GameObject.Find("note3");
        note4 = GameObject.Find("note4");
        enemyNote1 = GameObject.Find("enemynote1");
        enemyNote2 = GameObject.Find("enemynote2");
        enemyNote3 = GameObject.Find("enemynote3");
        deadlyNote1 = GameObject.Find("deadlyNote1");
        deadlyNote2 = GameObject.Find("deadlyNote2");
        deadlyNote3 = GameObject.Find("deadlyNote3");
        deadlyNote4 = GameObject.Find("deadlyNote4");

        //enemySliderのhpスクリプトを参照
        notes = GameObject.Find("enemySlider");
        hp = notes.GetComponent<hp>();
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            mouseClickPosition = Input.mousePosition;
            //敵の攻撃を防ぐ処理
            Debug.Log("クリックした座標は" + mouseClickPosition);
            //クリックした座標が一定域内かどうかの判別
            if (mouseClickPosition.x >= 0.0 && mouseClickPosition.x <= 230.0f)
            {
                if (mouseClickPosition.y >= 190.0 && mouseClickPosition.y <= 676.0)
                {
                    //noteの位置が一定域内だったらnoteを消す処理
                    if (enemyNote1.transform.position.x <= -3 && enemyNote1.transform.position.x >= -5)
                    {
                        enemyNote1.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("敵の攻撃を防いだ");
                    }
                    if (enemyNote2.transform.position.x <= -3 && enemyNote2.transform.position.x >= -5)
                    {
                        enemyNote2.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("敵の攻撃を防いだ");
                    }
                    if (enemyNote3.transform.position.x <= -3 && enemyNote3.transform.position.x >= -5)
                    {
                        enemyNote3.transform.position = new Vector2(-7.5f, 5);
                        Debug.Log("敵の攻撃を防いだ");
                    }
                    
                }
            }
            //1番目の勇者が攻撃する処理
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f)
            {
                if (mouseClickPosition.y >= 559.0 && mouseClickPosition.y <= 676.0)
                {
                    //noteの位置が一定域内だったらnoteを消して相手にダメージを与える処理
                    if (techniuqueNote1.transform.position.x >= 3 && techniuqueNote1.transform.position.x <= 5)
                    {
                        techniuqueNote1.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者１攻撃");
                        hp.DownEnemyHp();
                    }
                    //techniqueNoteの位置が一定域内だったらnoteを消して必殺技を繰り出す処理
                    if (deadlyNote1.transform.position.x >= 3 && deadlyNote1.transform.position.x <= 5)
                    {
                        deadlyNote1.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者１必殺技");
                        hp.DownEnemyHp();
                    }
                }
            }
            //2番目の勇者が攻撃する時の処理
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f)
            {
                if (mouseClickPosition.y >= 451.0 && mouseClickPosition.y < 559.0)
                {
                    if (note2.transform.position.x >= 3 && note2.transform.position.x <= 5)
                    {
                        //noteの位置が一定域内だったらnoteを消して相手にダメージを与える処理
                        note2.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者2攻撃");
                        hp.DownEnemyHp();
                    }
                    //techniqueNoteの位置が一定域内だったらnoteを消して必殺技を繰り出す処理
                    if (deadlyNote2.transform.position.x >= 3 && deadlyNote2.transform.position.x <= 5)
                    {
                        deadlyNote2.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者2必殺技");
                        hp.DownEnemyHp();
                    }
                }
            }
            //3番目の勇者が攻撃するときの処理
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f)
            {
                if (mouseClickPosition.y >= 322.0 && mouseClickPosition.y <= 451.0)
                {
                    if (note3.transform.position.x >= 3 && note3.transform.position.x <= 5)
                    {
                        //noteの位置が一定域内だったらnoteを消して相手にダメージを与える処理
                        note3.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者3攻撃");
                        hp.DownEnemyHp();
                    }
                    //techniqueNoteの位置が一定域内だったらnoteを消して必殺技を繰り出す処理
                    if (deadlyNote3.transform.position.x >= 3 && deadlyNote3.transform.position.x <= 5)
                    {
                        deadlyNote3.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者3必殺技");
                        hp.DownEnemyHp();
                    }
                }
            }
            //4番目の勇者が攻撃するときの処理
            if (mouseClickPosition.x >= 780.0 && mouseClickPosition.x <= 1024.0f)
            {
                if (mouseClickPosition.y >= 190.0 && mouseClickPosition.y <= 322.0)
                {
                    if (note4.transform.position.x >= 3 && note4.transform.position.x <= 5)
                    {
                        //noteの位置が一定域内だったらnoteを消して相手にダメージを与える処理
                        note4.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者4攻撃");
                        hp.DownEnemyHp();
                    }
                    //techniqueNoteの位置が一定域内だったらnoteを消して必殺技を繰り出す処理
                    if (deadlyNote4.transform.position.x >= 3 && deadlyNote4.transform.position.x <= 5)
                    {
                        deadlyNote4.transform.position = new Vector2(-10, 5);
                        Debug.Log("勇者4必殺技");
                        hp.DownEnemyHp();
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
    //ランダムな数値を出す関数
    public int RandomRange()
    {
        int random = Random.Range(0, 10000);
        return random;
    }
}
