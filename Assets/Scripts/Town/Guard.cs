using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

    public float crazySpeed;
    public float pausedTime = 1f;

    private Rigidbody2D body;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {

            StartCoroutine(Catch());

            GetComponent<BoxCollider2D>().enabled = false;
            
        }

    }

    private IEnumerator Catch() {
        yield return new WaitForSeconds(pausedTime);

        Flip();

        body.velocity = new Vector2(-crazySpeed, 0);

    }

    private void Flip() {

        float scale = transform.localScale.x;

        scale *= -1;

        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    }
}
