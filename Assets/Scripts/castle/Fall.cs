using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {
    public float pausedTime;

    private CameraFollow follow;
    private Vector3 velocity;


    // Use this for initialization
    void Start () {
        follow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {

            StartCoroutine(FallDown());
            
        }
    }

    IEnumerator FallDown() {
        DataTransformer.enableInput = false;

        yield return new WaitForSeconds(pausedTime);

        DataTransformer.enableInput = true;

        follow.ChangeToHall();

        //加入掉下来的效果
    }
}
