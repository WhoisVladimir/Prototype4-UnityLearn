﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Rigidbody ownRb;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        ownRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        ownRb.AddForce(lookDirection * speed);
        if (transform.position.y < -10) Destroy(gameObject);
    }
}
