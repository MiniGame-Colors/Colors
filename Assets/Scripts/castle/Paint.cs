using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour {
    
    private GameObject blurry;
    private GameObject key;

    private bool picked = false;
	
	void Awake() {
        //获取模糊的骑士画像
        blurry = transform.Find("Blurry").gameObject;

        key = transform.Find("Key").gameObject;
    }


    void Update() {
        if (blurry.activeSelf) {
            if (DataTransformer.Awakening) {
                blurry.SetActive(false);

                GetComponent<BoxCollider2D>().enabled = true;
            }
        } else {
            DataTransformer.keyOfHall = !key.activeSelf;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (!picked && other.CompareTag("Player") && Input.GetKey(KeyCode.X)) {
            //删除钥匙图片
            key.SetActive(false);


            picked = true;
        }
    }
}
