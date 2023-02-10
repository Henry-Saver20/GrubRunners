using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public TextMeshProUGUI speedText;
    [SerializeField] public GameObject player;
    private Rigidbody2D rb;

    void Start()
    {
        speedText.text = "0";
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        string newText = (rb.velocity.magnitude).ToString();
        if(newText.Length > 6)
        {
            newText = newText.Substring(0, 5);
        }

        speedText.text = newText;
    }
}
