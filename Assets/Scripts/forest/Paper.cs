using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour {

    public string content;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.X)) {
            PromptManager.Instance.PromptShow(content);

            Destroy(this.gameObject);
        }
    }
}
