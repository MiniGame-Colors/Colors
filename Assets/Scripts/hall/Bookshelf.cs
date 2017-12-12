using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : MonoBehaviour {

    public bool active;


    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            if (active) {
                DataTransformer.Awakening = true;

                PromptManager.Instance.PromptShow("一场邪恶的祭祀仪式，必须要献上颜色");

            }else {

                PromptManager.Instance.PromptShow("论颜色的重要性");
            }
        }

    }
}
