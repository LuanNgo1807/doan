using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MainUi : Singleton<MainUi>
{
    public Image healthBar;
    public TextMeshProUGUI enemyTxt;
    public int CurrentAmountEnemy;
    private int TotalAmountEnemy;

    public Image GunImg;
    public TextMeshProUGUI nameGunTxt;
    public TextMeshProUGUI CountBulletTxt;
    private void Start()
    {
        TotalAmountEnemy = GameManager._instance.gamePlay.GetCountEnemies();
        CurrentAmountEnemy = TotalAmountEnemy;
        enemyTxt.text = CurrentAmountEnemy + "/" + TotalAmountEnemy;

    }
    public void ChangeFillAmountHealth(float CountHealth)
    {
        //if(Random.RandomRange(1,7)==1)
        //{
            healthBar.fillAmount = healthBar.fillAmount + CountHealth;
       // }
    }
    private void OnEnable()
    {
        EventManager.EnemyDie += DisplayAmountEnemy;
    }
    private void OnDisable()
    {
        EventManager.EnemyDie -= DisplayAmountEnemy;
    }
    public void DisplayAmountEnemy()
    {
        CurrentAmountEnemy--;
        enemyTxt.text = CurrentAmountEnemy + "/" + TotalAmountEnemy;
        if(CurrentAmountEnemy<=0)
        {
            GameManager._instance.gamePlay.EndGame();
        }
    }

    public void LoadGunPlaying(Weapon weapon)
    {
        CountBulletTxt.text = weapon.GetNumberBullets() + "/" + weapon.GetTotalBullet();
    }
    public void LoadImageWeapon(bool IsFrag, int idGun)
    {
        if (!IsFrag)
        {
            GunImg.sprite = Resources.Load<Sprite>("Image/Shop/Guns/" + idGun);
        }
        else
        {
            GunImg.sprite = Resources.Load<Sprite>("Image/Shop/Frag/" + 1);
        }
    }
}
