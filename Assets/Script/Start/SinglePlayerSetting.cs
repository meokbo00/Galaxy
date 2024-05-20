using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SinglePlayerSetting : MonoBehaviour
{
    public GameObject SinglePlaySetting;
    public Image FadeIn;
    public Button X;
    public Button NewBtn;
    public Button ContinueBtn;
    public Button EndlessBtn;

    private bool fadeInComplete = false;

    void Start()
    {
        this.X.onClick.AddListener(() =>
        {
            SinglePlaySetting.SetActive(false);
        });
        this.NewBtn.onClick.AddListener(() =>
        {
            StartCoroutine(FadeInAndLoadScene());
        });
        this.ContinueBtn.onClick.AddListener(() =>
        {

        });
        this.EndlessBtn.onClick.AddListener(() =>
        {

        });
    }

    IEnumerator FadeInAndLoadScene()
    {
        FadeIn.gameObject.SetActive(true);
        Color originalColor = FadeIn.color;
        while (FadeIn.color.a < 1)
        {
            float newAlpha = FadeIn.color.a + Time.deltaTime/3;
            FadeIn.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
            yield return null;
        }
        fadeInComplete = true;
        if (fadeInComplete)
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("Prologue");
        }
    }
}