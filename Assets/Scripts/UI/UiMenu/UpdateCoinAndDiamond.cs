using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCoinAndDiamond : MonoBehaviour
{
    [SerializeField] Text _amountCoinTxt;
    [SerializeField] Text _amountDiamondTxt;

    private void OnEnable()
    {
        _amountCoinTxt.text = DataPlayer.GetInforPlayer().countCoins.ToString();
        _amountDiamondTxt.text = DataPlayer.GetInforPlayer().countDiamond.ToString();
    }
}
