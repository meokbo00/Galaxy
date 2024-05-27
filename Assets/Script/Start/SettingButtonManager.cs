using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingButtonManager : MonoBehaviour
{
    public Button BGM_ON;
    public Button BGM_OFF;
    public Button Sound_Effect_ON;
    public Button Sound_Effect_OFF;
    public Button Credit;
    public Button Back;

    public AudioSource ButtonAudio;

    public static SettingButtonManager Instance = null;
    public bool isBGM = true;
    public bool isSoundEffect = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    void Start()
    {
        BGM_ON.onClick.AddListener(BGM_ONClicked);
        BGM_OFF.onClick.AddListener(BGM_OFFClicked);
        Sound_Effect_ON.onClick.AddListener(Sound_Effect_ONClicked);
        Sound_Effect_OFF.onClick.AddListener(Sound_Effect_OFFClicked);
        Credit.onClick.AddListener(CreditClicked);
        Back.onClick.AddListener(BackClicked);
    }
    void BGM_ONClicked()
    {
        this.isBGM = true;
        ButtonAudio.Play();
        BGM_ON.gameObject.SetActive(false);
        BGM_OFF.gameObject.SetActive(true);
    }
    void BGM_OFFClicked()
    {
        this.isBGM = false;
        ButtonAudio.Play();
        BGM_ON.gameObject.SetActive(true);
        BGM_OFF.gameObject.SetActive(false);
    }
    void Sound_Effect_ONClicked()
    {
        this.isSoundEffect = true;
        ButtonAudio.Play();
        Sound_Effect_ON.gameObject.SetActive(false);
        Sound_Effect_OFF.gameObject.SetActive(true);
    }
    void Sound_Effect_OFFClicked()
    {
        this.isSoundEffect = false;
        ButtonAudio.Play();
        Sound_Effect_ON.gameObject.SetActive(true);
        Sound_Effect_OFF.gameObject.SetActive(false);
    }
    void CreditClicked()
    {
        ButtonAudio.Play();
        SceneManager.LoadScene("Credit Scene");
    }
    void BackClicked()
    {
        ButtonAudio.Play();
        SceneManager.LoadScene("Start Scene");
    }
}
