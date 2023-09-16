using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevels : MonoBehaviour
{
    [Header("NewGame")]
    [SerializeField] private Toggle manTG;
    [SerializeField] private Toggle womanTG;
    public EnergyBar energy;
    [SerializeField] private GameObject notenergyui;
    public AutSave saver;
   
    public void LoadNewGame()
    {
        if (manTG.isOn)
        {
            SceneManager.LoadScene(1);
            PlayerPrefs.SetInt("Scene", 1);
            PlayerPrefs.DeleteKey("sugarInDay");
            PlayerPrefs.DeleteKey("Day");
            PlayerPrefs.DeleteKey("EnegryBar");
            PlayerPrefs.DeleteKey("stattext");
            PlayerPrefs.DeleteKey("ValueList");
            
        }
        else if (womanTG.isOn)
        {
            SceneManager.LoadScene(2);
            PlayerPrefs.DeleteKey("sugarInDay");
            PlayerPrefs.DeleteKey("Day");
            PlayerPrefs.DeleteKey("EnegryBar");
            PlayerPrefs.SetInt("Scene", 2);
            PlayerPrefs.DeleteKey("stattext");
            PlayerPrefs.DeleteKey("ValueList");
            




        }
    }


    public void OpenGame()
    {
        if(energy.slider.value - 40 > 0)
        {
        energy.slider.value -= 40;
        SceneManager.LoadScene(3);
        notenergyui.SetActive(false);
        saver.SaveGame();
        PlayerPrefs.SetFloat("EnergyBar", energy.slider.value);
        }
        else
        {
            notenergyui.SetActive(true);
        }    
    }
    public void CloseMiniGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Scene"));

    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
