using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {

    public float speed;
    public Transform left;
    public Transform right;

    private Transform player;
    private bool start = false;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Update() {
        if (start) {
            float posX = Mathf.Lerp(transform.position.x, player.position.x, speed * Time.deltaTime);

            posX = Mathf.Clamp(posX, left.position.x, right.position.x);

            transform.position = new Vector3(posX, transform.position.y, transform.position.z);

            float scale = Mathf.Sign(transform.position.x - player.position.x);
            transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            start = true;

            GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
