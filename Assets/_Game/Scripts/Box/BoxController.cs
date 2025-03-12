using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] private GameObject itemBox;
    [SerializeField] private GameObject itemBox1;
    [SerializeField] private GameObject itemBox2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HeadPlayer"))
        {
            GameObject item = Instantiate(itemBox, transform.position, Quaternion.identity);
            Rigidbody2D box = item.GetComponent<Rigidbody2D>();
            box.velocity = new Vector2(1f, 5f);

            GameObject item1 = Instantiate(itemBox1, transform.position, Quaternion.identity);
            Rigidbody2D box1 = item1.GetComponent<Rigidbody2D>();
            box1.velocity = new Vector2(0f, 6f);

            GameObject item2 = Instantiate(itemBox2, transform.position, Quaternion.identity);
            Rigidbody2D box2 = item2.GetComponent<Rigidbody2D>();
            box2.velocity = new Vector2(-1f, 5f);

            Destroy(gameObject);

            Destroy(item, 1f);
            Destroy(item1, 1f);
            Destroy(item2, 1f);
            Debug.Log("box box box");
        }
    }
}
