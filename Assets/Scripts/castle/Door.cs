using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour {

    //public float pausedTime;
    //public Vector2 position;
    public bool key;

    private Transform player;

    private SceneTransformation scene;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        scene = GetComponent<SceneTransformation>();
    }



    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            if (key) {

                if (DataTransformer.keyOfHall) {
                    StartCoroutine(scene.ChangeScene());
                }else {
                    //播放门打不开的音效
                }

            } else {

                if (DataTransformer.Awakening) {
                    StartCoroutine(scene.ChangeScene());
                } else {
                    //播放门打不开的音效
                }

            }
        }
    }
}
