using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

    //落地允许最小Y分量
    public float minGroundNormalY = 0.65f;
    //用来控制加速度
    public float gravityModifier = 1f;

    protected Rigidbody2D body;

    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    //用于检测是否落地
    protected bool grounded;
    //物体的初始速度
    protected Vector2 targetVelocity;
    //碰撞点和地点的法向量
    protected Vector2 groundNormal;
    //物体当前的速度
    protected Vector2 velocity;

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    private void OnEnable() {
        body = GetComponent<Rigidbody2D>();
    }

    void Start () {
        //关闭过滤触发器碰撞检测的功能，
        //也就是对触发器也进行碰撞检测?
        contactFilter.useTriggers = false;
        //设置在检测碰撞前要过滤掉哪些层
        //Physics2D.GetLayerCollisionMask(gameObject.layer)获取对象当前所在的层
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        //sets the contact filter to filter results by layer mask,官网的解释
        contactFilter.useLayerMask = true;

    }
	
	void Update () {
        //设置targetVelocity的默认值为零
        targetVelocity = Vector2.zero;
        ComputeVelocity();

	}

    //用来设置targetVelocity
    protected virtual void ComputeVelocity() {

    }

    private void FixedUpdate() {
        //因为RigidBody的Body type设置为konematic，因此需要自己加重力效果
        //velocity小于零
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        //根据外部输入的targetVelocity来设置velocity的x分量
        velocity.x = targetVelocity.x;

        //默认为不落地
        grounded = false;

        //前进的位移
        Vector2 deltaPosition = velocity * Time.deltaTime;

        //计算当前要前进的方向（沿着地面往右或者沿着斜坡往上）
        //放大x方向上的分量（也就是获得加速效果）
        //并且设置y方向的分量向上
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        //放大move
        //deltaPosition.x = velocity.x * Time.deltaTime
        Vector2 move = moveAlongGround * deltaPosition.x;
        //不只是处理y方向上的移动
        Movement(move, false);

        //deltaPosition.y = velocity.y * Time.deltaTime
        move = Vector2.up * deltaPosition.y;
        //处理Y方向上的移动
        Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement) {
        //distance默认为move向量的长度
        float distance = move.magnitude;

        //角色还在移动，minMoveDistance为0.001，因此相当于是distance > 0
        if (distance > minMoveDistance) {
            //根据move的方向进行检测
            //在检测前添加contactFilter过滤器（相当于给检测添加限制条件）
            //hitBuffer用于缓存检测的结果
            //distance+shellRadius为检测的距离，只有在这个范围内的物体会被检测到
            int count = body.Cast(move, contactFilter, hitBuffer, distance + shellRadius);


            //将检测结果存进hitBufferList
            hitBufferList.Clear();
            for(int i = 0; i < count; i++) {
                hitBufferList.Add(hitBuffer[i]);
            }

            //检查碰撞对象的法向量（也就是碰撞的角度
            for(int i = 0; i<hitBufferList.Count; i++) {
                //currentNormal为碰撞点相对于的法向量
                Vector2 currentNormal = hitBufferList[i].normal;
                
                //currentNormal的Y分量大于minGroundNormalY时判定其着地
                //坡度越大，Y分量越小
                //也就当坡度不大的时候认为角色可以站稳
                if (currentNormal.y > minGroundNormalY) {
                    
                    //只有检测到碰撞点并且碰撞点的坡度不大的时候，才判断其落地
                    grounded = true;

                    //如果物体只有竖直方向上的移动，清除currentNormal的x分量，更新groundNormal
                    if (yMovement) {
                        //将groundNormal设置为当前站立点（碰撞点）的法向量
                        groundNormal = currentNormal;


                        currentNormal.x = 0;
                    }
                }

                //--------------------------------------------------//
                /*----------没有这段代码将无法爬坡且下落速度很快----------*/
                //projection用于判断速度和法向量的夹角是否大于90度
                float projection = Vector2.Dot(velocity, currentNormal);

                //前进速度和法向量夹角大于90度，
                //1、爬坡：获得加速效果
                //2、站在平面上：还是不动
                if (projection < 0) {
                    velocity = velocity - projection * currentNormal;
                }
                //---------------------------------------------------//


                //如果碰撞对象离物体的距离小于move的长度，
                //那么把distance改成modifiedDistance避免进入碰撞对象里面
                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        body.position += move.normalized * distance;
    }
}
