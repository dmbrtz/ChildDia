using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiaryScript : MonoBehaviour
{
    [SerializeField] private TMP_Text statisticText;
    [SerializeField] private GameObject diaryUI;
    public void UpdateText() //апдейт текста статистики после засыпания если сахар-норм
    {
        statisticText.text += "\n" + "День-" + PlayerPrefs.GetInt("Day").ToString() + ", сахара-" + PlayerPrefs.GetInt("sugarInDay").ToString() + "(Норма)";
        PlayerPrefs.SetString("stattext", statisticText.text);
    }

    public void UpdateTextBad() //апдейт текста статистики после засыпания если сахар -плохой
    {
        statisticText.text += "\n" + "День-" + PlayerPrefs.GetInt("Day").ToString() + ", сахара-" + PlayerPrefs.GetInt("sugarInDay").ToString() + "(Плохо)";
        PlayerPrefs.SetString("stattext", statisticText.text);
    }

    public void NextPage()
    {
        statisticText.pageToDisplay++;
    }

    public void BackPage()
    {
        statisticText.pageToDisplay--;
    }

    public void LoadDiary()
    {
        diaryUI.SetActive(true);
    }

    public void CloseDiary()
    {
        diaryUI.SetActive(false);
    }

    public void EraseStatistic()
    {
        statisticText.text = "";
    }
}

