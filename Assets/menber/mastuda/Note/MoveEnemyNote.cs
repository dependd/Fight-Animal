using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyNote : MonoBehaviour {

    float noteSpeed;
    private void Start()
    {
        noteSpeed = NoteSpeeds();
    }
    // Update is called once per frame
    void FixedUpdate () {
        this.transform.position += new Vector3(noteSpeed,0,0);
	}

    //noteのスピードを変える変数
    private float NoteSpeeds()
    {
        float noteSpeed = Random.Range(-0.05f, -0.15f);
        return noteSpeed;
    }
}
