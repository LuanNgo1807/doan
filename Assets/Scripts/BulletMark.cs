using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BulletMark : MonoBehaviour
{
    private void OnEnable()
    {
        DOVirtual.DelayedCall(3f, () => ObjectPooler._instance.AddElement("BulletMark1", transform.gameObject)
        );
    }
    
}
