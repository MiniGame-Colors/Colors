using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

    public float crazySpeed;
    public float pausedTime = 1f;

    private Rigidbody2D body;
    private Animator anim;
    private bool hasCatched = false;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();

        anim = transform.Find("body").gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!hasCatched && collision.CompareTag("Player")) {

            StartCoroutine(Catch());

            GetComponent<BoxCollider2D>().enabled = false;
            
        }

    }

    private IEnumerator Catch() {
        hasCatched = true;

        yield return new WaitForSeconds(pausedTime);

        Flip();

        body.velocity = new Vector2(-crazySpeed, 0);

        anim.SetFloat("velocity", Mathf.Abs(body.velocity.x));

    }

    public void Death(float time) {

        body.velocity = Vector3.zero;

        anim.SetTrigger("death");

        GetComponent<CapsuleCollider2D>().enabled = false;

        StartCoroutine(Remove(time));
    }


    private IEnumerator Remove(float time) {
        yield return new WaitForSeconds(time);

        transform.Find("body").parent = transform.parent;

        Destroy(this.gameObject);
    }

    private void Flip() {

        float scale = transform.localScale.x;

        scale *= -1;

        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    }
}
