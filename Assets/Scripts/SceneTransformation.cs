using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SceneTransformation : MonoBehaviour
{

    public Vector2 position;
    public float pausedTime;
    public Collider2D cameraMoveRange;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            StartCoroutine(ChangeScene());

        }
    }

    IEnumerator ChangeScene()
    {
        DataTransformer.enableInput = false;

        yield return new WaitForSeconds(pausedTime);

        DataTransformer.enableInput = true;

        player.position = new Vector3(position.x, position.y, player.position.z);


        if (cameraMoveRange)
        {
            GameObject CameraManager = GameObject.Find("CameraManager");
            Destroy(CameraManager.GetComponent<CinemachineConfiner>());
            CameraManager.AddComponent<CinemachineConfiner>().m_BoundingShape2D = cameraMoveRange;
            //CinemachineConfiner confiner = CameraManager.GetComponent<CinemachineConfiner>();
            //confiner.m_BoundingShape2D = cameraMoveRange;
        }

        DataTransformer.position = player.position;

    }
}
