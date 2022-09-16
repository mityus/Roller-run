using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    
    [Header("Speed")]
    [SerializeField] private float speedDisplace = 3f;
    [SerializeField] private float spedMove = 7f;
    [SerializeField] private int speedJump = 20;

    private Rigidbody _rb;
    private bool _isGraunded = true;

    ///////////////////////Main
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
       Run(); 
    }

    private void FixedUpdate()
    {
        if (!_isGraunded)
        {
            Jump();
        }
    }
    
    /////////////////UnityFunction
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PointJump")) _isGraunded = false;
    }
    
    ///////////////////MyFunction
    private void Run()
    {
        transform.Translate(joystick.Horizontal * Time.deltaTime * speedDisplace,
            0, 1 * spedMove * Time.deltaTime);
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * speedJump, ForceMode.Impulse);
        _isGraunded = true;
    }
}
