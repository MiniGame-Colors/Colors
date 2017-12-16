using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDoor : MonoBehaviour {

    public string sortingLayer;
    public Vector3 position;

    private GameObject player;
    private SpriteRenderer sprite;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");

        //sprite = GameObject.Find("TowerFront").GetComponent<SpriteRenderer>();
        sprite = this.transform.parent.Find("TowerFront").GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (Input.GetKeyDown(KeyCode.X)) {
                sprite.sortingLayerName = sortingLayer;

                player.transform.position = position;
            }
        }
    }


}
