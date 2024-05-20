using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager Instance;
    [Space]
    [Header("aniamtion setting")]
    [SerializeField] [Range(0.5f, 0.9f)] float minAnimDuration;
    [SerializeField] [Range(0.9f, 2f)] float maxAnimDuration;

    [SerializeField] Transform desTransform;
    [SerializeField] Ease easeType;
    [SerializeField] float spread;
    [SerializeField] float _scaleCoin;
    public Transform targetRectTransform;

    public void Awake()
    {
        Instance = this;
    }
    public void InitCoins(Transform DesTransform)
    {
        desTransform = DesTransform;
        StartCoroutine(FadeAnimate(20));
    }
    IEnumerator FadeAnimate(int amount)
    {
        List<GameObject> ListCoins = new List<GameObject>();
        for (int i = 0; i < amount; i++)
        {
            GameObject newCoin = ObjectPooler._instance.SpawnFromPool("Coin", desTransform.position, Quaternion.identity);
            newCoin.SetActive(true);
            newCoin.transform.position = desTransform.position;
            newCoin.transform.localScale = new Vector3(0f, 0f, 0);
            newCoin.transform.LookAt(Camera.main.transform.position, Camera.main.transform.up);
            newCoin.transform.DOScale(_scaleCoin, 0.1f);
            newCoin.transform.DOMove(desTransform.position + new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0f), 0.3f).SetEase(Ease.OutBack);
            ListCoins.Add(newCoin);
        }
        yield return new WaitForSeconds(0.25f);
        for (int i = 0; i < ListCoins.Count; i++)
        {
            float duration = Random.Range(minAnimDuration, maxAnimDuration);
            GameObject CoinPrefab = ListCoins[i].gameObject;
            CoinPrefab.transform.DOMove(targetRectTransform.position, duration)
            .SetEase(easeType)
            .OnComplete(() =>
            {
                CoinPrefab.SetActive(false);
                ObjectPooler._instance.AddElement("Coin", CoinPrefab);
                //  UiAndGame._instance.Coins++;
                //  DataPlayer.UpdateAmountCoins(UiAndGame._instance.Coins);
            });
            yield return new WaitForSeconds(0.05f);
        }
    }



}