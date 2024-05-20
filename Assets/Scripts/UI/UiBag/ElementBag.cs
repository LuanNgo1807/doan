using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TypeElementBag
{
    Grenad,
    Hp,
    Bullet,
}
public class ElementBag : MonoBehaviour
{
    public TypeElementBag typeElementBag;
    public Text countElementTxt;
    public Button buyMoreItemBtn;
    public int pirceItem;

    public void Awake()
    {
        buyMoreItemBtn.onClick.AddListener(BuyMoreItem);
    }
    private void OnEnable()
    {
        UpdateCountElement();
    }
    public void BuyMoreItem()
    {
        if(DataPlayer.GetInforPlayer().countCoins>=pirceItem)
        {
            int AmountCoins = DataPlayer.GetInforPlayer().countCoins - pirceItem;
            DataPlayer.UpdateAmountCoins(AmountCoins);
            int CountItem = int.TryParse(countElementTxt.text, out int result) ? result : -1;
            if (CountItem !=-1)
            {
                CountItem++;
            }
            UserDataPref.SetAmountAuxiliaryItems((int)typeElementBag, CountItem);
            MainUiMenu._instance.UpdateCoinsAndDiamonds();
            UpdateCountElement();
        }
        else
        {
            UiNotice._instance.Init(false, "Not enough money");
        }
    }
    public void UpdateCountElement()
    {
        countElementTxt.text = UserDataPref.GetAmountAuxiliaryItems((int)typeElementBag).ToString();
    }
}
