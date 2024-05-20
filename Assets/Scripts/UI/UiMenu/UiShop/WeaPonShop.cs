using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaPonShop
{
    public int idType;
    public int idWeapon;
    public int level;
    public string name;
    public float damage;
    public float rateOfFire;
    public float accuracy;
    public int priceForCoin;
    public int priceForDiamond;

}
[System.Serializable]
public class DataListWeapon
{
  public  WeaPonShop[] ListDataGun;
}