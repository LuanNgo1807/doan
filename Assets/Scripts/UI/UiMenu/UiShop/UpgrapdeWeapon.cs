using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UpgrapdeWeapon : MonoBehaviour
{
    public Button quiteBtn;

    public Text levelGunTxt;
    public Text nameGunTxt;
    public Text tutorialTxt;

    public Image damageBar;
    public Image rateRireBar;
    public Image accuracyBar;
    public Image timeReloadBar;


    public Text damageTxt;
    public Text rateFireTxt;
    public Text accuracyTxt, timeReLoadTxt;

    public Text priceDiamondTxt;
    public Button upGradeBtn;

    public int nextIdLevelGun;
    GunData gunData;

    private void Awake()
    {
        quiteBtn.onClick.AddListener(CloseTab);
        upGradeBtn.onClick.AddListener(upGradeWeapon);
    }
    public void Init(int IdGun)
    {
        nextIdLevelGun = UserDataPref.GetLevelGun(IdGun) + 1;
        if (nextIdLevelGun > 5)
        {
            UiNotice._instance.Init(false, "Max Level");
            return;
        }

        InforWeaponManager._instance.SetDeActiveCurrentWeapon();

        gameObject.SetActive(true);
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(new Vector3(1, 1, 1), 0.5f);

        gunData = SelectWeaponUiShop._instance.gunDatas[IdGun - 1];


        levelGunTxt.text = (nextIdLevelGun - 1).ToString();
        nameGunTxt.text = gunData.nameGun;
        tutorialTxt.text = "Nâng cấp để xếp hạng level " + nextIdLevelGun;
        damageBar.fillAmount = gunData.listDamage[nextIdLevelGun - 1];
        rateRireBar.fillAmount = gunData.listRateOfFire[nextIdLevelGun - 1];
        accuracyBar.fillAmount = gunData.listAccuracy[nextIdLevelGun - 1];
        timeReloadBar.fillAmount = gunData.timeCharge[nextIdLevelGun - 1];

        damageTxt.text = (gunData.listDamage[nextIdLevelGun - 1] * 1000).ToString();
        rateFireTxt.text = (gunData.listRateOfFire[nextIdLevelGun - 1] * 1000).ToString();
        accuracyTxt.text = (gunData.listAccuracy[nextIdLevelGun - 1] * 1000).ToString();
        timeReLoadTxt.text = gunData.timeCharge[nextIdLevelGun - 1]+ " s";
        priceDiamondTxt.text = gunData.priceUpGrapde[nextIdLevelGun - 1].ToString();


    }
    public void loadInforWeaponLevelUp()
    {

    }
    public void upGradeWeapon()
    {
        if (DataPlayer.GetInforPlayer().countDiamond >= gunData.priceUpGrapde[nextIdLevelGun - 1])
        {

            int AmountDiamond = DataPlayer.GetInforPlayer().countDiamond - gunData.priceForDiamond;
            DataPlayer.UpdateAmountDiamond(AmountDiamond);

            UserDataPref.SetLevelGun(gunData.id, nextIdLevelGun);
            CloseTab();
            UiNotice._instance.Init(true, "Succes");
            InforWeaponManager._instance.ChangePropertiesGun(true, gunData.id, false);
        }
        else
        {
            UiNotice._instance.Init(false, "Not Enough Money");
        }


    }

    public void CloseTab()
    {
        InforWeaponManager._instance.SetActiveCurrentWeapon();
        transform.DOScale(new Vector3(0, 0, 0), 0.5f).OnComplete(() => gameObject.SetActive(false));
    }
}
