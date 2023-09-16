using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject startgameUI;
    [SerializeField] private GameObject resumegameUI;
    [SerializeField] private GameObject settingsgameUI;
    [SerializeField] private GameObject checkingUI;
    [SerializeField] private GameObject ngUI;

    [SerializeField] private InputField persname;
    [SerializeField] private GameObject errortext;
    public string chname;
    [SerializeField] private GameObject newgameUI;
    [SerializeField] private GameObject gotoset;


    [Header ("NewGame")]
    [SerializeField] private InputField playerName;


    public void StartGame()
    {
        if (PlayerPrefs.HasKey("playerSugarBorder") && PlayerPrefs.HasKey("playerAge"))
        {
            Animator newGameAnim = ngUI.GetComponent<Animator>();
            newGameAnim.Play("newGameUION");
            ngUI.SetActive(true);
        }
        else
        {
            gotoset.SetActive(true);
        }
        
    }

    public void ResumeStartGame()
    {
        chname = persname.text;
        if (string.IsNullOrEmpty(chname))
        {
            errortext.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetString("playerName",playerName.text);
            newgameUI.SetActive(true);
            errortext.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        resumegameUI.SetActive(true);
    }

    public void ResumeResumingGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Scene"));
    }

    public void Settings()
    {
        Animator checkingUIAnim = checkingUI.GetComponent<Animator>();
        checkingUIAnim.Play("StartChecking");
        checkingUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void CloseSettings()
    {
        
        Animator settingsUIAnim = settingsgameUI.GetComponent<Animator>();
        settingsUIAnim.enabled = true;
        settingsUIAnim.Play("SettingsClose");
    }
    
    public void CloseCheck()
    {
        Animator checkingUIAnim = checkingUI.GetComponent<Animator>();
        checkingUIAnim.Play("CloseCheking");
    }

    public void CloseNewGameUI()
    {
        Animator newGameAnim = ngUI.GetComponent<Animator>();
        newGameAnim.enabled = true;
        newGameAnim.Play("newGameUIOFF");    
    }
}
