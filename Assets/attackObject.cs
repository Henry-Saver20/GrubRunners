using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class attackObject : MonoBehaviour
{
    [SerializeField] public float exitVelocity;

    [SerializeField] public Rigidbody2D projectile;

    [SerializeField] public float timeToDespawn = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeToDespawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
    }
}
