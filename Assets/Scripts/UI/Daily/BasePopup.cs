using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class BasePopup : MonoBehaviour
{
    public Button darkBgBtn;
    public GameObject mainObj;

    public virtual void Awake()
    {
        darkBgBtn.gameObject.SetActive(false);
        darkBgBtn.onClick.AddListener(Hide);
        mainObj.SetActive(false);
    }

    public virtual void Hide()
    {
        mainObj.transform.DOScale(0, 0.5f).OnComplete(() =>
        {
            CavasControllerUiMenu._instance._player.SetActive(true);
            darkBgBtn.gameObject.SetActive(false);
            mainObj.SetActive(false);
        });
    }

    public virtual void Show()
    {
        CavasControllerUiMenu._instance._player.SetActive(false);
        mainObj.transform.localScale = new Vector3(0, 0, 0);
        mainObj.SetActive(true);
        mainObj.transform.DOScale(1, 0.5f).OnComplete(() =>
        {
            darkBgBtn.gameObject.SetActive(true);
        });

    }
}
