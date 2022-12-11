using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rb;
    [SerializeField] private float m_playerSpeed;
    private Vector3 finalVelocity;


    private Vector3 _moveVector;
    void Start()
    {
        m_rb.centerOfMass = Vector3.zero;
    }
    
    void FixedUpdate ()
    {
        InputHandler();
        Rotate();

        if (_moveVector != Vector3.zero)
        {
            Move();
            
        }
    }

    private void InputHandler()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _moveVector.y = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        Vector3 dir = _moveVector *  m_playerSpeed;
        m_rb.MovePosition(transform.position + dir * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, Angle360(transform.forward, _moveVector, transform.right));
    }
    
    float Angle360(Vector3 from, Vector3 to, Vector3 right) 
    {
        float angle = Vector3.Angle(from, to);
        return (Vector3.Angle(right, to) > 90f) ? 360f - angle : angle;
        
    }
}