using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healthPickup;
    [SerializeField] private bool fullHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
            {
                if (fullHealth == true)
                {
                    PlayerHealthController.instance.AddHealth(PlayerHealthController.instance.maxHealth);
                }
                else
                {
                    PlayerHealthController.instance.AddHealth(healthPickup);
                }

                Destroy(gameObject);
                //AudioManager.instance.allSFXPlay(10);
            }
        }
    }
}
