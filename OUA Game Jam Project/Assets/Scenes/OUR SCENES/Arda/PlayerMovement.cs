using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // hareket hýzý
    public float rotationSpeed = 100f; // rotasyon hýzý
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
        rb.velocity = transform.forward * speed;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // yatay inputu al

        float rotation = horizontalInput * rotationSpeed * Time.deltaTime; // rotasyon açýsýný hesapla
        rotationObject.Rotate(0f, rotation, 0f); // rotationObject'in rotasyonunu güncelle

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