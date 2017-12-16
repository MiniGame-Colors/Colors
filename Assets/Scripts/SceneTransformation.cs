using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SceneTransformation : MonoBehaviour
{

    public Transform targetPlace;
    public float pausedTime;
    public Collider2D cameraMoveRange;

    private Transform player;
    private SceneController sceneCtrl;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sceneCtrl = GameObject.Find("SceneController").GetComponent<SceneController>();
    }



    public IEnumerator ChangeScene()
    {
        DataTransformer.enableInput = false;
        //进入转换场景状态
        DataTransformer.changeScene = true;

        yield return new WaitForSeconds(pausedTime);

        DataTransformer.enableInput = true;
        //退出场景转换状态
        DataTransformer.changeScene = false;

        player.position = new Vector3(targetPlace.position.x, targetPlace.position.y, player.position.z);


        if (cameraMoveRange)
        {
            GameObject CameraManager = GameObject.Find("CameraManager");
            Destroy(CameraManager.GetComponent<CinemachineConfiner>());
            CameraManager.AddComponent<CinemachineConfiner>().m_BoundingShape2D = cameraMoveRange;
        }

        sceneCtrl.Save();
        DataTransformer.position = player.position;
    }
}
