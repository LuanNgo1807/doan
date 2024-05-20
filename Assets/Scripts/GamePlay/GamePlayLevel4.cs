using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayLevel4 : GamePlay
{
    public override int CalculaterStar()
    {
        int AmountStar = 0;
        if (UiCountTime._instance.totalTime > 60)
        {
            AmountStar = 1;
        }
        else if (UiCountTime._instance.totalTime > 30)
        {
            AmountStar = 2;
        }
        else if (UiCountTime._instance.totalTime < 10)
        {
            AmountStar = 3;
        }
        if (UserDataPref.GetAmountStarLevel(IdLevel) < AmountStar)
        {
            UserDataPref.SetAmountStarLevel(IdLevel, AmountStar);
        }
        // UpdateDiamondAndKey(AmountStar);
        return AmountStar;
    }

    public override void EndGame()
    {
        base.EndGame();
        int AmountStar = base.CalculaterStar();
        int Amountkeys = base.GetNumberKey(AmountStar);
        int AmountDiamond = base.GetNumberDiamond(AmountStar);
        UiController._instance.ActiveEndGameUi(AmountStar, Amountkeys, AmountDiamond);
    }
}
