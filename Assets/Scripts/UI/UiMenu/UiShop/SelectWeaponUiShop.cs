using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SelectWeaponUiShop : Singleton<SelectWeaponUiShop>
{
    public int idTypeWeaPonDisplay;
    public UpgrapdeWeapon upgrapdeWeapon;
    public Button upGrapdeBtn;
    public List<GunData> gunDatas;  
    public List<GunData> auxiliaryItemsDatas;
    public List<ShopButtonElement> listShopButtonElement;

    protected override void Awake()
    {
        idTypeWeaPonDisplay = 1;
        base.Awake();
        upGrapdeBtn.onClick.AddListener(UpGrapde);
    }
    private void OnEnable()
    {
        OpenStoreWeapon(idTypeWeaPonDisplay);
    }
    public void UpGrapde()
    {
       upgrapdeWeapon.Init(InforWeaponManager._instance.gunData.id);
    }

    // chosse = 1 create list guns
    // chosse = 2 create auxiliaryItems
    // chosse = 3 create list pans
    public void OpenStoreWeapon(int idTypeWeaPon)
    {
        for (int i = 0; i < listShopButtonElement.Count; i++)
        {
           CreateListGuns(i, idTypeWeaPon, listShopButtonElement[i]);
        }
         DOVirtual.DelayedCall(0.1f,listShopButtonElement[0].SelectWeapon);
    }
    private void OnDisable()
    {
        DOTween.KillAll();
    }

    void CreateListGuns(int i, int TypeWeapon, ShopButtonElement shopButtonE)
    {
        switch (TypeWeapon)
        {
            case 1:

                if (i >= gunDatas.Count)
                {
                    shopButtonE.IsButtonGun(i+1, "NewGun",1000);
                }
                else
                {
                    shopButtonE.IsButtonGun(i+1, gunDatas[i].name, gunDatas[i].id);

                }

                break;
            case 2:
                shopButtonE.IsButtonAuxiliaryItems(i + 1, auxiliaryItemsDatas[i].name, auxiliaryItemsDatas[i].id);
                break;
            case 3:

                break;
        };

        if (!DataPlayer.GetInforPlayer().listIdGun.Contains(i+1))
        {
            shopButtonE.IsLock();
        }
    }
}