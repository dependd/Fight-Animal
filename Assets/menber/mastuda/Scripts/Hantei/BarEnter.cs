using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarEnter : MonoBehaviour {
    [SerializeField] GameObject bar;
    [SerializeField] GameObject deadlyBar;
    BarLight barLight;

    private void Start()
    {
        barLight = bar.GetComponent<BarLight>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy") return;
        barLight.ChengeSprite(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        barLight.ChengeSprite(false);
    }
}
