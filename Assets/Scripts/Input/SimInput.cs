using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WindowsInput;

public class SimInput : MonoBehaviour
{

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetAxis("Event") > 0)
    {
      InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_X);
    }
  }
}
