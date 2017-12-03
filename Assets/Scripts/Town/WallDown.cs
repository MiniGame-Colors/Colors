using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDown : MonoBehaviour
{

    public GameObject wall;
    public Transform secondFloor;
    public float topLength = 0.0f; // 高出二层平面的距离
    public float downTime = 8.0f;

    private bool canDown = false;
    private float initialWallTop;


    private void Start()
    {
        initialWallTop = wall.transform.position.y + wall.GetComponent<BoxCollider2D>().size.x / 2 * wall.transform.localScale.x;
    }

    void Update()
    {
        float wallTop = wall.transform.position.y + wall.GetComponent<BoxCollider2D>().size.x / 2 * wall.transform.localScale.x;
        if (canDown && wallTop - secondFloor.position.y > topLength)
        {
            wall.transform.Translate(-(initialWallTop - secondFloor.position.y) / (60 * downTime), 0, 0);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canDown = true;
        }
    }

    void OnTriggerExit(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canDown = false;
        }
    }
}
