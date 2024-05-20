using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScope : Singleton<UiScope>
{
    public GameObject NormalScope;
    public GameObject ScopeAWM;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        SetNormalScope();
    }
    public void SetNormalScope()
    {
        NormalScope.SetActive(true);
        ScopeAWM.SetActive(false);
        MainCamera._instance.SetNormalMainCamera();
    }
    public void SetScopeAWM()
    {
        NormalScope.SetActive(false);
        ScopeAWM.SetActive(true);
        MainCamera._instance.SetMainCameraAWM();
    }
}
