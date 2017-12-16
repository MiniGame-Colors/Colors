using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bridge : MonoBehaviour {

    public float gravityScale = 0.1f;
    public float pausedTime = 4f;
    public Vector3 brigdePos;

    private Vector3 playerPos;
    private GameObject mainCam;
    private CinemachineVirtualCamera cam;

    private GameObject higherDoor;

    private void Awake() {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        cam = GameObject.Find("CameraManager").GetComponent<CinemachineVirtualCamera>();

        higherDoor = this.transform.parent.Find("HigherDoor").gameObject;
    }


    public void Landing() {
        GetComponent<Rigidbody2D>().gravityScale = gravityScale;
    }

    public IEnumerator MoveCamera() {
        DataTransformer.enableInput = false;

        //移动摄像机到吊桥那里
        cam.enabled = false;
        mainCam.transform.position = brigdePos;
        //播放吊桥音效

        yield return new WaitForSeconds(pausedTime);

        //把镜头移动回来
        cam.enabled = true;

        //公主可以正常下楼
        higherDoor.SetActive(true);

        DataTransformer.enableInput = true;
    }
}
