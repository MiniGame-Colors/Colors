using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDoor : MonoBehaviour {

    public string sortingLayer;
    public Transform destination;
    public bool ShowDeath;

    private GameObject player;
    private SpriteRenderer sprite;
    private bool ready = false;

    private BoxCollider2D death;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");

        sprite = this.transform.parent.Find("TowerFront").GetComponent<SpriteRenderer>();

        death = transform.parent.Find("Death").GetComponent<BoxCollider2D>();
    }

    private void Update() {
        if(ready && Input.GetKeyDown(KeyCode.X)) {
            sprite.sortingLayerName = sortingLayer;

            player.transform.position = destination.position;

            death.enabled = ShowDeath;
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
