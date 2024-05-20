using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Gun : Weapon
{
    public float power;
    public ParticleSystem _explosionVfx;
    int levelGun;
    protected override void Start()
    {
        Init();
        base.Start();
    }
    void Init()
    {
        levelGun = UserDataPref.GetLevelGun(idGun);
        power = gunData.listDamage[levelGun - 1] * 1000 + gunData.listRateOfFire[levelGun - 1] * 1000 + gunData.listAccuracy[levelGun - 1] * 1000;
        power = power / (float)3;
        timeReload = gunData.timeCharge[levelGun - 1];
        SetNumberBullets(gunData.numberBullets);
    }
    protected virtual void Update()
    {


        if (GameState.stateGame != StateGame.OpenStore && isReloading)
        {
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = MainCamera._instance.gameObject.GetComponent<Camera>().ScreenPointToRay(screenCenterPoint);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                _shootPoint = raycastHit.point;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (_countBullet != 0)
                {
                    _explosionVfx.Play();
                    SoundController._instance.OnPlayAudio(SoundType.Akfire);
                    Shoot();
                }
                else
                {
                    ReloadWeapon((int)TypeElementBag.Bullet);
                }
            }

            if (Input.GetKeyDown("q"))
            {
                ReloadWeapon((int)TypeElementBag.Bullet);
            }
        }
    }

    public void Shoot()
    {
        if (_countBullet == 0)
            return;
        StartCoroutine(WaitTimeBullet());
    }
    IEnumerator WaitTimeBullet()
    {
        GameObject Bullet = ObjectPooler._instance.SpawnFromPool("Bullet", _gunHead.position, _gunHead.rotation);
        Bullet bullet = Bullet.GetComponent<Bullet>();
        bullet.power = power;
        bullet._firePoint = _shootPoint;
        bullet.Fly();
        _animator.SetTrigger("Fire");

        /*transform.GetComponent<Weapon>().*/
        _countBullet--;

        MainUi._instance.LoadGunPlaying(transform.GetComponent<Weapon>());
        yield return new WaitForSeconds(0.1f);
        ObjectPooler._instance.AddElement("Bullet", Bullet);
        Bullet.SetActive(false);

    }

}
