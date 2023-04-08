using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Karakterin hýzý
    public float horizontalSpeed;

    private Rigidbody rb;
    private Animator animator;
    public Vector3 playerpos;
    public float laneDistance = 2.0f; // Her þerit arasýndaki mesafe
    public float laneSpeed = 10.0f; // Þerit deðiþtirme hýzý
    public int currentLane = 1; // Karakterin baþlangýçta hangi þeritte olduðunu belirleyen deðiþken

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Ýleri hareket
        rb.velocity = transform.forward * speed;

        // Hareket hýzýný Animator'a gönder
        float movementSpeed = rb.velocity.magnitude;
        animator.SetFloat("Speed", movementSpeed);
    }
    public void SwitchLane(int direction)
    {
        int targetLane = currentLane + direction;

        // Þerit sýnýrýna ulaþýldýðýnda karakterin daha fazla hareket etmesini engelleyen koþullar
        if (targetLane < 0 || targetLane > 2)
        {
            return;
        }

        // Hedef þeride ulaþana kadar karakterin yavaþça hareket etmesini saðlayan kod
        float x = (targetLane - currentLane) * laneDistance;
        Vector3 targetPosition = new Vector3(transform.position.x + x, transform.position.y, transform.position.z+z);
        StartCoroutine(MoveToLane(targetPosition));

        currentLane = targetLane;
    }
    // Þerit deðiþtirme animasyonunu oynatan fonksiyon
    IEnumerator MoveToLane(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneSpeed * Time.deltaTime);
            yield return null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SwitchLane(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SwitchLane(1);
        }
        // Sol ve saða hareket

        //float horizontalInput = Input.GetAxis("Horizontal");
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    horizontalSpeed = -5;

        //    transform.position = Vector3.Lerp(transform.position, new Vector3(59, transform.position.y, transform.position.z), 0.4f);
        //}

        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    horizontalSpeed = 5;
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(61, transform.position.y, transform.position.z), 0.4f);
        //}


        // Hareket yönüne göre karakterin yüzünü çevir
        if (rb.velocity.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }

        // Idle animasyonunu kontrol et
        if (rb.velocity.magnitude == 0)
        {
          //  animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }
    }
}