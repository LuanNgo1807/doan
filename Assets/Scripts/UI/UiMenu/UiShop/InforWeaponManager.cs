using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class InforWeaponManager : Singleton<InforWeaponManager>
{
    [SerializeField] Image _barDamageWeapon;
    [SerializeField] Image _barRateOfFireWeapon;
    [SerializeField] Image _barAccuracyWeapon;
    public Image _barReloadTime;
    [SerializeField] Text _nameWeapon;
    public Text levelTxt;

    public Text damageTxt;
    public Text rateOfFireTxt;
    public Text accuracyTxt;
    public Text reloadTimeTxt;

    [SerializeField] Text _priceWeaponFCoinTxt;
    [SerializeField] Text _priceWeaponFDiamondTxt;

    public GameObject _weaPonCurrent;

    [SerializeField] Vector3 _positionGun;

    public Button buyGunCoinBtn;
    public Button buyGunDiamondBtn;
    public ShopButtonElement shopButtonElement;

    public GameObject priceWeaponUpGrade;
    public GameObject pirceWeaponDiamond;
    public GameObject upGrade;

    public GunData gunData;

    protected override void Awake()
    {
        base.Awake();
        buyGunCoinBtn.onClick.AddListener(BuyGunWithCoin);
        buyGunDiamondBtn.onClick.AddListener(BuyGunWithDiamond);
    }
    public void SetGunOwner()
    {
        priceWeaponUpGrade.SetActive(false);
        pirceWeaponDiamond.SetActive(false);
        upGrade.SetActive(true);
    }
    public void SetGunNotOwner()
    {
        priceWeaponUpGrade.SetActive(true);
        pirceWeaponDiamond.SetActive(true);
        upGrade.SetActive(false);
    }
    public void SetActiveCurrentWeapon()
    {
        _weaPonCurrent.gameObject.SetActive(true);
        _weaPonCurrent.transform.localScale = Vector3.zero;
        _weaPonCurrent.transform.DOScale(_weaPonCurrent.GetComponent<RotateWeapon>().localScale, 0.5f);

    }
    public void SetDeActiveCurrentWeapon()
    {
        _weaPonCurrent.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() => _weaPonCurrent.gameObject.SetActive(false));
    }
    public void ChangePropertiesGun(bool IsOwner, int IdWeapon, bool IsUpGrapdeGun)
    {
        gunData = SelectWeaponUiShop._instance.gunDatas[IdWeapon - 1];
        int idLevelGun = UserDataPref.GetLevelGun(gunData.id) - 1;


        _barDamageWeapon.fillAmount = gunData.listDamage[idLevelGun];
        _barRateOfFireWeapon.fillAmount = gunData.listRateOfFire[idLevelGun];
        _barAccuracyWeapon.fillAmount = gunData.listAccuracy[idLevelGun];
        _barReloadTime.fillAmount = gunData.timeCharge[idLevelGun];

        damageTxt.text = (gunData.listDamage[idLevelGun] * 1000).ToString();
        rateOfFireTxt.text = (gunData.listRateOfFire[idLevelGun] * 1000).ToString();
        accuracyTxt.text = (gunData.listAccuracy[idLevelGun] * 1000).ToString();
        reloadTimeTxt.text = gunData.timeCharge[idLevelGun] + " s";
        _nameWeapon.text = gunData.name;
        levelTxt.text = "Level: " + (idLevelGun + 1);

        if (IsOwner)
        {
            SetGunOwner();
        }
        else
        {
            SetGunNotOwner();
            _priceWeaponFCoinTxt.text = "Buy it for " + gunData.priceForCoint.ToString();
            _priceWeaponFDiamondTxt.text = "Buy it for " + gunData.priceForDiamond.ToString();
        }
        if (!IsUpGrapdeGun)
            CreateWeapon(IdWeapon);

    }
    public void CreateWeapon(int idWeapon)
    {
        if (_weaPonCurrent != null)
        {
            Destroy(_weaPonCurrent);
        }

        if (SelectWeaponUiShop._instance.idTypeWeaPonDisplay == 1)
        {
            string nameGunInAsset = "Gun_" + idWeapon;

            GameObject _newWeapon = Instantiate(Resources.Load("UI/UiShop/TypeWeapon1/" + nameGunInAsset, typeof(GameObject)), _positionGun, Quaternion.identity) as GameObject;
            _weaPonCurrent = _newWeapon;

        }

    }

    public void BuyGunWithCoin()
    {
        if (DataPlayer.GetInforPlayer().countCoins >= gunData.priceForCoint)
        {
            UpdateMoney(true);
        }
        else
        {
            UiNotice._instance.Init(false, "Not enough money");
        }

    }
    public void BuyGunWithDiamond()
    {
        if (DataPlayer.GetInforPlayer().countDiamond >= gunData.priceForDiamond)
        {
            UpdateMoney(false);
        }
        else
        {
            UiNotice._instance.Init(false, "Not enough money");
        }

    }
    void UpdateMoney(bool isCoins)
    {
        UiNotice._instance.Init(true, "Success");
        shopButtonElement.UnLock();
        DataPlayer.AddNewIdGun(gunData.id);
        if (isCoins)
        {
            int AmountCoins = DataPlayer.GetInforPlayer().countCoins - gunData.priceForCoint;
            DataPlayer.UpdateAmountCoins(AmountCoins);
        }
        else
        {
            int AmountDiamond = DataPlayer.GetInforPlayer().countDiamond - gunData.priceForDiamond;
            DataPlayer.UpdateAmountDiamond(AmountDiamond);

        }
        ChangePropertiesGun(true, gunData.id, false);

    }
}
