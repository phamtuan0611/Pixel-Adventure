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

    void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        theRB.velocity = new Vector2(4, 3);
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
            //Debug.Log("wall hit");

            // Kiểm tra va chạm với tường bằng Raycast
            bool hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 0.5f, LayerMask.GetMask("Ground"));
            bool hitRight = Physics2D.Raycast(transform.position, Vector2.right, 0.5f, LayerMask.GetMask("Ground"));

            if (hitLeft || hitRight)
            {
                //Debug.Log("Hit Side Wall");
                anim.SetTrigger("wallHit");
                isDefeated = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Top hit");
            anim.SetTrigger("topHit");

            FindFirstObjectByType<PlayerController>().Jump();

            isDefeated = true;
        }
    }
}
