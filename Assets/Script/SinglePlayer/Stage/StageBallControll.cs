using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StageBallController : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 lastVelocity;
    float deceleration = 2f;
    public GameObject StageStart;
    private StageGameManager stageGameManager;
    public GameObject LineBox;
    private bool hasbeenout = false;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        stageGameManager = FindObjectOfType<StageGameManager>();
    }

    private void Update()
    {
        if (!stageGameManager.isDragging)
        {
            Debug.Log("StageBallContrller에서 클릭 뗀것을 인지");
            rigid.velocity = StageGameManager.shotDirection * StageGameManager.shotDistance; // GameManager에서 값 가져와서 구체 발사
            stageGameManager.isDragging = true;
        }
        Move();
    }

    void Move()
    {
        lastVelocity = rigid.velocity;
        rigid.velocity -= rigid.velocity.normalized * deceleration * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasbeenout) return;
        if (collision.gameObject.tag == "StageDeadZone")
        {
            LineBox.SetActive(true);
            Debug.Log("대화창이 활성화 되었습니다");
            hasbeenout = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("빠져나가지 못하도록 위치 조절합니다");
        switch (collision.gameObject.tag)
        {
            case "StageDeadZone":
                rigid.velocity = Vector2.zero;
                break;
            case "Stage":
                StageStart.gameObject.SetActive(true);
                break;
            case "SDZ_Bottom":
                transform.Translate(0, 390, 0);
                break;
            case "SDZ_Top":
                transform.Translate(0, -390, 0);
                break;
            case "SDZ_Left":
                transform.Translate(470, 0, 0);
                break;
            case "SDZ_Right":
                transform.Translate(-470, 0, 0);
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stage")
            StageStart.gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.contacts != null && coll.contacts.Length > 0)
        {
            
            Vector2 dir = Vector2.Reflect(lastVelocity.normalized, coll.contacts[0].normal);
            if (rigid != null)
                rigid.velocity = dir * Mathf.Max(lastVelocity.magnitude, 0f); // 감속하지 않고 반사만 진행
        }
    }
}

