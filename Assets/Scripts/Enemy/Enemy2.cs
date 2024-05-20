using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;
using DG.Tweening;

public class Enemy2 : EnemyController
{
    // no di tuan tra trong khu vuc cua no
    // no phat hieen ra player
    // bao no quay ve can cu bao cho ca con enemy khac cac con enemy khac den ban player

    public Transform PosTeam1;
    public bool IsNotice;
    public bool IsColliderNotice;
    private bool IsHit;
    protected override void Awake()
    {
        base.Awake();
        IsColliderNotice = false;
        IsNotice = false;
        IsHit = false;
    }
    protected override void Update()
    {
        //base.Update();
        if (!isDead)
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            if ((playerInSightRange|| IsHit) && !IsNotice)
            {
                IsNotice = true;
                NotifyTeammates();

            }
            else if (IsNotice)
            {
                if (IsColliderNotice)
                {
                    playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
                    if (playerInAttackRange)
                    {
                        AttackPlayer();
                    }
                    else
                    {
                        ChasePlayer();
                    }
                }
            }
        }
    }
    public override void Damage(float HealthEnemy)
    {
        base.Damage(HealthEnemy);
        IsHit = true;

    }
        public void NotifyTeammates()
    {
        Destroy(gameObject.GetComponent<DOTweenPath>());
        agent.destination = PosTeam1.position;
        agent.speed = 7f;
    }
}
