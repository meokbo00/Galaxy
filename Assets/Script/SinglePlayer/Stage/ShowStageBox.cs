using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowStageBox : MonoBehaviour
{
    public TextAsset stageDataFile;
    public TextMeshProUGUI stageTitleText;
    public TextMeshProUGUI stageExplainText;

    public class Stage
    {
        public int id;
        public string StageTitle;
        public string StageDetail;
    }

    private List<Stage> stages;

    void Start()
    {
        stages = JsonConvert.DeserializeObject<List<Stage>>(stageDataFile.text);
    }

    public void UpdateStageInfo(int chooseStage)
    {
        Stage selectedStage = stages.Find(stage => stage.id == chooseStage);
        if (selectedStage != null)
        {
            stageTitleText.text = selectedStage.StageTitle;
            stageExplainText.text = selectedStage.StageDetail;
            Debug.Log($"Stage {chooseStage} 정보가 업데이트되었습니다: {selectedStage.StageTitle} - {selectedStage.StageDetail}");
        }
        else
        {
            Debug.LogWarning($"Stage {chooseStage} 정보를 찾을 수 없습니다.");
        }
    }
}
