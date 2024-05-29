using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class EnemySpawnData
{
    public string type;
    public float x;
    public float y;
}

public class EnemyData
{
    public int id;
    public List<EnemySpawnData> enemies;
}

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] Enemy;
    public TextAsset jsonFile;

    void Start()
    {
        if (jsonFile == null)
        {
            Debug.LogError("JSON file not set in the inspector.");
            return;
        }

        int stage = GlobalData.SelectedStage;
        string jsonData = jsonFile.text; // JSON 데이터를 TextAsset에서 가져옵니다.
        List<EnemyData> enemyDataList = JsonConvert.DeserializeObject<List<EnemyData>>(jsonData);

        if (enemyDataList == null)
        {
            Debug.LogError("Failed to deserialize JSON data.");
            return;
        }

        // 해당 stage의 데이터를 찾습니다.
        EnemyData data = enemyDataList.Find(d => d.id == stage);
        if (data != null)
        {
            if (data.enemies == null)
            {
                Debug.LogError("No enemies data found for the selected stage.");
                return;
            }

            foreach (var enemy in data.enemies)
            {
                if (!string.IsNullOrEmpty(enemy.type))
                {
                    InstantiateEnemy(enemy.type, enemy.x, enemy.y);
                }
            }
        }
        else
        {
            Debug.LogError("No data found for the selected stage.");
        }
    }

    void InstantiateEnemy(string enemyType, float x, float y)
    {
        int index = GetEnemyIndex(enemyType);
        if (index >= 0 && index < Enemy.Length)
        {
            Instantiate(Enemy[index], new Vector3(x, y, 0), Quaternion.identity);
        }
    }

    int GetEnemyIndex(string enemyType)
    {
        switch (enemyType)
        {
            case "Enemy1": return 0;
            case "Enemy2": return 1;
            case "Enemy3": return 2;
            case "Enemy4": return 3;
            case "Enemy5": return 4;
            case "Enemy6": return 5;
            case "Enemy7": return 6;
            default: return -1;
        }
    }
}