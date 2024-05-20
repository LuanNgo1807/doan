using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : EnemyController
{
    protected override void Awake()
    {
        base.Awake();
        isDead = true;
    }

    protected override void Update()
    {
        base.Update();
    }
    public void SetStateEnemy(bool value)
    {
        isDead = value;
    }
}
