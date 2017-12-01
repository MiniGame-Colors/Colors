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


    public float moveSpeed = 100.0f;
    public float jumpSpeed = 250.0f;

    public float minSpeedY = -5.0f;

    public GameObject talk;
    public GameObject talkPanel;

    private Transform groundCheck;
    private bool grounded = true;
    private Rigidbody2D body;

    private Animator animator;
    private GameObject light;

    //箱子实例
    private Rigidbody2D box;

    void Awake()
    {
        //获取刚体组件实例
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        groundCheck = transform.Find("groundCheck");
        light = GameObject.Find("light");


        //监测死亡事件
        Messenger.AddListener("Death", Death);
    }

    void OnDestroy() {
        Messenger.RemoveListener("Death", Death);
    }

    //死亡函数
    void Death() {

        StartCoroutine(Restart());

    }

    IEnumerator Restart() {
        animator.SetBool("dead", true);
        DataTransformer.enableInput = false;

        //EffectManager.Instance.EffectShow();

        yield return new WaitForSeconds(2.0f);

        //让角色回到存档的位置
        this.transform.position = DataTransformer.position;
        animator.SetBool("dead", false);

        yield return new WaitForSeconds(1.0f);
        DataTransformer.enableInput = true;
    }


    void Start() {
        //默认没有开启能力,如果要开启能力，设置为true即可
        light.SetActive(false);
        
        //这句代码不能放在Awake里面
        GameObject boxObject = GameObject.FindGameObjectWithTag("box");
        if (boxObject) {
            box = boxObject.GetComponent<Rigidbody2D>();
        }else {
            box = null;
        }
    }

    IEnumerator Climb() {
        //禁用输入
        DataTransformer.enableInput = false;
        
        this.body.bodyType = RigidbodyType2D.Static;

        yield return new WaitForSeconds(3.0f);

        this.body.bodyType = RigidbodyType2D.Dynamic;

        DataTransformer.enableInput = true;
    }


    void Update()
    {
        //检测是否落地
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        DataTransformer.grounded = grounded;


        //播放站立动画
        animator.SetBool("grounded", grounded);

        //Debug.Log(DataTransformer.climb);
        animator.SetBool("climb", DataTransformer.climb);
        if (DataTransformer.climb) {

            if (DataTransformer.enableInput && Input.GetAxis("Vertical") > 0) {

                StartCoroutine(Climb());

            }else {
                Debug.Log("climb");
                //在这里上下移动角色位置
                float positionY;
                if(this.transform.position.y < -10) {
                    positionY = this.transform.position.y + 1 * Time.deltaTime;
                }else {
                    positionY = this.transform.position.y - 1 * Time.deltaTime;
                }
                this.transform.position = new Vector3(this.transform.position.x, positionY, this.transform.position.z);
            }
        }

        //用于实现禁用输入功能
        if (DataTransformer.enableInput) {

            //播放攀爬动作
            animator.SetBool("climb", Input.GetKey(KeyCode.K));
            

            //用于测试，暂时按M键获得能力
            if (Input.GetKey(KeyCode.M)) {
                DataTransformer.yellow = true;
            }


            light.SetActive(DataTransformer.yellow);

            //对话框
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
        }else {
            return;
        }

        /*--------------------------------这部分是采用恒定速度的代码--------------------------------------------*/
        //因为h还是从0到1逐渐变化的，所以这里也是加速移动，只是幅度比较小
        //保持帧率平衡
        float velocityX = h * moveSpeed * Time.deltaTime;
        float velocityY = body.velocity.y < minSpeedY ? minSpeedY : body.velocity.y;
        body.velocity = new Vector2(velocityX, velocityY);
        /*---------------------------------------------------------------------------------------------------*/


        // h>0说明角色正要朝右走，facingRight==false说明角色当前朝向为左，需要转向
        if (h > 0 && !facingRight)
            Flip();
        // h<0说明角色正要朝左走，facingRight==true说明角色当前朝向为右，需要转向
        else if (h < 0 && facingRight)
            Flip();

        //当角色正在push的时候，不播放行走动画
        if (!DataTransformer.push) {
            animator.SetFloat("velocityX", Mathf.Abs(body.velocity.x));
        } else {
            animator.SetFloat("velocityX", 0);
        }


        animator.SetBool("push", DataTransformer.push && (h * DataTransformer.deltaLength < 0));

        // 假如当前正处于跳跃状态下
        if (jump)
        {
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