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

    public bool isAlive;
    public float fireRate = 5f;
    [SerializeField] public GameObject attackObj;

    private player_gamecontroller playerController;


    private float timeToFire;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        playerController = this.GetComponent<player_gamecontroller>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAlive)
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
            if (isAlive)
            {
                rb.velocity = new Vector2(horiz, vert) * moveSpeed;
                if (Input.GetKey(KeyCode.Space) && timeToFire < Time.time)
                {
                    timeToFire = Time.time + fireRate;
                    Vector2 shotPosition = new Vector2(rb.position.x, rb.position.y + 1f);
                    float atkVelocity = attackObj.GetComponent<attackObject>().exitVelocity;
                    GameObject atk = Instantiate(attackObj,shotPosition, Quaternion.identity);
                    atk.GetComponent<attackObject>().projectile.velocity = new Vector2(0f,atkVelocity);
                }
            }

            //Rotation Controller

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
            rb.AddForce(new Vector2(-col.transform.position.x * 20f,-col.transform.position.y * 20f));
            playerController.DamagePlayer(10);
        }
        
    }
}
