using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour {

    private PlayerController playerCtrl;


    void Awake() {
        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            if (!playerCtrl.Awakening) {
                playerCtrl.Death();
            } 
        }

    }
}
