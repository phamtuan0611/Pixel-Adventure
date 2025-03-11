using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPickup : MonoBehaviour
{
    [SerializeField] private int amount = 1;
    [SerializeField] private int countFruit = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            countFruit++;
            Destroy(gameObject);

            //AudioManager.instance.allSFXPlayPitched(9);
        }
    }
}
