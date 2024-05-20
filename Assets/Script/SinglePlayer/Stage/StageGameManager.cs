using System;
using UnityEngine;

public class StageGameManager : MonoBehaviour
{
    private Vector3 clickPosition;
    public bool isDragging = false;
    public static float shotDistance;
    public static Vector3 shotDirection;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0f;
            Collider2D[] colliders = Physics2D.OverlapPointAll(clickPosition);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("StageBall"))
                {
                    isDragging = true;
                    break;
                }
            }
        }

        if (isDragging && Input.GetMouseButtonUp(0))
        {
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0f;
            shotDistance = Vector3.Distance(clickPosition, currentPosition);
            Vector3 dragDirection = (currentPosition - clickPosition).normalized;
            shotDirection = -dragDirection;
            isDragging = false;
            Debug.Log(shotDistance);
            Debug.Log(shotDirection);
        }
    }
}