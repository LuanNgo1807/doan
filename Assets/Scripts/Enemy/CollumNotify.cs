using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollumNotify : MonoBehaviour
{
    public List<Enemy2> enemiesTeam2;
    public List<Enemy3> enemiesTeam3;
    public List<Enemy4> enemiesTeam4;
    private bool isNotice;
  //  public GameObject Team1Object, Team2Object;
    private void Start()
    {
        isNotice = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy")&& !isNotice)
        {
            isNotice = true;
            for(int i=0;i<enemiesTeam2.Count;i++)
            {
                enemiesTeam2[i].IsNotice = true;
                enemiesTeam2[i].IsColliderNotice = true;
                if(enemiesTeam2[i].GetComponent<Enemy2>()!=null)
                {
                    Destroy(enemiesTeam2[i].GetComponent<DOTweenPath>());
                }
            }
            for (int i=0;i<enemiesTeam3.Count;i++)
            {
                enemiesTeam4[i].gameObject.SetActive(true);
                enemiesTeam3[i].gameObject.SetActive(true);

                enemiesTeam4[i].SetStateEnemy(false);
                enemiesTeam3[i].isAttackPlayer = true;
             }
        }
    }
}
