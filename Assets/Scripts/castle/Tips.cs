using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour {
    private Transform cam;

    private bool showed = false;
    private GameObject tips;

    private void Awake() {

        DataTransformer.enableInput = false;

        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;

        tips = GameObject.Find("UI").transform.Find("Canvas").Find("Tips").gameObject;
    }


    private void Start() {
        cam.position = new Vector3(cam.position.x, cam.position.y, -cam.position.z);

        tips.SetActive(true);

        showed = true;
    }

    // Update is called once per frame
    void Update () {

        if (showed && Input.GetKey(KeyCode.X)) {

            showed = false;

            tips.SetActive(false);

            cam.position = new Vector3(cam.position.x, cam.position.y, -cam.position.z);

            DataTransformer.enableInput = true;
        }

	}
}
