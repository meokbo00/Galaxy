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
        ButtonAudio.Play();
        BGM_ON.gameObject.SetActive(false);
        BGM_OFF.gameObject.SetActive(true);
    }
    void BGM_OFFClicked()
    {
        ButtonAudio.Play();
        BGM_ON.gameObject.SetActive(true);
        BGM_OFF.gameObject.SetActive(false);
    }
    void Sound_Effect_ONClicked()
    {
        ButtonAudio.Play();
        Sound_Effect_ON.gameObject.SetActive(false );
        Sound_Effect_OFF.gameObject.SetActive (true );
    }
    void Sound_Effect_OFFClicked()
    {
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
