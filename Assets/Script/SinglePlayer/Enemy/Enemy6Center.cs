using System.Collections;
using TMPro;
using UnityEngine;

public class Enemy6center : MonoBehaviour
{
    Rigidbody2D rigid;
    public float increase = 4f;
    public bool hasExpanded = false;
    public int randomNumber;
    private TextMeshPro textMesh;
    public Enemy1Fire[] enemy1Fires; // 여러 Enemy1Fire 참조를 위한 배열

    public int MaxHP;
    public int MinHP;
    public float MaxFireTime;
    public float MinFireTime;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        GameObject textObject = new GameObject("TextMeshPro");
        textObject.transform.parent = transform;
        textMesh = textObject.AddComponent<TextMeshPro>();
        randomNumber = Random.Range(MinHP, MaxHP);
        textMesh.text = randomNumber.ToString();
        textMesh.fontSize = 6;
        textMesh.alignment = TextAlignmentOptions.Center;
        textMesh.autoSizeTextContainer = true;
        textMesh.rectTransform.localPosition = Vector3.zero;
        textMesh.sortingOrder = 3;

        enemy1Fires = GetComponentsInChildren<Enemy1Fire>(); // Enemy1Fire 컴포넌트 배열 참조

        StartCoroutine(RotateObject());
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "P1ball" || coll.gameObject.tag == "P2ball" || coll.gameObject.tag == "P1Item" || coll.gameObject.tag == "P2Item")
        {
            if (randomNumber > 0)
            {
                randomNumber--;
                textMesh.text = randomNumber.ToString();
            }
            if (randomNumber <= 0)
            {
                Destroy(transform.parent.gameObject); // 부모 오브젝트 삭제
            }
        }
    }

    private IEnumerator RotateObject()
    {
        while (true)
        {
            // 5초 동안 정지
            yield return new WaitForSeconds(Random.Range(MinFireTime, MaxFireTime));

            if (enemy1Fires != null)
            {
                foreach (var enemy1Fire in enemy1Fires)
                {
                    enemy1Fire.SpawnBullet();
                }
            }
        }
    }
}