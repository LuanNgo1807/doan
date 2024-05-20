using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TypeElementRewarDaily
{
    coins,
    diamond,
    key,
    hp,
    scope,
    boom,
}
public class ElementRewarDaily : MonoBehaviour
{
    public TypeElementRewarDaily typeElementRollCall;
    public GameObject darkBg;
    public int countReward;
    public void ReceiverRewar()
    {
        if(typeElementRollCall==TypeElementRewarDaily.coins)
        {
            int AmountCoins = DataPlayer.GetInforPlayer().countCoins + countReward;
            DataPlayer.UpdateAmountCoins(AmountCoins);
        }else if(typeElementRollCall== TypeElementRewarDaily.diamond)
        {
            int AmountCoins = DataPlayer.GetInforPlayer().countDiamond + countReward;
            DataPlayer.UpdateAmountCoins(AmountCoins);
        }
        else if(typeElementRollCall==TypeElementRewarDaily.scope)
        {

        }
    }
}
