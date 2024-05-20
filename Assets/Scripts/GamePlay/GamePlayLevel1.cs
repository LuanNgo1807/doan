using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayLevel1 : GamePlay
{
    public override void EndGame()
    {
        base.EndGame();
        int AmountStar = base.CalculaterStar();
        int Amountkeys = base.GetNumberKey(AmountStar);
        int AmountDiamond = base.GetNumberDiamond(AmountStar);
        UiController._instance.ActiveEndGameUi(AmountStar, Amountkeys, AmountDiamond);

 
    }

}
