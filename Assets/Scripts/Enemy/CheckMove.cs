using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMove : MonoBehaviour
{
    public bool IsCantMove;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Moutain"))
        {
            Debug.Log("OnTriggerEnter");
            IsCantMove = false;
        }
    }
}
