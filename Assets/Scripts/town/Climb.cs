using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour {

    private bool hasChange = false;

    void OnTriggerStay2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            if (DataTransformer.grounded && !hasChange) {
                //进入攀爬状态
                DataTransformer.climb = true;

                hasChange = true;
                Debug.Log("climb");

            }
        }

    }

    //void OnTriggerExit2D(Collider2D other) {

    //    if (other.CompareTag("Player")) {
    //        Debug.Log("exit");
    //        //退出攀爬状态
    //        DataTransformer.climb = false;
    //    }
    //}
}
