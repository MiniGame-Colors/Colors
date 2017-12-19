using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransformation : MonoBehaviour
{

    public Transform targetPlace;
    public float pausedTime;


    private Transform player;
    private SceneController sceneCtrl;
    private Transform cam;
    private CameraFollow follow;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sceneCtrl = GameObject.Find("SceneController").GetComponent<SceneController>();

        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        follow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }



    public IEnumerator ChangeScene()
    {
        DataTransformer.enableInput = false;
        //进入转换场景状态
        DataTransformer.changeScene = true;
        

        yield return new WaitForSeconds(pausedTime);

        
        DataTransformer.enableInput = true;

        

        player.position = new Vector3(targetPlace.position.x, targetPlace.position.y, player.position.z);
        cam.position = new Vector3(player.position.x, player.position.y, cam.position.z);

        //退出场景转换状态
        DataTransformer.changeScene = false;

        sceneCtrl.Save();
        DataTransformer.position = player.position;
        
    }
}
