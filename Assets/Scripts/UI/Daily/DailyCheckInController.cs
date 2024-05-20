using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyCheckInController  : BasePopup
{
    public static DailyCheckInController Instance;
    public List<ElementRewarDaily> listElementRewar;

    // Số ngày đã điểm danh
    private int daysCheckedIn = 0;

    // Ngày hiện tại
    private int currentDay = 0;

    // Thời điểm lần cuối điểm danh
    private int lastCheckInTime = 0;
    public override void Awake()
    {
        base.Awake();
        Instance = this;

    }
    public void Start()
    {
      //  PlayerPrefs.DeleteAll();
        CheckClaimReward(false);
    }

    public void CheckClaimReward(bool IsClick)
    {
        daysCheckedIn = PlayerPrefs.GetInt("DaysCheckedIn", 0);
        lastCheckInTime = PlayerPrefs.GetInt("LastCheckInTime", 0);
        currentDay = System.DateTime.Now.DayOfYear;

        if (currentDay == lastCheckInTime)
        {
            Debug.Log("You have already checked in today!");
        }
        else
        {
            IsClick = true;
            daysCheckedIn++;
            PlayerPrefs.SetInt("DaysCheckedIn", daysCheckedIn);
            PlayerPrefs.SetInt("LastCheckInTime", System.DateTime.Now.DayOfYear);
            listElementRewar[daysCheckedIn - 1].ReceiverRewar();
            MainUiMenu._instance.UpdateCoinsAndDiamonds();
        }
        CheckReward();
        if(IsClick)
        base.Show();
    }
    public void CheckReward()
    {
        for(int i=0;i<daysCheckedIn;i++)
        {
            listElementRewar[i].darkBg.SetActive(false);
        }
    }

}
