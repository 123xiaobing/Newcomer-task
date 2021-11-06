using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject stopBtn;
    public GameObject continueBtn;

    public GameObject PlayerCollDisBtn;
    public GameObject PlayerCollAppBtn;

    public Image myImage;

    private GameObject m_sldR;
    private GameObject m_sldG;
    private GameObject m_sldB;
    private Slider m_sliderR;
    private Slider m_sliderG;
    private Slider m_sliderB;

    private void Start()
    {
        m_sldR = GameObject.Find("Canvas/ColorSliderR");
        m_sliderR = m_sldR.GetComponent<Slider>();
        m_sldG = GameObject.Find("Canvas/ColorSliderG");
        m_sliderG = m_sldG.GetComponent<Slider>();
        m_sldB = GameObject.Find("Canvas/ColorSliderB");
        m_sliderB = m_sldB.GetComponent<Slider>();
    }

    private void Update()
    {
        myImage.color = new Color(m_sliderR.value,m_sliderG.value, m_sliderB.value);
    }

   
    public void GameStop()
    {
        Time.timeScale = 0;
        stopBtn.SetActive(false);
        continueBtn.SetActive(true);
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        stopBtn.SetActive(true);
        continueBtn.SetActive(false);
    }

    public void PlayerCollDis()
    {
        if (PlayerControl.instance.coll.enabled)
            Debug.Log("玩家的碰撞体消失");
        PlayerControl.instance.coll.enabled = false;
        
    }

    public void PlayerCollApp()
    {
        if (!PlayerControl.instance.coll.enabled)
            Debug.Log("玩家的碰撞体恢复");
        PlayerControl.instance.coll.enabled = true;
        
    }
}
