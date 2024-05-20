using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAllObject : MonoBehaviour
{
    private void OnValidate()
    {
       // SetAllObject(transform);
    }
    void SetAllObject(Transform trans)
    {
        for (int i = 0; i < trans.childCount; i++)
        {
          //  trans.GetChild(i).tag = "Obj";
          if(trans.GetChild(i).gameObject.name.Equals("HOME"))
            {
                trans.GetChild(i).gameObject.AddComponent<MeshCollider>();
            }
           SetAllObject(trans.GetChild(i).transform);
        }
    }
}
