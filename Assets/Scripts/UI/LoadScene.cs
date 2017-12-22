using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for LoadScene
public class LoadScene : MonoBehaviour
{

  public int sceneIndex;

  public void chooseSceneToLoad()
  {
    SceneManager.LoadScene(sceneIndex);
  }

  void Update()
  {
    if (Input.GetAxis("Submit") > 0)
    {
      SceneManager.LoadScene(sceneIndex);
    }
  }
}
