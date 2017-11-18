using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    private string[] talk = { "晓飞：这就是我的大学吗？", "晓飞：看起来意外的不错呀！","晓飞：也许我的人生就要在这里转折了","晓飞：希望在这里我能有所改变"};
    public bool isTalk=false;

    public int index = 0;                      //对话进度

    public GameObject talkcontext;         //对话框内容
    public GameObject talkPanel;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
	    if (isTalk == true)
	    {
	        
	            if (Input.GetKeyUp(KeyCode.Mouse0)||Input.GetKeyUp(KeyCode.Space))
	            {

	                if (talkcontext.GetComponent<TypewriterEffect>().isActive == false)
	                {
	                    if (index < talk.Length - 1)
	                    {
	                        talkcontext.GetComponent<TypewriterEffect>().enabled = true;
	                        index += 1;

	                        talkcontext.GetComponent<Text>().text = talk[index];
	                        talkcontext.GetComponent<TypewriterEffect>().starteffect();



	                    }
	                    else
	                    {
	                        //对话结束
	                        isTalk = false;
	                        talkPanel.GetComponent<Canvas>().enabled = false;

	                    }
	                }
	                else
	                {
	                    talkcontext.GetComponent<TypewriterEffect>().OnFinish();
	                }



	            }
	    }

	}
}
