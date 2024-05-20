// 문서 내에 있는 모든 적들을 생성하는 스크립트

//using System.Collections.Generic;
//using UnityEngine;
//using Newtonsoft.Json;
//class Data
//{
//    public int id;
//    public float x;
//    public float y;
//}
//public class Insenemy : MonoBehaviour
//{
//    public GameObject enemyball;
//    public int stage;

//    void Start()
//    {
//        var asset = Resources.Load<TextAsset>("enemy");
//        var json = asset.text;
//        var datas = JsonConvert.DeserializeObject<List<Data>>(json);
//        foreach (var data in datas)
//        {
//            Debug.LogFormat("{0}, {1}, {2}", data.id, data.x, data.y);
//            Instantiate(enemyball, new Vector3(data.x, data.y, 0), Quaternion.identity);
//        }
//    }
//}

// 만약 다른 코드에서 stage의 값을 변형시키고 싶다면

//using UnityEngine;

//public class OtherScript : MonoBehaviour
//{
//    // Insenemy 스크립트 참조
//    public Insenemy insenemyScript;

//    void Start()
//    {
//        // Insenemy 스크립트의 stage 값을 설정
//        insenemyScript.stage = 2; // 예시로 2를 설정하면 stage가 2인 적만 생성됩니다.
//    }
//}
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
    public GameObject enemyball;
    public int stage = 1;

    void Start()
    {
        // 스테이지에 해당하는 ID 계산

        var asset = Resources.Load<TextAsset>("enemy");
        var json = asset.text;
        var datas = JsonConvert.DeserializeObject<List<Data>>(json);
        foreach (var data in datas)
        {
            // 현재 스테이지에 해당하는 ID만 생성
            if (data.id == stage)
            {
                Debug.LogFormat("{0}, {1}, {2}", data.id, data.x, data.y);
                Instantiate(enemyball, new Vector3(data.x, data.y, 0), Quaternion.identity);
            }
        }
    }
}