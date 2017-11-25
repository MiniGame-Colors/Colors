using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	//void OnTriggerEnter2D(Collider2D other) {

 //       if (other.CompareTag("Player") && DataTransformer.grounded) {

            
            

 //       }

 //   }

    void OnTriggerStay2D(Collider2D other) {

        if (Mathf.Abs(other.transform.position.x - this.transform.position.x) < 6.0f) {
            Messenger.Broadcast("Push");

            this.transform.GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

    }

    void OnTriggerExit2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            Messenger.Broadcast("EndPush");
            this.transform.GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }

    }
}
