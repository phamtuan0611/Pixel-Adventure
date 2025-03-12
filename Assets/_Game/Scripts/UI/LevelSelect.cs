using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    private Text levelSelect;

    public void BackHome()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void ReadButtonText()
    {
        GameObject selectedButton = EventSystem.current.currentSelectedGameObject;
        Debug.Log("Damm");
        if (selectedButton != null)
        {
            Debug.Log("Select");
            Text buttonText = selectedButton.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                SceneManager.LoadScene("Level 0" + buttonText.text);
                Debug.Log("Level 0" + buttonText.text);
            }
        }
    }

    public void LoadLevel()
    {

    }
}
