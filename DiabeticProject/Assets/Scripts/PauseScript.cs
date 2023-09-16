using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject exitUI;
    private Animator anim;
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Animator pauseMenuUIAnim = pauseMenuUI.GetComponent<Animator>();
        pauseMenuUIAnim.Play("pauseAnim");
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Animator pauseMenuUIAnim = pauseMenuUI.GetComponent<Animator>();
        pauseMenuUIAnim.Play("pauseOFF");
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        exitUI.SetActive(true);
    }

    public void ÑloseMiniGame()
    {
        exitUI.SetActive(true);
    }

    public void StopTime()
    {
        Time.timeScale = 0f;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }
}
