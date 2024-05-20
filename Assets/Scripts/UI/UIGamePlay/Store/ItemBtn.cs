using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBtn : MonoBehaviour
{
    public int _idGun;
    public Image _weaponImage;
    public Button _selectBtn;

    private void Awake()
    {
        _selectBtn.onClick.AddListener(LoadGun);
    }
    void LoadGun()
    {
        UiController._instance.CloseStore();
        WeaponManager._instance.ChangeGun(_idGun);
    }
    public void LoadImage()
    {
        _weaponImage.sprite = Resources.Load<Sprite>("Image/Shop/Guns/" + _idGun);
    }
}
