using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour {

	private bool hasStarted;

    public float pausedTime = 1.0f;

	void Start () {
        //隐藏破碎的瓶子
        Transform shatteredBottole = (this.gameObject.transform.GetChild(1)) as Transform;
        shatteredBottole.gameObject.SetActive(false);

        hasStarted = false;
    }


    void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("light")){
            float length = Mathf.Abs(other.gameObject.transform.position.x - this.transform.position.x);

            if (length <= 1.0 && !hasStarted) {
                hasStarted = true;

                //显示破碎的瓶子图片
                Transform shatteredBottole = (this.gameObject.transform.GetChild(1)) as Transform;
                shatteredBottole.gameObject.SetActive(true);

                StartCoroutine(PauseGame());
            }
        }
        
    }

    private IEnumerator PauseGame() {
        //暂停游戏
        Time.timeScale = 0;

        //游戏暂停时间，等待黑屏动画播放完毕
        float pauseEndTime = Time.realtimeSinceStartup + pausedTime;
        while (Time.realtimeSinceStartup < pauseEndTime){
            yield return 0;
        }

        Time.timeScale = 1;

    }
}
