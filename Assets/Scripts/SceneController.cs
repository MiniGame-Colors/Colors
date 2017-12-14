using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    private GameObject scene;
    private GameObject sceneClone;

    void Start() {
        scene = GameObject.Find("Castle");

        sceneClone = Instantiate(scene);
        sceneClone.SetActive(false);
    }

    public void Reset() {
        Destroy(scene);

        sceneClone.SetActive(true);
        sceneClone.name = "Castle";
        scene = sceneClone;
        sceneClone = Instantiate(scene);
        sceneClone.SetActive(false);
    }


    public void Save() {

        Destroy(sceneClone);

        sceneClone = Instantiate(GameObject.Find("Castle"));
        sceneClone.SetActive(false);
    }
}
