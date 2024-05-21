using System.Collections;
using TMPro;
using UnityEngine;

public class Enemy6LegControl : MonoBehaviour
{
    public float moveSpeed = 1f;  // 이동 속도
    public float rotationSpeed = 180f;  // 회전 속도
    private TextMeshPro textMesh;

    private Transform parentTransform;

    private void Start()
    {
        parentTransform = transform.parent;  // 상위 오브젝트의 Transform을 참조
        StartCoroutine(MoveAndRotate());
    }

    private IEnumerator MoveAndRotate()
    {
        while (true)
        {
            float targetAngle = Random.Range(-70f, 70f);
            float currentAngle = parentTransform.eulerAngles.z;  // 상위 오브젝트의 현재 각도
            float rotationTime = Mathf.Abs(targetAngle - currentAngle) / rotationSpeed;
            float elapsedTime = 0f;

            while (elapsedTime < rotationTime)
            {
                elapsedTime += Time.deltaTime;
                float angle = Mathf.LerpAngle(currentAngle, targetAngle, elapsedTime / rotationTime);
                parentTransform.eulerAngles = new Vector3(0, 0, angle);
                yield return null;
            }

            // 이동할 방향 벡터 계산 (바라보고 있는 방향으로 이동)
            Vector3 moveDirection = Random.Range(0, 2) == 0 ? -parentTransform.up : parentTransform.up;  // 부모 오브젝트의 위쪽 방향 또는 아래쪽 방향 중 랜덤으로 선택

            // 1.5~2.5초 동안 이동
            float moveTime = Random.Range(1.5f, 2.5f);
            elapsedTime = 0f;

            while (elapsedTime < moveTime)
            {
                elapsedTime += Time.deltaTime;
                parentTransform.position += moveDirection * moveSpeed * Time.deltaTime;
                yield return null;
            }

            // 1~5초 동안 정지 상태로 대기
            float waitTime = Random.Range(2f, 3f);
            yield return new WaitForSeconds(waitTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy6center enemy6Center = GetComponent<Enemy6center>();

        if (collision.gameObject.tag == "P1ball" || collision.gameObject.tag == "P2ball" || collision.gameObject.tag == "P1Item" || collision.gameObject.tag == "P2Item")
        {
            if (enemy6Center.randomNumber > 0)
            {
                enemy6Center.randomNumber--;
                textMesh.text = enemy6Center.randomNumber.ToString();
            }
            if (enemy6Center.randomNumber <= 0)
            {
                Destroy(transform.parent.gameObject); // 부모 오브젝트 삭제
            }
        }
    }
}