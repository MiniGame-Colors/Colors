using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMoveController : MonoBehaviour {

    public Transform bedroomLeft;
    public Transform bedroomRight;

    public Transform hallLeft;
    public Transform hallRight;

    public Transform townLeft;
    public Transform townRight;

    public Transform forestLeft;
    public Transform forestRight;

    public Transform altarLeft;
    public Transform altarRight;

    private Vector3 currentLeft;
    private Vector3 currentRight;
    private CinemachineVirtualCamera cam;
    private Transform player;

    private void Awake() {
        cam = GameObject.Find("CameraManager").GetComponent<CinemachineVirtualCamera>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() {
        float posY = player.position.y;

        if(posY > -4.5) {
            currentLeft = bedroomLeft.position;
            currentRight = bedroomRight.position;
        } else if(posY < -4.5 && posY > -20.2) {
            currentLeft = hallLeft.position;
            currentRight = hallRight.position;
        } else if(posY < -20.2 && posY > -48.8) {
            currentLeft = townLeft.position;
            currentRight = townRight.position;
        }else if(posY < -48.8 && posY > -79.9) {
            currentLeft = forestLeft.position;
            currentRight = forestRight.position;
        } else if(posY < -79.9 && posY > -112.8) {
            currentLeft = altarLeft.position;
            currentRight = altarRight.position;
        }

        //if(transform.position.x < currentLeftBootom.x || transform.position.x > currentRightTop.x 
        //    || transform.position.y < currentLeftBootom.y || transform.position.y > currentRightTop.y) {
        //    cam.enabled = true;
        //} else {
        //    cam.enabled = false;
        //}

        if (player.position.x < currentLeft.x) {
            cam.enabled = false;

            //transform.position = new Vector3(currentLeftBootom.x, transform.position.y, transform.position.z);
        } else if (player.position.x > currentRight.x) {
            cam.enabled = false;

            //transform.position = new Vector3(currentRightTop.x, transform.position.y, transform.position.z);
        } else {
            cam.enabled = true;
            //if(Mathf.Abs(player.position.x - transform.position.x)<0.1) {
            //    cam.enabled = true;
            //}
        }
    }
}
