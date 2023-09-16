using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI printedText;
    [SerializeField] private string startString;
    private void Start()
    {
        printedText.text = ""; 

        StartCoroutine(PrintText(startString));
    }

    private IEnumerator PrintText(string str)
    {
        foreach (char letter in str)
        {
            printedText.text +=  letter;
            yield return new WaitForSeconds(0.1f); 
        }

        printedText.text += "\n";
        StartCoroutine(PrintName("Меня зовут " + PlayerPrefs.GetString("playerName")));
    }

    private IEnumerator PrintName(string strf)
    {
        foreach (char letter in strf)
        {
            printedText.text += letter;
            yield return new WaitForSeconds(0.1f); 
        }
    }
}