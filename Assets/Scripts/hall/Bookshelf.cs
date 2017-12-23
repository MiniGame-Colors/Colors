using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bookshelf : MonoBehaviour {

    public bool activePower;
    public float stayTime;

    public Sprite[] pictures;
    private GameObject imgRect;
    private Image img;
    private Transform cam;

    private string activePowerMessage = @"窃取颜色的人，太过愚蠢
我不知昏迷多时，世界亦黯然受苦
请把颜色还给我们。
神啊，你心已经向我，不然这火焰，如何熊熊燃起。";

    private string otherMessage = @"《论颜色》
物质产生的不同颜色的物理特性，被人们称为颜色。
混沌中的物质需要通过颜色，成为独一无二的存在。
其中，红、黄、蓝被称为三原色，它们可以混合出世界上所有的颜色。";


    private void Awake() {
        imgRect = GameObject.Find("UI").transform.Find("Canvas").Find("Image").gameObject;

        img = imgRect.GetComponent<Image>();

        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            if (activePower) {
                DataTransformer.Awakening = true;

                PromptManager.Instance.PromptShow(activePowerMessage);

                StartCoroutine(ShowPictures());

            }else {

                PromptManager.Instance.PromptShow(otherMessage);
            }


            GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    private IEnumerator ShowPictures() {
        DataTransformer.enableInput = false;
        cam.position = new Vector3(cam.position.x, cam.position.y, -cam.position.z);
        imgRect.SetActive(true);


        for(int i = 0; i < pictures.Length; i++) {
            img.sprite = pictures[i];

            yield return new WaitForSeconds(stayTime);
        }

        imgRect.SetActive(false);
        cam.position = new Vector3(cam.position.x, cam.position.y, -cam.position.z);
        DataTransformer.enableInput = true;
    }
}
