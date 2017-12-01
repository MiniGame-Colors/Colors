using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    private float length = 2.77f;

    void OnTriggerStay2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            if (Mathf.Abs(other.transform.position.x - this.transform.position.x) < length && !DataTransformer.push) {
                DataTransformer.deltaLength = other.transform.position.x - this.transform.position.x;
                DataTransformer.push = true;

                StartCoroutine(ChangeBodyType());
            }
        }

    }

    void OnTriggerExit2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            DataTransformer.push = false;

            //设置箱子不能移动
            this.transform.GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }

    }

    IEnumerator ChangeBodyType() {
        //延时五秒之后让箱子可以被移动
        yield return new WaitForSeconds(0.5f);

        this.transform.GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
