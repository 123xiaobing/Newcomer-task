using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PageControl : MonoBehaviour
{
    private ScrollRect scrollRect;
    
    private RectTransform contentRt;
    Button nextBtn;
    Button lastBtn;
    Button picBtn1;
    Button picBtn2;
    Button picBtn3;
    Button picBtn4;
    //577一张
    public Image[] images; 

    private int num;//图片数量

    private int CurrentNum=0;//当前滚到的数量

    float thisPos=0;
    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        num = scrollRect.content.childCount;
        contentRt = GameObject.Find("Canvas/Scroll View/Viewport/Content").GetComponent<RectTransform>();

        nextBtn = GameObject.Find("Canvas/NextBtn").GetComponent<Button>();
        lastBtn = GameObject.Find("Canvas/LastBtn").GetComponent<Button>();
        picBtn1 = GameObject.Find("Canvas/NextBtnPoint1").GetComponent<Button>();
        picBtn2 = GameObject.Find("Canvas/NextBtnPoint2").GetComponent<Button>();
        picBtn3 = GameObject.Find("Canvas/NextBtnPoint3").GetComponent<Button>();
        picBtn4 = GameObject.Find("Canvas/NextBtnPoint4").GetComponent<Button>();
        
        nextBtn.onClick.AddListener(NextPicCahnge);
        lastBtn.onClick.AddListener(LastPicChange);
        picBtn1.onClick.AddListener(ChangeToPic_1);
        picBtn2.onClick.AddListener(ChangeToPic_2);
        picBtn3.onClick.AddListener(ChangeToPic_3);
        picBtn4.onClick.AddListener(ChangeToPic_4);

        images[0].color = new Color(0.2f, 0.2f, 0.2f);
    }
    void LastPicChange()
    {
        StopCoroutine(_LastPicChange());
        StartCoroutine(_LastPicChange());

    }

    IEnumerator _LastPicChange()
    {
        while(contentRt.offsetMin.x < thisPos+577&&CurrentNum>0)
        {

            contentRt.offsetMin = new Vector2(0.577f,0)+ contentRt.offsetMin;

            yield return new WaitForSeconds(0.001f);
        }

        if(CurrentNum>0)
        {
            thisPos += 577f;
            CurrentNum--;
            Debug.Log(CurrentNum);
            for(int i=0;i<images.Length;i++)
            {
                images[i].color = new Color(1, 1, 1);
            }
            images[CurrentNum].color = new Color(0.2f, 0.2f, 0.2f);
        }
    }

    void NextPicCahnge()
    {
        StopCoroutine(_NextPicChange());
        StartCoroutine(_NextPicChange());
    }
    IEnumerator _NextPicChange()
    {
        
        while(contentRt.offsetMin.x> thisPos - 577 && CurrentNum < num - 1)
        {
            
            contentRt.offsetMin = new Vector2(-0.577f, 0) + contentRt.offsetMin;
            
            yield return new WaitForSeconds(0.001f);
        }
        if (CurrentNum<num-1)
        {
            thisPos -= 577;
            CurrentNum++;
            Debug.Log(CurrentNum);
            for (int i = 0; i < images.Length; i++)
            {
                images[i].color = new Color(1, 1, 1);
            }
            images[CurrentNum].color = new Color(0.2f, 0.2f, 0.2f);
        }
    }


    private void ChangeToPic_1()
    {
        StopCoroutine(_ChangeTo1());
        StartCoroutine(_ChangeTo1());
    }
    IEnumerator _ChangeTo1()
    {
        while (contentRt.offsetMin.x<0)
        {
            contentRt.offsetMin = new Vector2(((CurrentNum - 0) * 577f) / 1000, 0) + contentRt.offsetMin;
            
            yield return new WaitForSeconds(0.0001f);
        }
        CurrentNum = 0;
        Debug.Log(CurrentNum);
        thisPos = -577*0;
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = new Color(1, 1, 1);
        }
        images[CurrentNum].color = new Color(0.2f, 0.2f, 0.2f);
    }
    private void ChangeToPic_2()
    {
        StopCoroutine(_ChangeTo2());
        StartCoroutine(_ChangeTo2());
    }

    IEnumerator _ChangeTo2()
    {
        while (contentRt.offsetMin.x > -577 + 5 || contentRt.offsetMin.x < -577 - 5)
        {
            contentRt.offsetMin=new Vector2(((CurrentNum - 1) * 577f) / 1000,0)+contentRt.offsetMin;
            //scrollbar.value += -((CurrentNum - 1) * 2285.5f) / 1000;
            yield return new WaitForSeconds(0.0001f);
        }

        CurrentNum = 1;
        Debug.Log(CurrentNum);
        thisPos = -577 * 1;
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = new Color(1, 1, 1);
        }
        images[CurrentNum].color = new Color(0.2f, 0.2f, 0.2f);
    }
    private void ChangeToPic_3()
    {
        StopCoroutine(_ChangeTo3());
        StartCoroutine(_ChangeTo3());
    }

    IEnumerator _ChangeTo3()
    {
        while (contentRt.offsetMin.x > -577 * 2 + 5 || contentRt.offsetMin.x < -577f * 2-5)
        {
            contentRt.offsetMin = new Vector2(((CurrentNum - 2) * 577f) / 1000, 0) + contentRt.offsetMin;
            //scrollbar.value += -((CurrentNum - 2) * 2285.5f) / 1000;
            yield return new WaitForSeconds(0.0001f);
        }

        CurrentNum = 2;
        Debug.Log(CurrentNum);
        thisPos = -577 * 2;
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = new Color(1, 1, 1);
        }
        images[CurrentNum].color = new Color(0.2f, 0.2f, 0.2f);
    }
    private void ChangeToPic_4()
    {
        StopCoroutine(_ChangeTo4());
        StartCoroutine(_ChangeTo4());
    }

    IEnumerator _ChangeTo4()
    {
        while (contentRt.offsetMin.x > -577 * 3f)
        {
            contentRt.offsetMin = new Vector2(((CurrentNum - 3) * 577f) / 1000, 0) + contentRt.offsetMin;
            //scrollbar.value += -((CurrentNum - 3) * 2285.5f) / 1000;
            yield return new WaitForSeconds(0.0001f);
        }

        CurrentNum = 3;
        Debug.Log(CurrentNum);
        thisPos = -577 * 3;
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = new Color(1, 1, 1);
        }
        images[CurrentNum].color = new Color(0.2f, 0.2f, 0.2f);
    }

}
