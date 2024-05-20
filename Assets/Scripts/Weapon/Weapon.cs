using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator _animator;
    public Transform _gunHead;
    public Vector3 _shootPoint;

    // public string _name;
    protected int _countBullet;
    private int _amountbullets;
    public int idGun;

    protected bool isReloading;
    protected float timeReload;

    public GunData gunData;


    protected virtual void Start()
    {
        isReloading = true;
        _amountbullets = _countBullet;
    }
    private void OnEnable()
    {
        StartCoroutine(IWaitTime());
    }
    IEnumerator IWaitTime()
    {
        yield return new WaitForSeconds(0.1f);
        MainUi._instance.LoadGunPlaying(gameObject.GetComponent<Weapon>());
    }
    public void StateReady()
    {
        _animator.SetTrigger("Ready");
    }

    protected void ReloadWeapon(int IdItem)
    {
        StartCoroutine(IEReload(IdItem));
    }
    public IEnumerator IEReload(int IdItem)
    {
        isReloading = false;
        _animator.SetTrigger("Reload");

        int remainingBullet = UserDataPref.GetAmountAuxiliaryItems(IdItem);
        /*if (remainingBullet >= _amountbullets)
        {
            UserDataPref.SetAmountAuxiliaryItems(IdItem, remainingBullet - _amountbullets);
            remainingBullet = _amountbullets;
        }
        else
        {
            UserDataPref.SetAmountAuxiliaryItems(IdItem,30);
        }*/
        UserDataPref.SetAmountAuxiliaryItems(IdItem, 30);
        _countBullet = remainingBullet;
        yield return new WaitForSeconds(timeReload);
        MainUi._instance.LoadGunPlaying(transform.GetComponent<Weapon>());
        isReloading = true;
    }
    public int GetTotalBullet()
    {
        return _amountbullets;
    }
    public int GetNumberBullets()
    {
        return _countBullet;
    }
    public void SetNumberBullets(int NumberBullets)
    {
        _countBullet = NumberBullets;

    }
}
