using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWM : Gun
{
   public GameObject gunModel;
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown("3"))
        {
            if(gunModel.activeSelf)
            {
                gunModel.SetActive(false);
                UiScope._instance.SetScopeAWM();
            }
            else
            {
                gunModel.SetActive(true);
                UiScope._instance.SetNormalScope();
            }

        }
    }
}
