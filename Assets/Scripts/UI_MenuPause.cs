using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuPause : MonoBehaviour
{
    public GameObject pauseMenu;

    public void PauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        GetComponent<CatMovement>().enabled = false;
    }
}
