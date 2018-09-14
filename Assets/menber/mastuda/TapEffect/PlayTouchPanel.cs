using UnityEngine;
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
		Touch[] myTouches = Input.touches;
		//マルチタッチに対応する処理
		for (int i = 0; i < Input.touchCount; i++)
		{
			Vector3 ray = Input.touches[i].position;
			NewTapEffect(ray);
		}
    }
	/*
    void CheckTap()
    {
        Touch[] myTouches = Input.touches;
        //マルチタッチに対応する処理
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            NewTapEffect(ray);
        }
    }*/
    //タップエフェクトを出す
    void NewTapEffect(Vector2 pos)
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(pos);
        Object.Instantiate(mTapEffect, worldPos, Quaternion.identity, transform);
    }
}