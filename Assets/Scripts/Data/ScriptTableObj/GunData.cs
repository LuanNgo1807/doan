using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GunData",menuName ="ScriptableObjects/GunData",order =1)]
public class GunData:ScriptableObject
{
    public int id;
    public string nameGun;
    public int priceForCoint;
    public int priceForDiamond;

    public List<float> listDamage;
    public List<float> listRateOfFire;
    public List<float> listAccuracy;
    public List<int>   priceUpGrapde;
    public List<float> timeCharge;
    public int numberBullets;

    public bool scope;
    public bool isStart;

    public void OnValidate()
    {
        if(isStart)
        {
            float value = 0.2f;
            for (int i = 0; i < 5; i++)
            {
                listDamage.Add(value);
                listRateOfFire.Add(value);
                listAccuracy.Add(value);
                value += 0.2f;
            }
        }
    }
}
    