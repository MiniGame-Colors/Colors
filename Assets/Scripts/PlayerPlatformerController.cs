using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {
    [HideInInspector]
    public bool facingRight = true;

    public float jumpTakeOffSpeed = 7.0f;
    public float maxSpeed = 7.0f;

    public GameObject talk;
    public GameObject talkPanel;

    //private SpriteRenderer spriteRender;
    private Animator animator;
    private Transform target;


    private bool filp = false;
    private void Awake() {
        // spriteRender = GetComponent<SpriteRenderer>();
        //获取动画对象
        animator = GetComponent<Animator>();
        target = this.transform;
    }

    protected override void ComputeVelocity() {
        Vector2 move = Vector2.zero;

        //根据方向键的输入设置x方向上的速度
        move.x = Input.GetAxis("Horizontal");

        if (move.x > 0 && !facingRight)
            Flip();
        // h<0说明角色正要朝左走，facingRight==true说明角色当前朝向为右，需要转向
        else if (move.x < 0 && facingRight)
            Flip();

        //根据跳跃键的输入设置y方向上的速度
        if (Input.GetButtonDown("Jump") && grounded) {
            velocity.y = jumpTakeOffSpeed;
        } else if (Input.GetButtonDown("Jump")) {
            //在跳跃的过程中按空格键的时候减速
            if(velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }

        //触发对话框效果
        if (Input.GetKey(KeyCode.T))
        {
            talkPanel.GetComponent<Canvas>().enabled = true;
            talk.GetComponent<TalkManager>().isTalk = true;
        }


        //播放动画
        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        animator.SetBool("push", Input.GetKey(KeyCode.J));
        animator.SetBool("climb", Input.GetKey(KeyCode.K));
        animator.SetBool("dead", Input.GetKey(KeyCode.L));

        //设置targetVelocity，这将在后面影响velocity的值
        targetVelocity = move * maxSpeed;
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
