using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Communication : MonoBehaviour {

    //小纸条显示的内容
    private string content;

    private void Start() {
        content = "";
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (Input.GetKeyDown(KeyCode.X)) {

                //播放字条效果

            }
        }
    }
}
