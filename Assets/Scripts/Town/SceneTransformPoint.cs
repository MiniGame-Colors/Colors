using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransformPoint : MonoBehaviour {

    private Transform player;

    private SceneTransformation scene;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        scene = GetComponent<SceneTransformation>();
    }

    void OnTriggerEnter2D(Collider2D other) {

        StartCoroutine(scene.ChangeScene());

    }
}
