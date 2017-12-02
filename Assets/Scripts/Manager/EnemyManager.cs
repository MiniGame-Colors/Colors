using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public float PatrolTime = 3;                 //敌人巡逻一个方向的时间
    public float PatrolSpeed = 1;                  //敌人巡逻速度
    public float PursuitSpeed = 2;                 //敌人追击速度
    public Transform Princess;                     //公主的位置
    public float AlertDistance=5;                    //敌人的警戒距离
    public float FleeDistance=10;                    //逃离距离
    public int EnemyState=0;                       //敌人的状态，0为巡逻状态，1为追击状态
    public float time;                         
    public float distance;                         //与公主的距离
    public float DeadDistance = 1;                 //接触死亡距离
    
    // Use this for initialization
    void Start () {
        time = PatrolTime;
        EnemyState = 0;
	}

    // Update is called once per frame
    void Update()
    {
        
        distance = Princess.transform.position.x - transform.position.x;
        if (Mathf.Abs(distance) < AlertDistance)
        {
            EnemyState = 1;
            if (Mathf.Abs(distance) < DeadDistance)               //公主死亡
            {
                //调用公主死亡的动画，并且结束
            }
            
        }
        else if(Mathf.Abs(distance)>FleeDistance)
        {
            EnemyState = 0;
        }
        if (EnemyState == 0)             //巡逻状态
        {
            if (time <= 0)
            {
                PatrolSpeed = -PatrolSpeed;
                time = PatrolTime;
            }
            time -= Time.deltaTime;
            transform.Translate(-PatrolSpeed * Time.deltaTime, 0, 0);
        }
        if (EnemyState == 1)             //追击状态
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
