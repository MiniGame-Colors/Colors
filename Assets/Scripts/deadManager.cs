using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadManager : MonoBehaviour {
    private PlayerController playCtrl;
    void Start() {
      

        playCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //  Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player") {
            //调用公主死亡的动画，并且结束
            // state = false;
            //调用公主死亡函数
            playCtrl.Death();
        }
    }
}
