using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for LoadScene
public class LoadScene : MonoBehaviour
{

  public void chooseSceneToLoad(int sceneIndex)
  {
    SceneManager.LoadScene(sceneIndex);
  }
}
