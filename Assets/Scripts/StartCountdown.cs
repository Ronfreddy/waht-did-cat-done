using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartCountdown : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject timeOutAnim;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject cinecam;
    [SerializeField] private GameObject virtualCam;
    [SerializeField] private GameObject endUI;
    [SerializeField] private GameObject cat;
    [SerializeField] private GameObject CGCat;
    [SerializeField] private AudioSource readySound;
    [SerializeField] private AudioSource endSound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCountdownCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.timer.isEnteringCutscene)
        {
            Time.timeScale = 1;
            GameManager.Instance.timer.isEnteringCutscene = false;
            StartCoroutine(TimeOutCoroutine());
        }
    }

    private IEnumerator StartCountdownCoroutine()
    {
        GameManager.Instance.soundManager.GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(1.0f);
        readySound.Play();
        yield return new WaitForSeconds(1.0f);
        readySound.Play();
        yield return new WaitForSeconds(1.0f);
        readySound.Play();
        yield return new WaitForSeconds(1.0f);
        readySound.pitch = 1.5f;
        readySound.Play();
        GameManager.Instance.soundManager.GetComponent<AudioSource>().Play();
        startUI.SetActive(false);
        playerInput.enabled = true;
        GameManager.Instance.GameStart();
    }

    private IEnumerator TimeOutCoroutine()
    {
        playerInput.enabled = false;
        timeOutAnim.SetActive(true);
        HUD.SetActive(false);
        endSound.Play();
        yield return new WaitForSeconds(1.0f);
        timeOutAnim.SetActive(false);
        CGCat.SetActive(true);
        cat.SetActive(false);
        Camera.main.gameObject.SetActive(false);
        cinecam.SetActive(true);
        virtualCam.SetActive(true);
        yield return new WaitForSeconds(32.333f);
        endUI.SetActive(true);
    }
}
