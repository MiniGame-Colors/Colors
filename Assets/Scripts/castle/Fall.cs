using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fall : MonoBehaviour {
    public float pausedTime;
    public string content;


    private GameObject cam;
    private CameraFollow follow;
    private Vector3 velocity;
    private GameObject text;


    // Use this for initialization
    void Start() {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        follow = cam.GetComponent<CameraFollow>();

        text = GameObject.Find("UI").transform.Find("Canvas").Find("Text").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {

            StartCoroutine(FallDown());
            
        }
    }

    IEnumerator FallDown() {
        DataTransformer.enableInput = false;

        //加入掉下来的效果
        cam.transform.position = new Vector3(cam.transform.position.x, 
            cam.transform.position.y, -cam.transform.position.z);
        text.SetActive(true);

        yield return new WaitForSeconds(pausedTime);

        text.SetActive(false);
        cam.transform.position = new Vector3(cam.transform.position.x,
            cam.transform.position.y, -cam.transform.position.z);

        DataTransformer.enableInput = true;

        follow.ChangeToHall();

        


    }
}
