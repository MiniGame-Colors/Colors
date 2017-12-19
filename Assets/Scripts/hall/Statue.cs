using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour {

    private float length = 0.0f;
    private SpriteRenderer sprite;

    private Transform player;

    void Awake() {
        sprite = transform.Find("Gray").GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    //道具进入灯光的范围的时候
    void OnTriggerEnter2D(Collider2D other) {
        //只需要进入一次，后面就记住这个距离，一直用这个距离来测试
        if (other.CompareTag("light")) {
            length = Mathf.Abs(other.gameObject.transform.position.x - this.transform.position.x);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("light")) {
            float temp = Mathf.Abs(player.position.x - this.transform.position.x);

            float alpha = temp / length;

            sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, alpha);
        }
    }
}
