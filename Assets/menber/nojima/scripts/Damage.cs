using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    
    public GameObject PartyDamage;
    public GameObject EnemyDamage;

    public GameObject PartyNote;
    public GameObject EnemyNote;

    // Use this for initialization
    void Start () {
        PartyDamage.SetActive(false);
        EnemyDamage.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        
        DamageDisplay();
    }

    void DamageDisplay() {
        /*if ( == true) {
            
        }*/
    }
}
