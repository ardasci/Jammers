using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Karakterin h�z�
    public float horizontalSpeed;

    private Rigidbody rb;
    private Animator animator;
    public Vector3 playerpos;
    public float laneDistance = 2.0f; // Her �erit aras�ndaki mesafe
    public float laneSpeed = 10.0f; // �erit de�i�tirme h�z�
    public int currentLane = 1; // Karakterin ba�lang��ta hangi �eritte oldu�unu belirleyen de�i�ken

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // �leri hareket
        rb.velocity = transform.forward * speed;

        // Hareket h�z�n� Animator'a g�nder
        float movementSpeed = rb.velocity.magnitude;
        animator.SetFloat("Speed", movementSpeed);
    }
    public void SwitchLane(int direction)
    {
        int targetLane = currentLane + direction;

        // �erit s�n�r�na ula��ld���nda karakterin daha fazla hareket etmesini engelleyen ko�ullar
        if (targetLane < 0 || targetLane > 2)
        {
            return;
        }

        // Hedef �eride ula�ana kadar karakterin yava��a hareket etmesini sa�layan kod
        float x = (targetLane - currentLane) * laneDistance;
        Vector3 targetPosition = new Vector3(transform.position.x + x, transform.position.y, transform.position.z+z);
        StartCoroutine(MoveToLane(targetPosition));

        currentLane = targetLane;
    }
    // �erit de�i�tirme animasyonunu oynatan fonksiyon
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
        // Sol ve sa�a hareket

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


        // Hareket y�n�ne g�re karakterin y�z�n� �evir
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