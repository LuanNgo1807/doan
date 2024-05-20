using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    [SerializeField] GameObject _frag;
    public List<GameObject> listGun;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        StartCoroutine(UseWeapon(true));
    }
    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            //UiScope._instance.SetNormalScope();
            StartCoroutine(UseWeapon(true));
        }
        if (Input.GetKeyDown("2"))
        {
            // UiScope._instance.SetNormalScope();
            StartCoroutine(UseWeapon(false));
        }
    }
    IEnumerator UseWeapon(bool IsGun)
    {
        for(int i=0;i<listGun.Count;i++)
        {
            listGun[i].SetActive(false);
        }

        int idGun = DataPlayer.GetInforPlayer().idGun;
        listGun[idGun-1].GetComponent<Weapon>().StateReady();
        yield return new WaitForSeconds(0.1f);
        listGun[idGun - 1].SetActive(IsGun);
        _frag.SetActive(!IsGun);
        _frag.GetComponent<Weapon>().StateReady();
        MainUi._instance.LoadGunPlaying(_frag.GetComponent<Weapon>());
        MainUi._instance.LoadImageWeapon(!IsGun, idGun);
    }

    public void ChangeGun(int idNewGun)
    {
        DataPlayer.UpdateGun(idNewGun);
        StartCoroutine(UseWeapon(true));
    }
}
