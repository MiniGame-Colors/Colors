using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Manager : MonoBehaviour {
    public Transform Princess;                     //公主的位置
    public float AlertDistance = 5;                //敌人的警戒距离
    public float PursuitSpeed = 2;                 //敌人追击速度
    public float time;
    public float distance;                         //与公主的距离
    public float DeadDistance = 1;                 //接触死亡距离
    public bool state = false;                     //是否追击

    private PlayerController playCtrl;
    void Start () {
        playCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 scale = transform.localScale; //设置scale变量
        distance = Princess.transform.position.x - transform.position.x;
        if (Mathf.Abs(distance) < DeadDistance)               //公主死亡
        {
            //调用公主死亡的动画，并且结束
            state = false;
            //调用公主死亡函数
            //playCtrl.Death();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            state = true;
            if (distance < 0)
            {
                scale.x = Mathf.Abs(scale.x);
            }
            else
            {
                scale.x = -Mathf.Abs(scale.x);
            }
        }
        if (state)
        {
            if (distance < 0)
            {
                transform.Translate(-PursuitSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Translate(PursuitSpeed * Time.deltaTime, 0, 0);
            }
        }
    }
}
