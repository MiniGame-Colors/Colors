using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public string content;
    public float pausedTime;
    public float speed;
    public float size;

    private CameraFollow follow;
    private GameObject cam;
    private new Camera camera;

    private float originSize;
    private bool show = false;

    private void Awake() {
        cam = GameObject.FindGameObjectWithTag("MainCamera");

        camera = cam.GetComponent<Camera>();

        follow = cam.GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {

            originSize = camera.orthographicSize;
            StartCoroutine(Show());

        }
    }

    private void Update() {

        if (show) {
            float posX = Mathf.Lerp(cam.transform.position.x, transform.position.x, speed * Time.deltaTime);
            float posY = Mathf.Lerp(cam.transform.position.y, transform.position.y, speed * Time.deltaTime);

            cam.transform.position = new Vector3(posX, posY, cam.transform.position.z);

            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, size, speed * Time.deltaTime);

        }

    }

    private IEnumerator Show() {
        GetComponent<CircleCollider2D>().enabled = false;

        show = true;

        follow.enabled = false;
        DataTransformer.enableInput = false;

        yield return new WaitForSeconds(pausedTime);

        PromptManager.Instance.PromptShow(content);

        yield return new WaitForSeconds(PromptManager.Instance.delayTime);

        DataTransformer.enableInput = true;

        camera.orthographicSize = originSize;
        follow.enabled = true;

        //GetComponent<CircleCollider2D>().enabled = false;

        show = false;
    }

}
