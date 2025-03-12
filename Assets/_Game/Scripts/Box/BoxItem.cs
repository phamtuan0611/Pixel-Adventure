using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItem : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HeadPlayer"))
        {
            Instantiate(item, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Debug.Log("box box box");
        }
    }
}
