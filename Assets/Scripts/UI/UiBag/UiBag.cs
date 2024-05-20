using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiBag : BasePopup
{
    public static UiBag instance;
    public override void Awake()
    {
        base.Awake();
        instance = this;
    }


}
