using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
public class RoomScript : MonoBehaviour
{
    [SerializeField] private GameObject mainRoom;
    [SerializeField] private GameObject kitchenRoom;
    [SerializeField] private GameObject playingRoom;
    [SerializeField] private Text activeRoom;
    [SerializeField] private GameObject textBlock;
    private string active;

    private void Start()
    {
        activeRoom.text = "Спальня";
    }

    public void NextRoom()
    {
       
        if(mainRoom.activeSelf == true)
        {
            KitchenActive();
        }
          

        else if(kitchenRoom.activeSelf == true)
        {
            PlayingActive();
        }
        else if (playingRoom.activeSelf == true)
        {
            MainActive();
        }

        textBlock.SetActive(false);
    }

    public void BackRoom()
    {
        if (mainRoom.activeSelf)
        {
            PlayingActive();
        }

        else if (playingRoom.activeSelf)
        {
            KitchenActive();
        }
        else if (kitchenRoom.activeSelf)
        {
            MainActive();
        }
        textBlock.SetActive(false);
    }
    
    private void KitchenActive()
    {
        playingRoom.SetActive(false);
        kitchenRoom.SetActive(true);
        mainRoom.SetActive(false);
        activeRoom.text = "Кухня";
        
    }

    private void PlayingActive()
    {
        mainRoom.SetActive(false);
        kitchenRoom.SetActive(false);
        playingRoom.SetActive(true);
        activeRoom.text = "Игровая";

    }

    private void MainActive()
    {
        kitchenRoom.SetActive(false);
        playingRoom.SetActive(false);
        mainRoom.SetActive(true);
        activeRoom.text = "Спальня";
    }
}
