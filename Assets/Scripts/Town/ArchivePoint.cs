using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchivePoint : MonoBehaviour {

    public string content;

    private SceneController sceneCtrl;


    void Start () {
        sceneCtrl = GameObject.Find("SceneController").GetComponent<SceneController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if(content.Length > 0) {
                PromptManager.Instance.PromptShow(content);
            }

            sceneCtrl.Save();
        }
    }
}
