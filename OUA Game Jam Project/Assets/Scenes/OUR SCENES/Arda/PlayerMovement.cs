using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f; // hareket h�z�
    public float rotationSpeed = 100f; // rotasyon h�z�
    public Transform rotationObject; // rotation object
    private Rigidbody rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rotationObject = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // yatay inputu al
        rb.velocity = transform.forward * speed;
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime; // rotasyon a��s�n� hesapla
        rotationObject.Rotate(0f, rotation/1.25f, 0f); // rotationObject'in rotasyonunu g�ncelle

        if (speed > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

}