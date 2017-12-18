using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour {
    
    private GameObject stairs;
    private SceneTransformation scene;
    private BoxCollider2D col;

    void Awake () {

        stairs = transform.Find("Stairs").gameObject;

        col = GetComponent<BoxCollider2D>();
        col.enabled = false;

    }
	

	void Update () {
        if (DataTransformer.Awakening && !stairs.activeSelf) {
            stairs.SetActive(true);

            scene = stairs.GetComponent<SceneTransformation>();

           col .enabled = true;
        }
	}

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            StartCoroutine(scene.ChangeScene());
        }
    }
}
