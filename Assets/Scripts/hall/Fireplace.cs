using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour {
    private CameraFollow follow;
    private PlayerController playerCtrl;

    private void Awake() {
        follow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();

        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            if (!DataTransformer.Awakening) {
                playerCtrl.Death();

                StartCoroutine(Reset());
            } 
        }

    }

    private IEnumerator Reset() {
        yield return new WaitForSeconds(playerCtrl.restartTime);

        follow.ChangeToBedroom();
    }
}
