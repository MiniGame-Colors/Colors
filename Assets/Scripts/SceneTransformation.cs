using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransformation : MonoBehaviour {

    public Vector2 position;
    public float pausedTime;

    private Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            StartCoroutine(ChangeScene());

        }
    }

    IEnumerator ChangeScene() {
        DataTransformer.enableInput = false;

        yield return new WaitForSeconds(pausedTime);

        DataTransformer.enableInput = true;

        player.position = new Vector3(position.x, position.y, player.position.z);

        DataTransformer.position = player.position;

    }
}
