﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;

    private bool isAttack;
    [SerializeField] private Animator anim;

    private float playerIn, playerOut;
    [SerializeField] private float timePeriod;

    //[SerializeField] private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();

        playerIn = timePeriod;
        playerOut = timePeriod;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttack == true)
        {
            playerIn -= Time.deltaTime;
            //anim.SetBool("isAttack", false);

            if (playerIn <= 0)
            {
                timer += Time.deltaTime;

                if (timer > 0.5)
                {
                    anim.SetBool("isAttack", true);
                    timer = 0;
                    Shoot();
                }

                StartCoroutine(DelayTime());
            }

        }
        else
        {
            playerOut -= Time.deltaTime;

            if (playerOut <= 0)
                anim.SetBool("isAttack", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Attack");
            isAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isAttack = false;
        }
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(0.5f);
        playerIn = timePeriod;
    }

    void Shoot()
    {
        GameObject spawnedBullet = Instantiate(bullet, bulletPos.position, Quaternion.identity);
        StartCoroutine(DestroyBullet(spawnedBullet));
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        Destroy(bullet);
    }
}
