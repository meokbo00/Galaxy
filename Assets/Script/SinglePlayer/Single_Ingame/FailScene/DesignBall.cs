using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingSphere : MonoBehaviour
{
    public float speed = 20f;
    public float moveDuration = 0.1f; // 이동 시간
    private Vector2 moveDirection;
    private float moveTimer = 0f;

    private void Start()
    {
        // 초기 이동 방향 설정
        SetRandomDirection();
    }

    private void Update()
    {
        // 이동 타이머 업데이트
        moveTimer += Time.deltaTime;

        // 주어진 방향으로 일정 시간 동안 이동
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // 이동 시간이 지나면 새로운 방향을 설정
        if (moveTimer >= moveDuration)
        {
            SetRandomDirection();
            moveTimer = 0f; // 타이머 초기화
        }
    }

    private void OnMouseDown()
    {
        // 클릭되면 Stage 씬으로 전환
        SceneManager.LoadScene("Stage");
    }

    // 무작위 이동 방향을 설정하는 함수
    private void SetRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f); // 0도에서 360도 사이의 무작위 각도
        moveDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.right; // 각도를 벡터로 변환하여 이동 방향으로 설정
    }
}