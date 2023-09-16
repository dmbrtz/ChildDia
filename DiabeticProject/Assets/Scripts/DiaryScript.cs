using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiaryScript : MonoBehaviour
{
    [SerializeField] private TMP_Text statisticText;
    [SerializeField] private GameObject diaryUI;
    public void UpdateText() //������ ������ ���������� ����� ��������� ���� �����-����
    {
        statisticText.text += "\n" + "����-" + PlayerPrefs.GetInt("Day").ToString() + ", ������-" + PlayerPrefs.GetInt("sugarInDay").ToString() + "(�����)";
        PlayerPrefs.SetString("stattext", statisticText.text);
    }

    public void UpdateTextBad() //������ ������ ���������� ����� ��������� ���� ����� -������
    {
        statisticText.text += "\n" + "����-" + PlayerPrefs.GetInt("Day").ToString() + ", ������-" + PlayerPrefs.GetInt("sugarInDay").ToString() + "(�����)";
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

