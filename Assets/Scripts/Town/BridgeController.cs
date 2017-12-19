using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BridgeController : MonoBehaviour {
    public float speed;
    public Transform start;
    public Transform end;

    private Bridge bridge;
    private bool ready;
    private bool hasStarted = false;

    private GameObject mainCam;

    private void Awake() {
        bridge = this.transform.parent.Find("Bridge").gameObject.GetComponent<Bridge>();

        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update() {
        if (!hasStarted && ready && Input.GetKeyDown(KeyCode.X)) {

            bridge.Landing();

            Destroy(transform.parent.Find("Wall").gameObject);
        }

        if(bridge.start) {
            if (!bridge.end) {
                Vector3 position = Vector3.Lerp(start.position, end.position, speed * Time.deltaTime);

                mainCam.transform.position = position;
            } 
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            ready = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            ready = false;
        }
    }

    

    
}
