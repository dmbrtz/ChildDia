using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AutSave : MonoBehaviour
{
    [SerializeField] private TMP_Text sugarText;
    [SerializeField] private TMP_Text dayText;
    [SerializeField] private Slider slider;
    public EnergyBar bar;
    public void SaveGame() //сохранение параметров перса
    {
        PlayerPrefs.SetInt("sugarInDay", bar.sugarnum);
        PlayerPrefs.SetInt("Day", Convert.ToInt32(dayText.text));
        PlayerPrefs.SetFloat("EnegryBar", slider.value);
    }
}


