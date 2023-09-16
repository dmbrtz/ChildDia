using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class ResumeSync : MonoBehaviour
{
    [SerializeField] private GameObject textBlock;
    [SerializeField] private TMP_Text dayText;
    [SerializeField] private TMP_Text sugarText;
    [SerializeField] private TMP_Text statText;
    [SerializeField] private Slider energyBar;
    public DiaryScript statistic;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("EnergyBar") && PlayerPrefs.HasKey("sugarInDay") && PlayerPrefs.HasKey("Day"))
        {
            energyBar.value = PlayerPrefs.GetFloat("EnegryBar");
            dayText.text = PlayerPrefs.GetInt("Day").ToString();
            sugarText.text = PlayerPrefs.GetInt("sugarInDay").ToString();
            textBlock.SetActive(false);
        }
        else
        {

            statistic.EraseStatistic();
            sugarText.text = (PlayerPrefs.GetInt("playerSugarBorder") / 2).ToString();
            Debug.Log("ItsNew");
        }

        if(PlayerPrefs.HasKey("stattext"))
        {
            statText.text = PlayerPrefs.GetString("stattext");
        }
    }
}
