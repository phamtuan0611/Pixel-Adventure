using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public SpriteRenderer artworkSprite;
    public Animator anim;

    private int selectedOption = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
            Debug.Log("Khong co gi ca");
        }
        else
        {
            Debug.Log("Cos");
            Load();
        }

        UpdateCharacter(selectedOption);

        Debug.Log(PlayerPrefs.GetInt("selectedOption"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        anim = character.characterAnimator;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
