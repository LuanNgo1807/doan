using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlayer
{
    private const string ALL_DATA = "all_data";
    private static InforPlayer inforPlayer;
    static DataPlayer()
    {
        inforPlayer = JsonUtility.FromJson<InforPlayer>(PlayerPrefs.GetString(ALL_DATA));
        if (inforPlayer == null)
        {
            inforPlayer = new InforPlayer
            {
                name = "User",
                ranking = 1,
                isOnMusicBg = true,
                countCoins = 0,
                countDiamond = 0,
                isOnSound = true,
                listIdGun = new List<int>() { 1, 2 },
                level = 1,
                idGun = 1,
                countKeys = 0,
            };
            SaveData();
        }
    }
    private static void SaveData()
    {
        var data = JsonUtility.ToJson(inforPlayer);
        PlayerPrefs.SetString(ALL_DATA, data);
    }
    public static void UpdateAmountCoins(int Amount)
    {
        inforPlayer.countCoins = Amount;
        SaveData();
    }

    public static void UpdateAmountDiamond(int Amount)
    {
        inforPlayer.countDiamond = Amount;
        SaveData();
    }
    public static void ChangeStateAudio(bool IsOnAudio)
    {
        inforPlayer.isOnMusicBg = IsOnAudio;
        SaveData();
    }
    public static void ChangeStateSound(bool IsOnAudio)
    {
        inforPlayer.isOnSound = IsOnAudio;
        SaveData();
    }
    public static void UpdateLevel(int Level)
    {
        inforPlayer.level = Level;
        SaveData();
    }
    public static void UpdateRanking(int Ranking)
    {
        inforPlayer.ranking = Ranking;
        SaveData();
    }
    public static void UpdateName(string name)
    {
        inforPlayer.name = name;
        SaveData();
    }
    public static void AddNewIdGun(int idGun)
    {
        inforPlayer.listIdGun.Add(idGun);
        SaveData();

    }

    public static void UpdateGun(int id)
    {
        inforPlayer.idGun = id;
        SaveData();
    }
    public static void UpdateAmountKeys(int CountKeys)
    {
        inforPlayer.countKeys = CountKeys;
        SaveData();
    }
    public static InforPlayer GetInforPlayer()
    {
        return inforPlayer;
    }
}
public class InforPlayer
{
    public string name;
    public int ranking;
    public bool isOnMusicBg;
    public bool isOnSound;
    public int countCoins;
    public int countDiamond;
    public List<int> listIdGun;


    public int level;
    public int idGun;
    public int countKeys;

}