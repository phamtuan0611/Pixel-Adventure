using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailController : MonoBehaviour
{
    [SerializeField] private GameObject shellShall, snailNShell;
    [SerializeField] private float speed;

    [SerializeField] private bool isTouch;
    [SerializeField] private Transform snail;

    [SerializeField] private float launchForce = 5f;
    [SerializeField] private float arcHeight = 2f;

    private void Update()
    {
        if (isTouch == true)
        {
            //(snail, snail.position, Quaternion.identity);
            
            Debug.Log("12345");
            isTouch = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //snail = gameObject.transform;
            shellShall.SetActive(true);

            snailNShell.SetActive(true);

            isTouch = true;
        }
    }
}
