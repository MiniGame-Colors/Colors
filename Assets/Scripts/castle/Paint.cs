using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour {

    private PlayerController playerCtrl;
    private GameObject blurry;

    private bool picked = false;
	
	void Awake() {
        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        blurry = transform.Find("Blurry").gameObject;
    }


    void Update() {
        if (blurry.activeSelf) {
            if (playerCtrl.Awakening) {
                blurry.SetActive(false);

                GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {

            //删除钥匙图片

            picked = true;
            playerCtrl.keyOfHall = true;
        }
    }
}
