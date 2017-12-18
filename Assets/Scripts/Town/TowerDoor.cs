using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDoor : MonoBehaviour {

    public string sortingLayer;
    public Transform destination;

    private GameObject player;
    private SpriteRenderer sprite;
    private bool ready = false;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");


        sprite = this.transform.parent.Find("TowerFront").GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if(ready && Input.GetKeyDown(KeyCode.X)) {
            sprite.sortingLayerName = sortingLayer;

            player.transform.position = destination.position;
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
