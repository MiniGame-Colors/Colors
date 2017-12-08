using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour {

    public float pausedTime;
    public Vector2 position;

    private Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    IEnumerator ChangeScene() {
        DataTransformer.enableInput = false;

        yield return new WaitForSeconds(pausedTime);

        DataTransformer.enableInput = true;

        player.position = new Vector3(position.x, position.y, player.position.z);

    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            //if (DataTransformer.yellow) {

            //    StartCoroutine(ChangeScene());

            //}else {
            //    PromptManager.Instance.PromptShow("前面好像有什么东西");
            //}
        }
    }
}
