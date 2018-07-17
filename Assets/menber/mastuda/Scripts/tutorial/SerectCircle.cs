using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerectCircle : MonoBehaviour {
    
    public void TutorialSerectCircle(float XScale,float YScale,float XPos,float YPos)
    {
        Vector2 pos = this.gameObject.transform.position;
        this.gameObject.transform.localPosition = new Vector2(pos.x = XPos,pos.y = YPos);
        Vector2 scale = this.gameObject.transform.localScale;
        this.gameObject.transform.localScale = new Vector2(scale.x = XScale, scale.y = YScale);
    }
}
