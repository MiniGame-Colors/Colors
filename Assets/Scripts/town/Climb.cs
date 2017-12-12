//把这个脚本挂在可以攀爬的物体上，并设置物体的Layer为“Climb”即可

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour {

    //设置角色攀爬速度
    public float climbSpeed = 50.0f;

    //maxX（minX）代表角色脸朝左（右）边攀爬时的横坐标    
    //maxY（minY）代表角色在攀爬时能达到的范围
    public Vector2 maxXAndY;
    public Vector2 minXAndY;

    //用于保存引用对象
    private PlayerController playerCtrl;
    private Transform frontCheck;
    private GameObject player;
    private Animator animator;

    //检测角色前方是否有可以攀爬的物体
    private bool climb;
    //用于检测角色当前是否正在攀爬
    private bool hasClimbed = false;

    private void Start() {
        //获取必要的引用对象
        player = GameObject.FindGameObjectWithTag("Player");

        playerCtrl = player.GetComponent<PlayerController>();
        animator = player.GetComponent<Animator>();
        frontCheck = player.transform.Find("frontCheck");
    }

    private void Update() {
        //检测climb的值
        climb = Physics2D.Linecast(player.transform.position, frontCheck.position, 1 << LayerMask.NameToLayer("Climb"));

        float v = Input.GetAxis("Vertical");


        if(climb) {
            //当角色前方有可攀爬物体且按了向上的方向键时，进入攀爬操作
            if(v != 0) {

                if (!hasClimbed) {
                    //固定角色攀爬的位置
                    if (playerCtrl.facingRight)
                        player.transform.position = new Vector2(minXAndY.x, player.transform.position.y);
                    else
                        player.transform.position = new Vector2(maxXAndY.x, player.transform.position.y);

                    //播放攀爬动画
                    animator.SetTrigger("climb");

                    //避免重复操作
                    hasClimbed = true;
                }

                //改变角色的运动方式
                DataTransformer.enableInput = false;
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, climbSpeed * Time.deltaTime * v);
                player.transform.position = new Vector2(player.transform.position.x, Mathf.Clamp(player.transform.position.y, minXAndY.y, maxXAndY.y));
                
                /*-----------------------------------*/
                /*---------这里播放攀爬音效----------*/
            }

            //退出攀爬状态
            if (Input.GetButtonDown("Jump")) {
                DataTransformer.enableInput = true;

                hasClimbed = false;

                animator.SetTrigger("fall");

                playerCtrl.Flip();
            }

        } 
    }

}
