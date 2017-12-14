using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour {

    public float pausedTime = 1.0f;
    public new AudioClip audio;

    private bool hasStarted = false;
    private float detectedLength = 5.0f;
    private GameObject withBottole;
    private GameObject withoutBottole;

    private void Awake() {
        withBottole = transform.Find("WithBottle").gameObject;
        withoutBottole = transform.Find("WithoutBottle").gameObject;
    }

    void Start () {
        withoutBottole.SetActive(false);
        withBottole.SetActive(true);
    }


    void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("Player")){
            float length = Mathf.Abs(other.gameObject.transform.position.x - this.transform.position.x);

            if (length <= detectedLength && !hasStarted) {
               
                StartCoroutine(PauseGame());

            }
        }
    }

    private IEnumerator PauseGame() {
        //更新状态
        hasStarted = true;

        //显示黑屏动画
        EffectManager.Instance.EffectShow2();

        //禁止输入
        DataTransformer.enableInput = false;

        yield return new WaitForSeconds(pausedTime);


        //显示提示框
        //PromptManager.Instance.PromptShow("镜子碎了");


        MusicManager.instance.RandomPlay(audio);
        //显示破碎的瓶子图片
        Transform shatteredBottole = (this.gameObject.transform.GetChild(0)) as Transform;
        shatteredBottole.gameObject.SetActive(true);
        //隐藏正常的瓶子
        Transform bottole = (this.gameObject.transform.GetChild(1)) as Transform;
        bottole.gameObject.SetActive(false);


        //恢复输入
        DataTransformer.enableInput = true;
    }
}
