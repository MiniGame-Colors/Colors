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

    private GameObject higherDoor;
    private CameraFollow follow;
    public GameObject cam;

    private void Awake() {

        higherDoor = this.transform.parent.Find("HigherDoor").gameObject;

        cam = GameObject.FindGameObjectWithTag("MainCamera");
        follow = cam.GetComponent<CameraFollow>();
    }


    public void Landing() {
        GetComponent<Rigidbody2D>().gravityScale = gravityScale;

        start = true;
        //禁用镜头脚本
        follow.enabled = false;
        DataTransformer.enableInput = false;

        //播放吊桥音效
    }

    private void Update() {
        if (!end && transform.rotation.z <= 0) {
            start = false;
            end = true;

            follow.enabled = true;

            //公主可以正常下楼
            higherDoor.SetActive(true);

            DataTransformer.enableInput = true;

            GetComponent<HingeJoint2D>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
