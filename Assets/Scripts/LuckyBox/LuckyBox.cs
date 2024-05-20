using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LuckyBox : MonoBehaviour
{
    public GameObject chestImg;
    public GameObject coinImg;
    public ParticleSystem particle;
    public TextMeshProUGUI cointTxt;
    public Button boxBtn;
    int amountCoin;
    private void Awake()
    {
        boxBtn.onClick.AddListener(Open);
    }
    private void Start()
    {
        Renew();
    }
    public void Renew()
    {
        chestImg.SetActive(true);
        coinImg.SetActive(false);
        particle.gameObject.SetActive(false);
        coinImg.SetActive(false);
        cointTxt.gameObject.SetActive(false);
    }
    public void Open()
    {
        if (DataPlayer.GetInforPlayer().countKeys > 0 && chestImg.activeSelf)
        {
            particle.gameObject.SetActive(true);
            particle.Play();
            cointTxt.gameObject.SetActive(true);
            chestImg.SetActive(false);
            coinImg.gameObject.SetActive(true);
            amountCoin = int.Parse(cointTxt.text.ToString());

            int amountKeys = DataPlayer.GetInforPlayer().countKeys - 1;
            DataPlayer.UpdateAmountKeys(amountKeys);
            LuckyBoxPanel._instance.DisplayKeys();

            // add coin
            CoinsManager.Instance.InitCoins(transform);
            int amountCoins = DataPlayer.GetInforPlayer().countCoins+int.Parse(cointTxt.text);

            DataPlayer.UpdateAmountCoins(amountCoins);
            MainUiMenu._instance.UpdateCoinsAndDiamonds();
        }else
        {
            UiNotice._instance.Init(false, "Out of slots");
        }
    }

}
