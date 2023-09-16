using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startUI;
    [SerializeField] InputField answerfield;
    private string answertext;
    [SerializeField] private GameObject diaryBT;
    [SerializeField] private GameObject errortext;
    [SerializeField] private GameObject checkpanel;
    [SerializeField] private GameObject settingspanel;
    void Start()
    {
        startUI.SetActive(true);
        if (PlayerPrefs.GetInt("diaryValue") == 1)
        {
            diaryBT.SetActive(true);
        }
        else
        {
            diaryBT.SetActive(false);
        }
    }

    public void CheckingAnswer() //проверка на ответ на вопрос в главном меню
    {
        answertext = answerfield.text;
        if(answertext == "2")
        {
            errortext.SetActive(false);
            settingspanel.SetActive(true);
            Animator settingsUIAnim = settingspanel.GetComponent<Animator>();
            settingsUIAnim.Play("SettingsStart");
            
        }
        else
        {
            errortext.SetActive(true);
        }

    }
}
