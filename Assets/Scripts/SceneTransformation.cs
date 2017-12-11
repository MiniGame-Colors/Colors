using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SceneTransformation : MonoBehaviour
{

    public Transform targetPlace;
    public float pausedTime;
    public Collider2D cameraMoveRange;

    private Transform player;
    private PlayerController playerCtrl;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerCtrl = player.gameObject.GetComponent<PlayerController>();
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{

    //    if (other.CompareTag("Player"))
    //    {

    //        StartCoroutine(ChangeScene());

    //    }
    //}

    public IEnumerator ChangeScene()
    {
        playerCtrl.enableInput = false;

        yield return new WaitForSeconds(pausedTime);

        playerCtrl.enableInput = true;

        player.position = new Vector3(targetPlace.position.x, targetPlace.position.y, player.position.z);


        if (cameraMoveRange)
        {
            GameObject CameraManager = GameObject.Find("CameraManager");
            Destroy(CameraManager.GetComponent<CinemachineConfiner>());
            CameraManager.AddComponent<CinemachineConfiner>().m_BoundingShape2D = cameraMoveRange;
        }

        playerCtrl.position = player.position;
    }
}
