using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour {
    
    private GameObject stairs;
    private SceneTransformation scene;

    void Awake () {

        stairs = transform.Find("Stairs").gameObject;
	}
	

	void Update () {
        if (DataTransformer.Awakening && !stairs.activeSelf) {
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
