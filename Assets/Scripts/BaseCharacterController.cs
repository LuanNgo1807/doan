using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterController : MonoBehaviour
{
    [SerializeField] Animator _animator;

   // [SerializeField] Transform _posGun;

  //  [SerializeField] GameObject _gun;

   // protected int health = 10000;

  //  [SerializeField] public Image _healthBar;

  //  [SerializeField] protected Transform _positionOfParticleBlood;

    protected enum CharacterState
    {
        Run,
        Shoot,
        Idle,
    }
    public void PlayerRun()
    {
        _animator.SetBool("shoot", false);
        _animator.SetBool("run", true);

    }
    public void Playershoot()
    {
        _animator.SetBool("shoot", true);
    }
    public void PlayerIdle()
    {
        _animator.SetBool("shoot", false);
        _animator.SetBool("run", false);
    }

    protected void AnimatorPlayer(CharacterState state)
    {
        switch (state)
        {
            case CharacterState.Idle:
                PlayerIdle();
                break;
            case CharacterState.Run:
                PlayerRun();
                break;
            case CharacterState.Shoot:
                Playershoot();
                break;
            default:
                break;
        }

    }
}
