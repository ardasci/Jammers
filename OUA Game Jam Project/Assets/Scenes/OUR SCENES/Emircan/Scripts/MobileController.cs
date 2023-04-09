using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MobileController : MonoBehaviour
{
    Joystick joystick;
    private Animator anim;
    private Rigidbody PlayerRb;
    

    private float speed = 5f;
    

    void Awake()
    {
        PlayerRb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
        anim = GetComponent<Animator>();
                
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        JoystickControl();
    }

    void JoystickControl()
    {
   
        PlayerRb.velocity = new Vector3(-joystick.Vertical * speed, PlayerRb.velocity.y, joystick.Horizontal * speed); 
    }


}
