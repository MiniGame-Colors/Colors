using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptManager : MonoBehaviour {
    public GameObject PromptPanel;
    public GameObject PromptText;
    public float delayTime = 3f;

    private bool show = false;
    private bool close = false;

    #region 单例模式
    private static PromptManager _Instance;



    public static PromptManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = GameObject.Find("PromptManager").GetComponent<PromptManager>();

            }
            return _Instance;
        }
    }
    #endregion
    void Start () {
		
	}

    private void Update() {
        if(show && close && Input.GetKeyDown(KeyCode.X)){
            PromptPanel.SetActive(false);

            show = false;

            close = false;
        }
    }

    public void PromptShow(string Prompttext)
    {
        show = true;
        PromptText.GetComponent<Text>().text = Prompttext;
        PromptPanel.SetActive(true);
        StartCoroutine(WaitAndPrint(delayTime));//delayTime秒后执行WaitAndPrint()方法 
    }
    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //等待之后执行的动作    
        //PromptPanel.SetActive(false);
        close = true;
    }
}
