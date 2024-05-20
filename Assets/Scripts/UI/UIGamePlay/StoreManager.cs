using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public List<GameObject> listItemButtonWeapon;
    private void OnEnable()
    {
        LoadDataStoreUnlocked();
    }
    public  void LoadDataStoreUnlocked()
    {
        for (int i=0;i< listItemButtonWeapon.Count;i++)
        {
            if(i< DataPlayer.GetInforPlayer().listIdGun.Count)
            {
                listItemButtonWeapon[i].GetComponent<ItemBtn>()._idGun = DataPlayer.GetInforPlayer().listIdGun[i];
                listItemButtonWeapon[i].GetComponent<ItemBtn>().LoadImage();
            }
            else
            {
                listItemButtonWeapon[i].gameObject.SetActive(false);
            }    

        }

    }
}
