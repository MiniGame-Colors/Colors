using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    public GameObject Effect;
    public GameObject Effect2;
    public float delayTime = 3;
    #region 单例模式
    private static EffectManager _Instance;



    public static EffectManager Instance {
        get {
            if (_Instance == null) {
                _Instance = GameObject.Find("EffectManager").GetComponent<EffectManager>();

            }
            return _Instance;
        }
    }
    #endregion
    // Use this for initialization
    void Start() {

    }

    public void EffectShow() {
      //  Effect.SetActive(true);
        Effect.GetComponent<Animation>().Play();
      //  StartCoroutine(WaitAndPrint(delayTime));//delayTime后执行WaitAndPrint()方法 
    }
    //IEnumerator WaitAndPrint(float waitTime) {
    //    yield return new WaitForSeconds(waitTime);
    //    //等待之后执行的动作    
    //    Effect.SetActive(false);
    //}
    public void EffectShow2()
    {
        Effect2.GetComponent<Animation>().Play();
    }
}