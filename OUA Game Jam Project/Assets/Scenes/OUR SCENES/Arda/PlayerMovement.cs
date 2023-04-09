using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Joystick joystick;


    public float speed = 8f; // hareket hýzý
    public float rotationSpeed = 100f; // rotasyon hýzý
    public Transform rotationObject; // rotation object
    private Rigidbody rb;
    private Animator animator;

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rotationObject = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {

    }

    private void Update()
    {
        //PlayerRb.velocity = new Vector2(joystick.Horizontal , PlayerRb.velocity.y); //yürüme. sa? -> axis > 0 
        rb.velocity = transform.forward * speed;

        float horizontalInput = joystick.Horizontal * speed; // yatay inputu al
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime; // rotasyon açýsýný hesapla
        rotationObject.Rotate(0f, rotation / 1.25f, 0f); // rotationObject'in rotasyonunu güncelle

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