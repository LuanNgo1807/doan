using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CavasControllerUiMenu : Singleton<CavasControllerUiMenu>
{
    [SerializeField] GameObject _mainUi;
    [SerializeField] GameObject _shopUi;
    [SerializeField] GameObject _rankUi;
    public GameObject _player;

    [SerializeField] GameObject _mapUi;


    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        //UserDataPref.SetAmountAuxiliaryItems((int)TypeElementBag.Bullet, 300);
        //   DataPlayer a = new DataPlayer();
        MusicController.instance.OnPlayAudio(SoundType.mainmenu);
    }
    public void SetActiveLuckyPanel()
    {
        _mapUi.SetActive(false);
        _player.SetActive(false);
        _mainUi.SetActive(true);
        _shopUi.SetActive(false);
    }

    public void SetActiveShopUi()
    {
        _mapUi.SetActive(false);
        _player.SetActive(false);
        _mainUi.SetActive(false);
        _shopUi.SetActive(true);
    }
    public void SetActiveMainUi()
    {
        _mapUi.SetActive(false);
        _shopUi.SetActive(false);
        _player.SetActive(true);
        _mainUi.SetActive(true);
    }
  
    public void OpenMapUi()
    {

        _shopUi.SetActive(false);
        _player.SetActive(false);
        _mainUi.SetActive(false);
        _mapUi.SetActive(true);
    }
    public void OpenRankingPanel()
    {
        _shopUi.SetActive(false);
        _player.SetActive(false);
        _mainUi.SetActive(false);
        _mapUi.SetActive(false);
    }

}
