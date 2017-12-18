using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bridge : MonoBehaviour {

    public float gravityScale = 0.1f;
    public float pausedTime = 4f;
    public Vector3 brigdePos;

    public bool start = false;
    //播放动画是否停止
    public bool end = false;

    private Vector3 playerPos;
    private GameObject higherDoor;
    private CinemachineVirtualCamera cam;
    private CameraMoveController mainCamCtrl;

    private void Awake() {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        cam = GameObject.Find("CameraManager").GetComponent<CinemachineVirtualCamera>();

        higherDoor = this.transform.parent.Find("HigherDoor").gameObject;

        mainCamCtrl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMoveController>();
    }


    public void Landing() {
        GetComponent<Rigidbody2D>().gravityScale = gravityScale;

        start = true;

        //禁用补丁
        mainCamCtrl.enabled = false;
        //移动摄像机到吊桥那里
        cam.enabled = false;

        DataTransformer.enableInput = false;

        //播放吊桥音效
    }

    private void Update() {
        if (!end && transform.rotation.z <= 0) {
            start = false;
            end = true;

            
            //把镜头移动回来
            cam.enabled = true;
            //开启补丁
            mainCamCtrl.enabled = true;

            //公主可以正常下楼
            higherDoor.SetActive(true);

            DataTransformer.enableInput = true;
        }
    }
}
