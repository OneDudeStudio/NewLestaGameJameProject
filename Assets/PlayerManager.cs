using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerTopDownController _playerTopDownController;
    [SerializeField] private Animator _playerAnimator;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetRunAnimation();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetDanceAnimation();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetAttackAnimation();
        }
    }

    public void SetAttackAnimation()
    {
        _playerAnimator.Play("Attack");
    }
    public void SetWalkAnimation()
    {
        
    }
    public void SetRunAnimation()
    {
        _playerAnimator.Play("Run");
    }
    public void SetInteractAnimation()
    {
        
    }
    public void SetDanceAnimation()
    {
        _playerAnimator.Play("Dance");
    }
    public void SetDefeatAnimation()
    {
        
    }
    public void SetIdleAnimation()
    {
        
    }
    
    
}