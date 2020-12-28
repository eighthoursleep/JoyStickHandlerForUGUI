using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class JoyStickHandler : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    [SerializeField]
    private RectTransform joyStickBG;
    [SerializeField]
    private RectTransform joyStickCenter;
    private Vector2 originPos;
    private Vector2 targetPos;
    private Vector2 targetDir;
    private Vector2 joyStickCenterMoveDir;
    private float mRadius = 10;
    private float offset;
    private float ratio;
    private float Horizontal = 0;
    private float Vertical = 0;

    private void Start()
    {
        targetDir = new Vector2();
        originPos = joyStickBG.position;
        targetPos = originPos;
        mRadius = (joyStickBG.rect.width - joyStickCenter.rect.width) / 2;
    }

    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        OnEndDrag(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("eventData.position:" + eventData.position + ", joyStickBG.position:" + joyStickBG.position);
        targetDir = eventData.position - originPos;
        ratio =(targetDir.magnitude > mRadius)?(mRadius / targetDir.magnitude):1;
        targetDir.x *= ratio;
        targetDir.y *= ratio;
        //Debug.Log("targetDir:"+ targetDir);
        joyStickCenter.position = originPos + targetDir;
        Horizontal = targetDir.x / mRadius;
        Vertical = targetDir.y / mRadius;
        Debug.Log("Horizontal" + Horizontal + ", Vertical" + Vertical);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        joyStickCenter.transform.position = originPos;
    }
}
