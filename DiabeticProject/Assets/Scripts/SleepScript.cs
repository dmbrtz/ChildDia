using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UIElements.Slider;

public class SleepScript : MonoBehaviour
{
    [SerializeField] private TMP_Text dayText;
    [SerializeField] private TMP_Text sugarText;
    [SerializeField] private GameObject errorUI;
    [SerializeField] private GameObject nextdayUI;
    public EnergyBar energyBar;
    public int dayer;
    public int sugaring;
    public DiaryScript statistic;
    public AutSave saver;
    public WindowGraph graphic;
    [SerializeField] private GameObject ura;
   
    private void Update()
    {
        sugaring = Convert.ToInt32(sugarText.text);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Day"))
        {
            dayer = PlayerPrefs.GetInt("Day");
            dayText.text = dayer.ToString();
        }
        else
        {
            dayer = 1;
            dayText.text = dayer.ToString();
        }
    }

    public void SleepBT()
    {
        if (sugaring < 3)
        {
            errorUI.SetActive(true);
        }
        else if (sugaring >= 3)
        {
            if(sugaring <= PlayerPrefs.GetInt("playerSugarBorder"))
            {
                PlayerPrefs.SetInt("sugarInDay", Convert.ToInt32(sugarText.text));
                PlayerPrefs.SetInt("Day", Convert.ToInt32(dayText.text));
                errorUI.SetActive(false);
                nextdayUI.SetActive(true);
                ura.SetActive(true);
                statistic.UpdateText();
                graphic.AddValueFromPlayerPrefs();
                graphic.SaveListToPlayerPrefs();
            }
           else
            {
                PlayerPrefs.SetInt("sugarInDay", Convert.ToInt32(sugarText.text));
                PlayerPrefs.SetInt("Day", Convert.ToInt32(dayText.text));
                errorUI.SetActive(false);
                nextdayUI.SetActive(true);
                statistic.UpdateTextBad();
                graphic.AddValueFromPlayerPrefs();
                graphic.SaveListToPlayerPrefs();
            }
        }
      
    }

    public void LoadNextDay()
    {

        sugaring = PlayerPrefs.GetInt("playerSugarBorder") / 2 ;
        dayer = dayer + 1;
        dayText.text = dayer.ToString();
        energyBar.ResetSugar();
        sugarText.text = energyBar.sugarnum.ToString();
        energyBar.slider.value = 100f;
        PlayerPrefs.SetFloat("EnergyBar", energyBar.slider.value);
        Animator nextdayUIAnim = nextdayUI.GetComponent<Animator>();
        nextdayUIAnim.Play("closeNEXT");
        ura.SetActive(false);
        saver.SaveGame();
    }

    public void CloseUINextDay()
    {
        nextdayUI.SetActive(false);
    }
}
