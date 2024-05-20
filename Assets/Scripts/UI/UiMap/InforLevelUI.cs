using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class InforLevelUI : MonoBehaviour
{
    int idLevel;
    public Text levelTxt;
    public Text MissionTxt;
    public List<Text> starTxt;
    public List<Text> diamondTxt;
    public List<Text> keysTxt;

    public Button playBtn;
    public Button closeBtn;
    public List<InforLevelData> listInforLevelDatas;
    public GameObject mainObj;

    private void Awake()
    {
        playBtn.onClick.AddListener(PlayGame);
        closeBtn.onClick.AddListener(CloseTab);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(idLevel);
    }
    public void Init(int IdLevel)
    {
        idLevel = IdLevel;
        gameObject.SetActive(true);
        mainObj.GetComponent<RectTransform>().localScale = Vector3.zero;
        mainObj.GetComponent<RectTransform>().DOScale(Vector3.one, 0.5f);

        InforLevelData inforLevelData = listInforLevelDatas[IdLevel - 1];

        levelTxt.text = "Infor Level: " + inforLevelData.idLevel;
        MissionTxt.text = "Mission: " + inforLevelData.mission;

        for (int i = 0; i < 3; i++)
        {
            starTxt[i].text = inforLevelData.reward[i].numberStar.ToString();
            diamondTxt[i].text = inforLevelData.reward[i].numberDimond.ToString();
            keysTxt[i].text = inforLevelData.reward[i].numberKey.ToString();
        }
    }
    public void CloseTab()
    {
        mainObj.GetComponent<RectTransform>().DOScale(Vector3.zero, 0.5f).OnComplete(() => gameObject.SetActive(false));
    }
}
