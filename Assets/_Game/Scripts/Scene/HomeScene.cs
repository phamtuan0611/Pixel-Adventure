using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
    [SerializeField] private string firstLevel;
    [SerializeField] private GameObject btnContinue;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("currentLevel"))
        {
            btnContinue.SetActive(true);
        }
        else
        {
            btnContinue.SetActive(false);
        }

        if (PlayerPrefs.HasKey("selectedOption"))
        {
            Debug.Log("Yes");
        }
        else
        {
            Debug.Log("No");
        }
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.DeleteAll();
        }
#endif
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("currentLevel"));
        Time.timeScale = 1.0f;
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(firstLevel);
        Time.timeScale = 1.0f;
    }

    public void MenuCharacter()
    {
        SceneManager.LoadScene("ChooseCharacter");
        Time.timeScale = 1.0f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SelectScene()
    {
        SceneManager.LoadScene("SelectLevel");
        Time.timeScale = 1.0f;
    }
}
