using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour {

    private PlayerController playerCtrl;
    private GameObject stairs;
    private SceneTransformation scene;

    void Awake () {
        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        stairs = transform.Find("Stairs").gameObject;
	}
	

	void Update () {
        if (playerCtrl.Awakening && !stairs.activeSelf) {
            stairs.SetActive(true);

            scene = stairs.GetComponent<SceneTransformation>();

            GetComponent<BoxCollider2D>().enabled = true;
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Enter");
        if (other.CompareTag("Player")) {

            StartCoroutine(scene.ChangeScene());
        }
    }
}
