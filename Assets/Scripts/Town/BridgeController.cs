using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour {

    private Bridge bridge;
    private bool ready;
    private bool hasStarted = false;

    private void Awake() {
        bridge = this.transform.parent.Find("Bridge").gameObject.GetComponent<Bridge>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            ready = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            ready = false;
        }
    }

    private void Update() {
        if (!hasStarted && ready && Input.GetKeyDown(KeyCode.X)) {

            bridge.Landing();

            Destroy(transform.parent.Find("Wall").gameObject);

            StartCoroutine(bridge.MoveCamera());
        }
    }
}
