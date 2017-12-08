using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour {

    private float length = 2.77f;

    private Rigidbody2D body;
    private Animator animator;
    private PlayerController playerCtrl;

    private void Awake() {
        body = this.transform.GetComponentInParent<Rigidbody2D>();

        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    void OnTriggerStay2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            if (Mathf.Abs(other.transform.position.x - this.transform.position.x) < length && !playerCtrl.push) {
                //DataTransformer.deltaLength = other.transform.position.x - this.transform.position.x;
                //DataTransformer.push = true;
                playerCtrl.push = true;
                //animator.SetBool("push", DataTransformer.push && (h * DataTransformer.deltaLength < 0));

                StartCoroutine(ChangeBodyType());
            }
        }

    }

    void OnTriggerExit2D(Collider2D other) {

        //if (other.CompareTag("Player")) {

        //    //DataTransformer.push = false;
        //    playerCtrl.push = false;

        //    //设置箱子不能移动
        //    this.transform.GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //}

    }

    IEnumerator ChangeBodyType() {
        //延时五秒之后让箱子可以被移动
        yield return new WaitForSeconds(0.5f);

        body.bodyType = RigidbodyType2D.Dynamic;
    }
}
