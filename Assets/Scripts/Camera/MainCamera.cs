using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : Singleton<MainCamera>
{
    protected override void Awake()
    {
        base.Awake();
    }
    public void SetNormalMainCamera()
    {
        transform.GetComponent<Camera>().fieldOfView = 40;
    }
    public void SetMainCameraAWM()
    {
        transform.GetComponent<Camera>().fieldOfView = 10;
  
    }
}
