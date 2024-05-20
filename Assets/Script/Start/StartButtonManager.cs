using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartButtonManager : MonoBehaviour
{
    public GameObject SinglePlaySetting;
    public Button SinglePlayer;
    public Button MultiPlayer;
    public Button OnlinePlay;
    public Button Setting;
    public Button Quit;

    public AudioSource ButtonAudio;

    private TextMeshProUGUI singlePlayerText;
    private TextMeshProUGUI onlinePlayText;

    private Coroutine resetSinglePlayerCoroutine;
    private Coroutine resetOnlinePlayCoroutine;

    void Start()
    {
        singlePlayerText = SinglePlayer.GetComponentInChildren<TextMeshProUGUI>();
        onlinePlayText = OnlinePlay.GetComponentInChildren<TextMeshProUGUI>();

        SinglePlayer.onClick.AddListener(OnSinglePlayerClicked);
        MultiPlayer.onClick.AddListener(OnMultiPlayerClicked);
        OnlinePlay.onClick.AddListener(OnOnlinePlayClicked);
        Setting.onClick.AddListener(OnSettingClicked);
        Quit.onClick.AddListener(OnQuitClicked);
    }

    void OnSinglePlayerClicked()
    {
        ButtonAudio.Play();
        SinglePlaySetting.gameObject.SetActive(true);
    }
    void OnMultiPlayerClicked()
    {
        ButtonAudio.Play();
        SceneManager.LoadScene("Main Scene");
    }

    void OnOnlinePlayClicked()
    {
        ButtonAudio.Play();
        if (resetOnlinePlayCoroutine != null)
            StopCoroutine(resetOnlinePlayCoroutine);

        onlinePlayText.text = "Coming Soon!";
        resetOnlinePlayCoroutine = StartCoroutine(ResetTextAfterDelay(onlinePlayText, "Online Play", 3f));
    }

    void OnSettingClicked()
    {
        ButtonAudio.Play();
        SceneManager.LoadScene("Setting Scene");
    }

    void OnQuitClicked()
    {
        ButtonAudio.Play();
        Application.Quit();
        Debug.Log("게임 종료!");
    }
    IEnumerator ResetTextAfterDelay(TextMeshProUGUI text, string originalText, float delay)
    {
        yield return new WaitForSeconds(delay);
        text.text = originalText;
    }
}