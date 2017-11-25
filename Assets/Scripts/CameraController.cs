using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    
    //摄像机停留在窗口所用的时间
    public float time = 2.0f;
    public float moveSpeed = 5.0f;

    private GameObject parent;
    private Vector2 currentPosition;
    private Vector2 targetPosition;
    private bool startMoving;

	void Start () {
        parent = GameObject.FindGameObjectWithTag("Player");
        startMoving = false;


        StartCoroutine(Tranformation());
    }



    void Update() {
        if (startMoving) {
            currentPosition = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);

            this.transform.position = new Vector3(currentPosition.x, currentPosition.y, -100.0f);

            if(currentPosition.x == targetPosition.x) {
                startMoving = false;
                this.transform.parent = parent.transform;

                //角色可以开始移动
                DataTransformer.enableInput = true;
            }
        }


    }

	IEnumerator Tranformation() {
        //禁止角色移动
        DataTransformer.enableInput = false;

        yield return new WaitForSeconds(time);

        currentPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        targetPosition = new Vector2(parent.transform.position.x, parent.transform.position.y + 1.4f);

        //让镜头开始移动
        startMoving = true;
    }


    void freeFromPlayer() {
        this.transform.parent = null;
    }

    void bindToPlayer() {
        this.transform.parent = parent.transform;
    }
}
