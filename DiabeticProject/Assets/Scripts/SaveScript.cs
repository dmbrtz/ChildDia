using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UI.Toggle;
using TMPro;
using Slider = UnityEngine.UI.Slider;

public class SaveScript : MonoBehaviour
{
    [SerializeField] private InputField ageField;
    [SerializeField] private InputField sugarborderField;
    [SerializeField] private GameObject errorText;
    [SerializeField] private GameObject doneText;
    [SerializeField] private Toggle diaryToggle;
    [SerializeField] private Toggle reminderToggle;
    [SerializeField] private GameObject sugarerror;

   private void Awake()
    {
            ageField.text = PlayerPrefs.GetString("playerAge");
            sugarborderField.text = PlayerPrefs.GetString("playerSugarBorder");

        int diaryValue = PlayerPrefs.GetInt("diaryValue");
        if (diaryValue == 1)
        {
           diaryToggle.isOn = true;
        }
        else
        {
            diaryToggle.isOn = false;
        }

        int remindValue = PlayerPrefs.GetInt("remindValue");
        if (remindValue == 1)
        {
           reminderToggle.isOn = true;
        }
        else
        {
            reminderToggle.isOn = false;
        }

    }
    public void SettingSave()
    {
        if(string.IsNullOrEmpty(ageField.text) || string.IsNullOrEmpty(sugarborderField.text))
        {
             errorText.SetActive(true);
        }
        else if(Convert.ToInt32(sugarborderField.text) < 4)
        {
            sugarerror.SetActive(true);
        }
        else
        {

            PlayerPrefs.SetString("playerAge", ageField.text);
            PlayerPrefs.SetInt("playerSugarBorder", Convert.ToInt32(sugarborderField.text));
            PlayerPrefs.Save();


            int diaryValue;
            if (diaryToggle.isOn)
            {
                diaryValue = 1;
            }
            else
            {
                diaryValue = 0;
            }
            PlayerPrefs.SetInt("diaryValue", diaryValue);

            int remindValue;
            if (reminderToggle.isOn)
            {
                remindValue = 1;
            }
            else
            {
                remindValue = 0;
            }
            PlayerPrefs.SetInt("remindValue", remindValue);

            doneText.SetActive(true);
            errorText.SetActive(false);
            sugarerror.SetActive(false);
        }
    }


}
