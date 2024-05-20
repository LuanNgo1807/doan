using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class UiShop : Singleton<UiShop>
{
    [SerializeField] Button _quiteBg;
    [SerializeField] Button _quiteBtn;
    [SerializeField] Button _primaryButton;

    [SerializeField] Button _pansButton;

    protected override void Awake()
    {
        _quiteBg.onClick.AddListener(CloseShop);
        _quiteBtn.onClick.AddListener(CloseShop);
        _primaryButton.onClick.AddListener(OpenShopGun);

        _pansButton.onClick.AddListener(OpenpansButton);
    }
 
    void OpenpansButton()
    {

    }   
    void OpenShopGun()
    {
        SelectWeaponUiShop._instance.OpenStoreWeapon(1);
    }
    void OpenShopAuxiliaryItems()
    {
        SelectWeaponUiShop._instance.OpenStoreWeapon(2);
    }
    public void CloseShop()
    {
        Destroy(InforWeaponManager._instance._weaPonCurrent);
        CavasControllerUiMenu._instance.SetActiveMainUi();
    }
}
