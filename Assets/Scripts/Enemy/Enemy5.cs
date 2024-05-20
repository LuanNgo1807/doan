using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : EnemyController
{
    //protected override void Awake()
    //{
    //    base.Awake();
    //}

    //protected override void Update()
    //{
    //    if (!isDead)
    //    {
    //        //Check if Player in sightrange
    //        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
    //        //Check if Player in attackrange
    //        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
    //        if (!playerInSightRange && !playerInAttackRange) Patroling();
    //        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
    //        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    //    }
    //}

    //protected override void Patroling()
    //{
    //}

    //protected override void ChasePlayer()
    //{
    //}

    public override void StateIdle()
    {
        _animator.Play("idle");
    }
    public override void StateRun()
    {
        _animator.Play("walk");
    }
    public override void StateShoot()
    {
        _animator.Play("fire");
    }
}
