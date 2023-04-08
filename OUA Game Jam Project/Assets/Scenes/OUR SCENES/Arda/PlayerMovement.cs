using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Karakterin hýzý
    public float horizontalSpeed;
    public float verticalSpeed;


    private Rigidbody rb;
    private Animator animator;
    public Vector3 playerpos;
   
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
        
        //transform.position += new Vector3(horizontalSpeed * Time.fixedDeltaTime, 0, 0);
       transform.right += new Vector3(horizontalSpeed * Time.fixedDeltaTime, 0, 0);


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("TurningPoint"))
        {
            if (horizontalSpeed>0)
            {
                Debug.Log("sað");
                Debug.Log(Input.GetAxisRaw("Horizontal"));
                rb.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles.x, 90f, transform.rotation.eulerAngles.z));
            }
            if (horizontalSpeed < 0)
            {
                Debug.Log("sol");
                Debug.Log(Input.GetAxisRaw("Horizontal"));
                //rb.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles.x, -90f, transform.rotation.eulerAngles.z));
                transform.rotation = (Quaternion.Euler(transform.rotation.eulerAngles.x, -90f, transform.rotation.eulerAngles.z));
            }

            //Vector3 newPosition = transform.position + transform.forward * speed * Time.deltaTime + new Vector3(horizontalSpeed * Time.deltaTime, 0, 0);
            //rb.MovePosition(newPosition);
        }
    }
   
    void Update()
    {
        horizontalSpeed = Input.GetAxisRaw("Horizontal") * speed;
        //transform.Rotate(0, Input.GetAxis("Horizontal") * 180 * Time.deltaTime, 0);
        //KeyboardControl();
        // Sol ve saða hareket
        //float horizontalInput = Input.GetAxis("Horizontal");
        //transform.position += new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime;
        //float horizontalInput = Input.GetAxis("Horizontal");
        //if (Input.GetKeyDown(KeyCode.A))
        //{


        //    transform.position += new Vector3(horizontalInput, 0,0)*Time.deltaTime*speed;
        //}

        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    horizontalSpeed = 5;
        //   transform.position += new Vector3(horizontalInput, 0,0)*Time.deltaTime*speed;
        //}


        // Hareket yönüne göre karakterin yüzünü çevir
        //if (rb.velocity.magnitude > 0)
        //{
        //    transform.rotation = Quaternion.LookRotation(rb.velocity);
        //}

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
    void KeyboardControl()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, rb.velocity.z);
       
    }
 }