using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UiController : Singleton<UiController>
{
    [SerializeField] GameObject _uiStore;
    [SerializeField] StoreManager _storeManager;
    [SerializeField] UiEndGame _uiEndGame;
    [SerializeField] GameObject _scope;

    // Zone When play hit
    public GameObject HitZone;
    public float CountTimeHizone;
    public GameObject cameraObj;
    private void Start()
    {
    //   PlayerPrefs.DeleteAll();
        CountTimeHizone = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown("z")&&UiScope._instance.NormalScope.activeSelf&&PlayerController.instance.statePlayer!=PlayerController.StatePlayer.Die)
        {
            if (_uiStore.activeSelf)
            {
                CloseStore();
            }
            else
            {
                OpenStore();
            }
        }
        CountTimeHizone += Time.deltaTime;
        if (CountTimeHizone >= 2)
        {
            HitZone.SetActive(false);
            CountTimeHizone = 0;
        }
        if(Input.GetKeyDown("j"))
        {
            EnableCursor();
            SceneManager.LoadScene(0);
        }

        if(Input.GetKeyDown("h"))
        {
            int NumberHp = UserDataPref.GetAmountAuxiliaryItems((int)TypeElementBag.Hp);
            if (NumberHp == 0)
                return;
            PlayerController.instance.AddHp(500f, null);
            UserDataPref.SetAmountAuxiliaryItems((int)TypeElementBag.Hp, NumberHp - 1);
        }
    }
    public void OpenStore()
    {
        _uiStore.SetActive(true);
        GameState.stateGame = StateGame.OpenStore;
        EnableCursor();
    }
    public void CloseStore()
    {
        _uiStore.SetActive(false);
        GameState.stateGame = StateGame.Playing;
        DisableCursor();
    }
    public void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void EnableHitZone()
    {
        if (!HitZone.activeSelf)
        {
            HitZone.SetActive(true);
        }
    }
    public void ActiveEndGameUi(int NumberStar, int NumberKeys, int NumberDiamond)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        HitZone.SetActive(false);
        cameraObj.SetActive(true);
        _scope.SetActive(false);
        _uiEndGame.gameObject.SetActive(true);
        _uiEndGame.Show(NumberStar,NumberKeys,NumberDiamond);
 
    }
}
