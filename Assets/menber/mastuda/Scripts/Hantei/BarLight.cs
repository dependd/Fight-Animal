using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarLight : MonoBehaviour {
    [SerializeField]
    Sprite lightImages;
    [SerializeField]
    Sprite NoteImage;
    Image image;
    
    // Use this for initialization
    void Start () {
        image = this.GetComponent<Image>();
	}

    public void ChengeSprite(bool enter)
    {
        if (enter)
        {
            image.sprite = lightImages;
        }
        else
        {
            image.sprite = NoteImage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        image.sprite = lightImages;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        image.sprite = NoteImage;
    }
}
