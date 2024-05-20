using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class LuckyBoxPanel : BasePopup
{
    public static LuckyBoxPanel _instance;
    public GameObject[] arrayKeys;
    public List<LuckyBox> listBoxBtn;
    public GameObject Content;

    public override void Awake()
    {
        _instance = this;
        LoadAllBoxBtn();
        base.Awake();

        DisplayKeys();
    }
    private void OnEnable()
    {
        RenewAllBoxBtn();
    }
    public override void Show()
    {
        base.Show();
    }
    public override void Hide()
    {
        base.Hide();
    }
    public void DisplayKeys()
    {
        int CountKey = DataPlayer.GetInforPlayer().countKeys;
        for (int i = 0; i < CountKey; i++)
        {
           arrayKeys[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        for(int i= CountKey;i<3;i++)
        {
            arrayKeys[i].transform.GetChild(0).gameObject.SetActive(true);
        }    
    }
    public void LoadAllBoxBtn()
    {
        int countBoxBtn = Content.transform.childCount;

        for(int i=0;i<countBoxBtn;i++)
        {
            listBoxBtn.Add(Content.transform.GetChild(i).gameObject.GetComponent<LuckyBox>());
        }
    }
    public void RenewAllBoxBtn()
    {
        for(int i=0;i<listBoxBtn.Count;i++)
        {
            listBoxBtn[i].Renew();
        }
    }

}
