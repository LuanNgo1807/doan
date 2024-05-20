
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonElement : MonoBehaviour
{
    public Image _backGround;
    public Image _weaponImage;
    public Text _textnameWeapon;
    public Button _btSelectWeapon;
    public GameObject _darkBackGround;
    public GameObject _lock;
    public int level;
    public int idWeapon;
    
    private void Awake()
    {
        _btSelectWeapon.onClick.AddListener(SelectWeapon);

    }

    public void IsLock()
    {
        _darkBackGround.SetActive(true);
        _lock.SetActive(true);
    }
    public void UnLock()
    {
        _darkBackGround.SetActive(false);
        _lock.SetActive(false);
    }
    public void IsButtonGun(int idImage, string NameWeapon, int IdGun)
    {
        _weaponImage.sprite = Resources.Load<Sprite>("Image/Shop/Guns/" + idImage);
        _textnameWeapon.text = NameWeapon;
        idWeapon = IdGun;
    }
    public void IsButtonAuxiliaryItems(int idImage, string NameWeapon, int IdItem)
    {
        _weaponImage.sprite = Resources.Load<Sprite>("Image/Shop/Guns/" + idImage);
        _textnameWeapon.text = NameWeapon;
        idWeapon = IdItem;
    }

    public void SelectWeapon()
    {
        InforWeaponManager._instance.shopButtonElement = gameObject.GetComponent<ShopButtonElement>();
        InforWeaponManager._instance.ChangePropertiesGun( !_lock.activeSelf,idWeapon,false);
    }
}
