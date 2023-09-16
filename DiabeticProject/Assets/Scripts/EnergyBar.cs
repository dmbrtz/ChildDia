using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private GameObject foodList;
    [SerializeField] private TMP_Text sugarStat;
    public int sugarnum;
    [SerializeField] private GameObject souringe;
    [SerializeField] private AudioSource sound;
    public AutSave saver;

    [SerializeField] private GameObject insulinChoiseUI;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    private void Check() //проверка на количество сахара для включения шприца и отбавления энергии
    {
        if(sugarnum > PlayerPrefs.GetInt("playerSugarBorder"))
        {
            souringe.SetActive(true);
            slider.value -= 60;
        }
        else
        {
            souringe.SetActive(false);
        }
        
    }

    public void InsulinChoise()
    {
        insulinChoiseUI.SetActive(true);
    }

    public void InsulinYes()
    {
        Souringe();
        OpenMenu();
        insulinChoiseUI.SetActive(false);
    }
    
    public void InsulinNo()
    {
        OpenMenu();
        insulinChoiseUI.SetActive(false);
    }

    public void OpenMenu()
    {
        Animator foodUIAnim = foodList.GetComponent<Animator>();
        foodUIAnim.Play("OpenFOOD");
        foodList.SetActive(true);
        
    }

    public void BreadEat()
    {
        sugarnum += 1; 
        slider.value += 10;
        sugarStat.text = sugarnum.ToString();
        PlayerPrefs.SetFloat("EnergyBar", slider.value);
        Check();
    }
    public void AppleEat()
    {
        sugarnum += 1;
        slider.value += 10;
        sugarStat.text = sugarnum.ToString();
        PlayerPrefs.SetFloat("EnergyBar", slider.value);
        Check();
    }

    public void BananaEat()
    {
        sugarnum += 2;
        slider.value += 10;
        sugarStat.text = sugarnum.ToString();
        PlayerPrefs.SetFloat("EnergyBar", slider.value);
        Check();
    }

    public void PastaEat()
    {
        sugarnum += 2;
        slider.value += 10;
        sugarStat.text = sugarnum.ToString();
        PlayerPrefs.SetFloat("EnergyBar", slider.value);
        Check();

    }

    public void JuiceEat()
    {
        sugarnum += 2;
        slider.value += 10;
        sugarStat.text = sugarnum.ToString();
        PlayerPrefs.SetFloat("EnergyBar",slider.value);
        Check();
        
    }

    public void CloseFoodList()
    {
        Animator foodUIAnim = foodList.GetComponent<Animator>();
        foodUIAnim.Play("closeFOOD");
    }

    public void Souringe()
    {
        sugarnum = 0;
        sugarStat.text = sugarnum.ToString();
        souringe.SetActive(false);
        saver.SaveGame();
    }

    public void ResetSugar()
    {
        sugarnum = PlayerPrefs.GetInt("playerSugarBorder") / 2;
        sugarStat.text = sugarnum.ToString();
    }

}
