using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartCountdown : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject timeOutAnim;
    [SerializeField] private GameObject endUI;

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
        yield return new WaitForSeconds(1.0f);

        yield return new WaitForSeconds(1.0f);

        yield return new WaitForSeconds(1.0f);

        yield return new WaitForSeconds(1.0f);
        playerInput.enabled = true;
        GameManager.Instance.GameStart();
    }

    private IEnumerator TimeOutCoroutine()
    {
        playerInput.enabled = false;
        timeOutAnim.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        timeOutAnim.SetActive(false);
        endUI.SetActive(true);
    }
}
