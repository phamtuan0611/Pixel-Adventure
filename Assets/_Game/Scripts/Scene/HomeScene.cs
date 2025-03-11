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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("currentLevel"));
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
