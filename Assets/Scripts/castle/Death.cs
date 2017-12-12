using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    private PlayerController playerCtrl;

    private void Awake() {
        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player") && !DataTransformer.dead) {
            playerCtrl.Death();
        }
    }

}
