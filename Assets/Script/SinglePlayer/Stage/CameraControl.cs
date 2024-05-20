using UnityEngine;

public class CameraControl : MonoBehaviour 
{
    GameObject player;
    public RectTransform stage1RectTransform;
    public Camera mainCamera;

    void Start()
    {
        this.player = GameObject.Find("Player");
    }
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y+5, transform.position.z);
    }
}