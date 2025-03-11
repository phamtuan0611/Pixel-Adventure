using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private Image fadeScreen;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private bool fadingToBlack, fadingFromBlack;
    [SerializeField] private GameObject waitScreen, lostPopup, pausePopup;

    // Start is called before the first frame update
    void Start()
    {
        FadeFromBlack();
        StartCoroutine(WaitScreen());
    }

    // Update is called once per frame
    void Update()
    {
        FadeScreen();

        if (PlayerHealthController.instance.currentHealth == 0)
        {
            lostPopup.SetActive(true);
        }
    }

    public void FadeFromBlack()
    {
        fadingToBlack = false;
        fadingFromBlack = true;
    }

    public void FadeToBlack()
    {
        fadingToBlack = true;
        fadingFromBlack = false;
    }

    private void FadeScreen()
    {
        if (fadingFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
        }

        if (fadingToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
        }
    }

    private IEnumerator WaitScreen()
    {
        yield return new WaitForSeconds(0.8f);
        waitScreen.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        waitScreen.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void PauseAndResume()
    {
        if (pausePopup.activeSelf == false)
        {
            pausePopup.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePopup.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
