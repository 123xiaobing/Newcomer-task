using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterGame : MonoBehaviour
{
    private InputField inputAccount;
    private InputField inputPassword;
    public GameObject enterMenu;
    private GameObject m_welcomeImage;
    private Scrollbar m_scrollbar;

    private void Start()
    {
        m_welcomeImage = GameObject.Find("Canvas/WelcomeImage");
        m_scrollbar = GameObject.Find("Canvas/WelcomeImage/Scrollbar").GetComponent<Scrollbar>();
        m_scrollbar.value = 1;
    }

    public void ShowEnterMenu()
    {
        enterMenu.SetActive(true);
        m_welcomeImage.SetActive(false);
    }

    public void Show()
    {
        if (enterMenu.activeSelf == true)
        {
            inputAccount = GameObject.Find("Canvas/EnterMenu/InputFieldAccount").GetComponent<InputField>();
            inputPassword = GameObject.Find("Canvas/EnterMenu/InputFieldPassword").GetComponent<InputField>();

        }
        print("您的账号是:" + inputAccount.text);
        print("您的密码是:" + inputPassword.text);
    }

    public void Enter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Delete()
    {
        if (enterMenu.activeSelf == true)
        {
            inputAccount = GameObject.Find("Canvas/EnterMenu/InputFieldAccount").GetComponent<InputField>();
            inputPassword = GameObject.Find("Canvas/EnterMenu/InputFieldPassword").GetComponent<InputField>();

        }
        inputAccount.text = null;
        inputPassword.text = null;
    }

}
