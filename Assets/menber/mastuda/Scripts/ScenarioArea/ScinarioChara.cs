using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScinarioChara : MonoBehaviour {

    Image image;
    SpriteRenderer mainSpriteRenderer;
    public Sprite datyo;
    public Sprite tokage;
    public Sprite momonga;
    public Sprite kame;
    // Use this for initialization
    void Start() {
        image = this.GetComponent<Image>();
        //mainSpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void PopUpChara(string name)
    {
        string charaName = CharaName(name);
        switch (charaName)
        {
            case "datyo":
                image.color = new Color(1, 1, 1, 1);
                image.sprite = datyo;
                //mainSpriteRenderer.sprite = datyo;
                break;
            case "tokage":
                image.color = new Color(1, 1, 1, 1);
                image.sprite = tokage;
                //mainSpriteRenderer.sprite = tokage;
                break;
            case "momonga":
                image.color = new Color(1, 1, 1, 1);
                image.sprite = momonga;
                //mainSpriteRenderer.sprite = momonga;
                break;
            case "kame":
                image.color = new Color(1, 1, 1, 1);
                image.sprite = kame;
                //mainSpriteRenderer.sprite = kame;
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

