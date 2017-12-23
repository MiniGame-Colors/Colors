using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour {

    public string content;

    private bool ready = false;

    private void Update() {
        if (ready && Input.GetKey(KeyCode.X)) {
            PromptManager.Instance.PromptShow(content);

            Destroy(this.gameObject);

            ready = false;
        }
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
}
