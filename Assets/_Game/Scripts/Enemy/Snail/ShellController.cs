using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    [SerializeField] protected bool isDefeated;
    [SerializeField] private float waitToDestroy;

    [SerializeField] private Animator anim;
    protected Rigidbody2D theRB;
    [SerializeField] private float hitSpeed;

    //public void OnEnable()
    //
    //.SetParent(null);
    //theRB = GetComponent<Rigidbody2D>();
    //}
    void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //theRB = GetComponent<Rigidbody2D>();
        theRB.velocity = new Vector2(-5, 2);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (isDefeated == true)
        {
            waitToDestroy -= Time.deltaTime;

            if (waitToDestroy <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("wall hit");
            //anim.SetTrigger("wallHit");
            //FindFirstObjectByType<PlayerController>().Jump();

            //isDefeated = true;

            foreach (ContactPoint2D contactPoint in other.contacts)
            {
                Debug.Log("Touch ground"); Vector2 normal = contactPoint.normal;
                Debug.Log($"Va ch?m v?i: {other.gameObject.name}, Normal: {normal}");


                if (Mathf.Abs(normal.x) > 0.5f && normal.y > -0.1f && normal.y < 0.1f)
                {
                    //theRB.velocity = new Vector2(hitSpeed, transform.position.y);

                    Debug.Log("Hit Ground");
                    anim.SetTrigger("wallHit");
                    isDefeated = true;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Top hit");
            anim.SetTrigger("topHit");

            FindFirstObjectByType<PlayerController>().Jump();

            isDefeated = true;
        }
    }
}
