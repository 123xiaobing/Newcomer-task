using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler,IScrollHandler
{
    private Image image;

    public Sprite[] sprites;

    private float speed=0.1f;

    private RectTransform rectTransform;

    Button resetBtn;
    private void Start()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        resetBtn = GameObject.Find("Canvas/Button").GetComponent<Button>();
        resetBtn.onClick.AddListener(ResetPicScale);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        image.sprite = sprites[3];
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        image.sprite = sprites[2];
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = sprites[1];
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = sprites[0];
    }

    public void OnScroll(PointerEventData eventData)
    {
        if (rectTransform.localScale.x>=0.1f) {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
                rectTransform.localScale = new Vector3(rectTransform.localScale.x + speed, rectTransform.localScale.y + speed, rectTransform.localScale.z + speed);
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
                rectTransform.localScale = new Vector3(rectTransform.localScale.x - speed, rectTransform.localScale.y - speed, rectTransform.localScale.z - speed);
        } 
        
        if(rectTransform.localScale.x <0.1f)
            rectTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

    }

    public void ResetPicScale()
    {
        rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

}
