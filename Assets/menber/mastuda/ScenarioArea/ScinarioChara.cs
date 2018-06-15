using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScinarioChara : MonoBehaviour {

    enum ScenarioCharas {
        datyo,
        tokage,
        momonga,
        kame
    }
    SpriteRenderer mainSpriteRenderer;
    public Sprite datyo;
    public Sprite tokage;
    public Sprite momonga;
    public Sprite kame;
    // Use this for initialization
    void Start() {
        mainSpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void PopUpChara(string name)
    {
        switch (name)
        {
            case "datyo":
                mainSpriteRenderer.sprite = datyo;
                break;
            case "tokage":
                mainSpriteRenderer.sprite = tokage;
                break;
            case "momonga":
                mainSpriteRenderer.sprite = momonga;
                break;
            case "kame":
                mainSpriteRenderer.sprite = kame;
                break;
        }
    }
}

