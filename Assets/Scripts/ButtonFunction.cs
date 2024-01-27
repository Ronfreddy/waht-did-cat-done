using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject mainmenu;
    public GameObject guidemenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGAME()
    {
        GameManager.Instance.scoreSystem.ResetScore();
        GameManager.Instance.timer.ResetTimer();
        GameManager.Instance.soundManager.ResetBGM();
        SceneManager.LoadScene("EonTestMovement");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void Control()
    {
        mainmenu.SetActive(false);
        guidemenu.SetActive(true);
    }

    public void ReturnMain()
    {
        guidemenu.SetActive(false);
        mainmenu.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
        GameManager.Instance.timer.ResetTimer();
        GameManager.Instance.ResetGame();
        GameManager.Instance.soundManager.ResetBGM();
    }

    public void ReturnToGame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1.0f;
        GameObject.Find("FunctionedCat").GetComponent<CatMovement>().enabled = true;
    }
}
