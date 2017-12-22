using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour {
    public bool key;

    private SceneTransformation scene;

    //private CameraFollow follow;

    void Start() {

        scene = GetComponent<SceneTransformation>();

        //follow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
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
