using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailNShell : ShellController
{
    //[SerializeField] private Rigidbody2D theRB;

    

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        theRB.velocity = new Vector2(5, 2);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealthController.instance.DamagePLayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Color theColor = GetComponent<SpriteRenderer>().color;
            theColor = Color.white;

            isDefeated = true;
        }
    }
}
