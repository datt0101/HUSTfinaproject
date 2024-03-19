using System;
using System.Threading;
using UnityEngine;
public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;
    private float timer;
    private float minuteToRealTime = 2f; // 1 phut = 2 giay ngoai doi
    [SerializeField] private static int minute, hour;
    [SerializeField] private static Period period;

    public static int Minute { get => minute;}
    public static int Hour { get => hour; }
    internal static Period Period { get => period; set => period = value; }

    private void Start()
    {
        minute = 0;
        hour = 7;
        timer = minuteToRealTime;
        Period = Period.Morning;
    }

    private void Update()
    {
        CalculateTime();
    }

    public void CalculateTime()
    {
        timer -= Time.deltaTime;
        if (timer <=0)
        {
            minute++;
            OnMinuteChanged?.Invoke();
            if (minute >= 60)
            {
                hour++;
                minute = 0;
                CalculatePeriod();
                OnHourChanged?.Invoke();
            }
            timer = minuteToRealTime;
        }
    }

    public void CalculatePeriod()
    {
        if (hour <= 5)
            Period = Period.Night;
        else if (hour <= 12)
            Period = Period.Morning;
        else if (hour <= 18)
            Period = Period.Afternoon;
        else
            Period = Period.Evening;
    }
}

enum Period
{
    Morning,
    Afternoon,
    Evening,
    Night
}



