using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            if (DataTransformer.yellow) {

                StartCoroutine(ChangeScene());

            }else {
                PromptManager.Instance.PromptShow("前面好像有什么东西");
            }
        }
    }

    IEnumerator ChangeScene() {
        //显示黑屏动画
        EffectManager.Instance.EffectShow();

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("Hall", LoadSceneMode.Single);
    }
}
