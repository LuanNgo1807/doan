using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class UiMap : Singleton<UiMap>
{
    public Button comeback;
    public GameObject mainPanel;
    public List<SelectLevelBtn> listSelectLevel;
    public Vector3 lastMouse;
    public Vector3 currentMouse;
    public InforLevelUI inforLevelUI;
    protected override void Awake()
    {
        base.Awake();
        comeback.onClick.AddListener(ComeBackMenu);
    }
    public void ComeBackMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void Start()
    {
        LevelProgress();
    }
    void LevelProgress()
    {
        for (int i = 0; i < listSelectLevel.Count; i++)
        {
            int CountStar = UserDataPref.GetAmountStarLevel(i + 1); 

            int IdMap = UserDataPref.IdMapPlaying;
          
            if(i<=IdMap)
            {
                listSelectLevel[i].Init(true, CountStar, i+1);
            }
            else
            {
                listSelectLevel[i].Init(false, CountStar, i + 1);
            }
            if(i<IdMap)
            {
                listSelectLevel[i].SetLineNextLevel(true);
            }

        }
    }
    private void Update()
    {
        currentMouse = Input.mousePosition;
        if(Input.GetMouseButtonDown(0))
        {
            lastMouse = currentMouse;
        }
        if(Input.GetMouseButton(0))
        {
            float distance2Pos = lastMouse.x - currentMouse.x;
            if (distance2Pos!=0)
            {
                Vector3 targetPos = new Vector3(mainPanel.transform.localPosition.x + distance2Pos/50, mainPanel.transform.localPosition.y, 0f);
                mainPanel.GetComponent<RectTransform>().localPosition = targetPos;
            }
        }
    }
}
