using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPickup : MonoBehaviour
{
    [SerializeField] private int amount = 1;
    [SerializeField] private int countFruit = 0;
    [SerializeField] private GameObject effectFruit;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            countFruit++;
            Destroy(gameObject);
            Instantiate(effectFruit, transform.position, Quaternion.identity);

            //AudioManager.instance.allSFXPlayPitched(9);
        }
    }
}
