using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : MonoBehaviour {

    //private bool hasStarted = false;

    //private void Update() {
    //    if (hasStarted) {
    //        if (DataTransformer.dead && DataTransformer.resetSofa) {
    //            StartCoroutine(Reset());
    //        }

    //        //被存档，不需要再被重置
    //        if (DataTransformer.changeScene && DataTransformer.resetDesk) {
    //            DataTransformer.resetSofa = false;
    //        }
    //    }
    //}

    //private IEnumerator Reset() {
    //    yield return new WaitForSeconds(DataTransformer.restartTime);

    //    BoxCollider2D[] cols = GetComponents<BoxCollider2D>();

    //    foreach (BoxCollider2D c in cols) {
    //        c.enabled = true;
    //    }

    //    hasStarted = false;
    //}

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            BoxCollider2D[] cols = GetComponents<BoxCollider2D>();

            foreach(BoxCollider2D c in cols) {
                c.enabled = false;
            }

            //hasStarted = true;
        }
    }
}
