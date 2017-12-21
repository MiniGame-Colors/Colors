using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public float speed;
    public float crazySpeed;
    public float DetectLength;

    private float distance;
    private bool calmdown = true;
    private bool crazy = false;
    private Transform player;
    private float target;
    private Rigidbody2D body;

    private Animator anim;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        body = GetComponent<Rigidbody2D>();

        anim = transform.Find("body").gameObject.GetComponent<Animator>();
    }


    private void FixedUpdate() {
        Detect();

        if((!calmdown && Mathf.Abs(transform.position.x - target) <= 0.1) || body.velocity.x == 0) {
            body.velocity = new Vector2(0, 0);

            calmdown = true;

            crazy = false;
        }

        anim.SetFloat("velocity", Mathf.Abs(body.velocity.x));
    }

    private void Detect() {
        if (player.position.y < -20.2 && player.position.y > -48.8) {
            distance = player.position.x - this.transform.position.x;
            if (!crazy && Input.GetKey(KeyCode.X) && (Mathf.Abs(distance) < DetectLength)) {

                Flip();

                calmdown = false;

                target = player.position.x;

                body.velocity = new Vector2(Mathf.Sign(distance) * speed, body.velocity.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {

            crazy = true;

            distance = player.position.x - this.transform.position.x;

            Flip();

            calmdown = false;

            target = player.position.x;

            body.velocity = new Vector2(Mathf.Sign(distance) * crazySpeed, body.velocity.y);
        }

    }


    private void Flip() {
        if(distance != 0) {
            float scale = transform.localScale.x;

            scale = -Mathf.Sign(distance) * Mathf.Abs(scale); 

            transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
        }
    }
}
