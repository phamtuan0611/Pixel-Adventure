using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTraps : MonoBehaviour
{
    [SerializeField] protected Transform[] patrolPoints;
    [SerializeField] protected float speed;
    [SerializeField] protected float waitTime, timeAtPoint;
    [SerializeField] private int currentPoint = 0;

    // Start is called before the first frame update
    public virtual void Start()
    {
        foreach (Transform patrolPoint in patrolPoints)
        {
            patrolPoint.SetParent(null);
        }
        transform.position = patrolPoints[currentPoint].position;
        currentPoint++;
        waitTime = timeAtPoint;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, speed * Time.deltaTime);
        if (transform.position == patrolPoints[currentPoint].position)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                currentPoint++;
                waitTime = timeAtPoint;

                transform.localScale = new Vector3(transform.localScale.x * (-1f), transform.localScale.y, transform.localScale.z);
            }
        }
        if (currentPoint >= patrolPoints.Length)
        {
            currentPoint = 0;
        }
    }
}
