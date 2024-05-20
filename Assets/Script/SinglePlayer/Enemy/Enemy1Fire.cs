using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Fire : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public float MinPower;
    public float MaxPower;

    public void SpawnBullet()
    {
        GameObject bullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
        Vector2 shotDirection = -transform.up;
        float shotPower = Random.Range(MinPower, MaxPower);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = shotDirection * shotPower;
    }
}