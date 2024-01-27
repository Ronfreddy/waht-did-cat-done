using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    public GameObject pausemenu;

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
        SceneManager.LoadScene("EonTestMovement");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
        GameManager.Instance.timer.ResetTimer();
        GameManager.Instance.ResetGame();
    }

    public void ReturnToGame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1.0f;
        GameObject.Find("FunctionedCat").GetComponent<CatMovement>().enabled = true;
    }
}
