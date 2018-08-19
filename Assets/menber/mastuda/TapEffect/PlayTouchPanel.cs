﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayTouchPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject mTapEffect;

    public void OnPointerDown(PointerEventData eventData)
    {
        //マウスクリック時
        NewTapEffect(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
    }


    void Update()
    {
        //タップ時
        CheckTap();
    }

    void CheckTap()
    {
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
            {

                Vector3 ray = Camera.main.WorldToScreenPoint(t.position);
                NewTapEffect(ray);
            }
        }
    }

    //タップエフェクトを出す
    void NewTapEffect(Vector2 pos)
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(pos);
        Object.Instantiate(mTapEffect, worldPos, Quaternion.identity, transform);
    }
}