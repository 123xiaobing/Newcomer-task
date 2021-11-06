using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Final : MonoBehaviour
{
    private ScrollRect scrollRect;
    private Scrollbar scrollbar;
    Button nextBtn;
    Button lastBtn;
    Button picBtn1;
    Button picBtn2;
    Button picBtn3;
    Button picBtn4;

    public Image[] backgrounds;

    public Image[] images;

    private int num;//图片数量

    private int CurrentNum = 0;//当前滚到的数量

    float thisPos = 0;
    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        scrollbar = GameObject.Find("Canvas/Scroll View/Scrollbar").GetComponent<Scrollbar>();
        num = scrollRect.content.childCount;
        scrollbar.value = 0f;

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
        while (scrollRect.transform.position.x>backgrounds[CurrentNum].transform.position.x)
        {
            scrollRect.transform.position=new Vector3(backgrounds[CurrentNum].transform.position.x,scrollRect.transform.position.y,scrollRect.transform.position.z);
            yield return new WaitForSeconds(0.0001f);
        }

        if (CurrentNum > 0)
        {
            thisPos -= 2285.5f;
            CurrentNum--;
            Debug.Log(CurrentNum);
            for (int i = 0; i < images.Length; i++)
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

        while (scrollRect.transform.position.x < backgrounds[CurrentNum].transform.position.x)
        {
            scrollRect.transform.position = new Vector3(backgrounds[CurrentNum].transform.position.x, scrollRect.transform.position.y, scrollRect.transform.position.z);
            yield return new WaitForSeconds(0.0001f);
        }
        if (CurrentNum < num - 1)
        {
            thisPos += 2285.5f;
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
        while (scrollbar.value > 0)
        {
            scrollbar.value += -((CurrentNum - 0) * 2285.5f) / 1000;
            yield return new WaitForSeconds(0.0001f);
        }
        CurrentNum = 0;
        Debug.Log(CurrentNum);
        thisPos = 2285.5f * 0;
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
        while (scrollbar.value < 2285.5 - 5 || scrollbar.value > 2285.5 + 5)
        {
            scrollbar.value += -((CurrentNum - 1) * 2285.5f) / 1000;
            yield return new WaitForSeconds(0.0001f);
        }

        CurrentNum = 1;
        Debug.Log(CurrentNum);
        thisPos = 2285.5f * 1;
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
        while (scrollbar.value < 2285.5 * 2 - 5 || scrollbar.value > 2285.5 * 2 + 5)
        {
            scrollbar.value += -((CurrentNum - 2) * 2285.5f) / 1000;
            yield return new WaitForSeconds(0.0001f);
        }

        CurrentNum = 2;
        Debug.Log(CurrentNum);
        thisPos = 2285.5f * 2;
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
        while (scrollbar.value < 2285.5 * 3f)
        {
            scrollbar.value += -((CurrentNum - 3) * 2285.5f) / 1000;
            yield return new WaitForSeconds(0.0001f);
        }

        CurrentNum = 3;
        Debug.Log(CurrentNum);
        thisPos = 2285.5f * 3;
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = new Color(1, 1, 1);
        }
        images[CurrentNum].color = new Color(0.2f, 0.2f, 0.2f);
    }

}
