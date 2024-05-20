using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevelBtn : MonoBehaviour
{
    //public Image bgImg;

    public Text levelTxt;
    public Image LineNextLevel;
    public PerformanceLevel performanceLevel;
    public Button mapSelectBtn;
    int idLevel;
    public bool isLock;
    public GameObject star;

    public GameObject IconLock;
    private void Awake()
    {
        mapSelectBtn.onClick.AddListener(LoadMap);
    }
    public void Init(bool IsPassed, int CountStar, int IdLevel)
    {
        isLock = !IsPassed;
        idLevel = IdLevel;
        levelTxt.color = Color.white;

        IconLock.SetActive(!IsPassed);
        star.SetActive(IsPassed);
        levelTxt.text = IdLevel.ToString();
        performanceLevel.CompleteStar(CountStar);
    }

    public void SetLineNextLevel(bool IsGreen)
    {
        if(!IsGreen)
        {
            LineNextLevel.color = Color.white;
        }
        else
        {
            LineNextLevel.color = Color.green;
        }
    }

    public void LoadMap()
    {
        if (isLock)
            return;
        UiMap._instance.inforLevelUI.Init(idLevel);
    }
}
