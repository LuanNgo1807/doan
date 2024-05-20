using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class UiEndGame : MonoBehaviour
{
    public static UiEndGame instance;
    [SerializeField] Button ComeBackBtn;
    [SerializeField] Button ComeBackMenu;
    [SerializeField] CanvasGroup _canvasGr;

    public List<Image> ListImages;
    public Text diamondTxt;
    public Text keyTxt;
    public void Awake()
    {
        instance = this;
        ComeBackBtn.onClick.AddListener(LoadSceneAgain);
        ComeBackMenu.onClick.AddListener(LoadMainScene);
    }
    public void Show(int NumberStar, int NumberKeys, int NumberDiamond)
    {
        foreach (var i in ListImages)
        {
            i.gameObject.SetActive(false);
        }
        _canvasGr.alpha = 0;
        DOTween.To(() => _canvasGr.alpha, value => _canvasGr.alpha = value, 1, 0.5f).OnComplete(() =>
        {
            StartCoroutine(LoadStar(NumberStar, NumberKeys, NumberDiamond));
        });
    }
    IEnumerator LoadStar(int NumberStar, int NumberKeys, int NumberDiamond)
    {
        for(int i=0;i<NumberStar;i++)
        {
            yield return new WaitForSeconds(0.5f);
            ListImages[i].gameObject.SetActive(true);
        }
        diamondTxt.text = NumberDiamond.ToString();
        keyTxt.text = NumberKeys.ToString();

        if(NumberStar==3)
        {
            DataPlayer.UpdateLevel(DataPlayer.GetInforPlayer().level + 1);
        }    
    }
    public void LoadSceneAgain()
    {
        int IdLevel = GameManager._instance.gamePlay.IdLevel;
        SceneManager.LoadScene(IdLevel);
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
