using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            BoxCollider2D[] cols = GetComponents<BoxCollider2D>();

            foreach(BoxCollider2D c in cols) {
                c.enabled = false;
            }
        }
    }
}
