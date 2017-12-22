using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransformPoint : MonoBehaviour {

    private SceneTransformation scene;

    void Start() {

        scene = GetComponent<SceneTransformation>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(scene.ChangeScene());
        }
    }
}
