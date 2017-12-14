using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false;
    [HideInInspector]
    public bool grounded = true;
    



    //主角的运动数值
    public float moveSpeed = 100.0f;
    public float jumpSpeed = 250.0f;
    public float minSpeedY = -5.0f;

    //打字机参数
    public GameObject talk;
    public GameObject talkPanel;

    private Transform groundCheck;
    
    private Rigidbody2D body;
    private Animator animator;
    private GameObject lightObject;

    //场景控制器实例
    private SceneController sceneCtrl;

    void Awake() {
        //获取刚体组件实例
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        groundCheck = transform.Find("groundCheck");
        lightObject = transform.Find("light").gameObject;

        sceneCtrl = GameObject.Find("SceneController").GetComponent<SceneController>();

        //初始化存档位置
        DataTransformer.position = transform.position;
    }


    //死亡函数
    public void Death() {
        
        /*-----------------------------------*/
        /*--------这里播放死亡的音效---------*/

        StartCoroutine(Restart());

        
    }

    IEnumerator Restart() {
        DataTransformer.dead = true;
        animator.SetBool("dead", true);
        DataTransformer.enableInput = false;

        yield return new WaitForSeconds(DataTransformer.restartTime);

        animator.SetBool("dead", false);
        DataTransformer.enableInput = true;
        DataTransformer.dead = false;

        //重置场景
        sceneCtrl.Reset();
        //让角色回到存档的位置
        this.transform.position = DataTransformer.position;
    }



    void Update()
    {
        //检测能力是否觉醒
        lightObject.SetActive(DataTransformer.Awakening);

        //检测是否落地
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        animator.SetBool("grounded", grounded);

        //用于实现禁用输入功能
        if (DataTransformer.enableInput) {
            this.body.gravityScale = 2;

            //对话框
            if (Input.GetKey(KeyCode.T)) {
                talkPanel.GetComponent<Canvas>().enabled = true;
                talk.GetComponent<TalkManager>().isTalk = true;
            }

            // 只有当角色落地的时候才能跳跃
            if (Input.GetButtonDown("Jump") && grounded)
                jump = true;
        }else {
            this.body.gravityScale = 0;
        }
    }


    void FixedUpdate()
    {
        // 获取输入
        float h = 0.0f;
        if (DataTransformer.enableInput) {
            h = Input.GetAxis("Horizontal");
        }

        /*--------------------------------这部分是采用恒定速度的代码--------------------------------------------*/
        //因为h还是从0到1逐渐变化的，所以这里也是加速移动，只是幅度比较小
        //保持帧率平衡
        float velocityX = h * moveSpeed * Time.deltaTime;
        float velocityY = body.velocity.y < minSpeedY ? minSpeedY : body.velocity.y;
        body.velocity = new Vector2(velocityX, velocityY);
        /*---------------------------------------------------------------------------------------------------*/

        //播放行走动画
        animator.SetFloat("velocityX", Mathf.Abs(body.velocity.x));

        // 需要转向
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        Jump();
        
    }

    void Jump() {
        // 假如当前正处于跳跃状态下
        if (jump) {
            //所以直接给角色设置向上的速度
            body.velocity = new Vector2(0, jumpSpeed * Time.deltaTime);

            // 避免多次跳跃
            jump = false;

            /*-----------------------------------*/
            /*---------这里播放跳跃音效----------*/
        }
    }

    public void Flip()
    {
        // 改变朝向
        facingRight = !facingRight;

        // 改变x方向上的scale进行翻转
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}