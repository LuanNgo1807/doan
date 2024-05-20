using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class EventManager
{
    public static event UnityAction HitPlayer;
    public static event UnityAction EnemyDie;
    public static void EnemyDied() => EnemyDie?.Invoke();
    public static void OnHitPlayer() => HitPlayer?.Invoke();
}