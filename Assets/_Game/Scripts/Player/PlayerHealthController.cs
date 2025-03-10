using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    private void Awake()
    {
        instance = this;
    }

    public int currentHealth, maxHealth;

    //Tao tym bat tu tam thoi
    [SerializeField] private float invincibilityLength = 1f;
    private float invincibilityCounter;

    [SerializeField] private SpriteRenderer theSR;

    private PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        thePlayer = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            if (invincibilityCounter <= 0)
            {
                //theSR.color = normalColor;
            }
        }
    }

    public void DamagePLayer()
    {
        if (invincibilityCounter <= 0)
        {
            //invincibilityCounter = invincibilityLength;

            currentHealth--;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);
            }
            else
            {
                invincibilityCounter = invincibilityLength;

                thePlayer.GetComponent<Animator>().SetTrigger("isKnocking");

                thePlayer.isKnock();
            }
        }

    }

    public void AddHealth(int amountToAdd)
    {
        currentHealth += amountToAdd;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
