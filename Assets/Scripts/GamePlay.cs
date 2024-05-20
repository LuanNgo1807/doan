using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public List<EnemyController> ListEnemys;
    public int IdLevel;
    public InforLevelData inforLevelData;

    public virtual int GetCountEnemies()
    {
        return ListEnemys.Count;
    }
    public virtual void CheckEnemysColistionWihtBoom(Transform BomTrans)
    {
        for (int i = 0; i < ListEnemys.Count; i++)
        {
            float DisEnemyBoom = Vector3.Distance(ListEnemys[i].transform.position, BomTrans.position);
            if (DisEnemyBoom < 5)
            {
                ListEnemys[i].Damage(500f);
            }
        }
    }
    public virtual void EndGame()
    {
        Debug.Log("EndGame");
        PlayerController.instance.ControllerPlayer(false);
    }
    public virtual void SetCantFindObj()
    {

    }
    public virtual int CalculaterStar()
    {
        float DeathRate = (ListEnemys.Count - MainUi._instance.CurrentAmountEnemy) / (float)ListEnemys.Count;
        int AmountStar = 0;
        if (DeathRate >= 1)
        {
            AmountStar = 3;
        }
        else if (DeathRate < 1 && DeathRate >= 0.5)
        {
            AmountStar = 2;
        }
        else if (DeathRate < 0.5 && DeathRate >= 0.1)
        {
            AmountStar = 1;
        }
        else
        {
            AmountStar = 0;
        }
        if (UserDataPref.GetAmountStarLevel(IdLevel) < AmountStar)
        {
            UserDataPref.SetAmountStarLevel(IdLevel, AmountStar);
        }
        return AmountStar;
        // UpdateDiamondAndKey(AmountStar);
    }
    public int GetNumberKey(int NumberStar)
    {
        if (NumberStar >= 2)
        {
            UserDataPref.IdMapPlaying = UserDataPref.IdMapPlaying + 1;
        }

        if (NumberStar >0)
        {
            int NumberKeys = DataPlayer.GetInforPlayer().countKeys + inforLevelData.reward[NumberStar - 1].numberKey;
            if (NumberKeys > 3)
                NumberKeys = 3;
            DataPlayer.UpdateAmountKeys(NumberKeys);
            return inforLevelData.reward[NumberStar - 1].numberKey;
        }
        else
        {
            return 0;
        }

    }
    public int GetNumberDiamond(int NumberStar)
    {
        if (NumberStar >0)
        {
            int NumberDiamond = DataPlayer.GetInforPlayer().countDiamond + inforLevelData.reward[NumberStar - 1].numberDimond;
            DataPlayer.UpdateAmountDiamond(NumberDiamond);
            return inforLevelData.reward[NumberStar - 1].numberDimond;
        }
        else
        {
            return 0;
        }

    }
}
