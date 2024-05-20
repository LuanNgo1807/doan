using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Chest : MonoBehaviour
{
    public GameObject particleVfx;
    public int numberHp;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Bullet"))
        {
            numberHp--;
            if(numberHp==0)
            {
                particleVfx.SetActive(true);
                DOVirtual.DelayedCall(1f, () =>
                {
                    MainUi._instance.CurrentAmountEnemy = 0;
                    GameManager._instance.gamePlay.EndGame();
                    gameObject.SetActive(false);
                });
            }         
        }
    }
}
