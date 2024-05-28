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
            // 씬을 로드하기 전에 chooseStage 값을 저장
            GlobalData.SelectedStage = StageBallController.chooseStage;
            SceneManager.LoadScene("Story-InGame");
        });
    }
}

public static class GlobalData
{
    public static int SelectedStage;
}