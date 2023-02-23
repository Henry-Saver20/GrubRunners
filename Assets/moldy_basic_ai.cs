using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class moldy_basic_ai : MonoBehaviour
{
    private CircleCollider2D _sc;

    private bool foundPlayer = false;

    [SerializeField] public float health = 10f;
    public float maxHealth;
    private GameObject trackedPlayer;
    [SerializeField] public float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _sc = this.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (foundPlayer == true)
        {
            Vector2 trackPos = trackedPlayer.GetComponent<Rigidbody2D>().position;
            _rb.position = Vector2.MoveTowards(transform.position, trackPos, moveSpeed * Time.deltaTime);
        }

        if (health <= 0)
        {
            Debug.Log("Enemy killed");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            foundPlayer = true;
            trackedPlayer = col.gameObject;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlayerAttack")
        {
            /*col.gameObject.GetComponent<>()*/
            health = health - 10;
        }
    }
}
