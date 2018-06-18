using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScinarioChara : MonoBehaviour {
    
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
        string charaName = CharaName(name);
        switch (charaName)
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
    private string CharaName(string name)
    {

        switch (name)
        {
            case "トカゲ":
                name = "tokage";
                break;
            case "ダチョウ":
                name = "datyo";
                break;
            case "モモンガ":
                name = "momonga";
                break;
            case "カメ":
                name = "kame";
                break;
        }
        return name;
    }
}

