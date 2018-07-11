using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyNote : MonoBehaviour {
    GameObject GameControler;
    GameControler gameControler;

    float noteSpeed;

    string objName;
    private void Start(){
        objName = this.gameObject.name;
        noteSpeed = NoteSpeeds();
        GameControler = GameObject.Find("GameControler");
        gameControler = GameControler.GetComponent<GameControler>();
    }
    // Update is called once per frame
    void FixedUpdate () {
        this.transform.position += new Vector3(noteSpeed,0,0);
	}

    //noteのスピードを変える変数
    private float NoteSpeeds(){
        float noteSpeed = Random.Range(-0.05f, -0.15f);
        return noteSpeed;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Party") return;
        Debug.Log("EnemyNoteOnTrigger");
        CheckEnemyLine(objName, true);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Party") return;
        Debug.Log("EnemyNoteExitTrigger");
        CheckEnemyLine(objName, false);
    }
    private void CheckEnemyLine(string line,bool check)
    {
        switch (line)
        {
            case "enemyNote1":
                gameControler.enemyLine1 = check;
                break;
            case "enemyNote2":
                gameControler.enemyLine2 = check;
                break;
            case "enemyNote3":
                gameControler.enemyLine3 = check;
                break;
            default:
                break;
        }
    }
}
