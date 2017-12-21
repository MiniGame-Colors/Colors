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

    private bool change = false;

    private Transform player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //ChangeToBedroom();
        ChangeToTown();
    }

    bool CheckXMargin() {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    bool CheckYMargin() {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }

    private void Update() {
        if (change) {
            maxXAndY.x = currentRightTop.x;
            maxXAndY.y = currentRightTop.y;
            minXAndY.x = currentLeftBottom.x;
            minXAndY.y = currentLeftBottom.y;

            change = false;
        }
    }

    public void ChangeToTown() {
        currentLeftBottom = townLeftBottom.position;
        currentRightTop = townRightTop.position;

        change = true;
    }

    public void ChangeToBedroom() {
        currentLeftBottom = bedroomLeftBottom.position;
        currentRightTop = bedroomRightTop.position;

        change = true;
    }

    public void ChangeToHall() {
        currentLeftBottom = hallLeftBottom.position;
        currentRightTop = hallRightTop.position;

        change = true;
    }

    public void ChangeToForest() {
        currentLeftBottom = forestLeftBottom.position;
        currentRightTop = forestRightTop.position;

        change = true;
    }

    public void ChangeToAltar() {
        currentLeftBottom = altarLeftBottom.position;
        currentRightTop = altarRightTop.position;

        change = true;
    }


    private void FixedUpdate() {
        TrackPlayer();

        //TrackPlayer();
    }

    void TrackPlayer() {
        if (change) {
            return;
        }

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

        ////双插值
        //if (CheckXMargin()) {
        //    targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
        //}

        //if (CheckYMargin()) {
        //    targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
        //}


        //targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        //targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        //transform.position = new Vector3(targetX, targetY, transform.position.z);

        ////双插值
        //if (CheckXMargin()) {
        //    targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
        //}

        //if (CheckYMargin()) {
        //    targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
        //}


        //targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        //targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        //transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
