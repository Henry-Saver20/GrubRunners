using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    /// <summary>
    /// TODO: non-hard coded controller
    /// - Import multiplayer pkgs
    /// - Projectiles
    /// </summary>
    public float moveSpeed = 5f;

    public float brakingSpeed = 5f;

    [SerializeField] private Rigidbody2D rb;
    public float rotationSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, 50f);
        if (rb.angularVelocity > 40f)
        {
            rb.angularVelocity = 40f;
        }

        if (rb.angularVelocity < -40f)
        {
            rb.angularVelocity = -40f;
        }
        //Movement Controller
        float ix = Input.GetAxis("Horizontal");
        float iy = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(0, 0);

        var horiz = Input.GetAxisRaw("Horizontal");
        var vert = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(horiz, vert) * moveSpeed;
        /*if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = (transform.up * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = (-transform.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = (transform.right  * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = (-transform.up  * moveSpeed * Time.deltaTime);
        }*/
        //Zero Grav controls - OLD version movement
        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            /*move = new Vector2(0, 1 * moveSpeed);#1#
            Vector2 newDir = transform.up;
            rb.velocity += newDir * moveSpeed * Time.deltaTime;


        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.angularVelocity += rotationSpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.angularVelocity += -1 * rotationSpeed;
        }*/
        //Rotation Controller
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = rb.velocity / brakingSpeed;
            rb.angularVelocity = rb.angularVelocity / brakingSpeed;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Wall")
        {
            Debug.Log("BONK");
            rb.AddForce((transform.position - col.transform.position).normalized * 0.25f, ForceMode2D.Impulse);
        }

        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("ENEMY HIT");
            rb.AddForce(new Vector2(2000f,2000f));
        }
        
    }
}
