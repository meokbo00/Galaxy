using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageGoBtn : MonoBehaviour
{
    public Button GoBtn;

    private void Start()
    {
        this.GoBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Story-InGame");
        });
    }
}
