using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour {

    //public float pausedTime;
    //public Vector2 position;
    public bool key;

    private Transform player;
    private PlayerController playerCtrl;
    private SceneTransformation scene;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerCtrl = player.gameObject.GetComponent<PlayerController>();

        scene = GetComponent<SceneTransformation>();
    }

    //IEnumerator ChangeScene() {
    //    playerCtrl.enableInput = false;

    //    yield return new WaitForSeconds(pausedTime);

    //    playerCtrl.enableInput = true;

    //    player.position = new Vector3(position.x, position.y, player.position.z);

    //}

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Door");
        if (other.CompareTag("Player")) {

            if (key) {

                if (playerCtrl.keyOfHall) {
                    StartCoroutine(scene.ChangeScene());
                }else {
                    //播放门打不开的音效
                }

            } else {

                if (playerCtrl.Awakening) {
                    StartCoroutine(scene.ChangeScene());
                } else {
                    //播放门打不开的音效
                }

            }
        }
    }
}
