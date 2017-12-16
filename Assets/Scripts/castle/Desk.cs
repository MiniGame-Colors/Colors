using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour {

    public float pausedTime = 1.0f;
    public new AudioClip audio;

    private bool hasStarted = false;
    public float detectedLength = 5.0f;

    private GameObject withBottole;
    private GameObject withoutBottole;

    private void Awake() {
        withBottole = transform.Find("WithBottle").gameObject;
        withoutBottole = transform.Find("WithoutBottle").gameObject;

    }

    void Start() {
        withoutBottole.SetActive(false);
    }


    //当角色进入时触发
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

        //播放音效
        MusicManager.instance.RandomPlay(audio);

        //显示破碎的瓶子图片
        withoutBottole.SetActive(true);

        //隐藏正常的瓶子
        withBottole.SetActive(false);


        //禁用触发脚本和Collider
        GetComponent<Desk>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        //恢复输入
        DataTransformer.enableInput = true;
    }
}
