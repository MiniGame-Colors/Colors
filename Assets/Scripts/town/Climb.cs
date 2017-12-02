using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour {

    private BoxCollider2D flag;

    private void Start() {
        flag = GameObject.FindGameObjectWithTag("flag").GetComponent<BoxCollider2D>();
    }

    void OnTriggerStay2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            if (DataTransformer.grounded && !DataTransformer.hasClimbed ) {
                //进入攀爬状态
                DataTransformer.climb = true;

                DataTransformer.hasClimbed = true;

            }
        }
    }

    private void Update() {
        if(flag != null) {
            if (DataTransformer.hasClimbed) {
                Destroy(flag);
            }
        }


    }

}
