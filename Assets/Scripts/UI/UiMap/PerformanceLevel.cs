using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerformanceLevel : MonoBehaviour
{
    public List<GameObject> listStart;
    public void CompleteStar(int CountStar)
    {
        for (int i = 0; i < CountStar; i++)
        {
            listStart[i].transform.GetChild(0).gameObject.SetActive(true);
        }
        
    }   
}
