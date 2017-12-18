using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour {
    
    private GameObject blurry;
    private bool picked = false;
	
	void Awake() {
        //获取模糊的骑士画像
        blurry = transform.Find("Blurry").gameObject;
    }


    void Update() {
        if (blurry.activeSelf) {
            if (DataTransformer.Awakening) {
                blurry.SetActive(false);

                GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    ////重置画像
    //IEnumerator Reset() {
    //    yield return new WaitForSeconds(DataTransformer.restartTime);

    //    blurry.SetActive(true);

    //    GetComponent<BoxCollider2D>().enabled = false;
    //}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Debug.Log("pick");
            //删除钥匙图片

            picked = true;
            DataTransformer.keyOfHall = true;
        }
    }
}
