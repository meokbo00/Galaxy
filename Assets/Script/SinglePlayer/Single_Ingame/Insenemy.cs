using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

class Data
{
    public int id;
    public float x;
    public float y;
}

public class Insenemy : MonoBehaviour
{
    //public TextAsset EnemySpawnData;
    //public GameObject Enemy1;

    void Start()
    {
        // stage 변수에 GlobalData.SelectedStage 값을 할당
        int stage = GlobalData.SelectedStage;
        //var asset = Resources.Load<TextAsset>("enemy");
        //var json = asset.text;
        //var datas = JsonConvert.DeserializeObject<List<Data>>(json);
        //foreach (var data in datas)
        //{
        //    if (data.id == stage)
        //    {
        //        Debug.LogFormat("{0}, {1}, {2}", data.id, data.x, data.y);
        //        Instantiate(Enemy1, new Vector3(data.x, data.y, 0), Quaternion.identity);
        //    }
        //}
    }
    private void Update()
    {
        int stage = GlobalData.SelectedStage;
        Debug.Log(stage + "이지롱");
    }
}