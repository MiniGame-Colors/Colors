using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour {

    void OnTriggerStay2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            if (DataTransformer.grounded && Input.GetAxis("Vertical") > 0){
                //进入攀爬状态
                DataTransformer.climb = true;

            }
        }

    }

    void OnTriggerExit2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            //退出攀爬状态
            DataTransformer.climb = false;
        }
    }
}
