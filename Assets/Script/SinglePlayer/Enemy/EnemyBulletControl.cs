using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 lastVelocity;
    float deceleration = 2f;
    public float increase = 4f;
    private bool iscolliding = false;
    public bool hasExpanded = false;
    private bool isStopped = false;
    private int randomNumber;
    private TextMeshPro textMesh;
    private bool hasBeenReleased = false;
    private float rotationAngle = 0f; // 회전 각도를 저장할 변수

    public float fontsize;
    public int BallMinHP = 1;
    public int BallMaxHP = 6;
    //public AudioSource HitSound;
    //public AudioSource SwellSound;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        GameObject textObject = new GameObject("TextMeshPro");
        textObject.transform.parent = transform;
        textMesh = textObject.AddComponent<TextMeshPro>();
        randomNumber = Random.Range(BallMinHP, BallMaxHP);
        textMesh.text = randomNumber.ToString();
        textMesh.fontSize = fontsize;
        textMesh.alignment = TextAlignmentOptions.Center;
        textMesh.autoSizeTextContainer = true;
        textMesh.rectTransform.localPosition = Vector3.zero;
        textMesh.sortingOrder = 1;
    }

    private void Update()
    {
        Move();
        expand();
    }

    public void SetRotationAngle(float angle)
    {
        rotationAngle = angle;
    }

    void Move()
    {
        if (rigid == null || isStopped) return;

        lastVelocity = rigid.velocity;
        rigid.velocity -= rigid.velocity.normalized * deceleration * Time.deltaTime;

        if (rigid.velocity.magnitude <= 0.01f && hasExpanded)
        {
            isStopped = true;
            StartCoroutine(DestroyRigidbodyDelayed());
        }
    }

    void expand()
    {
        if (rigid == null || iscolliding) return;
        if (rigid.velocity.magnitude > 0.1f) return;
        if (Input.GetMouseButton(0)) return;

        //if (!hasExpanded)
        //{
        //    SwellSound.Play();
        //}
        transform.localScale += Vector3.one * increase * Time.deltaTime;
        hasExpanded = true;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //if (!hasExpanded)
        //{
        //    HitSound.Play();
        //}
        if ((coll.gameObject.tag == "P1ball" || coll.gameObject.tag == "P2ball" || coll.gameObject.tag == "P1Item" || coll.gameObject.tag == "P2Item" || coll.gameObject.tag == "EnemyBall") && rigid == null)
        {
            if (randomNumber > 0)
            {
                randomNumber--;
                textMesh.text = randomNumber.ToString();
            }
            if (randomNumber <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (coll.contacts != null && coll.contacts.Length > 0)
        {
            Vector2 dir = Vector2.Reflect(lastVelocity.normalized, coll.contacts[0].normal);
            if (rigid != null)
                rigid.velocity = dir * Mathf.Max(lastVelocity.magnitude, 0f); // 벡터 값이 음수가 되지 않게 함
        }
        this.iscolliding = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        this.iscolliding = false;
    }

    IEnumerator DestroyRigidbodyDelayed()
    {
        yield return new WaitForSeconds(0.8f);
        if (rigid != null)
            Destroy(rigid);
    }
}