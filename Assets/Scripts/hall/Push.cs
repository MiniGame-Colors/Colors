//把这个脚本附加在能被推动的物体上,并把物体的Layer设置为“Ground”即可

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour {
    //保存引用
    private Animator animator;
    private Transform frontCheck;

    private void Awake() {
        //获取必要的引用

        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        frontCheck = GameObject.FindGameObjectWithTag("Player").transform.Find("frontCheck");
    }

    void Update() {

        Collider2D[] cols = Physics2D.OverlapPointAll(frontCheck.position, 1 << LayerMask.NameToLayer("Push"));

        animator.SetBool("push", cols.Length > 0);


        /*-----------------------------------*/
        /*---------这里播放推箱子音效----------*/
    }
}
