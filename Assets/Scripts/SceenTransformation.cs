using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceenTransformation : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("enter");
        if (other.CompareTag("Player")) {

            SceneManager.LoadScene(this.name, LoadSceneMode.Single);
        }
    }
}
