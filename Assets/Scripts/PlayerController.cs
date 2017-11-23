/*-------------------------------------------------------------------------------------------------------
这里选用刚体实现角色的移动控制，有两个注意事项，第一个是创建好一个空GameObject时要先reset对象transform属性
其次，角色图片作为一个SpriteRender组件在绑定到空GameObject对象上之前，也要先对transfrom属性进行reset
上面两个操作的目的是保证SpriteRender处于空GameObject对象坐标系的原点
改变GameObject对象的localScale.x的时候，GameObject对象的坐标系会相应改变
此外，因为本脚本采用给角色加力的方式让角色移动，
因此在创建的GameObject对象的RigidBody组件的Interpolate属性需要选择Interpolate（插值）
让移动平滑一点
---------------------------------------------------------------------------------------------------------*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false;

    //用于加速移动
    //public float moveForce = 1000f;
    //public float maxSpeed = 5f;

    public float moveSpeed = 100.0f;
    public float jumpSpeed = 250.0f;
    //public float jumpForce = 100.0f;
    //private float jumpScale = 100;
    
    public float minSpeedY = -5.0f;

    public GameObject talk;
    public GameObject talkPanel;

    private Transform groundCheck;
    private bool grounded = true;
    private Rigidbody2D body;

    private Animator animator;
    private GameObject light;

    void Awake()
    {
        //获取刚体组件实例
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        groundCheck = transform.Find("groundCheck");
        light = GameObject.Find("light");
    }

    void Start() {
        //默认没有开启能力,如果要开启能力，设置为true即可
        light.SetActive(false);
    }

    void Update()
    {
        // 创建一个空GameObject，把这个对象的中心放在角色脚底偏下的地方，
        // 只要这个对象的中心到角色的中心之间出现东西，就是落地了
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        //layerMask使用bitmap来记录哪些layer是开启的（对应位数为1），哪些layer是关闭的（对应位数为0）
        //现在只想检测Ground这一层，LayerMask.NameToLayer("Ground")得到Ground的层数
        //注意，需要在场景里面把所有可以落地的物体的layer换成Ground
        //再使用位运算使得Ground在bitmap里对应的bit为1
        //关于layerMask的说明详见官网API

        animator.SetBool("grounded", grounded);


        if (DataTransformer.enableInput) {
            animator.SetBool("push", Input.GetKey(KeyCode.J));
            animator.SetBool("climb", Input.GetKey(KeyCode.K));
            animator.SetBool("dead", Input.GetKey(KeyCode.L));

            //用于测试，暂时按M键获得能力
            if (Input.GetKey(KeyCode.M)) {
                light.SetActive(true);
            }

            if (Input.GetKey(KeyCode.T)) {
                talkPanel.GetComponent<Canvas>().enabled = true;
                talk.GetComponent<TalkManager>().isTalk = true;
            }

            // 只有当角色落地的时候才能跳跃
            if (Input.GetButtonDown("Jump") && grounded)
                jump = true;
        }
    }


    void FixedUpdate()
    {
        // 获取输入
        float h = 0.0f;
        if (DataTransformer.enableInput) {
            h = Input.GetAxis("Horizontal");
        }


        /*--------------------------------这部分是采用加速的代码--------------------------------------------*/
        // 当前速度没有达到最大速度（h和 body.velocity.x的符号相同） 或者正在向左行走(h<0 但是 body.velocity.x > 0)
        //if (h * body.velocity.x < maxSpeed)
        //    //增加向前的力让角色加速，h的方向就是角色行进的方向,加速前进
        //    body.AddForce(Vector2.right * h * moveForce * Time.deltaTime);

        ////限制物体的速度
        //if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
        //    //根据物体当前速度的方向Mathf.Sign(body.velocity.x)来限制
        //    body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * maxSpeed, body.velocity.y);
        /*---------------------------------------------------------------------------------------------------*/

        /*--------------------------------这部分是采用恒定速度的代码--------------------------------------------*/
        //因为h还是从0到1逐渐变化的，所以这里也是加速移动，只是幅度比较小
        //保持帧率平衡
        float velocityX = h * moveSpeed * Time.deltaTime;
        float velocityY = body.velocity.y < minSpeedY ? minSpeedY : body.velocity.y;
        body.velocity = new Vector2(velocityX, velocityY);
        /*---------------------------------------------------------------------------------------------------*/

        animator.SetFloat("velocityX", Mathf.Abs(body.velocity.x));

        // h>0说明角色正要朝右走，facingRight==false说明角色当前朝向为左，需要转向
        if (h > 0 && !facingRight)
            Flip();
        // h<0说明角色正要朝左走，facingRight==true说明角色当前朝向为右，需要转向
        else if (h < 0 && facingRight)
            Flip();

        // 假如当前正处于跳跃状态下
        if (jump)
        {
            // 给角色添加一个向上的力
            //body.AddForce(new Vector2(0f, jumpForce * Time.deltaTime * jumpScale));

            //加力跳跃需要的力太大
            //所以直接给角色设置向上的速度
            body.velocity = new Vector2(0, jumpSpeed * Time.deltaTime);

            // 避免多次跳跃
            jump = false;
        }
    }


    void Flip()
    {
        // 改变朝向
        facingRight = !facingRight;

        // 改变x方向上的scale进行翻转
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}