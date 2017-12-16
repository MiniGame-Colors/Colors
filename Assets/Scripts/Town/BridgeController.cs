using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour {

    private Bridge bridge;

    private void Awake() {
        bridge = this.transform.parent.Find("Bridge").gameObject.GetComponent<Bridge>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (Input.GetKeyDown(KeyCode.X)) {
                bridge.Landing();

                StartCoroutine(bridge.MoveCamera());
            }
        }
    }
}
