using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyController
{
    public bool isAttackPlayer;
    protected override void Awake()
    {
        base.Awake();
        isAttackPlayer = false;
    }
    protected override void Update()
    {
        //base.Update();
        if (!isDead && isAttackPlayer)
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
