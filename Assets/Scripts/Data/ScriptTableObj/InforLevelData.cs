using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RewardLevel
{
    public int numberStar;
    public int numberDimond;
    public int numberKey;
}

[CreateAssetMenu(fileName = "InforLevelData", menuName = "ScriptableObjects/InforLevelData", order = 1)]
public class InforLevelData : ScriptableObject
{
    public int idLevel;
    public string mission;
    public List<RewardLevel> reward;
}
