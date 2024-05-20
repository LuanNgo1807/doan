using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UiNotice : Singleton<UiNotice>
{
    public Color blue, red;
    public Image backGroundImg;
    public Text noticeTxt;
    public CanvasGroup canvasGr;
    protected override void Awake()
    {
        base.Awake();
        backGroundImg.gameObject.SetActive(false);
    }
    public void Init(bool IsSucces,string NoticeTxt)
    {
        backGroundImg.gameObject.SetActive(true);
        if (IsSucces)
        {
            backGroundImg.color = blue;
        }
        else
        {
            backGroundImg.color = red;
        }
        noticeTxt.text = NoticeTxt;
        backGroundImg.transform.localPosition = Vector3.zero;
        backGroundImg.GetComponent<RectTransform>().DOLocalMoveY(59.28f, 1f).OnComplete(() => backGroundImg.gameObject.SetActive(false));
        //var t = 1;
        //canvasGr.alpha = t;
        //DOTween.To(() => canvasGr.alpha, value => canvasGr.alpha = value, 0, 0.5f);

    }
}
