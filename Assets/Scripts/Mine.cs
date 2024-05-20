using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Mine : MonoBehaviour
{
    public GameObject particleVfx;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            particleVfx.SetActive(true);
           
            EndGame();


        }
        else if(other.gameObject.CompareTag("Bullet"))
        {
            particleVfx.SetActive(true);
            
            
            if (Vector3.Distance(other.gameObject.transform.position, PlayerController.instance.transform.position) < 4)
            {
                DOVirtual.DelayedCall(1f, () =>
                {
                    gameObject.SetActive(false);
                });
            }
            else
            {
                EndGame();
            }

        }
    }
    public void EndGame()
    {

        DOVirtual.DelayedCall(1f, () =>
        {
            MainUi._instance.CurrentAmountEnemy = 8;
            GameManager._instance.gamePlay.EndGame();
            gameObject.SetActive(false);
        });
    }
   
}
