using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    private GameObject scene;
    private GameObject sceneClone;

    public void Reset() {
        Destroy(scene);

        sceneClone.SetActive(true);
        sceneClone.name = "Scene";
        scene = sceneClone;
        sceneClone = Instantiate(scene);
        sceneClone.SetActive(false);
    }


    public void Save() {

        if (sceneClone) {
            Destroy(sceneClone);
        }

        scene = GameObject.Find("Scene");

        sceneClone = Instantiate(scene);
        sceneClone.SetActive(false);
    }
}
