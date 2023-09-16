using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleppingUpdate : MonoBehaviour
{
    public SleepScript sleeps;
    [SerializeField] GameObject nextdayUI;
    public void NextDay()
    {
        sleeps.LoadNextDay();

    }
    public void CloseUINextDay()
    {
        nextdayUI.SetActive(false);
    }
}
