using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDoor : MonoBehaviour {

    public string sortingLayer;
    public Vector3 position;

    private GameObject player;
    private SpriteRenderer sprite;
    private bool ready = false;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");

        //sprite = GameObject.Find("TowerFront").GetComponent<SpriteRenderer>();
        sprite = this.transform.parent.Find("TowerFront").GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if(ready && Input.GetKeyDown(KeyCode.X)) {
            sprite.sortingLayerName = sortingLayer;

            player.transform.position = position;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision) {
    //    if (collision.CompareTag("Player")) {
    //        if (Input.GetKeyDown(KeyCode.X)) {
    //            sprite.sortingLayerName = sortingLayer;

    //            player.transform.position = position;
    //        }
    //    }
    //}

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
