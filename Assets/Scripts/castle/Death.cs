using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    private PlayerController playerCtrl;

    public float restartTime = 3f;

    private void Awake() {
        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player") && !DataTransformer.dead) {
            playerCtrl.Death(restartTime);
        }

        if (other.CompareTag("Enemy")) {
            other.gameObject.GetComponent<Guard>().Death(restartTime);
        }
    }

}
