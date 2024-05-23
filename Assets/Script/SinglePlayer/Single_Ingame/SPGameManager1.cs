using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SPGameManager : MonoBehaviour
{
    public GameObject P1ballPrefab;
    public GameObject[] FireItemPrefab;

    public GameObject P1firezone;
    public GameObject P1Itemsave;

    public GameObject fireitem;

    private Vector3 clickPosition;
    public bool isDragging = false;
    public static float shotDistance;
    public static Vector3 shotDirection;

    //public bool P1FireMode = true;
    private void Start()
    {
        P1firezone.gameObject.SetActive(true);
    }
    public void PrintDestroyedicontag(string icontag)
    {
        this.fireitem = null;
        switch (icontag)
        {
            case "Item_BlackHole": fireitem = FireItemPrefab[0];break;
            case "Item_Durability":fireitem = FireItemPrefab[1];break;
            case "Item_Fasten":fireitem = FireItemPrefab[2];break;
            case "Item_Force":fireitem = FireItemPrefab[3];break;
            case "Item_Invincible":fireitem = FireItemPrefab[4];break;
            case "Item_Random_number":fireitem = FireItemPrefab[5];break;
            case "Item_Reduction":fireitem = FireItemPrefab[6];break;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0f;
            Collider2D[] colliders = Physics2D.OverlapPointAll(clickPosition);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject == P1firezone)
                {
                    if (fireitem != null)
                    {
                        //fireitem.gameObject.tag = "P1Item";
                        Instantiate(fireitem, clickPosition, Quaternion.identity);
                        Debug.Log("P1이 아이템을 사용하였습니다");
                        Debug.Log("아이템의 이름은 " + fireitem.gameObject.name + "입니다");
                        //P1FireMode = false;
                        isDragging = true;
                        fireitem = null;
                        break;
                    }
                    else
                    {
                        Instantiate(P1ballPrefab, clickPosition, Quaternion.identity);
                        Debug.Log("P1이 기본구체를 날렸습니다");
                        //P1FireMode = false;
                        isDragging = true;
                        break;
                    }
                }
            }
        }

        if (isDragging && Input.GetMouseButtonUp(0))
        {
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0f;
            GameManager.shotDistance = Vector3.Distance(clickPosition, currentPosition);
            Vector3 dragDirection = (currentPosition - clickPosition).normalized;
            GameManager.shotDirection = -dragDirection;
            isDragging = false;
        }

        int totalBalls = GameObject.FindGameObjectsWithTag("EnemyBall").Length +
                       GameObject.FindGameObjectsWithTag("P1ball").Length;
        if (totalBalls > 12)
        {
            Debug.Log("총알의 개수 총합이 12개를 넘겼습니다");
            SceneManager.LoadScene("Fail");
        }
    }

}