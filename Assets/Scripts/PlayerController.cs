﻿using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * Speed);  
    }
    void LateUpdate()
    {
        Camera.main.transform.LookAt(rb.transform);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rb.transform.position.y <= 0.5f)
        {
            Vector3 jump = new Vector3(0.0f, 10.0f, 0.0f);
            GetComponent<Rigidbody>().AddForce(jump, ForceMode.Impulse);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("picker"))
        {
            other.gameObject.SetActive  (false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 17)
        {
            winText.text = ("Level Cleared");
            SceneManager.LoadScene("next"); ;
        } 
    }

}
