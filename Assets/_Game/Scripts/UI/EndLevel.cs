using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private string nextScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("flagActive", true);
            AudioManager.instance.completeLevelMusicPlay();
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2.5f);
        
        if (nextScene != "Victory")
        {
            PlayerPrefs.SetString("currentLevel", nextScene);
        }

        SceneManager.LoadScene(nextScene);
    }
}
