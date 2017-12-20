using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public float speed;
    public float crazySpeed;
    public float DetectLength;
    //public float crazyLength;


    //private bool crazy = false;
    //private bool findPlayer = false;
    private bool calmdown = true;
    private Transform player;
    private float target;
    private Rigidbody2D body;

    private Animator anim;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        body = GetComponent<Rigidbody2D>();

        anim = transform.Find("body").gameObject.GetComponent<Animator>();
        Debug.Log(anim);
    }


    private void FixedUpdate() {
        Detect();

        if(!calmdown && Mathf.Abs(transform.position.x - target) <= 0.1) {
            body.velocity = new Vector2(0, 0);

            calmdown = true;
        }

        anim.SetFloat("velocityX", Mathf.Abs(body.velocity.x));
    }

    private void Detect() {

        if(player.position.y < -20.2 && player.position.y > -48.8) {
            float distance = player.position.x - this.transform.position.x;
            if(Input.GetKey(KeyCode.X) && (Mathf.Abs(distance) < DetectLength)) {
                Debug.Log("Enter");
                calmdown = false;

                target = player.position.x;

                body.velocity = new Vector2(Mathf.Sign(distance) * speed, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            float distance = player.position.x - this.transform.position.x;

            calmdown = false;

            target = player.position.x;

            body.velocity = new Vector2(Mathf.Sign(distance) * crazySpeed, 0);
        }

    }


    //public float PatrolTime = 3;                 //敌人巡逻一个方向的时间
    //public float PatrolSpeed = 1;                  //敌人巡逻速度
    //public float PursuitSpeed = 2;                 //敌人追击速度
    //public Transform Princess;                     //公主的位置
    //public float AlertDistance=5;                    //敌人的警戒距离
    //public float FleeDistance=10;                    //逃离距离
    //public int EnemyState=0;                       //敌人的状态，0为巡逻状态，1为追击状态
    //public float time;                         
    //public float distance;                         //与公主的距离
    //public float DeadDistance = 1;                 //接触死亡距离

    //private PlayerController playCtrl;
    //void Start () {
    //    time = PatrolTime;
    //    EnemyState = 0;

    //    playCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Vector3 scale = transform.localScale; //设置scale变量
    //    distance = Princess.transform.position.x - transform.position.x;
    //    if (Mathf.Abs(distance) < AlertDistance)
    //    {
    //        EnemyState = 1;
    //        float distanceY = Princess.transform.position.y - transform.position.y;
    //        if (Mathf.Abs(distance) < DeadDistance && Mathf.Abs(distanceY) < DeadDistance) {
    //            //调用公主死亡的动画，并且结束
    //            playCtrl.Death();
    //        }

    //    }
    //    else if(Mathf.Abs(distance)>FleeDistance)
    //    {
    //        EnemyState = 0;
    //    }
    //    if (EnemyState == 0)             //巡逻状态
    //    {
    //        if (time <= 0)
    //        {
    //            PatrolSpeed = -PatrolSpeed;
    //            time = PatrolTime;
    //            scale.x = -scale.x;
    //        }
    //        time -= Time.deltaTime;
    //        transform.Translate(-PatrolSpeed * Time.deltaTime, 0, 0);
    //    }
    //    if (EnemyState == 1)             //追击状态
    //    {
    //        if (distance < 0)
    //        {
    //            transform.Translate(-PursuitSpeed * Time.deltaTime, 0, 0);
    //            scale.x = Mathf.Abs(scale.x);
    //        }
    //        else
    //        {
    //            transform.Translate(PursuitSpeed * Time.deltaTime, 0, 0);
    //            scale.x = -Mathf.Abs(scale.x);
    //        }

    //    }
    //    transform.localScale = scale; //重新赋值
    //}
    //private void OnCollisionEnter2D(Collision2D collision) {
    //    //  Debug.Log(collision.gameObject.tag);
    //    if (collision.gameObject.tag == "Player") {
    //        //调用公主死亡的动画，并且结束
    //       // state = false;
    //        //调用公主死亡函数
    //        playCtrl.Death();
    //    }
    //}
}
