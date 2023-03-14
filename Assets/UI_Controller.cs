using System;
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
    [SerializeField] public TextMeshProUGUI hpText;
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] public TextMeshProUGUI deathText;
    
    void Start()
    {
        deathText.alpha = 0f;
        speedText.text = "0";
        hpText.text = (player.GetComponent<player_gamecontroller>().health).ToString();
        slider.value = 1;
        slider.maxValue = 1;
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

    public void UpdateHealth(float hp, float maxHp)
    {
        hpText.text = hp.ToString();
        slider.maxValue = maxHp;
        slider.value = hp;
        if (hp <= 0)
        {
            deathText.alpha = 1f;
            hpText.text = "0";
        }
    }
}
