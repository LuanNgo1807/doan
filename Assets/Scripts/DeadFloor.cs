using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadFloor : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager._instance.gamePlay.EndGame();
        }
    }
}
