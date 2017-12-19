using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    //摄像机中心和角色位置的最大偏移量
    public float xMargin = 2f;
    public float yMargin = 2f;
    //在跟随角色移动时被用来进行插值
    public float xSmooth = 2f;
    public float ySmooth = 2f;


    public Transform bedroomLeftBottom;
    public Transform bedroomRightTop;

    public Transform hallLeftBottom;
    public Transform hallRightTop;

    public Transform townLeftBottom;
    public Transform townRightTop;

    public Transform forestLeftBottom;
    public Transform forestRightTop;

    public Transform altarLeftBottom;
    public Transform altarRightTop;

    private Vector3 currentLeftBottom;
    private Vector3 currentRightTop;

    //镜头可移动的范围
    private Vector3 maxXAndY;
    private Vector3 minXAndY;

    private Transform player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    bool CheckXMargin() {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    bool CheckYMargin() {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }

    private void Update() {
        float posY = player.position.y;

        if (posY > -4.5) {
            currentLeftBottom = bedroomLeftBottom.position;
            currentRightTop = bedroomRightTop.position;
        } else if (posY < -4.5 && posY > -20.2) {
            currentLeftBottom = hallLeftBottom.position;
            currentRightTop = hallRightTop.position;
        } else if (posY < -20.2 && posY > -48.8) {
            currentLeftBottom = townLeftBottom.position;
            currentRightTop = townRightTop.position;
        } else if (posY < -48.8 && posY > -79.9) {
            currentLeftBottom = forestLeftBottom.position;
            currentRightTop = forestRightTop.position;
        } else if (posY < -79.9 && posY > -112.8) {
            currentLeftBottom = altarLeftBottom.position;
            currentRightTop = altarRightTop.position;
        }

        maxXAndY.x = currentRightTop.x;
        maxXAndY.y = currentRightTop.y;
        minXAndY.x = currentLeftBottom.x;
        minXAndY.y = currentLeftBottom.y;
    }

    public void changeToTown() {
        currentLeftBottom = townLeftBottom.position;
        currentRightTop = townRightTop.position;

        maxXAndY.x = currentRightTop.x;
        maxXAndY.y = currentRightTop.y;
        minXAndY.x = currentLeftBottom.x;
        minXAndY.y = currentLeftBottom.y;
    }

    private void FixedUpdate() {
        TrackPlayer();
    }

    void TrackPlayer() {
        //if (!DataTransformer.changeScene) {
        //    float targetX = transform.position.x;
        //    float targetY = transform.position.y;

        //    if (CheckXMargin()) {
        //        targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
        //    }

        //    if (CheckYMargin()) {
        //        targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
        //    }


        //    targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        //    targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        //    transform.position = new Vector3(targetX, targetY, transform.position.z);
        //}
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (CheckXMargin()) {
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
        }

        if (CheckYMargin()) {
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
        }


        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
